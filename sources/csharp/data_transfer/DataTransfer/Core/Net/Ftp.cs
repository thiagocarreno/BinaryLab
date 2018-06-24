using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using DataTransfer.Properties.Resources;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace DataTransfer.Core.Net
{
    public class Ftp
    {
        private readonly string _host;
        private readonly string _userName;
        private readonly string _password;
        private readonly int ChunkSize = (5 * 1024);
        private const int BufferSize = 1024;
        private const string SearchPattern = "*";

        public Ftp(
            string host,
            string userName,
            string password
        )
        {
            this._host = host;
            this._userName = userName;
            this._password = password;
        }

        public static Ftp Create(
            string host,
            string userName,
            string password
        )
        {
            return new Ftp(host, userName, password);
        }

        public void Download(
            string sourcePath,
            string destPath
        )
        {
            Check.NotNullOrWhiteSpace(
                () => sourcePath,
                () => destPath
            );

            var exists = this.FileExists(sourcePath);
            if (exists)
            {
                if (!Path.HasExtension(destPath))
                {
                    var fileName = Path.GetFileName(sourcePath);
                    destPath = string.Concat(
                        destPath,
                        Path.DirectorySeparatorChar,
                        fileName
                    );
                }

                var request = this.Connect(sourcePath, WebRequestMethods.Ftp.DownloadFile);
                var response = (FtpWebResponse)request.GetResponse();
                var streamRead = response.GetResponseStream();
                var streamWrite = new FileStream(destPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                this.WriteFile(streamRead, streamWrite);
            }
        }

        public void Upload(
            string sourcePath,
            string destPath
        )
        {
            this.Upload(sourcePath, destPath, true);
        }

        public void Upload(
            string sourcePath,
            string destPath,
            bool overwrite
        )
        {
            Check.NotNullOrWhiteSpace(
                () => sourcePath,
                () => destPath
            );

            var exists = File.Exists(sourcePath);
            if (exists)
            {
                if (!Path.HasExtension(destPath))
                {
                    var fileName = Path.GetFileName(sourcePath);
                    destPath = string.Concat(
                        destPath,
                        Path.AltDirectorySeparatorChar,
                        fileName
                    );
                }

                var method = overwrite ?
                    WebRequestMethods.Ftp.UploadFile :
                    WebRequestMethods.Ftp.UploadFileWithUniqueName;

                var request = this.Connect(destPath, method);
                var streamRead = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var streamWrite = request.GetRequestStream();
                this.WriteFile(streamRead, streamWrite);
            }
        }

        public void Rename(
            string filePath,
            string newFileName
        )
        {
            Check.NotNullOrWhiteSpace(
                () => filePath,
                () => newFileName
            );

            var exists = this.FileExists(filePath);
            if (exists)
            {
                var request = this.Connect(filePath, WebRequestMethods.Ftp.Rename);
                request.RenameTo = newFileName;

                var response = (FtpWebResponse)request.GetResponse();
                this.ExecuteCommand(
                    response.GetResponseStream()
                );
            }
        }

        public void DeleteFile(
            string path
        )
        {
            Check.NotNullOrWhiteSpace(() => path);

            var exists = this.FileExists(path);
            if (exists)
            {
                var request = this.Connect(path, WebRequestMethods.Ftp.DeleteFile);
                var response = (FtpWebResponse)request.GetResponse();
                this.ExecuteCommand(
                    response.GetResponseStream()
                );
            }
        }

        public void CreateDirectory(
            string path
        )
        {
            Check.NotNullOrWhiteSpace(() => path);
            Check.NotExtension(() => path);

            var parents = path
                .TrimStart(Path.AltDirectorySeparatorChar)
                .Split(Path.AltDirectorySeparatorChar);

            var parentPath = string.Empty;
            foreach (var parent in parents)
            {
                parentPath = string.Concat(
                    parentPath,
                    Path.AltDirectorySeparatorChar,
                    parent
                );
                var exists = this.DirectoryExists(parentPath);
                if (!exists)
                {
                    var request = this.Connect(parentPath, WebRequestMethods.Ftp.MakeDirectory);
                    var response = (FtpWebResponse)request.GetResponse();
                    this.ExecuteCommand(
                        response.GetResponseStream()
                    );
                }
            }


            //var exists = this.DirectoryExists(path);
            //if (!exists)
            //{
            //    var request = this.Connect(path, WebRequestMethods.Ftp.MakeDirectory);
            //    var response = (FtpWebResponse)request.GetResponse();
            //    this.ExecuteCommand(
            //        response.GetResponseStream()
            //    );
            //}
        }

        public void RemoveDirectory(
            string path
        )
        {
            Check.NotNullOrWhiteSpace(() => path);

            var exists = this.DirectoryExists(path);
            if (exists)
            {
                var request = this.Connect(path, WebRequestMethods.Ftp.RemoveDirectory);
                var response = (FtpWebResponse)request.GetResponse();
                this.ExecuteCommand(
                    response.GetResponseStream()
                );
            }
        }

        public FtpFileInfo[] GetFiles(
            string path
        )
        {
            return this.GetFiles(path, SearchPattern);
        }

        public FtpFileInfo[] GetFiles(
            string path,
            string searchPattern
        )
        {
            return this.GetFiles(path, searchPattern, SearchOption.TopDirectoryOnly);
        }

        public FtpFileInfo[] GetFiles(
            string path,
            string searchPattern,
            SearchOption searchOption
        )
        {
            Check.NotNullOrWhiteSpace(() => path);

            var request = this.Connect(path, WebRequestMethods.Ftp.ListDirectory);
            var response = (FtpWebResponse)request.GetResponse();
            var files = new List<FtpFileInfo>();
            var subDirectories = new List<string>();

            if (searchPattern != SearchPattern)
            {
                searchPattern = searchPattern.Replace(SearchPattern, string.Empty);
            }

            this.ExecuteCommand(
                response.GetResponseStream(),
                (stream) =>
                {
                    try
                    {
                        var fileOrDirectory = stream.ReadLine();
                        bool isFile = Path.HasExtension(fileOrDirectory);

                        if (isFile)
                        {
                            if (searchPattern.Equals(SearchPattern) || fileOrDirectory.Contains(searchPattern))
                            {
                                var filePath = string.Concat(
                                    path,
                                    Path.AltDirectorySeparatorChar,
                                    fileOrDirectory
                                );
                                var fileInfo = this.GetFile(filePath);

                                Console.WriteLine(fileInfo.FullName);

                                files.Add(fileInfo);
                            }
                        }
                        else
                        {
                            if (searchOption.Equals(SearchOption.AllDirectories))
                            {
                                var newPath = string.Concat(
                                    path,
                                    Path.AltDirectorySeparatorChar,
                                    fileOrDirectory
                                );
                                subDirectories.Add(newPath);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            );

            if (subDirectories.Count > 0)
            {
                foreach (var subDirectory in subDirectories)
                {
                    var moreFiles = this.GetFiles(subDirectory, searchPattern, searchOption);
                    files.AddRange(moreFiles);
                }
            }

            return files.ToArray();
        }

        public FtpFileInfo GetFile(
            string path
        )
        {
            Check.NotNullOrWhiteSpace(() => path);

            var request = this.Connect(path, WebRequestMethods.Ftp.ListDirectory);
            var response = (FtpWebResponse)request.GetResponse();

            FtpFileInfo fileInfo = default(FtpFileInfo);
            this.ExecuteCommand(
                response.GetResponseStream(),
                (stream) =>
                {
                    var file = stream.ReadLine();
                    if (!string.IsNullOrWhiteSpace(file))
                    {
                        fileInfo = new FtpFileInfo(path, this._host, this._userName, this._password);
                    }
                }
            );

            return fileInfo;
        }

        private FtpWebRequest Connect(
            string requestUri,
            string requestMethod = WebRequestMethods.Ftp.ListDirectory
        )
        {
            if (requestUri.IndexOf(this._host) == -1)
            {
                requestUri = string.Format(
                    @"{0}/{1}",
                    this._host.TrimEnd('/'),
                    requestUri.TrimStart('/')
                );
            }

            var request = (FtpWebRequest)FtpWebRequest.Create(requestUri);
            request.Credentials = new NetworkCredential(this._userName, this._password);
            request.UseBinary = true;
            request.UsePassive = true;
            request.KeepAlive = false;
            request.Method = requestMethod;

            return request;
        }

        public bool FileExists(
            string path
        )
        {
            Check.NotNullOrWhiteSpace(() => path);

            var fileSize = this.GetFileSize(path);
            return (fileSize > 0);
        }

        public bool DirectoryExists(
            string path
        )
        {
            Check.NotNullOrWhiteSpace(() => path);

            var parentPath = Path.GetDirectoryName(
                path.Trim(Path.AltDirectorySeparatorChar)
            );

            var directoryName = Path.GetFileName(
                path.Trim(Path.AltDirectorySeparatorChar)
            );

            var directoryInfo = this.DirectoryInfo(parentPath);

            return directoryInfo.Contains(directoryName);

            //var fileInfo = new FtpFileInfo(path, this._host, this._userName, this._password);
            //return fileInfo.Exists;
        }

        public string[] DirectoryInfo(
            string path
        )
        {
            var request = this.Connect(path, WebRequestMethods.Ftp.ListDirectory);
            var response = (FtpWebResponse)request.GetResponse();

            var directoryInfo = new List<string>();
            this.ExecuteCommand(
                response.GetResponseStream(),
                (stream) =>
                {
                    directoryInfo.Add(
                        stream.ReadLine()
                    );
                }
            );

            return directoryInfo.ToArray();
        }

        public long GetFileSize(
            string path
        )
        {
            Check.NotNullOrWhiteSpace(() => path);

            long fileSize = 0;
            FtpWebResponse response = null;

            try
            {
                var request = this.Connect(path, WebRequestMethods.Ftp.GetFileSize);
                response = (FtpWebResponse)request.GetResponse();
                fileSize = response.ContentLength;
            }
            catch (Exception ex)
            {
                if (response != null && response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                }
            }

            return fileSize;
        }

        private void WriteFile(
            Stream streamRead,
            Stream streamWrite
        )
        {
            Check.NotNull(
                () => streamRead,
                () => streamWrite
            );

            using (streamRead)
            {
                using (streamWrite)
                {
                    byte[] buffer = new byte[BufferSize];
                    int bytesRead = 0;
                    int totalBytes = 0;

                    while ((bytesRead = streamRead.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        streamWrite.Write(buffer, 0, bytesRead);
                        totalBytes += bytesRead;

                        if (totalBytes >= this.ChunkSize)
                        {
                            streamWrite.Flush();
                            totalBytes = 0;
                        }
                    }
                }
            }
        }

        private void ExecuteCommand(
            Stream stream
        )
        {
            Check.NotNull(() => stream);

            this.ExecuteCommand(
                stream,
                (streamReader) =>
                {
                    streamReader.ReadToEnd();
                }
            );
        }

        private void ExecuteCommand(
            Stream stream,
            Action<StreamReader> action
        )
        {
            Check.NotNull(
                new Expression<Func<object>>[]
                {
                    () => stream,
                    () => action
                }
            );

            using (stream)
            {
                using (var streamReader = new StreamReader(stream))
                {
                    while (streamReader.Peek() != -1)
                    {
                        action(streamReader);
                    }
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DataTransfer.Core.IO;
using System.Diagnostics;

namespace DataTransfer.Core.Net
{
    public class FtpTransfer
    {
        private readonly string _host;
        private readonly string _userName;
        private readonly string _password;

        public FtpTransfer(
            string host,
            string userName,
            string password
        )
        {
            Check.NotNullOrWhiteSpace(
                () => host,
                () => userName,
                () => password
            );

            this._host = host;
            this._userName = userName;
            this._password = password;
        }

        public void Download(
            string sourcePath,
            string destPath,
            string searchPattern = "*",
            bool deleteAfter = false,
            bool maintainStructure = true
        )
        {
            Check.NotNullOrWhiteSpace(
                () => sourcePath,
                () => destPath
            );

            var logger = new Logger();
            var transferWatch = new Stopwatch();
            var sourceFtp = new Ftp(this._host, this._userName, this._password);

            if (!Directory.Exists(destPath))
            {
                Directory.CreateDirectory(destPath);
            }

            logger.Log("    > Verify if Has Extension...\r\n");
            if (Path.HasExtension(sourcePath))
            {
                transferWatch.Start();

                logger.Log(
                    string.Format("      > Host: {0}\r\nFile: {1} ...\r\n", this._host, sourcePath),
                    Enumerators.LogColor.Success
                );
                logger.Log("      > Dowloading File...\r\n");

                sourceFtp.Download(sourcePath, destPath);

                if (deleteAfter)
                {
                    logger.Log("      > Deleting File...\r\n");
                    sourceFtp.DeleteFile(sourcePath);
                }

                logger.Log(
                    string.Format(
                        "      > Transfer File Duration: {0}...\r\n",
                        transferWatch.Elapsed
                    )
                );
                logger.Log("      > Transfer File Complete...\r\n", Enumerators.LogColor.Success);
            }
            else
            {
                logger.Log(
                    string.Format("    > Getting Files ({0})...\r\n", sourcePath)
                );

                var files = sourceFtp.GetFiles(sourcePath, searchPattern, SearchOption.AllDirectories);

                transferWatch.Start();

                logger.Log("    > Start Dowloading Files...\r\n");
                foreach (var file in files)
                {
                    logger.Log(
                        string.Format("      > File: {0} ...\r\n", file.FullName),
                        Enumerators.LogColor.Success
                    );

                    var path = destPath;

                    if (maintainStructure && !Path.HasExtension(path))
                    {
                        logger.Log("      > Creating the Structure...\r\n");
                        var relativePath = Transfer.GetRelativePath(sourcePath, file.DirectoryName);
                        if (!string.IsNullOrWhiteSpace(relativePath))
                        {
                            path = string.Concat(
                                path,
                                Path.DirectorySeparatorChar,
                                relativePath
                            );
                            Directory.CreateDirectory(path);
                        }
                    }

                    logger.Log("      > Dowloading File...\r\n");
                    sourceFtp.Download(file.RelativePath, path);

                    if (deleteAfter)
                    {
                        logger.Log("      > Deleting File...\r\n");
                        file.Delete();
                    }

                    logger.Log(
                        string.Format(
                            "      > Transfer File Duration: {0}...\r\n",
                            transferWatch.Elapsed
                        )
                    );
                    logger.Log("      > Transfer File Complete...\r\n", Enumerators.LogColor.Success);
                    transferWatch.Restart();
                }
            }

            transferWatch.Stop();
        }

        public void Upload(
            string sourcePath,
            string destPath,
            string searchPattern = "*",
            bool deleteAfter = false,
            bool maintainStructure = true
        )
        {
            Check.NotNullOrWhiteSpace(
                () => sourcePath,
                () => destPath
            );

            var logger = new Logger();
            var transferWatch = new Stopwatch();
            var destFtp = new Ftp(this._host, this._userName, this._password);

            if (!destFtp.DirectoryExists(destPath))
            {
                destFtp.CreateDirectory(destPath);
            }

            logger.Log("    > Verify if Has Extension...\r\n");
            if (Path.HasExtension(sourcePath))
            {
                transferWatch.Start();

                logger.Log(
                    string.Format("      > Host: {0}\r\nFile: {1} ...\r\n", this._host, sourcePath),
                    Enumerators.LogColor.Success
                );
                logger.Log("      > Uploading File...\r\n");

                destFtp.Upload(sourcePath, destPath);

                if (deleteAfter)
                {
                    logger.Log("      > Deleting File...\r\n");
                    File.Delete(sourcePath);
                }

                logger.Log(
                    string.Format(
                        "      > Transfer File Duration: {0}...\r\n",
                        transferWatch.Elapsed
                    )
                );
                logger.Log("      > Transfer File Complete...\r\n", Enumerators.LogColor.Success);
            }
            else
            {
                logger.Log(
                    string.Format("    > Getting Files ({0})...\r\n", sourcePath)
                );

                var dirInfo = new DirectoryInfo(sourcePath);
                var files = dirInfo.GetFiles(searchPattern, SearchOption.AllDirectories);

                transferWatch.Start();

                logger.Log("    > Start Uploading Files...\r\n");
                foreach (var file in files)
                {
                    logger.Log(
                        string.Format("      > File: {0} ...\r\n", file.FullName),
                        Enumerators.LogColor.Success
                    );

                    var path = destPath;

                    if (maintainStructure && !Path.HasExtension(path))
                    {
                        logger.Log("      > Creating the Structure...\r\n");
                        var relativePath = Transfer.GetRelativePath(sourcePath, file.DirectoryName);
                        if (!string.IsNullOrWhiteSpace(relativePath))
                        {
                            path = string.Concat(
                                path,
                                relativePath
                            );
                            destFtp.CreateDirectory(path);
                        }
                    }

                    logger.Log("      > Dowloading File...\r\n");
                    destFtp.Upload(file.FullName, path);

                    if (deleteAfter)
                    {
                        logger.Log("      > Deleting File...\r\n");
                        file.Delete();
                    }

                    logger.Log(
                        string.Format(
                            "      > Transfer File Duration: {0}...\r\n",
                            transferWatch.Elapsed
                        )
                    );
                    logger.Log("      > Transfer File Complete...\r\n", Enumerators.LogColor.Success);
                    transferWatch.Restart();
                }
            }
            transferWatch.Stop();
        }

        public void UploadFromFtp(
            string sourcePath,
            FtpFileInfo destFileInfo,
            string searchPattern = "*",
            bool deleteAfter = false,
            bool maintainStructure = true            
        ) 
        {
            Check.NotNull(() => destFileInfo);
            Check.NotNullOrWhiteSpace(() => sourcePath);

            var logger = new Logger();
            var transferWatch = new Stopwatch();
            var sourceFtp = new Ftp(this._host, this._userName, this._password);

            if (!destFileInfo.DirectoryExists)
            {
                destFileInfo.CreateDirectory();
            }

            var tempFilePath = string.Empty;
            var tempPath = string.Concat(
                Path.GetTempPath(),
                Guid.NewGuid()
            );

            if (!Directory.Exists(tempPath))
            {
                logger.Log("    > Creating the Temp Path...\r\n");
                Directory.CreateDirectory(tempPath);
            }

            logger.Log("    > Verify if Has Extension...\r\n");
            if (Path.HasExtension(sourcePath))
            {
                transferWatch.Start();

                tempFilePath = string.Concat(
                    tempPath,
                    Path.DirectorySeparatorChar,
                    Path.GetFileName(sourcePath)
                );

                logger.Log("    > Downloading File...\r\n");
                sourceFtp.Download(sourcePath, tempFilePath);
                
                logger.Log("    > Uploading File...\r\n");
                destFileInfo.Upload(tempFilePath);

                if (deleteAfter)
                {
                    logger.Log("    > Deleting File...\r\n");
                    sourceFtp.DeleteFile(sourcePath);
                }

                logger.Log(
                    string.Format(
                        "      > Transfer File Duration: {0}...\r\n",
                        transferWatch.Elapsed
                    )
                );
                logger.Log("    > Transfer File Complete...\r\n", Enumerators.LogColor.Success);
            }
            else
            {
                logger.Log(
                    string.Format("    > Getting Files ({0})...\r\n", sourcePath)
                );

                var files = sourceFtp.GetFiles(sourcePath, searchPattern, SearchOption.AllDirectories);

                transferWatch.Start();

                logger.Log("    > Start Dowloading Files...\r\n");
                foreach (var file in files)
                {
                    logger.Log(
                        string.Format("      > File: {0} ...\r\n", file.FullName),
                        Enumerators.LogColor.Success
                    );

                    var path = destFileInfo.RelativePath;
                    tempFilePath = tempPath;

                    if (maintainStructure && !Path.HasExtension(path))
                    {
                        logger.Log("      > Creating the Structure...\r\n");
                        var basePath = string.Concat(
                            this._host,
                            sourcePath
                        );
                        var relativePath = Transfer.GetRelativePath(basePath, file.DirectoryName);

                        if (!string.IsNullOrWhiteSpace(relativePath))
                        {
                            path = string.Concat(
                                path,
                                relativePath
                            );
                            destFileInfo.CreateDirectory(path);

                            tempFilePath = string.Concat(
                                tempFilePath,
                                Path.DirectorySeparatorChar,
                                relativePath
                            );

                            if (!Directory.Exists(tempFilePath))
                            {
                                Directory.CreateDirectory(tempFilePath);
                            }
                        }
                    }

                    tempFilePath = string.Concat(
                        tempFilePath,
                        Path.DirectorySeparatorChar,
                        Path.GetFileName(file.FullName)
                    );

                    logger.Log("      > Dowloading File...\r\n");
                    sourceFtp.Download(file.RelativePath, tempFilePath);

                    logger.Log("      > Uploading File...\r\n");
                    destFileInfo.Upload(tempFilePath, path);

                    if (deleteAfter)
                    {
                        logger.Log("      > Deleting File...\r\n");
                        file.Delete();
                    }

                    logger.Log(
                        string.Format(
                            "      > Transfer File Duration: {0}...\r\n",
                            transferWatch.Elapsed
                        )
                    );
                    logger.Log("      > Transfer File Complete...\r\n", Enumerators.LogColor.Success);
                    transferWatch.Restart();
                }
            }

            if (Directory.Exists(tempPath))
            {
                logger.Log("    > Deleting the Temp Path...\r\n");
                Directory.Delete(tempPath, true);
            }
            transferWatch.Stop();
        }
    }
}
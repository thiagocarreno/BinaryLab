using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security;

namespace DataTransfer.Core.Net
{
    public class FtpFileInfo
        : FileSystemInfo
    {
        private readonly string _host = null;
        private readonly string _userName = null;
        private readonly string _password = null;

        public FtpFileInfo(
            string path,
            string host,
            string userName,
            string password
        )
        {
            Check.NotNullOrWhiteSpace(
                () => path,
                () => host,
                () => userName,
                () => password
            );

            this._host = host;
            this._userName = userName;
            this._password = password;

            var value = string.Concat(host, path);
            this.FullPath = value;
            this.OriginalPath = value;
            this.RelativePath = path;
        }

        private Ftp Connect()
        {
            var ftpConnect = new Ftp(this._host, this._userName, this._password);
            return ftpConnect;
        }

        public string DirectoryName
        {
            get
            {
                var directoryName = this.FullName
                .Remove(
                    this.FullName.LastIndexOf(Path.AltDirectorySeparatorChar)
                );
                return directoryName;
            }
        }
        public override bool Exists
        {
            get
            {
                var ftp = this.Connect();
                var file = ftp.GetFile(this.FullPath);
                return (file != null);
            }
        }
        public bool IsReadOnly
        {
            get
            {
                //TODO: Implementar esse método
                //var ftp = this.Connect();
                //var file = ftp.GetFile(this.FullPath);
                return false;
            }
        }
        public long Length
        {
            get
            {
                var ftp = this.Connect();
                return ftp.GetFileSize(this.RelativePath);
            }
        }
        public override string Name
        {
            get
            {
                return Path.GetFileName(this.FullPath);
            }
        }
        
        public override void Delete()
        {
            var ftp = this.Connect();
            ftp.DeleteFile(this.FullPath);
        }

        public override string ToString()
        {
            return this.FullName;
        }

        public string RelativePath
        {
            get;
            private set;
        }
        public override string FullName
        {
            get
            {
                return this.FullPath;
            }
        }
        
        public void Upload(string sourcePath)
        {
            this.Upload(sourcePath, this.RelativePath);
        }
        
        public void Upload(string sourcePath, string destPath)
        {
            var ftp = this.Connect();
            ftp.Upload(sourcePath, destPath);
        }

        public bool DirectoryExists
        {
            get 
            {
                var ftp = this.Connect();
                return ftp.DirectoryExists(this.RelativePath);
            }
        }

        public void CreateDirectory()
        {
            this.CreateDirectory(this.RelativePath);
        }

        public void CreateDirectory(string relativePath)
        {
            var ftp = this.Connect();
            ftp.CreateDirectory(relativePath);
        }
    }
}
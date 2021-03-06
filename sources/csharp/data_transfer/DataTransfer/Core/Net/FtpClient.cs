﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace DataTransfer.Core.Net
{
    public class FTPClient
    {
        // The hostname or IP address of the FTP server
        private string _remoteHost;

        // The remote username
        private string _remoteUser;

        // Password for the remote user
        private string _remotePass;

        public FTPClient(string remoteHost, string remoteUser, string remotePassword, bool debug)
        {
            _remoteHost = remoteHost;
            _remoteUser = remoteUser;
            _remotePass = remotePassword;
        }

        /// <summary>
        /// Get a list of files and folders on the FTP server
        /// </summary>
        /// <returns></returns>
        public List<string> DirectoryListing()
        {
            return DirectoryListing(string.Empty);
        }

        /// <summary>
        /// List files and folders in a given folder on the server
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        public List<string> DirectoryListing(string folder)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_remoteHost + folder);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(_remoteUser, _remotePass);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            List<string> result = new List<string>();

            while (!reader.EndOfStream)
            {
                result.Add(reader.ReadLine());
            }

            reader.Close();
            response.Close();
            return result;
        }

        /// <summary>
        /// Download a file from the FTP server to the destination
        /// </summary>
        /// <param name="filename">filename and path to the file, e.g. public_html/test.zip</param>
        /// <param name="destination">The location to save the file, e.g. c:test.zip</param>
        public void Download(string filename, string destination)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_remoteHost + filename);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(_remoteUser, _remotePass);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            StreamWriter writer = new StreamWriter(destination);
            writer.Write(reader.ReadToEnd());

            writer.Close();
            reader.Close();
            response.Close();
        }

        /// <summary>
        /// Remove a file from the server.
        /// </summary>
        /// <param name="filename">filename and path to the file, e.g. public_html/test.zip</param>
        public void DeleteFileFromServer(string filename)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_remoteHost + filename);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.Credentials = new NetworkCredential(_remoteUser, _remotePass);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            response.Close();
        }

        /// <summary>
        /// Upload a file to the server
        /// </summary>
        /// <param name="source">Full path to the source file e.g. c:test.zip</param>
        /// <param name="destination">destination folder and filename e.g. public_html/test.zip</param>
        public void UploadFile(string source, string destination)
        {
            string filename = Path.GetFileName(source);

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_remoteHost + destination);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(_remoteUser, _remotePass);

            StreamReader sourceStream = new StreamReader(source);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());

            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            response.Close();
            requestStream.Close();
            sourceStream.Close();
        }
    }
}

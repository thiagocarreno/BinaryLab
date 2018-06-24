using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using DataTransfer.ConfigSections;
using DataTransfer.Core;
using DataTransfer.ConfigSections.DataTransfer;
using System.Linq.Expressions;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Net;
using DataTransfer.Core.IO;
using DataTransfer.Core.Net;
using System.Diagnostics;

namespace DataTransfer.Schedule
{
    //TODO: Implementar configuração e disparo de email se não houver arquivo no diretório

    class Program
    {
        static void Main(string[] args)
        {
#if !DEBUG
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
#endif
            Execute();
            Console.ReadKey();
        }

        static void Execute()
        {
            var logger = new Logger();
            var watch = new Stopwatch();
            watch.Start();

            logger.Log("> Starting...\r\n");
            logger.Log(
                string.Format("  > Start Time: {0}\r\n", DateTime.Now)
            );

            foreach (TransferElement transfer in Configuration.DataTransfer.Transfers)
            {
                try
                {
                    logger.Log(
                        string.Format(
                            "    > Transfer Name: {0}\r\n", transfer.InvariantName
                        )
                    );

                    var from = transfer.From;
                    var to = transfer.To;

                    if (from.IsFtp)
                    {
                        var sourceFtp = new FtpTransfer(from.Host, from.UserName, from.Password);

                        if (to.IsFtp)
                        {
                            var ftpFileInfo = new FtpFileInfo(to.Path, to.Host, to.UserName, to.Password);
                            sourceFtp.UploadFromFtp(from.Path, ftpFileInfo, from.SearchPattern, from.DeleteAfter, to.MaintainStructure);
                        }
                        else
                        {
                            sourceFtp.Download(from.Path, to.Path, from.SearchPattern, from.DeleteAfter, to.MaintainStructure);
                        }
                    }
                    else
                    {
                        if (to.IsFtp)
                        {
                            var destFtp = new FtpTransfer(to.Host, to.UserName, to.Password);
                            destFtp.Upload(from.Path, to.Path, from.SearchPattern, from.DeleteAfter, to.MaintainStructure);
                        }
                        else
                        {
                            Transfer.TransferFile(from.Path, to.Path, from.SearchPattern, to.MaintainStructure, from.DeleteAfter);
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Log(
                        string.Format(
                            "> Error: {0}\r\n", ex.Message
                        ),
                        Enumerators.LogColor.Error
                    );
                }
            }

            logger.Log(
                string.Format("  > End Time: {0}\r\n", DateTime.Now)
            );
            logger.Log(
                string.Format("  > Duration Time: {0}\r\n", watch.Elapsed)
            );
            logger.Log(
                string.Format("  > End Time: {0}\r\n", watch.Elapsed)
            );
            logger.Log("> End\r\n");
            watch.Stop();

            if (!Directory.Exists(Constants.LOG_RELATIVE_PATH))
            {
                Directory.CreateDirectory(Constants.LOG_RELATIVE_PATH);
            }

            var logPath = string.Format(
                "{0}{1}{2}{3}.log",
                Constants.LOG_RELATIVE_PATH,
                Path.DirectorySeparatorChar,
                Constants.LOG_FILE_NAME,
                DateTime.Now.ToString("yyyyMMddHHmmssfff")
            );

            logger.Write(logPath);

#if DEBUG
            Console.ReadLine();            
#endif
            Environment.Exit(1);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var logger = new Logger();

            logger.Log(
                string.Format(
                    "> Error: {0}\r\n", e.ExceptionObject.ToString()
                )
            );

            logger.SendEmail(Constants.LOG_EMAIL_SUBJECT, e.ExceptionObject.ToString(), Constants.LOG_EMAILS);
            Environment.Exit(0);
        }
    }
}
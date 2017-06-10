using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DataTransfer.Core.IO
{
    public class Transfer
    {
        private const int ChunkSize = (5 * 1024);
        private const int BufferSize = 1024;

        public static string GetRelativePath(
            string sourcePath,
            string directoryName
        )
        {
            Check.NotNullOrWhiteSpace(
                () => sourcePath,
                () => directoryName
            );

            if (Path.HasExtension(sourcePath))
            {
                sourcePath = Path.GetDirectoryName(sourcePath);
            }

            var relativePath = directoryName
                .Remove(0, sourcePath.Length);

            return relativePath;
        }

        public static void TransferFile(
            string sourcePath,
            string destPath,
            string searchPattern = "*",
            bool maintainStructure = true,
            bool deleteAfter = false
        ) 
        {
            Check.NotNullOrWhiteSpace(
                () => sourcePath,
                () => destPath
            );

            var logger = new Logger();
            var transferWatch = new Stopwatch();

            if (!Directory.Exists(destPath))
            {
                Directory.CreateDirectory(destPath);
            }

            logger.Log("    > Verify if Has Extension...\r\n");
            if (Path.HasExtension(sourcePath))
            {
                transferWatch.Start();

                logger.Log(
                    string.Format("      > File: {0} ...\r\n", sourcePath),
                    Enumerators.LogColor.Success
                );
                logger.Log("      > Writing File...\r\n");
                WriteFile(sourcePath, destPath);

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

                logger.Log("    > Start Writing Files...\r\n");
                foreach (var file in files)
                {
                    logger.Log(
                        string.Format("      > File: {0} ...\r\n", file.FullName),
                        Enumerators.LogColor.Success
                    );

                    if (maintainStructure && !Path.HasExtension(destPath))
                    {
                        logger.Log("      > Creating the Structure...\r\n");
                        var relativePath = GetRelativePath(sourcePath, file.DirectoryName);
                        if (!string.IsNullOrWhiteSpace(relativePath))
                        {
                            destPath = string.Concat(
                                destPath,
                                relativePath
                            );
                            Directory.CreateDirectory(destPath);
                        }
                    }

                    logger.Log("      > Writing File...\r\n");
                    WriteFile(file.FullName, destPath);

                    if (deleteAfter)
                    {
                        logger.Log("      > Deleting File...\r\n");
                        File.Delete(file.FullName);
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

        public static void WriteFile(
            string sourcePath,
            string destPath
        )
        {
            Check.NotNullOrWhiteSpace(
                () => sourcePath,
                () => destPath
            );

            if (!Path.HasExtension(destPath))
            {
                var fileName = Path.GetFileName(sourcePath);
                destPath = string.Concat(
                    destPath,
                    Path.DirectorySeparatorChar,
                    fileName
                );
            }

            using (var fileStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var fileWrite = new FileStream(destPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                {
                    byte[] buffer = new byte[BufferSize];
                    int bytesRead = 0;
                    int totalBytes = 0;

                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileWrite.Write(buffer, 0, bytesRead);
                        totalBytes += bytesRead;

                        if (totalBytes >= ChunkSize)
                        {
                            fileWrite.Flush(true);
                            totalBytes = 0;
                        }
                    }
                }
            }
        }
    }
}
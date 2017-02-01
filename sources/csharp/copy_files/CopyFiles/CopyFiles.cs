using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CopyFiles
{
    class CopyFiles
    {
        protected static string sourceFile;
        protected static string destinationFile;
        protected static string sourceDirectory;
        protected static string destinationDirectory;

        static void Main(string[] args)
        {
            //string resultCopy = CopyFile(@"D:\teste\files_old\", @"D:\teste\files_new\", "teste.jpg");
            string resultCopy = CopyAllFiles(@"D:\teste\files_old\", @"D:\teste\files_new\");
            Console.WriteLine(resultCopy);
            Console.ReadLine();
        }

        static string CopyFile(string source, string destination, string fileName)
        {
            string result = String.Empty;
            string fileSource = String.Format("{0}{1}", source, fileName);
            FileInfo fi = new FileInfo(fileSource);

            sourceFile = fi.FullName;
            destinationFile = String.Format("{0}{1}", destination, fileName);

            try
            {
                var bystesFile = File.ReadAllBytes(sourceFile);
                File.WriteAllBytes(destinationFile, bystesFile);
            }
            catch (Exception ex)
            {
                result = String.Format("Erro ao copiar arquivo:\n{0}", ex.Message);
            }
            finally
            {
                if (String.IsNullOrEmpty(result))
                {
                    result = "Arquivo copiado com sucesso.";
                }
            }
            return result;
        }

        static string CopyAllFiles(string source, string destination)
        {
            string result = String.Empty;
            string directorySource = String.Format("{0}", source);
            DirectoryInfo di = new DirectoryInfo(directorySource);

            sourceDirectory = di.FullName;
            destinationDirectory = String.Format("{0}", destination);

            //try
            //{
            //    var bystesFile = File.ReadAllBytes(sourceFile);
            //    File.WriteAllBytes(destinationFile, bystesFile);
            //}
            //catch (Exception ex)
            //{
            //    result = String.Format("Erro ao copiar arquivo:\n{0}", ex.Message);
            //}
            //finally
            //{
            //    if (String.IsNullOrEmpty(result))
            //    {
            //        result = "Arquivo copiado com sucesso.";
            //    }
            //}
            return result;
        }
    }
}

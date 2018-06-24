using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace criptTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string exeConfigName = System.AppDomain.CurrentDomain.FriendlyName.Replace(".vshost","");
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(exeConfigName);
                var section = config.GetSection("connectionStrings");

                if (section.SectionInformation.IsProtected)
                {
                    section.SectionInformation.UnprotectSection();
                }
                else
                {
                    section.SectionInformation.ProtectSection(ConfigurationManager.AppSettings["RSADataProtectionProvider"]);
                }

                config.Save();
                Console.WriteLine("Protected={0}", section.SectionInformation.IsProtected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            Console.ReadKey();
        }
    }
}
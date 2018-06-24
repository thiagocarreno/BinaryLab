using DryIoc;
using PoC.Serilog.Binding;
using Serilog;
using Serilog.Debugging;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoC.Serilog
{
    class Program
    {
        public static readonly string ExecutableName = AppDomain.CurrentDomain.FriendlyName;
        public static IContainer Container;

        static void ConfigureContainer()
        {
            Container = new Container();
            LoggerBinder.SetBinding(Container);
        }

        static void Main(string[] args)
        {
            try
            {
                ConfigureContainer();
                var logger = Container.Resolve<Abstraction.ILogger>();

                //logger.Debug("Debug...");
                //logger.Info("Info 1");
                //logger.Info("Info 2", "TestColumn", Guid.NewGuid());

                logger.Info("Info");
            }
            catch (Exception ex)
            {
                var logger = Container.Resolve<Abstraction.ILogger>();
                logger.Fatal(ex.Message, ex);
            }
        }
    }
}

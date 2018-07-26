using NewRelic.Api.Agent;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleAppNewRelic
{
    class Program
    {
        const string _version = "1.0.0";

        static void Main(string[] args)
        {
            var stopWatch = Stopwatch.StartNew();
            NewRelic.Api.Agent.NewRelic.SetApplicationName("Marketplace-HML");

            SetTransactionName("Notice Error Method");
            ErrorTest("Exception test.");

            SetTransactionName("Run Method");
            Run();

            stopWatch.Stop();
            NewRelic.Api.Agent.NewRelic.RecordMetric("PoC/Executable_Metric", stopWatch.ElapsedMilliseconds);
        }

        static void SetTransactionName(string transactionName) =>
            NewRelic.Api.Agent.NewRelic.SetTransactionName("PoC", transactionName);

        [Transaction]
        static void ErrorTest(string exceptionMessage)
        {
            NewRelic.Api.Agent.NewRelic.AddCustomParameter("Parameter_Value", exceptionMessage);
            NewRelic.Api.Agent.NewRelic.AddCustomParameter("Error_Test_Exception", "Exception without try");
            var exception = new Exception(exceptionMessage);
            NewRelic.Api.Agent.NewRelic.NoticeError(exception);

            try
            {
                NewRelic.Api.Agent.NewRelic.AddCustomParameter("Error_Test_Exception", "Exception in try");
                throw new Exception(exceptionMessage);
            }
            catch (Exception ex)
            {
                NewRelic.Api.Agent.NewRelic.NoticeError(ex);
            }
        }

        [Transaction]
        static void Run()
        {
            NewRelic.Api.Agent.NewRelic.AddCustomParameter("AppVersion", _version);

            for (int i = 0; i < 1000; i++)
            {
                NewRelic.Api.Agent.NewRelic.SetTransactionName("PoC", "Calculate Method");
                Calculate(i);
                System.Threading.Thread.Sleep(500);
            }
        }

        [Transaction]
        [Trace]
        static void Calculate(int i)
        {
            NewRelic.Api.Agent.NewRelic.AddCustomParameter("Add-Parameter", i);
            var result = Add(i, 1);
            Console.WriteLine($"Called Add method with parameter value: {i} => {result}");
        }

        [Trace]
        static int Add(int x, int y)
        {
            var eventAttributes = new Dictionary<string, object>() { { "x", x }, { "y", y } };
            NewRelic.Api.Agent.NewRelic.RecordCustomEvent("PoC_Sum_Operation", eventAttributes);
            return x + y;
        }
    }
}
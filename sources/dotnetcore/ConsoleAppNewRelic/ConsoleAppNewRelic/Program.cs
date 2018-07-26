using NewRelic.Api.Agent;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleAppNewRelic
{
    class Program
    {
        const string VERSION = "3.0.0";

        static void Main(string[] args)
        {
            var stopWatch = Stopwatch.StartNew();
            NewRelic.Api.Agent.NewRelic.SetApplicationName("Marketplace-HML");
            Run();
            stopWatch.Stop();
            NewRelic.Api.Agent.NewRelic.RecordMetric("PoC/ExecutableMetric", stopWatch.ElapsedMilliseconds);
        }

        static void SetTransactionName(string transactionName) =>
            NewRelic.Api.Agent.NewRelic.SetTransactionName("PoC", transactionName);

        [Transaction]
        [Trace]
        static void ErrorTest(string exceptionMessage)
        {
            SetTransactionName("Notice Error Method");
            NewRelic.Api.Agent.NewRelic.AddCustomParameter("PoC:ParameterValue", exceptionMessage);
            NewRelic.Api.Agent.NewRelic.AddCustomParameter("PoC:ErrorTestException", "Exception without try");
            NewRelic.Api.Agent.NewRelic.NoticeError($"String: {exceptionMessage}", null);

            try
            {
                NewRelic.Api.Agent.NewRelic.AddCustomParameter("PoC:ErrorTestException", "Exception in try");
                throw new Exception(exceptionMessage);
            }
            catch (Exception ex)
            {
                NewRelic.Api.Agent.NewRelic.NoticeError(ex);
            }
        }

        [Transaction]
        [Trace]
        static void Run()
        {
            SetTransactionName("Run Method.");
            NewRelic.Api.Agent.NewRelic.AddCustomParameter("PoC:AppVersion", VERSION);
            ErrorTest("Exception test.");

            for (int i = 0; i < 1000; i++)
            {
                Calculate(i);
                System.Threading.Thread.Sleep(500);
            }
        }

        [Transaction]
        [Trace]
        static void Calculate(int i)
        {
            SetTransactionName("Calculate Method.");
            NewRelic.Api.Agent.NewRelic.AddCustomParameter("AddParameter", i);
            var result = Add(i, 1);
            Console.WriteLine($"Called Add method with parameter value: {i} => {result}");
        }

        [Trace]
        static int Add(int x, int y)
        {
            var eventAttributes = new Dictionary<string, object>() { { "x", x }, { "y", y } };
            NewRelic.Api.Agent.NewRelic.RecordCustomEvent("PoCSumOperation", eventAttributes);
            return x + y;
        }
    }
}
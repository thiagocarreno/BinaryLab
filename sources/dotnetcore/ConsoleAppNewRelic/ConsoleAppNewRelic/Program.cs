using NewRelic.Api.Agent;
using System;
using System.Collections.Generic;

namespace ConsoleAppNewRelic
{
    class Program
    {
        public Program() =>
            NewRelic.Api.Agent.NewRelic.SetApplicationName("New Relic PoC.");

        static void Main(string[] args)
        {
            SetTransactionName("Notice Error Method");
            ErrorTest("Exception test.");

            SetTransactionName("Run Method");
            Run();
        }

        static void SetTransactionName(string transactionName) =>
            NewRelic.Api.Agent.NewRelic.SetTransactionName("PoC", transactionName);

        [Transaction]
        static void ErrorTest(string exceptionMessage)
        {
            try
            {
                throw new Exception(exceptionMessage);
            }
            catch (Exception ex)
            {
                var parameters = new Dictionary<string, string>
                {
                    { "TestKey", "Test value." }
                };

                NewRelic.Api.Agent.NewRelic.NoticeError(ex);
                NewRelic.Api.Agent.NewRelic.NoticeError(ex, parameters);
                NewRelic.Api.Agent.NewRelic.NoticeError(ex.Message, parameters);
            }
        }

        [Transaction]
        static void Run()
        {
            for (int i = 0; i < 1000; i++)
            {
                NewRelic.Api.Agent.NewRelic.SetTransactionName("PoC", "Calculate Method");
                Calculate();
                System.Threading.Thread.Sleep(500);
            }
        }

        [Transaction]
        static void Calculate()
        {
            Console.WriteLine("Call Add!");
            Add(6, 7);
        }

        [Trace]
        static int Add(int x, int y)
        {
            return x + y;
        }
    }
}

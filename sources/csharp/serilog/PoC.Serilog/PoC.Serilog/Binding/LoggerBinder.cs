using DryIoc;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoC.Serilog.Binding
{
    public class TestModel
    {
        public string TestColumn { get; set; }
    }

    public class LoggerBinder
    {
        public static void SetBinding(IContainer container)
        {
            var config = new LoggerConfiguration();

            var columnOptions = new ColumnOptions();
            //columnOptions.Store.Remove(StandardColumn.MessageTemplate);
            columnOptions.TimeStamp.ColumnName = "Logged";
            columnOptions.TimeStamp.ConvertToUtc = true;
            columnOptions.AdditionalDataColumns = new Collection<DataColumn>
            {
                new DataColumn
                {
                    ColumnName = "TestColumn",
                    AllowDBNull = true,
                    DataType = typeof(string)
                }
            };

            config.WriteTo.MSSqlServer(
                connectionString: "DefaultConnection",
                tableName: "Logs",
                restrictedToMinimumLevel: LogEventLevel.Verbose,
                columnOptions: columnOptions,
                autoCreateSqlTable: true
            )
            //.Destructure.ByTransforming<TestModel>(i => i.TestColumn)
            //.Enrich.WithProperty(
            //    "TestColumn",
            //    Guid.NewGuid().ToString()
            //)
            ;

            config.WriteTo.RollingFile(
                pathFormat: "logs\\SerilogPoC.txt"
            );

            config.WriteTo.Console(
                LogEventLevel.Debug
            ).ReadFrom.AppSettings();

            container.RegisterDelegate(
                resolver => config,
                serviceKey: "loggerConfiguration",
                reuse: Reuse.Transient
            );

            container.Register<Abstraction.ILogger, SerilogLogger>(
                made: Parameters.Of.Type<LoggerConfiguration>(serviceKey: "loggerConfiguration"),
                reuse: Reuse.Singleton
            );
        }
    }
}
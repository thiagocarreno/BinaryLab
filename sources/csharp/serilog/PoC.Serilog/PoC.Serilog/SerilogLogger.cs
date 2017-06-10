using Serilog;
using Serilog.Core;
using System;

namespace PoC.Serilog
{
    public class SerilogLogger
        : Abstraction.ILogger, IDisposable
    {
        private readonly ILogger _serilog;

        public SerilogLogger(LoggerConfiguration config)
        {
            _serilog = config.CreateLogger();
        }

        public void Debug(string message)
        {
            _serilog.Debug(message);
        }

        public void Debug(string message, Exception ex)
        {
            _serilog.Debug(message, ex);
        }

        public void Error(string message)
        {
            _serilog.Error(message);
        }

        public void Error(string message, Exception ex)
        {
            _serilog.Error(message, ex);
        }

        public void Fatal(string message)
        {
            _serilog.Fatal(message);
        }

        public void Fatal(string message, Exception ex)
        {
            _serilog.Fatal(message, ex);
        }

        public void Info(string message)
        {
            _serilog.Information("- {TestColumns}", message);
        }

        public void Info(string message, Exception ex)
        {
            _serilog.Information(message, ex);
        }

        public void Info(string message, string propertyName, object value)
        {
            _serilog.ForContext(propertyName, value.ToString(), true)
                .Information(message);
        }

        public void Warn(string message)
        {
            _serilog.Warning(message);
        }

        public void Warn(string message, Exception ex)
        {
            _serilog.Warning(message, ex);
        }

        public void Dispose()
        {
            (_serilog as Logger)?.Dispose();
        }
    }
}
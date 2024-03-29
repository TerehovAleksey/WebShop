﻿using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.IO;
using System.Xml;

namespace WebShop.Logger
{
    public class Log4NetProvider : ILoggerProvider
    {
        private readonly string _log4NetConfigFile;
        private readonly ConcurrentDictionary<string, Log4NetLogger> _loggers = new();

        public Log4NetProvider(string log4NetConfigFile)
        {
            _log4NetConfigFile = log4NetConfigFile;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
        }

        private Log4NetLogger CreateLoggerImplementation(string name)
        {
            return new Log4NetLogger(name, ParseLog4NetConfigFile(_log4NetConfigFile));
        }

        private XmlElement ParseLog4NetConfigFile(string filename)
        {
            var log4NetConfig = new XmlDocument();
            log4NetConfig.Load(File.OpenRead(filename));
            return log4NetConfig["log4net"];
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}

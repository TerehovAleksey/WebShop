using Microsoft.Extensions.Logging;

namespace WebShop.Logger
{
    public static class Log4NetExtentions
    {
        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, string log4NetConfigFile)
        {
            factory.AddProvider(new Log4NetProvider(log4NetConfigFile));
            return factory;
        }

        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory)
        {
            factory.AddProvider(new Log4NetProvider("log4Net.config"));
            return factory;
        }
    }
}

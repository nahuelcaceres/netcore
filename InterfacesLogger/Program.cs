using System;
using System.Collections.Generic;
using InterfacesLogger.Implementaciones;
using InterfacesLogger.Interfaces;

namespace InterfacesLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<ILogger> loggers = new List<ILogger>();
            
            ILogger consoleLogger = new ConsoleLogger();
            ILogger databaseLogger = new DatabaseLogger();
            ILogger windowLogger = new WindowLogger();

            loggers.Add(consoleLogger);
            loggers.Add(databaseLogger);
            loggers.Add(windowLogger);

            Loguear(loggers);
        }

        private static void Loguear(IList<ILogger> loggers)
        {
            foreach (var logger in loggers)
            {
                logger.Error("Object reference not set to an instance of an object");
                logger.Informacion("Sending information");
            }
        }
    }
}

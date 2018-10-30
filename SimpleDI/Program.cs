using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDI
{
    class Program
    {
        static void Main(string[] args)
        {
            String loggerType = "database";
            ILogger logger;
            switch (loggerType)
            {
                case "database":
                    logger = new DatabaseLogger();
                    break;

                default:
                    logger = new TextLogger();
                    break;
            }

            try
            {
                //some business sensitive code

                throw new DivideByZeroException();
            }
            catch(Exception e)
            {
                LogManager logManager = new LogManager(logger);
                logManager.Log(e.Message);
                Console.Read();
            }

        }
    }

    interface ILogger
    {
        void Log(String message);
    }

    class LogManager
    {
        private ILogger _logger;
        public LogManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(String message)
        {
            _logger.Log(message);
        }
    }

    class TextLogger : ILogger
    {
        public void Log(String message)
        {
            Console.WriteLine("Logged to text file: " + message);
        }
    }

    class DatabaseLogger : ILogger
    {
        public void Log(String message)
        {
            Console.WriteLine("Logged to Sql database: " + message);
        }
    }


}

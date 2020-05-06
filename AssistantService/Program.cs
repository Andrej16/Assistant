using System;
using System.ServiceProcess;

namespace Assistant
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main(string[] argc)
        {
            if (Environment.UserInteractive)
            {
                AssistanceService serv = new AssistanceService();
                serv.TestStartupAndStop(argc);
            }
            else
            {
                ServiceBase.Run(new AssistanceService());
            }            
        }
    }
}

using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;

namespace Assistant
{
    public partial class AssistanceService : ServiceBase
    {
        private static Timer timer;
        /// <summary>
        /// 30 sec
        /// </summary>
        private const int interval = 60000;
        private const string eventSourceName = "MyService";
        //private bool proceed;
        private EventLog eventLog;
        #region Load
        public AssistanceService()
        {
            InitializeComponent();

            string logName = eventSourceName + "Log";

            eventLog = new EventLog();

            if (!EventLog.SourceExists(eventSourceName))
                EventLog.CreateEventSource(eventSourceName, logName);

            eventLog.Source = eventSourceName;
            eventLog.Log = logName;
        }
        internal void TestStartupAndStop(string[] argc)
        {
            OnStart(argc);
            Console.ReadKey();
            OnStop();
        }
        private void InitializeInternal()
        {
            timer = new Timer(interval);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        #endregion 
        #region Service event's handlers
        protected override void OnStart(string[] args)
        {
            InitializeInternal();
            LifeTimeLog("Service stated!");
        }
        protected override void OnStop()
        {
            LifeTimeLog("Service stopped!");
        }
        #endregion
        #region Service methods
        private void LifeTimeLog(string msg)
        {
            eventLog.WriteEntry(msg, EventLogEntryType.Information);
        }
        #endregion
        #region Other event's handlers
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            ToLog();
            //DateTime cur = DateTime.Now;

            //if (cur.Hour == 18 && cur.Minute == 00 && !proceed)
            //{
            //    ToLog();
            //    proceed = true;
            //}
            //else if (cur.Hour != 18 && cur.Minute != 00)
            //    proceed = false;

        }
        #endregion
        #region Jobs
        private void ToLog()
        {
            eventLog.WriteEntry($"Current time: {DateTime.Now.ToString()}");
        }
        #endregion
    }
}

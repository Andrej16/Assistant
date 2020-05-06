using System;
using System.Timers;

namespace Assistant
{
    /// <summary>
    /// Generates an event after a set interval, with an option to generate recurring events.
    /// </summary>
    public class TimerCallBack : IDisposable
    {
        private Action doOperations;
        private Timer _aTimer;
        #region IDisposable suport
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~TimerCallBack()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _aTimer?.Dispose();
        }
        #endregion
        /// <summary>
        /// Initializes a new instance of the Timer class, and sets the Interval property to the specified number of milliseconds.
        /// </summary>
        /// <example>
        /// <code>
        /// TimerCallBack timer = new TimerCallBack(ActionsyncAddRequestNext, 500, senderForm);
        /// </code>
        /// </example>
        /// <param name="deleg">Opretion to do</param>
        /// <param name="delay">The time, in milliseconds - delay before proceed</param>
        public TimerCallBack(Action deleg, int delay, System.Windows.Forms.Form sender = null)
        {
            _aTimer = new Timer(delay);
            _aTimer.AutoReset = false;
            _aTimer.Enabled = true;
            _aTimer.Elapsed += ATimer_Elapsed;
            _aTimer.SynchronizingObject = sender;
            doOperations = deleg;
        }
        private void ATimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            doOperations();
            Dispose();
        }
    }
}

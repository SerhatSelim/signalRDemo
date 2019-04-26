using System;
using System.Threading;

namespace signalRDemo.TimerFeatures
{
    /// <summary>
    /// 
    /// </summary>
    public class TimerManager
    {
        /// <summary>
        /// The timer
        /// </summary>
        private Timer _timer;

        /// <summary>
        /// The automatic reset event
        /// </summary>
        private AutoResetEvent _autoResetEvent;
        
        /// <summary>
        /// The action
        /// </summary>
        private Action _action;

        /// <summary>
        /// Gets the timer started.
        /// </summary>
        /// <value>
        /// The timer started.
        /// </value>
        public DateTime TimerStarted { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerManager"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public TimerManager(Action action)
        {
            _action = action;
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Execute, _autoResetEvent, 1000, 2000);
            TimerStarted = DateTime.Now;
        }

        /// <summary>
        /// Executes the specified state information.
        /// </summary>
        /// <param name="stateInfo">The state information.</param>
        public void Execute(object stateInfo)
        {
            _action();

            if ((DateTime.Now - TimerStarted).Seconds > 60)
            {
                _timer.Dispose();
            }
        }
    }
}

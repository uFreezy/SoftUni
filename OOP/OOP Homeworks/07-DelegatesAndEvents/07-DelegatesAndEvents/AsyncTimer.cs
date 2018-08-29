namespace _07_DelegatesAndEvents
{
    using System;
    using System.ComponentModel;
    using System.Threading;

    public class AsyncTimer
    {
        private readonly BackgroundWorker _wroker = new BackgroundWorker();

        public AsyncTimer(Action<string> action, int tickCount, int interval, string message)
        {
            this.Action = action;
            this.TickCount = tickCount;
            this.Interval = interval;
            this.Message = message;
        }

        public Action<string> Action { get; }

        public int TickCount { get; }

        public int Interval { get; }

        public string Message { get; set; }

        public event TimeChangedEventHandler TimeChanged;

        protected void OnTimeChanged(int tick)
        {
            if (this.TimeChanged == null) return;
            var args = new TimeChangedEventArgs(tick);
            this.TimeChanged(this, args);
        }

        public void Run()
        {
            this._wroker.DoWork += delegate
            {
                var tick = TickCount;
                while (tick > 0)
                {
                    Action(Message);
                    Thread.Sleep(Interval);
                    tick--;
                    OnTimeChanged(tick);
                }
            };

            this._wroker.RunWorkerAsync();
        }
    }
}
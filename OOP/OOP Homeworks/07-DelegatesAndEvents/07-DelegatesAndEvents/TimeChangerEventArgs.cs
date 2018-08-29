namespace _07_DelegatesAndEvents
{
    using System;

    public class TimeChangedEventArgs : EventArgs
    {
        public TimeChangedEventArgs(int ticksLeft)
        {
            this.TicksLeft = ticksLeft;
        }

        public int TicksLeft { get; }
    }
}
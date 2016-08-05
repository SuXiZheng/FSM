using System;

namespace Sago.Framework.FSM
{
    public class OnStateChangedEventArgs : EventArgs
    {
        internal OnStateChangedEventArgs(State oldState,State newState)
        {
            this.OldState = oldState;
            this.NewState = newState;
        }

        public State OldState { get; private set; }

        public State NewState { get; private set; }
    }
}

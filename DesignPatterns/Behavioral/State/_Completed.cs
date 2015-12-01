using System;

namespace GangOfFour.Behavioral
{
    //--- Allow an object to alter its behavior when its internal state changes.
    //--- The object will appear to change its class.

    public static class UsageState
    {
        internal static void UsageMethod()
        {
            var context = new StateContext(new ConcreteStateA());
            context.Request();
            context.Request();
            context.Request();
            context.Request();
        }
    }

    public interface IState
    {
        void Handle(StateContext context);
    }

    public class ConcreteStateA : IState
    {
        public virtual void Handle(StateContext context)
        {
            context.State = new ConcreteStateB();
        }
    }

    public class ConcreteStateB : IState
    {
        public virtual void Handle(StateContext context)
        {
            context.State = new ConcreteStateA();
        }
    }

    public class StateContext
    {
        private IState state;

        //--- C'tor
        public StateContext(IState state)
        {
            State = state;
        }

        public IState State
        {
            get { return state; }
            set
            {
                state = value;
                System.Diagnostics.Debug.WriteLine("State: " + state.GetType().Name);
            }
        }

        public void Request()
        {
            state.Handle(this);
        }
    }
}

using System;

namespace GangOfFour.Behavioral
{
    //--- Without violating encapsulation, capture and externalize an object's 
    //--- internal state so that the object can be restored to this state later.

    public static class UsageMemento
    {
        internal static void UsageMethod()
        {
            Originator o = new Originator() { State = "On" };
            Caretaker c = new Caretaker() { Memento = o.CreateMemento() };
            o.State = "Off";
            o.SetMemento(c.Memento);
        }
    }

    public class Originator
    {
        private string state;

        public string State
        {
            get { return state; }
            set
            {
                state = value;
                System.Diagnostics.Debug.WriteLine("State = " + state);
            }
        }

        public Memento CreateMemento()
        {
            return (new Memento(state));
        }

        public void SetMemento(Memento memento)
        {
            System.Diagnostics.Debug.WriteLine("Restoring state...");
            State = memento.State;
        }
    }

    public class Memento
    {
        private readonly string state;

        //--- C'tor
        public Memento(string state)
        {
            this.state = state;
        }

        public string State
        {
            get { return state; }
        }
    }

    public class Caretaker
    {
        public Memento Memento { get; set; }
    }
}

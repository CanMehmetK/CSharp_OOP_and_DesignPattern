using System;

namespace GangOfFour.Behavioral
{
    //--- Define an object that encapsulates how a set of objects interact. 
    //--- Mediator promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently.

    public class UsageMediator
    {
        public void UsageMethod()
        {
            ConcreteMediator m = new ConcreteMediator();
            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);
            m.Colleague1 = c1;
            m.Colleague2 = c2;
            c1.Send("How are you?");
            c2.Send("Fine, thanks");
        }
    }

    public interface IMediator
    {
        void Send(string message, Colleague colleague);
    }

    public class ConcreteMediator : IMediator
    {
        private ConcreteColleague1 colleague1;
        private ConcreteColleague2 colleague2;

        public ConcreteColleague1 Colleague1
        {
            set { colleague1 = value; }
        }

        public ConcreteColleague2 Colleague2
        {
            set { colleague2 = value; }
        }

        public virtual void Send(string message, Colleague colleague)
        {
            if (colleague == colleague1)
            {
                colleague2.Notify(message);
            }
            else
            {
                colleague1.Notify(message);
            }
        }
    }

    public abstract class Colleague
    {
        protected readonly IMediator mediator;

        //--- C'tor
        public Colleague(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }

    public class ConcreteColleague1 : Colleague
    {
        //--- C'tor
        public ConcreteColleague1(IMediator mediator)
          : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            System.Diagnostics.Debug.WriteLine("Colleague1 gets message: " + message);
        }
    }

    public class ConcreteColleague2 : Colleague
    {
        //--- C'tor
        public ConcreteColleague2(IMediator mediator)
          : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            System.Diagnostics.Debug.WriteLine("Colleague2 gets message: " + message);
        }
    }
}

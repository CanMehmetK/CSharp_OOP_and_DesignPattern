using System;

namespace GangOfFour.Behavioral
{
    //--- Encapsulate a request as an object, thereby letting you parameterize clients 
    //--- with different requests, queue or log requests, and support undoable operations.

    public class UsageCommand
    {
        public void UsageMethod()
        {
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();
            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    public interface IReceiver
    {
        void Action();
    }

    public interface IInvoker
    {
        void SetCommand(ICommand command);
        void ExecuteCommand();
    }

    public abstract class Command : ICommand
    {
        protected IReceiver Receiver { get; private set; }

        //--- C'tor
        public Command(IReceiver receiver)
        {
            Receiver = receiver;
        }
        public abstract void Execute();
    }

    public class ConcreteCommand : Command
    {
        //--- C'tor
        public ConcreteCommand(IReceiver receiver) :
          base(receiver)
        {
        }

        public override void Execute()
        {
            Receiver.Action();
        }
    }

    public class Receiver : IReceiver
    {
        public void Action()
        {
            System.Diagnostics.Debug.WriteLine("Called Receiver.Action()");
        }
    }

    public class Invoker : IInvoker
    {
        private ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }
}

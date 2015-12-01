using System;

namespace GangOfFour.Behavioral
{
    //--- Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. 
    //--- Chain the receiving objects and pass the request along the chain until an object handles it.

    public static class UsageChainOfCommand
    {
        internal static void UsageMethod()
        {
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);
            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };
            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }
        }
    }

    public interface IHandler
    {
        void HandleRequest(int request);
    }

    public abstract class Handler : IHandler
    {
        protected IHandler Successor { get; private set; }

        public void SetSuccessor(IHandler successor)
        {
            Successor = successor;
        }

        public abstract void HandleRequest(int request);
    }

    public class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                System.Diagnostics.Debug.WriteLine("{0} handled request {1}", GetType().Name, request);
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(request);
            }
        }
    }

    public class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                System.Diagnostics.Debug.WriteLine("{0} handled request {1}", GetType().Name, request);
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(request);
            }
        }
    }

    public class ConcreteHandler3 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                System.Diagnostics.Debug.WriteLine("{0} handled request {1}", GetType().Name, request);
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(request);
            }
        }
    }
}

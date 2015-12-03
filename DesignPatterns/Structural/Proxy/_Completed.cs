using System;

namespace GangOfFour.Structural
{
    //--- Provide a surrogate or placeholder for another object to control access to it.

    public class UsageProxy
    {
        public void UsageMethod()
        {
            Proxy proxy = new Proxy();
            proxy.Request();
        }
    }

    public interface ISubject
    {
        void Request();
    }

    public class RealSubject : ISubject
    {
        public virtual void Request()
        {
            System.Diagnostics.Debug.WriteLine("Called RealSubject.Request()");
        }
    }

    public class Proxy : ISubject
    {
        private RealSubject realSubject;

        public virtual void Request()
        {
            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }
            realSubject.Request();
        }
    }
}

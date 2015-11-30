using System;

namespace GangOfFour.Structural
{
    //--- Decouple an abstraction from its implementation so that the two can vary independently.

    internal static class UsageBridge
    {
        internal static void UsageMethod()
        {
            Abstracion ab = new RefinedAbstracion();
            ab.Implementor = new ConcreteImplementorA();
            ab.DoSomething();
            ab.Implementor = new ConcreteImplementorB();
            ab.DoSomething();
        }
    }

    public class Abstracion
    {
        protected IImplementor implementor { get; private set; }

        public IImplementor Implementor
        {
            set { implementor = value; }
        }

        public virtual void DoSomething()
        {
            implementor.DoSomething();
        }
    }

    public interface IImplementor
    {
        void DoSomething();
    }

    public class RefinedAbstracion : Abstracion
    {
        public virtual void DoSomething()
        {
            implementor.DoSomething();
        }
    }

    public class ConcreteImplementorA : IImplementor
    {
        public virtual void DoSomething()
        {
            System.Diagnostics.Debug.WriteLine("ConcreteImplementorA DoSomething");
        }
    }

    public class ConcreteImplementorB : IImplementor
    {
        public virtual void DoSomething()
        {
            System.Diagnostics.Debug.WriteLine("ConcreteImplementorB DoSomething");
        }
    }
}

using System;

namespace GangOfFour.Behavioral
{
    //--- Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. 
    //--- Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.

    internal static class UsageTemplete
    {
        internal static void UsageMethod()
        {
            IAbstractClass aA = new ConcreteClassA();
            aA.TemplateMethod();
            IAbstractClass aB = new ConcreteClassB();
            aB.TemplateMethod();
        }
    }

    public interface IAbstractClass
    {
        void TemplateMethod();
        void PrimitiveOperation1();
        void PrimitiveOperation2();
    }

    public abstract class AbstractClass : IAbstractClass
    {
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();

        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            System.Diagnostics.Debug.WriteLine(string.Empty);
        }
    }

    public class ConcreteClassA : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            System.Diagnostics.Debug.WriteLine("ConcreteClassA.PrimitiveOperation1()");
        }

        public override void PrimitiveOperation2()
        {
            System.Diagnostics.Debug.WriteLine("ConcreteClassA.PrimitiveOperation2()");
        }
    }

    public class ConcreteClassB : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            System.Diagnostics.Debug.WriteLine("ConcreteClassB.PrimitiveOperation1()");
        }

        public override void PrimitiveOperation2()
        {
            System.Diagnostics.Debug.WriteLine("ConcreteClassB.PrimitiveOperation2()");
        }
    }
}

using System;

namespace GangOfFour.Creational
{
    //--- Provide an interface for creating families of related or 
    //--- dependent objects without specifying their concrete classes.

    public static class UsageAbstractFactory
    {
        internal static void UsageMethod()
        {
            IAbstractFactoryBase factory1 = new ConcreteFactory1();
            ClientClass client1 = new ClientClass(factory1);
            client1.Run();
            IAbstractFactoryBase factory2 = new ConcreteFactory2();
            ClientClass client2 = new ClientClass(factory2);
            client2.Run();
        }
    }

    public interface IAbstractFactoryBase
    {
        IAbstractProductA CreateAbstractProductA();
        IAbstractProductB CreateAbstractProductB();
    }

    public class ConcreteFactory1 : IAbstractFactoryBase
    {
        public virtual IAbstractProductA CreateAbstractProductA()
        {
            return new ConcreteProductA1();
        }

        public virtual IAbstractProductB CreateAbstractProductB()
        {
            return new ConcreteProductB1();
        }
    }

    public class ConcreteFactory2 : IAbstractFactoryBase
    {
        public virtual IAbstractProductA CreateAbstractProductA()
        {
            return new ConcreteProductA2();
        }

        public virtual IAbstractProductB CreateAbstractProductB()
        {
            return new ConcreteProductB2();
        }
    }

    public interface IAbstractProductA
    {
    }

    public interface IAbstractProductB
    {
        void Interact(IAbstractProductA a);
    }

    public class ConcreteProductA1 : IAbstractProductA
    {
    }

    public class ConcreteProductB1 : IAbstractProductB
    {
        public virtual void Interact(IAbstractProductA a)
        {
            //--- Interact with 'a'
        }
    }

    public class ConcreteProductA2 : IAbstractProductA
    {
    }

    public class ConcreteProductB2 : IAbstractProductB
    {
        public virtual void Interact(IAbstractProductA a)
        {
            //--- Interact with 'a'
        }
    }

    public class ClientClass
    {
        private readonly IAbstractProductA abstractProductA;
        private readonly IAbstractProductB abstractProductB;

        //--- C'tor
        public ClientClass(IAbstractFactoryBase factory)
        {
            abstractProductB = factory.CreateAbstractProductB();
            abstractProductA = factory.CreateAbstractProductA();
        }

        public void Run()
        {
            abstractProductB.Interact(abstractProductA);
        }
    }
}

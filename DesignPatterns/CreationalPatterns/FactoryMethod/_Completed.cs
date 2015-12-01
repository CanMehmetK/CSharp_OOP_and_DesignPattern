using System;

namespace GangOfFour.Creational
{
    //--- Define an interface for creating an object, but let subclasses decide which class to instantiate. 
    //--- Factory Method lets a class defer instantiation to subclasses.

    public static class UsageFactoryMethod
    {
        internal static void UsageMethod()
        {
            ICreator[] creators = new ICreator[2];
            creators[0] = new ConcreteCreator1();
            creators[1] = new ConcreteCreator2();
            foreach (ICreator creator in creators)
            {
                IProduct product = creator.FactoryMethod();
                System.Diagnostics.Debug.WriteLine("The type created was {0}", product.GetType().Name);
            }
        }
    }

    public interface IProduct
    {
    }

    public class ConcreteProduct1 : IProduct
    {
    }

    public class ConcreteProduct2 : IProduct
    {
    }

    public interface ICreator
    {
        IProduct FactoryMethod();
    }

    public class ConcreteCreator1 : ICreator
    {
        public virtual IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }

    public class ConcreteCreator2 : ICreator
    {
        public virtual IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }
}

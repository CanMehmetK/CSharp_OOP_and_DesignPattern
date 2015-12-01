using System;

namespace GangOfFour.Creational
{
    //--- Specify the kind of objects to create using a prototypical instance, 
    //--- and create new objects by copying this prototype.

    public static class UsagePrototype
    {
        internal static void UsageMethod()
        {
            ConcretePrototype1 originalObject1 = new ConcretePrototype1("Type 1");
            ConcretePrototype1 clonedObject1 = (ConcretePrototype1)originalObject1.Clone();
            System.Diagnostics.Debug.WriteLine("The cloned object is: {0}", clonedObject1.Id);
            ConcretePrototype2 originalObject2 = new ConcretePrototype2("Type 2");
            ConcretePrototype2 clonedObject2 = (ConcretePrototype2)originalObject2.Clone();
            System.Diagnostics.Debug.WriteLine("The cloned object is: {0}", clonedObject2.Id);
        }
    }

    public abstract class Prototype
    {
        private readonly string id;

        //--- C'tor
        public Prototype(string id)
        {
            this.id = id;
        }

        public string Id
        {
            get { return id; }
        }

        public abstract Prototype Clone();
    }

    public class ConcretePrototype1 : Prototype
    {
        //--- C'tor
        public ConcretePrototype1(string id)
          : base(id)
        {
        }

        //--- Clone using a shallow copy
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }

    public class ConcretePrototype2 : Prototype
    {
        //--- C'tor
        public ConcretePrototype2(string id)
          : base(id)
        {
        }

        //--- Clone using a shallow copy
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }
}

using System;
using System.Collections.Generic;

namespace GangOfFour.Behavioral
{
    //--- Represent an operation to be performed on the elements of an object structure. 
    //--- Visitor lets you define a new operation without changing the classes of the elements on which it operates.

    public class UsageVisitor
    {
        public void UsageMethod()
        {
            ObjectStructure o = new ObjectStructure();
            o.Attach(new ConcreteElementA());
            o.Attach(new ConcreteElementB());
            ConcreteVisitor1 visitor1 = new ConcreteVisitor1();
            ConcreteVisitor2 visitor2 = new ConcreteVisitor2();
            o.Accept(visitor1);
            o.Accept(visitor2);
        }
    }

    public interface IVisitor
    {
        void VisitConcreteElementA(ConcreteElementA concreteElementA);
        void VisitConcreteElementB(ConcreteElementB concreteElementB);
    }

    public class ConcreteVisitor1 : IVisitor
    {
        public virtual void VisitConcreteElementA(ConcreteElementA concreteElementA)
        {
            System.Diagnostics.Debug.WriteLine("{0} visited by {1}", concreteElementA.GetType().Name, GetType().Name);
        }

        public virtual void VisitConcreteElementB(ConcreteElementB concreteElementB)
        {
            System.Diagnostics.Debug.WriteLine("{0} visited by {1}", concreteElementB.GetType().Name, GetType().Name);
        }
    }

    public class ConcreteVisitor2 : IVisitor
    {
        public virtual void VisitConcreteElementA(ConcreteElementA concreteElementA)
        {
            System.Diagnostics.Debug.WriteLine("{0} visited by {1}", concreteElementA.GetType().Name, GetType().Name);
        }

        public virtual void VisitConcreteElementB(ConcreteElementB concreteElementB)
        {
            System.Diagnostics.Debug.WriteLine("{0} visited by {1}", concreteElementB.GetType().Name, GetType().Name);
        }
    }

    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    public class ConcreteElementA : IElement
    {
        public virtual void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }

        public void OperationA()
        {
        }
    }

    public class ConcreteElementB : IElement
    {
        public virtual void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }

        public void OperationB()
        {
        }
    }

    public class ObjectStructure
    {
        private readonly List<IElement> elements = new List<IElement>();

        public void Attach(IElement element)
        {
            elements.Add(element);
        }

        public void Detach(IElement element)
        {
            elements.Remove(element);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (IElement element in elements)
            {
                element.Accept(visitor);
            }
        }
    }
}

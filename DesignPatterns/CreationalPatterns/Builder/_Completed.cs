using System;
using System.Collections.Generic;

namespace GangOfFour.Creational
{
    //--- Separate the construction of a complex object from its representation 
    //--- so that the same construction process can create different representations.

    public static class UsageBuilder
    {
        internal static void UsageMethod()
        {
            Director director = new Director();
            IBuilder b1 = new ConcreteBuilder1();
            IBuilder b2 = new ConcreteBuilder2();
            //---Construct two products
              director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();
            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();
        }
    }

    public class Director
    {
        //--- IBuilder knows how to build individual parts
        public void Construct(IBuilder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }

    public interface IBuilder
    {
        void BuildPartA();
        void BuildPartB();
        Product GetResult();
    }

    public class ConcreteBuilder1 : IBuilder
    {
        private readonly Product product = new Product();

        public virtual void BuildPartA()
        {
            product.Add("PartA");
        }

        public virtual void BuildPartB()
        {
            product.Add("PartB");
        }

        public virtual Product GetResult()
        {
            return product;
        }
    }

    public class ConcreteBuilder2 : IBuilder
    {
        private readonly Product product = new Product();

        public virtual void BuildPartA()
        {
            product.Add("PartX");
        }

        public virtual void BuildPartB()
        {
            product.Add("PartY");
        }

        public virtual Product GetResult()
        {
            return product;
        }
    }

    public class Product
    {
        private readonly List<string> parts = new List<string>();

        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            //--- Parts can be enumerated here!
        }
    }
}

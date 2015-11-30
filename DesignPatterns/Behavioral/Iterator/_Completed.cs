using System;
using System.Collections.Generic;

namespace GangOfFour.Behavioral
{
    //--- Provide a way to access the elements of an aggregate object  
    //--- sequentially without exposing its underlying representation.

    internal static class UsageIterator
    {
        internal static void UsageMethod()
        {
            ConcreteAggregate a = new ConcreteAggregate();
            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";
            ConcreteIterator i = new ConcreteIterator(a);
            System.Diagnostics.Debug.WriteLine("Iterating over collection:");
            string item = i.First();
            while (item != null)
            {
                System.Diagnostics.Debug.WriteLine(item);
                item = i.Next();
            }
        }
    }

    public interface IAggregate
    {
        IIterator CreateIterator();
    }

    public class ConcreteAggregate : IAggregate
    {
        private List<string> items = new List<string>();

        public virtual IIterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Count
        {
            get { return items.Count; }
        }

        public string this[int index]
        {
            get { return items[index]; }
            set { items.Insert(index, value); }
        }
    }

    public interface IIterator
    {
        string First();
        string Next();
        bool IsDone();
        string CurrentItem();
    }

    public class ConcreteIterator : IIterator
    {
        private readonly ConcreteAggregate aggregate;
        private int current = 0;

        //--- C'tor
        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public virtual string First()
        {
            return aggregate[0];
        }

        public virtual string Next()
        {
            string ret = null;
            if (current < aggregate.Count - 1)
            {
                ret = aggregate[++current];
            }
            return ret;
        }

        public virtual string CurrentItem()
        {
            return aggregate[current];
        }

        public virtual bool IsDone()
        {
            return current >= aggregate.Count;
        }
    }
}

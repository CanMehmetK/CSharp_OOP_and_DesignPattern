using System;
using System.Collections.Generic;

namespace GangOfFour.Structural
{
    //--- Compose objects into tree structures to represent part-whole hierarchies. 
    //--- Composite lets clients treat individual objects and compositions of objects uniformly.

    internal static class UsageComposite
    {
        internal static void UsageMethod()
        {
            Composite root = new Composite("root");
            root.Add(new Leaf("Branch 1A"));
            root.Add(new Leaf("Branch 1B"));
            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Branch 2A"));
            comp.Add(new Leaf("Branch 2B"));
            root.Add(comp);
            root.Add(new Leaf("Branch C"));
            Leaf branch = new Leaf("Branch D");
            root.Add(branch);
            root.Remove(branch);
            root.Display(1);
        }
    }

    public abstract class Component
    {
        protected string name { get; private set; }

        //--- C'tor
        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }

    public class Composite : Component
    {
        private readonly List<Component> children = new List<Component>();

        //--- C'tor
        public Composite(string name)
          : base(name)
        {
        }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int depth)
        {
            System.Diagnostics.Debug.WriteLine(new String('-', depth) + name);
            foreach (Component component in children)
            {
                component.Display(depth + 2);
            }
        }
    }

    public class Leaf : Component
    {
        //--- C'tor
        public Leaf(string name)
          : base(name)
        {
        }

        public override void Add(Component c)
        {
            throw new ApplicationException("Cannot add to a branch");
        }

        public override void Remove(Component c)
        {
            throw new ApplicationException("Cannot remove from a branch");
        }

        public override void Display(int depth)
        {
            //System.Diagnostics.Debug.WriteLine(new String('-', depth) + name);
        }
    }
}

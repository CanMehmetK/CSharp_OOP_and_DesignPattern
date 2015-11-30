using System;

namespace GangOfFour.Structural
{
    //--- Provide a unified interface to a set of interfaces in a subsystem.
    //--- Façade defines a higher-level interface that makes the subsystem easier to use.

    internal static class UsageFacade
    {
        internal static void UsageMethod()
        {
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();
        }
    }

    public class SubSystemOne
    {
        public void MethodOne()
        {
            System.Diagnostics.Debug.WriteLine(" SubSystemOne Method");
        }
    }

    public class SubSystemTwo
    {
        public void MethodTwo()
        {
            System.Diagnostics.Debug.WriteLine(" SubSystemTwo Method");
        }
    }

    public class SubSystemThree
    {
        public void MethodThree()
        {
            System.Diagnostics.Debug.WriteLine(" SubSystemThree Method");
        }
    }

    public class SubSystemFour
    {
        public void MethodFour()
        {
            System.Diagnostics.Debug.WriteLine(" SubSystemFour Method");
        }
    }

    public class Facade
    {
        private readonly SubSystemOne one;
        private readonly SubSystemTwo two;
        private readonly SubSystemThree three;
        private readonly SubSystemFour four;

        public Facade()
        {
            one = new SubSystemOne();
            two = new SubSystemTwo();
            three = new SubSystemThree();
            four = new SubSystemFour();
        }

        public void MethodA()
        {
            System.Diagnostics.Debug.WriteLine(" \nMethodA() ---- ");
            one.MethodOne();
            two.MethodTwo();
            four.MethodFour();
        }

        public void MethodB()
        {
            System.Diagnostics.Debug.WriteLine(" \nMethodB() ---- ");
            two.MethodTwo();
            three.MethodThree();
        }
    }
}

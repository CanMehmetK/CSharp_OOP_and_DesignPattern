using System;
//           GangOfFour.Structural.UsageAdapter
namespace GangOfFour.Structural // UsageAdapter
{
    //--- Convert the interface of a class into another interface clients expect.
    //--- Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.

    public static class UsageAdapter
    {
        public static void UsageMethod()
        {
            Target target = new Adapter();
            target.TargetRequest();
        }
    }

    public class Target
    {
        public virtual void TargetRequest()
        {
            System.Diagnostics.Debug.WriteLine("Called Target TargetRequest()");
        }
    }

    public class Adapter : Target
    {
        private readonly Adaptee adaptee = new Adaptee();

        public override void TargetRequest()
        {
            //--- Call the AdapteeSpecificRequest to use the Adaptee's specific functionallity
            adaptee.AdapteeSpecificRequest();
        }
    }

    public class Adaptee
    {
        public void AdapteeSpecificRequest()
        {
            System.Diagnostics.Debug.WriteLine("You called AdapteeSpecificRequest()");
        }
    }
}

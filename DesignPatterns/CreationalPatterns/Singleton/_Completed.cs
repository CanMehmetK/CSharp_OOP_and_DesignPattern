using System;
using System.Diagnostics;

namespace GangOfFour.Creational
{
    //--- Ensure a class has only one instance and provide a global point of access to it.

    internal static class UsageSingleton
    {
        internal static void UsageMethod()
        {
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();
            Debug.Assert(s1 == s2);
        }
    }

    public class Singleton
    {
        private static Singleton instance;

        //--- C'tor is non public, so can't be instantiated
        protected Singleton()
        {
        }

        public static Singleton Instance()
        {
            //--- Note: Not thread safe!
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}

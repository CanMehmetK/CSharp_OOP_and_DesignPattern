using System;
using System.Collections;

namespace GangOfFour.Behavioral
{
    //--- Given a language, define a representation for its grammar along with an 
    //--- interpreter that uses the representation to interpret sentences in the language.

    internal static class UsageInterpreter
    {
        internal static void UsageMethod()
        {
            Context context = new Context();
            ArrayList list = new ArrayList();
            list.Add(new TerminalExpression());
            list.Add(new NonTerminalExpression());
            list.Add(new TerminalExpression());
            list.Add(new TerminalExpression());
            foreach (IAbstractExpression exp in list)
            {
                exp.Interpret(context);
            }
        }
    }

    public class Context
    {
    }

    public interface IAbstractExpression
    {
        void Interpret(Context context);
    }

    public class TerminalExpression : IAbstractExpression
    {
        public virtual void Interpret(Context context)
        {
            System.Diagnostics.Debug.WriteLine("Called Terminal.Interpret()");
        }
    }

    public class NonTerminalExpression : IAbstractExpression
    {
        public virtual void Interpret(Context context)
        {
            System.Diagnostics.Debug.WriteLine("Called Nonterminal.Interpret()");
        }
    }
}

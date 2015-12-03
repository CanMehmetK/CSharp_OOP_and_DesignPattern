using System;

namespace GangOfFour.Behavioral
{
    //--- Define a family of algorithms, encapsulate each one, and make them interchangeable. 
    //--- Strategy lets the algorithm vary independently from clients that use it.

    public class UsageStrategy
    {
        public void UsageMethod()
        {
            StrategyContext context;
            context = new StrategyContext(new ConcreteStrategyA());
            context.ContextInterface();
            context = new StrategyContext(new ConcreteStrategyB());
            context.ContextInterface();
            context = new StrategyContext(new ConcreteStrategyC());
            context.ContextInterface();
        }
    }

    public interface IStrategy
    {
        void AlgorithmInterface();
    }

    public class ConcreteStrategyA : IStrategy
    {
        public virtual void AlgorithmInterface()
        {
            System.Diagnostics.Debug.WriteLine("Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }

    public class ConcreteStrategyB : IStrategy
    {
        public virtual void AlgorithmInterface()
        {
            System.Diagnostics.Debug.WriteLine("Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }

    public class ConcreteStrategyC : IStrategy
    {
        public virtual void AlgorithmInterface()
        {
            System.Diagnostics.Debug.WriteLine("Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }

    public class StrategyContext
    {
        private readonly IStrategy strategy;

        //--- C'tor
        public StrategyContext(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ContextInterface()
        {
            strategy.AlgorithmInterface();
        }
    }
}

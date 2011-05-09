using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPartsFrame.Patterns.Strategy
{
    /// <summary>
    /// Context class of strategies
    /// </summary>
    internal class StrategyContext
    {
        StrategyBase strategy;

        public StrategyContext(StrategyBase defaultStrategy)
        {
            this.strategy = defaultStrategy;
        }

        public void SetStrategy(StrategyBase strategy)
        {
            this.strategy = strategy;
        }

        /// <summary>
        /// Execute current strategy
        /// </summary>
        public void Execute()
        {
            strategy.Execute();
        }
    }
}

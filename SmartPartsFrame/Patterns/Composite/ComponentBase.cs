using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SmartPartsFrame.Patterns.Composite
{
    internal abstract class ComponentBase
    {
        protected string name;

        public ComponentBase(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Add object to composition
        /// </summary>
        /// <param name="c">Another composite object</param>
        public abstract void Add(ComponentBase c);

        /// <summary>
        /// Remove object from composition
        /// </summary>
        /// <param name="c">Composite object</param>
        public abstract void Remove(ComponentBase c);

        /// <summary>
        /// Common method for composite objects
        /// </summary>
        /// <param name="depth">Depth</param>
        public abstract void Action(int depth);
    }
}

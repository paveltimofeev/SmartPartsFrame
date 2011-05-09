using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SmartPartsFrame.Patterns.Composite
{
    internal class ConcreteCompositeObject : ComponentBase
    {
        private ArrayList children = new ArrayList();

        public ConcreteCompositeObject(string name) : base(name) { ;}

        /// <summary>
        /// Add object to composition
        /// </summary>
        /// <param name="c">Another composite object</param>
        public override void Add(ComponentBase component)
        {
            children.Add(component);
        }

        /// <summary>
        /// Remove object from composition
        /// </summary>
        /// <param name="c">Composite object</param>
        public override void Remove(ComponentBase component)
        {
            children.Remove(component);
        }

        /// <summary>
        /// Common method for composite objects
        /// </summary>
        /// <param name="depth">Depth</param>
        public override void Action(int depth)
        {
            ///Implementation of action for this concrete composite object.
            Console.WriteLine(string.Format("Depth is: {0}\t Object name is: {1}", depth, name));

            ///Call actions of children composite objects.
            foreach (ComponentBase component in children)
            {
                component.Action(depth + 2);
            }
        }
    }
}

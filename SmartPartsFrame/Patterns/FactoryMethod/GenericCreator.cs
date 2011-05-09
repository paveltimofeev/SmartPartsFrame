using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPartsFrame.Patterns.FactoryMethod
{
    internal class GenericCreator<T> : FactoryMethodCreatorBase
    where T : FactoryMethodProductBase, new()
    {
        public override FactoryMethodProductBase FactoryMethod()
        {
            return new T();
        }

        public T GenericFactoryMethod()
        {
            return new T();
        }
    }
}

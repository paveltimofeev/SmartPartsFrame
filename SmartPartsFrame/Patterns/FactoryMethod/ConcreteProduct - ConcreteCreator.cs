using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPartsFrame.Patterns.FactoryMethod
{
    internal class ConcreteProduct : FactoryMethodProductBase
    {
        public string ConcreteProductName { get; private set; }

        public ConcreteProduct()
        {
            ConcreteProductName = Guid.NewGuid().ToString();
        }
    }

    internal class ConcreteCreator : FactoryMethodCreatorBase
    {
        public override FactoryMethodProductBase FactoryMethod()
        {
            return new ConcreteProduct();
        }
    }
}

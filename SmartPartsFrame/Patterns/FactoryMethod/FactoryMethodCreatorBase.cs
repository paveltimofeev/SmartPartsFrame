using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPartsFrame.Patterns.FactoryMethod
{
    internal abstract class FactoryMethodCreatorBase
    {
        public abstract FactoryMethodProductBase FactoryMethod();

        public FactoryMethodProductBase TypeFactoryMethod(Type type)
        {
            FactoryMethodProductBase obj;

            if (type.IsSubclassOf(typeof(FactoryMethodProductBase)))
                obj = (FactoryMethodProductBase)Activator.CreateInstance(type);
            else
                throw new InvalidCastException(type.FullName);

            return obj;
        }

        public T FactoryMethod<T>()
        where T : FactoryMethodProductBase, new()
        {
            return new T();
        }
    }
}

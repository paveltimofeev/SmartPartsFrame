using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPartsFrame.Patterns.Singleton
{
    internal class Singletone
    {
        private static volatile Singletone instance = null;
        private static Object syncObject = new Object();

        /// <summary>
        /// One access piont to class instance.
        /// </summary>
        public static Singletone Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (instance == null)
                    {
                        instance = new Singletone();
                    }
                    return instance;
                }
            }
        }

        private Singletone() { ;}
    }
}

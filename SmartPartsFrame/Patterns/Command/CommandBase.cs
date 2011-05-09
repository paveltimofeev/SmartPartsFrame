using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SmartPartsFrame.Patterns.Command
{
    /// <summary>
    /// Abstract command
    /// </summary>
    internal abstract class CommandBase
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }
}

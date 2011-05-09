using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SmartPartsFrame.Patterns.Command
{
    /// <summary>
    /// Concrete command
    /// Команда создающая и регистрирующая точку Point
    /// </summary>
    internal class MappingCommand : CommandBase
    {
        MappingCommandReceiver reciever;
        public Point MappingPoint { get; set; }

        public MappingCommand(MappingCommandReceiver reciever) : this(reciever, new Point(0, 0)) { ;}

        public MappingCommand(MappingCommandReceiver reciever, Point mappingPoint)
        {
            this.reciever = reciever;
            this.MappingPoint = mappingPoint;
        }

        public override void Execute()
        {
            bool result = false;
            result = reciever.MapPoint(MappingPoint);

            if (!result)
                throw new InvalidOperationException();
        }

        public override void UnExecute()
        {
            bool result = false;
            result = reciever.UnMapPoint(MappingPoint);

            if (!result)
                throw new InvalidOperationException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SmartPartsFrame.Patterns.Command
{
    /// <summary>
    /// Command receiver
    /// Получатель, регистрирует точку на карте, проверяя попадание в границы карты
    /// </summary>
    public class MappingCommandReceiver
    {
        public Rectangle MapArea { get; private set; }
        public List<Point> Points { get; private set; }

        public MappingCommandReceiver(Rectangle mapArea)
        {
            this.MapArea = mapArea;
            this.Points = new List<Point>();
        }

        public bool MapPoint(Point mappingPoint)
        {
            bool result = false;

            if (MapArea.Contains(mappingPoint))
            {
                this.Points.Add(mappingPoint);
                result = true;
            }

            return result;
        }

        public bool UnMapPoint(Point mappingPoint)
        {
            bool result = false;
            if (this.Points.Contains(mappingPoint))
            {
                this.Points.Remove(mappingPoint);
                result = true;
            }

            return result;
        }
    }
}

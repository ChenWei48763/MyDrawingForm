using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class Line
    {
        public Shape FromShape { get; set; }
        public Shape ToShape { get; set; }
        public int FromConnector { get; set; }
        public int ToConnector { get; set; }

        public Line(Shape fromShape, Shape toShape, int fromConnector, int toConnector)
        {
            FromShape = fromShape;
            ToShape = toShape;
            FromConnector = fromConnector;
            ToConnector = toConnector;
        }

        public void Draw(IGraphics graphics)
        {
            var (startX, startY) = GetConnectorCoordinates(FromShape, FromConnector);
            var (endX, endY) = GetConnectorCoordinates(ToShape, ToConnector);
            graphics.DrawLine(startX, startY, endX, endY);
        }

        public (int, int) GetConnectorCoordinates(Shape shape, int connector)
        {
            switch (connector)
            {
                case 1:
                    return (shape.X + shape.Width / 2, shape.Y);
                case 2:
                    return (shape.X, shape.Y + shape.Height / 2);
                case 3:
                    return (shape.X + shape.Width / 2, shape.Y + shape.Height);
                default:
                    return (shape.X + shape.Width, shape.Y + shape.Height / 2);
            }
        }
    }
}
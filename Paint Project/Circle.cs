using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace P_Project
{
    [Serializable]
    public class Circle : Elipse
    {
        public Circle()
        {
            counter++;
            this._value = counter;
        }


        public override void Draw(Graphics g, Point startPoint, Point endPoint, Pen pen)
        {
           int xSize = endPoint.X - startPoint.X;
            int ySize = endPoint.Y - startPoint.Y;
            int c;
            if (xSize < ySize)
                c = xSize;
            else c = ySize;
            Point NewEndPoint;
            if (xSize * ySize > 0)
            {
                NewEndPoint = startPoint + new Size(c, c);
            }
            else if (ySize < 0)
            {
                NewEndPoint = startPoint + new Size(-c, c);
            }
            else
            {
                NewEndPoint = startPoint + new Size(c, -c);
            }



            SolidBrush br = new SolidBrush(Color.Red);
            base.Draw(g, startPoint, NewEndPoint, pen);

        }
        public override bool isInside(int xP, int yP)
        {
            return Math.Sqrt((xP - StartPoint.X) * (xP - StartPoint.X) + (yP - StartPoint.Y) * (yP - StartPoint.Y)) < Radius;
        }
        ~Circle() { }

    }
}

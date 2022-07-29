using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace P_Project
{
    [Serializable]
    class Line : Figure
    {

        public Line()
        {
            counter++;
            this._value = counter;
        }


        public override bool isInside(int xP, int yP)
        {
            return Math.Abs(xP - StartPoint.X) <= EndPoint.X/ 2 && Math.Abs(yP - StartPoint.Y) <= EndPoint.Y / 2;
        }

        public override void Draw(Graphics g, Point startPoint, Point endPoint,Pen pen)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            g.DrawLine(pen, StartPoint, EndPoint);
        }

        ~Line() { }
    }
}


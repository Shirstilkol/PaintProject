using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace P_Project
{
    [Serializable]
    class Triangular : Rectangle
    {
       

        public Triangular() 
        {
            counter++;
            this._value = counter;
        }



        public override void Draw(Graphics g, Point startPoint, Point endPoint, Pen pen)
        {

            StartPoint = startPoint;
            EndPoint = endPoint;
            g.DrawPolygon(pen, new Point[]
            { new Point(startPoint.X,startPoint.Y),
            new Point(startPoint.X + ((int)Width), endPoint.Y),
            new Point(endPoint.X-(int)Width, endPoint.Y),
            new Point(endPoint.X,endPoint.Y)});


            //base.Draw(g, startPoint, endPoint, pen);//we call to rectangle draw method here.


        }
        public override bool isInside(int xP, int yP)
        {
            return Math.Abs(xP - StartPoint.X) <= Width / 2 && Math.Abs(yP - StartPoint.Y) <= Height / 2;
        }

        ~Triangular() { }
    }
    
}


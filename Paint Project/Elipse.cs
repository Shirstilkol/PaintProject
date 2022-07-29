using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace P_Project
{
    public class Elipse : Figure
    {
        private float radius;


        public Elipse() 
        {
            counter++;
            this._value = counter;
        }

        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public override void Draw(Graphics g, Point startPoint, Point endPoint, Pen pen)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            radius = Math.Abs(startPoint.X - endPoint.Y);
            SolidBrush br = new SolidBrush(Color.White);
            Pen linePen = new Pen(pen.Color);
            int rectHeight = endPoint.Y - startPoint.Y;
            int rectWidth = endPoint.X - startPoint.X;

            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(startPoint,new Size(rectWidth, rectHeight));
            g.FillEllipse(br, rect);
            g.DrawEllipse(pen, rect);
           
        }
        public override bool isInside(int xP, int yP)
        {
            return Math.Sqrt((xP - StartPoint.X) * (xP - StartPoint.X) + (yP - StartPoint.Y) * (yP - StartPoint.Y)) < Radius;
        }

        ~Elipse() { }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace P_Project
{
    [Serializable]
    public class Rectangle : Figure
    {
        protected float width;
        protected float height;
       
        public Rectangle()
        {
            counter++;
            this._value = counter;
        }
        

        //Properties
        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        public float Height
        {
            get { return height; }
            set { height = value; }
        }

        public override bool isInside(int xP, int yP)
        {
            bool isInside = xP >= StartPoint.X && xP <= EndPoint.X && yP>=StartPoint.Y && yP <= EndPoint.Y;
            return isInside;
        }

        public override void Draw(Graphics g, Point startPoint, Point endPoint, Pen pen)
        {
            SetStartAndEndingPoints(startPoint, endPoint);
            Width = endPoint.X - startPoint.X;
            Height = endPoint.Y - startPoint.Y;
            SolidBrush br = new SolidBrush(Color.White);
            Pen linePen = new Pen(pen.Color);

            if (Width > 0 && height <0)
                SetStartAndEndingPoints(startPoint+new Size(0, (int)Height), endPoint-new Size(0,(int)Height));

            if(width<0 && height>0)
                SetStartAndEndingPoints(startPoint + new Size((int)Width,0), endPoint - new Size((int)Width, 0));

            if (width < 0 && height < 0)
                SetStartAndEndingPoints(endPoint,startPoint);

            Width = Math.Abs(Width);
            Height = Math.Abs(Height);
            g.FillRectangle(br, StartPoint.X, StartPoint.Y, Width, Height);
            g.DrawRectangle(pen, StartPoint.X, StartPoint.Y, Width, Height);
        }

        ~Rectangle() { }
    }
}

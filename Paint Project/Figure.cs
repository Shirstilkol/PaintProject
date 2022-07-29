using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace P_Project
{
    [Serializable]//To enable data retention and recovery
    public abstract class Figure
    {
        static protected int counter = 0;
        protected int _value;
        Point startPoint;
        Point endPoint;
       



        public Point StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }

        public Point EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        protected void SetStartAndEndingPoints(Point ExternalStartPoint, Point ExternalEndPoint)
        {
            startPoint = ExternalStartPoint;
            endPoint = ExternalEndPoint;
        }

        // abstract method to draw the figure 
        public abstract void Draw(Graphics g, Point startPoint, Point endPoint, Pen pen);
        public abstract bool isInside(int xP, int yP);
    }
}

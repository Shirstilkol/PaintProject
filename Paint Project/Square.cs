using System;
using System.Drawing;


namespace P_Project
{
    [Serializable]
    class Square : Rectangle
    {
        int edgeSize;
        public Square() 
        {
            counter++;
            this._value = counter;
        }

        public override void Draw(Graphics g, Point startPoint, Point endPoint, Pen pen)
        {
            int xSize = (int)Math.Pow(endPoint.X - startPoint.X, 2);
            int ySize = (int)Math.Pow(endPoint.Y - startPoint.Y, 2);
            edgeSize = (int)Math.Sqrt(xSize + ySize);

            Point squareEndPoint;
            if (startPoint.X > endPoint.X && startPoint.Y > endPoint.Y)
            {
                squareEndPoint = new Point(startPoint.X - edgeSize, startPoint.Y - edgeSize);

            }
            else if (startPoint.X < endPoint.X && startPoint.Y < endPoint.Y)
            {
                squareEndPoint = new Point(startPoint.X + edgeSize, startPoint.Y + edgeSize);

            }
            else if (startPoint.X > endPoint.X && startPoint.Y < endPoint.Y)
            {
                squareEndPoint = new Point(startPoint.X - edgeSize, startPoint.Y + edgeSize);
            }
            else
            {
                squareEndPoint = new Point(startPoint.X + edgeSize, startPoint.Y - edgeSize);

            }
            base.Draw(g, startPoint, squareEndPoint, pen);//we call to rectangle draw method here.
        }

        //we dont have is inside here, becuase its the same as rectangle

        ~Square() { }
    }
}






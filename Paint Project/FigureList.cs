using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;
namespace P_Project
{
    [Serializable]
    class FigureList
    {
        private SortedList figures;
   

        public FigureList()
        {
            figures = new SortedList();// create new elements
        }

        public int Count
        {
            get
            {
                return figures.Count; // Gets the number of elements contained in the SortedList
            }
        }
        public Figure this[int index]// how many kids
        {
            get
            {
                if (index >= figures.Count || index < 0)
                    return (Figure)null;
                return (Figure)figures.GetByIndex(index);
            }
            set
            {
                if (index <= figures.Count && index >= 0)
                    figures[index] = value;
            }
        }
        public void remove_all()
        {
            figures.Clear();
        }
        public void ADD(Figure e)
        {
            figures.Add(figures.Count, e);

        }
        public void Remove(int element)
        {
            if (element >= 0 && element < figures.Count)
            {
                figures.RemoveAt(figures.Count - 1);
            }
        }
        public void DrawAll(Graphics g, Point startPoint, Point endPoint, Pen pen)
        {


            for (int i = 0; i < figures.Count; i++)
                ((Figure)figures[i]).Draw(g, startPoint, endPoint, pen);
        }
    


    }
}

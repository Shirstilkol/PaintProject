using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace P_Project
{

    public partial class Form1 : Form
    {
        Graphics g;
        

        
       
        FigureList removed = new FigureList();
        FigureList figureRedoList = new FigureList();

        //  Boot variables
        int startX = -1;
        int startY = -1;

        int moveX = -1;
        int moveY = -1;
        bool isMouseDown;
        Pen pen;
        Pen eraser;

        Figure fig;
        int index = -1;//-1 = none.
        FigureList pts = new FigureList();
 


        public Form1()
        {
            //Set colors and eraser
            InitializeComponent();
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pen = new Pen(Color.Black, 5);
            eraser = new Pen(Color.White, 15);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            eraser.StartCap = eraser.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //to show starting color on start (black)
            pictureBox1.BackColor = Color.Black;


        }

        private void Button1_Click(object sender, EventArgs e)
        {//Color Palette
            Button p = (Button)sender;
            pen.Color = p.BackColor;
            pictureBox1.BackColor = p.BackColor;//We have set up here the screen that shows the colors
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;

            startX = e.X;
            startY = e.Y;
            moveX = e.X;
            moveY = e.Y;

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //preview
            if (isMouseDown)//to draw in MouseMove we need MouseDown==True
            {
                DecideMovingActionById(e.Location);
                moveX = e.X;
                moveY = e.Y;

                if (index > 0)
                {
                    panel1.Cursor = Cursors.Cross;


                }
            }


        }

        private void DecideMovingActionById(Point point)//a function that draws by changing cases
        {
            switch (index)
            {
                case 1:
                    g.DrawLine(pen, new Point(moveX, moveY), point);
                    break;
                case 2:
                    g.DrawLine(eraser, new Point(moveX, moveY), point);
                    break;
                case 3:
                case 4:
                case 6:
                    //  fig.Draw(g, new Point(startX, startY), point,pen); // we need to show preview and not draw.
                    break;
                case -1:
                default:
                    break;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;

            panel1.Cursor = Cursors.Default;

            DecideMouseUpActionById(new Point(moveX, moveY));


            startX = -1;
            startY = -1;
        }

        private void DecideMouseUpActionById(Point point)
        {
            switch (index)
            {
                case 3://line
                case 4://rect
                case 6://eclipse
                case 7://circle
                case 10://Triangular

                    fig.Draw(g, new Point(startX, startY), point, pen);
                    pts.ADD(fig);//add figure to list figure

                    break;
                case 8:
                    

                    break;
                case -1:
                default:
                    break;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            index = 3;//Line
            fig = new Line();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index = 4;//Rectangle
            fig = new Rectangle();

            


        }

        //make pen width bigger
        private void button26_Click(object sender, EventArgs e)
        {
            if (pen.Width < 48)
            {
                pen.Width += 2;
                eraser.Width = pen.Width;
                textBox1.Text = pen.Width.ToString();//ToString Converts Stuff to string
            }

        }

        //make pen width smaller
        private void button25_Click(object sender, EventArgs e)
        {
            if (pen.Width > 2)
            {
                pen.Width -= 2;
                eraser.Width = pen.Width;
                textBox1.Text = pen.Width.ToString();//ToString Converts Stuff to string
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {//
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();//From which director he will upload
            saveFileDialog1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.*";//File type
            saveFileDialog1.FilterIndex = 1;//When you go up you will see the first one
            saveFileDialog1.RestoreDirectory = true;//When we are done he will restore the folder that was previously active
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)//model Dialog: when displayed on the screen you can not return to the app that ordered it, you need to close it and only then we can return to the app
            {//Thanks to getting OK in the dialog we will get the file name (string) and where we want to save it
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {

                    formatter.Serialize(stream, pts);
                }

            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            this.Close();

        }




        //Pen Button
        private void button32_Click(object sender, EventArgs e)
        {
            index = 1;//pen index
        }


        private void button33_Click(object sender, EventArgs e)
        {
            index = 2;//eraser
            Button p = (Button)sender;
        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            index = 6;//Elipse
            fig = new Elipse();

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            index = 7;//Circle
            fig = new Circle();

            
        }

        private void button30_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();  //From which director he will upload
            openFileDialog1.Filter = "model files (.mdl)|.mdl|All files (.)|.";  //File type
            openFileDialog1.FilterIndex = 1;//When you go up you will see the first one
            openFileDialog1.RestoreDirectory = true;//When we are done he will restore the folder that was previously active
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//model Dialog: when displayed on the screen you can not return to the app that ordered it,
                                                                //you need to close it and only then we can return to the app
            {
                Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                pts = (FigureList)binaryFormatter.Deserialize(stream);//Deserialize-from the file into the information, we do casting to pts
                button6.Invalidate();                                            // invalidate- that he came out again
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);//Clean the board by setting white paint 



        }


       

        

        private void btn_move_Click(object sender, EventArgs e)
        {
            index = 9;
        }

        private void btn_eraser_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            index = 10;
            fig = new Triangular();

            
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;

                pen.Color = colorDialog1.Color;
                pictureBox1.BackColor = colorDialog1.Color;
            }

        }

    }



}


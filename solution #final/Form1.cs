using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using drawingApp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Csharp_project_Hagasha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Width = 900;
            this.Height = 700;
            bm = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            Pencil.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
            Pencil.Width = Convert.ToInt32(numericUpDown1.Value);
            pictureBox2.Image = bm;
           
        }

        square s = new square(50);
        rectangle r = new rectangle(100, 50);
        circle c = new circle(20);
        equalRibbedTriangle t = new equalRibbedTriangle(50);
        makbilit m = new makbilit(50, 150, 20);
        meuyan me = new meuyan();
        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        Pen Pencil = new Pen(Color.Black, 3);
        Pen Brush = new Pen(Color.DodgerBlue, 10);
        Pen erase = new Pen(Color.White, 20);
        int index;
        ColorDialog cd = new ColorDialog();
        Color new_color;
        FigureList pts = new FigureList();
        int i = 0;





        //__________________________________________________________


        // Mouse event functions:

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;
            if (index == 4) // Draw Square:
            {
                s.Draw(g , Pencil , e.X, e.Y);
                pts[pts.NextIndex] =new square(s);
                
            }
            if (index == 5) // Draw rectangle:
            {
                r.Draw(g, Pencil, e.X, e.Y);
                pts[pts.NextIndex] = new rectangle(r);
            }
            if (index == 6) // Draw circle:
            {
                c.Draw(g, Pencil, e.X, e.Y);
                pts[pts.NextIndex] = new circle(c);
            }
            if (index == 7) // Draw triangle:
            {
                t.Draw(g, Pencil, e.X, e.Y);
                pts[pts.NextIndex] = new equalRibbedTriangle(t);
            }
            if (index == 8) // Draw makbilit:
            {
                m.Draw(g, Pencil, e.X, e.Y);
                pts[pts.NextIndex] = new makbilit(m);
            }
            if (index == 9) // Draw meuyan:
            {
                me.Draw(g, Pencil, e.X, e.Y);
                pts[pts.NextIndex] = new meuyan(me);
            }
            pictureBox2.Refresh();
        }
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                if (index==1) // Pen:
                {
                    px = e.Location;
                    g.DrawLine(Pencil, px, py);
                    py = px;
                }
                if (index==2) // Eeaser:
                {
                    px = e.Location;
                    g.DrawLine(erase, px, py);
                    py = px;
                }
                if (index==3) // Brush:
                {
                    px = e.Location;
                    g.DrawLine(Brush, px, py);
                    py = px;
                }

                pictureBox2.Refresh();
            }
        }
        
        //_________________________________________________________

        // Buttons:

        private void pencil_Click(object sender, EventArgs e)
        {
            index = 1; // if pencil is pressed it activates the 
            // pictureBox1_MouseMove functios and draws line;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void myEraser_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            index = 3;
        }

        private void DrawSquarePicBox_Click(object sender, EventArgs e)
        {
            index = 4;
        }

        private void DrawRectanglePicBox_Click(object sender, EventArgs e)
        {
            index = 5;
        }

        private void DrawCirclePicBox_Click(object sender, EventArgs e)
        {
            index = 6;
        }

        private void DrawTrianglePicBox_Click(object sender, EventArgs e)
        {
            index = 7;
        }

        private void DrawMakbilitPicBox_Click(object sender, EventArgs e)
        {
            index = 8;
        }

        private void DrawMeuyanPicBox_Click(object sender, EventArgs e)
        {
            index = 9;
        }

        private void fill_btn_Click(object sender, EventArgs e)
        {
            index = 10;
        }

        // Pick new color for all Pens and Shapes:
        private void pic_color_Click(object sender, EventArgs e)
        {
            cd.ShowDialog();
            new_color = cd.Color;
            pic_color.BackColor = cd.Color;
            Pencil.Color = cd.Color;
            Brush.Color = cd.Color;
        }

        // Pencil width change:
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(numericUpDown1.Value);
            Pencil.Width = value;
        } 

        // Eraser width change:
        private void erase_numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(erase_numericUpDown2.Value);
            erase.Width = value;
        } 

        // Brush width change:
        private void brush_numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(brush_numericUpDown3.Value);
            Brush.Width = value;
        } 

        // Filling shapes with paint click:
        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        { 
            if (index == 10) 
            {
                Point point = set_point(pictureBox2, e.Location);
                Fill(bm, point.X, point.Y, new_color);
                pictureBox2.Refresh();
            }
        }

        // Saving .jpg files:
        private void Save_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.InitialDirectory = Directory.GetCurrentDirectory();
            sfd.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap btm = bm.Clone(new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height), bm.PixelFormat);
                btm.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        // Loading .jpg files:
        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Browse jpg Files";
            openFileDialog1.DefaultExt = "jpg";
            openFileDialog1.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               bm =(Bitmap)Image.FromFile(openFileDialog1.FileName);
               g = Graphics.FromImage(bm);
               pictureBox2.Image = bm;
               pictureBox2.Height = bm.Height;
               pictureBox2.Width = bm.Width;
            }
        }

        // Saving object with serialization:
        private void Save_ser_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\myModels";
            saveFileDialog1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //!!!!
                    formatter.Serialize(stream, pts);
                }
            }
        }

        // Loading serialized object:
        private void Load_ser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\myModels";
            openFileDialog1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                //!!!!
                pts = (FigureList)binaryFormatter.Deserialize(stream);
                for(int i = 0; i < pts.NextIndex; i++)
                {
                    pts[i].Draw(g, Pencil, pts[i].X, pts[i].Y);
                }
                pictureBox2.Invalidate();
            }
        }

        // Clearing the board function:
        private void clear_btn_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox2.Image = bm;
            index = 0;
        }

        // switching colors by picture function:
        private void all_colors_pic_MouseClick(object sender, MouseEventArgs e)
        { 
            Point point = set_point(all_colors_pic, e.Location);
            pic_color.BackColor = ((Bitmap)all_colors_pic.Image).GetPixel(point.X, point.Y);
            new_color = pic_color.BackColor;
            Pencil.Color = pic_color.BackColor;
            Brush.Color = pic_color.BackColor;
        }


        //______________________________________________________________

        // functions:
        static Point set_point(PictureBox pb, Point pt)
        {
            float pX = 1f * pb.Image.Width / pb.Width;
            float pY = 1f * pb.Image.Height / pb.Height;
            return new Point((int)(pt.X * pX), (int)(pt.Y * pY));
        }

        private void validate(Bitmap bm, Stack<Point> sp, int x, int y, Color old_color, Color new_color)
        {
            Color cx = bm.GetPixel(x, y);
            if (cx == old_color)
            {
                sp.Push(new Point(x, y));
                bm.SetPixel(x, y, new_color);
            }
        }

        private void all_colors_pic_Click(object sender, EventArgs e)
        {

        }

        private void Fill(Bitmap bm, int x, int y, Color new_clr)
        {
            Color old_color = bm.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            bm.SetPixel(x, y, new_clr);
            if (old_color == new_clr)
            { return; }

            while (pixel.Count > 0)
            {
                Point pt = (Point)pixel.Pop();
                if (pt.X > 0 && pt.Y > 0 && pt.X < bm.Width - 1 && pt.Y < bm.Height - 1)
                {
                    validate(bm, pixel, pt.X - 1, pt.Y, old_color, new_clr);
                    validate(bm, pixel, pt.X, pt.Y - 1, old_color, new_clr);
                    validate(bm, pixel, pt.X + 1, pt.Y, old_color, new_clr);
                    validate(bm, pixel, pt.X, pt.Y + 1, old_color, new_clr);
                }
            }
        }



        //__________________________________________________________________
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperMario
{
    public partial class Form1 : Form
    {
        bool up = false, down = false;
        public Form1()
        {
            
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
        char key, keyup;
        int poch;
        static Bitmap bm = new Bitmap(4914, 460);

        Bitmap bm1 = new Bitmap("фон.PNG");
        Bitmap bm2 = new Bitmap("фон1.PNG");
        Bitmap bm3 = new Bitmap("фон2.PNG");
        Bitmap bm4 = new Bitmap("фон3.PNG");
        Bitmap bm5 = new Bitmap("фон4.PNG");
        Bitmap bm6 = new Bitmap("фон5.PNG");
        Bitmap bm7 = new Bitmap("777.PNG");
        Graphics g = Graphics.FromImage(bm);
        

        static Size size = new Size(819,460);
        Bitmap b = new Bitmap(819,460);
        Bitmap mario = new Bitmap("right.PNG");
        Rectangle r = new Rectangle(0, 0, 819, 460);
        
        int x=0,y=350;
        private void Form1_Load(object sender, EventArgs e)
        {
            
            g.DrawImage(bm1, 0, 0, 819,460);
            g.DrawImage(bm2, 819, 0, 819, 460);
            g.DrawImage(bm3, 1638, 0, 819, 460);
            g.DrawImage(bm4, 2457, 0, 819, 460);
            g.DrawImage(bm5, 3276, 0, 819, 460);
            g.DrawImage(bm6, 4095, 0, 819, 460);
            g.DrawImageUnscaled(bm7, 500, 300, 200, 200);
            g.Dispose();
        }

       

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                mario = new Bitmap("right.PNG");
                key = (char)e.KeyValue;
                Refresh();
            }

            if (e.KeyCode == Keys.Left)
            {
                mario = new Bitmap("left.PNG");
                key = (char)e.KeyValue;
                Refresh();
            }

           if (e.KeyCode == Keys.Up && !down && !up)
           {
               poch = y;
               keyup = (char)e.KeyValue;
               timer3.Enabled = true;
           }

           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                r = new Rectangle(x, 0, 800, 460);
                b = bm.Clone(r, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            }
            catch { }
                e.Graphics.DrawImage(b, new Point(0, 0));
                e.Graphics.DrawImage(mario, new Point(80, y));
            
        }

       private void timer3_Tick(object sender, EventArgs e)
        {
           if (keyup == (char)Keys.Up) // Вверх
            for(int i=0; i<5;i++)   
                if (y >= poch - 200 && bm.GetPixel(x + 80 + 30, y).Name != "ff000000")
                {
                    y --;
                    up = true;
                }
                else
                {
                    keyup = (char)0;
                    up = false;
                    break;
                }



            for (int i = 0; i < 7; i++) // Вниз
                if (((bm.GetPixel(x + 82, y + 87).Name != "ff000000") && (bm.GetPixel(x + 81 + 62, y + 87).Name != "ff000000"))
                    && y <= 350 && !up)
                {
                    y++;
                    down = true;
                }
                else
                {
                    down = false;
                    break;
                }


            for (int i = 0; i < 5; i++) // Вправо


                if (key == (char)Keys.Right && x < 4700 && bm.GetPixel(x + 81 + 65, y + 85).Name != "ff000000")
                {
                    x++;
                }
                else
                   break;
            


            for (int i = 0; i < 5; i++) // Вліво
                if (key == (char)Keys.Left && x > 0 && bm.GetPixel(x + 81, y + 85).Name != "ff000000")
                    x--;
                else break;
           
            Refresh();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                key = (char)0;
            }
        }
 
    }
}

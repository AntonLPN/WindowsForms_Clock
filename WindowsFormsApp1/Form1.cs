using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
       private Graphics g;
       private Pen MyPenMinutes;
       private Pen MyPenHour;


       private   float x2;
       private float x3;
       private float x4;
       private float y2;
       private float y3;
       private float y4;
       private int fi;
       private int fm ;
       private int fh;
       private int r;
       private int counter;
       private  int counter1;
        public Form1()
        {
            InitializeComponent();
           
            MyPenMinutes = new Pen(Color.Green, 2);
            MyPenHour = new Pen(Color.Black, 5);
           
            x2 = 175;
            x3 = 175;
            x4 = 175;
            y2 = 50;
            y3 = 80;
            y4 = 100;

            fi = -90;
            fm = -90;
            fh = -90;
            r = 125;

            counter = 0;
            counter1 = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
            timer1.Tick += Timer1_Tick;


            int i = 0;
            while (i < DateTime.Now.Second)
            {
                fi += 6;
                float cosFi = (float)Math.Cos(((Math.PI * fi) / 180));
                float sinFi = (float)Math.Sin(((Math.PI * fi) / 180));
                counter++;

                x2 = 175 + r * cosFi;
                y2 = 175 + r * sinFi;
                i++;
            }
            i = 0;
            while (i < DateTime.Now.Minute)
            {
                fm += 6;

                float cosFimin = (float)Math.Cos(((Math.PI * fm) / 180));
                float sinFimin = (float)Math.Sin(((Math.PI * fm) / 180));

                x3 = 175 + 95 * cosFimin;
                y3 = 175 + 95 * sinFimin;
                counter1++;
                i++;
            }
            i = 0;
            while (i < DateTime.Now.Hour)
            {
                fh += 30;
                float cosFihour = (float)Math.Cos(((Math.PI * fh) / 180));
                float sinFihour = (float)Math.Sin(((Math.PI * fh) / 180));

                x4 = 175 + 75 * cosFihour;
                y4 = 175 + 75 * sinFihour;
                i++;
            }
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            fi += 6;

            float cosFi = (float)Math.Cos(((Math.PI * fi) / 180));
            float sinFi = (float)Math.Sin(((Math.PI * fi) / 180));

            counter++;

            x2 = 175 + r * cosFi;
            y2 = 175 + r * sinFi;
            if (counter == 60)
            {
                fm += 6;

                float cosFimin = (float)Math.Cos(((Math.PI * fm) / 180));
                float sinFimin = (float)Math.Sin(((Math.PI * fm) / 180));

                x3 = 175 + 95 * cosFimin;
                y3 = 175 + 95 * sinFimin;
                counter1++;

                counter = 0;
            }
            if (counter1 == 60)
            {
                fh += 30;
                float cosFihour = (float)Math.Cos(((Math.PI * fh) / 180));
                float sinFihour = (float)Math.Sin(((Math.PI * fh) / 180));

                x4 = 175 + 75 * cosFihour;
                y4 = 175 + 75 * sinFihour;

                counter1 = 0;
            }

            this.Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new Pen(Color.BurlyWood,8), 50, 50, 250, 250);//круг часов
            e.Graphics.DrawLine(Pens.Red, 175, 175, x2, y2);//секундная стрелка
            e.Graphics.DrawLine(MyPenMinutes, 175, 175, x3, y3);
            e.Graphics.DrawLine(MyPenHour, 175, 175, x4, y4);
        }
    }
}

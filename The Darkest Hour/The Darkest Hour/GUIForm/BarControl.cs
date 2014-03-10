using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using The_Darkest_Hour;

namespace The_Darkest_Hour.GUIForm
{
    public class BarControl
    {    
        public BarControl(int LocX, int LocY, int width, int height, bool stat, int maxstat, int currentstat)
            {
                
                this.BarRect = new Rectangle(LocX, LocY, width, height);
                this.fillpercentage = (int)currentstat / maxstat;
                this.FillRect = new Rectangle(LocX, LocY, ((int)(width * fillpercentage)), height);
            if (stat)
            { BarBrush = new SolidBrush(Color.Red);
            BarPen = new Pen(Color.Red);}
            else
            {{ BarBrush = new SolidBrush(Color.Blue);
            BarPen = new Pen(Color.Blue);}}

           
           }
        public void Draw(Graphics g)
        {
            g.FillRectangle(BarBrush, FillRect);
            g.DrawRectangle(Pens.Black, BarRect);
            g.DrawRectangle(BarPen, FillRect);
        }


        private Brush BarBrush;
        private Pen BarPen;
        private Rectangle BarRect;
        private Rectangle FillRect;
        double fillpercentage;
        
    }
}

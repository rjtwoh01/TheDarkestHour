using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using The_Darkest_Hour;
using The_Darkest_Hour.Characters;




namespace The_Darkest_Hour.GUIForm
{
    public partial class DarkestHourWindow : Form
    {
        public DarkestHourWindow()
        {
            InitializeComponent();
            
            //SetInfo();
            Bargraphics = BarBox.CreateGraphics();
            //SetBarInfo(Bargraphics);
        }
        private void SetInfo()
        {
            MainGame game = new MainGame();
            //NameLabel.Text = GameState.Hero.Identifier;
            //ClassLabel.Text = GameState.Hero.Profession.Name;
        }
        //Next step is to pull info from game into message feed
        //Followed by replacing 90+% of in game controls with buttons
        //Then replace all info shown in feed (ie monster health and player health) with appropriate UI controls.
        //finally move combat feed to a separate label allowing the main feed to be filled with game info(story, descriptions,objectives, etc)
        //After that we make the game window completely independent of the console.
        private void SetBarInfo(Graphics g)
        {
            
            int DrawX = 60;
            int HealthDrawY = 10;
            int EnergyDrawY = 30;
            string HealthString = "Health: " + GameState.Hero.health.ToString() + " / " + GameState.Hero.maxHealth.ToString();
            string EnergyString = "Energy: " + GameState.Hero.energy.ToString() + " / " + GameState.Hero.maxEnergy.ToString();
            HealthBar = new BarControl(DrawX, HealthDrawY, 100, 20, true, GameState.Hero.maxHealth, GameState.Hero.health);
            EnergyBar = new BarControl(DrawX, EnergyDrawY, 100, 20, false, GameState.Hero.maxEnergy, GameState.Hero.energy);
            HealthBar.Draw(g);
            EnergyBar.Draw(g);
            g.DrawString(HealthString, stringfont, fontbrush, 0, 10);
            g.DrawString(EnergyString, stringfont, fontbrush, 0, 30);
        }
        private void UpdateBars(Graphics g)
        {
            HealthBar.Draw(g);
            EnergyBar.Draw(g);
        }
        //public static string ReadLine();
        private void CommandsBox_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                MessageFeed.Text = MessageFeed.Text+  Environment.NewLine + CommandsBox.Text;
            }
            SetInfo();
            //SetBarInfo(Bargraphics);
        }
        public static void WriteLine() {MessageFeed.Text = MessageFeed.Text + Environment.NewLine;}
        public static void WriteLine(bool value) { MessageFeed.Text = MessageFeed.Text + Environment.NewLine + value.ToString(); }
        public static void WriteLine(char value) { MessageFeed.Text = MessageFeed.Text + Environment.NewLine + value.ToString(); }
        public static void WriteLine(char[] buffer) { MessageFeed.Text = MessageFeed.Text + Environment.NewLine + buffer.ToString(); }
        public static void WriteLine(decimal value) { MessageFeed.Text = MessageFeed.Text + Environment.NewLine + value.ToString(); }
        public static void WriteLine(double value) { MessageFeed.Text = MessageFeed.Text + Environment.NewLine + value.ToString(); }
        public static void WriteLine(float value) { MessageFeed.Text = MessageFeed.Text + Environment.NewLine + value.ToString(); }
        public static void WriteLine(int value) { MessageFeed.Text = MessageFeed.Text + Environment.NewLine + value.ToString(); }
        public static void WriteLine(long value) { MessageFeed.Text = MessageFeed.Text + Environment.NewLine + value.ToString(); }
        public static void WriteLine(object value) { MessageFeed.Text = MessageFeed.Text + Environment.NewLine + value.ToString(); }
        public static void WriteLine(string value) { MessageFeed.Text = MessageFeed.Text + Environment.NewLine + value.ToString(); }

        public static void WriteLine(uint value) { MessageFeed.Text = MessageFeed.Text + Environment.NewLine + value.ToString(); }

        public static void WriteLine(ulong value) { MessageFeed.Text = MessageFeed.Text + Environment.NewLine + value.ToString(); }
        public static void WriteLine(string format, object arg0) { MessageFeed.Text += Environment.NewLine + String.Format(format, arg0); }
        public static void WriteLine(string format, params object[] arg) { MessageFeed.Text += Environment.NewLine + String.Format(format, arg); }
        public static void Clear() { MessageFeed.Text = ""; }
        //public void WriteLine(char[] buffer, int index, int count);
        //public void WriteLine(string format, object arg0, object arg1);
        //public void WriteLine(string format, object arg0, object arg1, object arg2);
        //[CLSCompliant(false)]
        //public void WriteLine(string format, object arg0, object arg1, object arg2, object arg3);

        BarControl HealthBar;
        BarControl EnergyBar;
        Graphics Bargraphics;
        Font stringfont = new Font("Terminal", 12);
        Brush fontbrush = Brushes.Black;
        //private void DrawInfo(Graphics HeroInformationBox)
        //{
        //    int DrawX = HeroInformationBox.x;

        //    BarControl HealthBar = new BarControl();

        //}
        
    }
}

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
            SetInfo();
            Bargraphics = BarBox.CreateGraphics();
            SetBarInfo(Bargraphics);
        }
        private void SetInfo()
        {
            NameLabel.Text = GameState.Hero.Identifier;
            ClassLabel.Text = GameState.Hero.Profession.Name;
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
        private void CommandsBox_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                MessageFeed.Text = MessageFeed.Text+  Environment.NewLine + CommandsBox.Text;
            }
            SetBarInfo(Bargraphics);
        }
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

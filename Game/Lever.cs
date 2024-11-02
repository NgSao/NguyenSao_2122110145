using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{

    public partial class Lever : Form
    {
        private string selectedShip = "Ship1";
        private string selectedWeapon = "Weapon1";
        public Lever()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameKho gamePlay = new GameKho(selectedShip, selectedWeapon);
            this.Hide();
            gamePlay.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChonVuKhi gamePlay1 = new ChonVuKhi();
            this.Hide();
            gamePlay1.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GameMenu gamePlay = new GameMenu();
            this.Hide();
            gamePlay.ShowDialog();
            this.Close();
        }
    }
}

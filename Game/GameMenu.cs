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
    public partial class GameMenu : Form
    {
        public GameMenu()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Lever gamePlay = new Lever(); 
            this.Hide();
            gamePlay.ShowDialog(); 
            this.Close(); 

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void GameMenu_Load(object sender, EventArgs e)
        {

        }
    }
}

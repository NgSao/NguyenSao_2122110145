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
    public partial class InTro : Form
    {
        public InTro()
        {
            InitializeComponent();
            
            this.Opacity = 0;
     
        }

        private void InTro_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Opacity<100)
            {
                Opacity += 0.05;
                progressBar1.Increment(2);
            }
            if(progressBar1.Value==100)
            {
                timer1.Stop();
                this.Hide();

                GameMenu optoon = new GameMenu(); 
                optoon.ShowDialog();

                this.Close();
            }

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}

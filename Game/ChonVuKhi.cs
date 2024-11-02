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
    public partial class ChonVuKhi : Form
    {
        private string selectedShip = null;
        private string selectedWeapon = null;
        public ChonVuKhi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedShip != null && selectedWeapon != null)
            {
                GameKho gamePlay1 = new GameKho(selectedShip, selectedWeapon);
                this.Hide();
                this.Close();
                gamePlay1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chiến hạm và đạn để bắt đầu trò chơi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ChonVuKhi_Load(object sender, EventArgs e)
        {
            picturePlayer1.Image = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\game.png");
            picturePlayer2.Image = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\play1.png");
            picturePlayer3.Image = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\play2.png");

            pictureDan2.Image = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\dany.png");
            pictureDan3.Image = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\play3.png");
            pictureDan1.Image = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\tl4.png");

        }

        private void picturePlayer1_Click(object sender, EventArgs e)
        {
            selectedShip = "Ship1";
            picturePlayer1.BorderStyle = BorderStyle.FixedSingle;
            picturePlayer2.BorderStyle = BorderStyle.None;
            picturePlayer3.BorderStyle = BorderStyle.None;

        }

        private void picturePlayer2_Click(object sender, EventArgs e)
        {
            selectedShip = "Ship2";
            picturePlayer2.BorderStyle = BorderStyle.FixedSingle;
            picturePlayer1.BorderStyle = BorderStyle.None;
            picturePlayer3.BorderStyle = BorderStyle.None;
        }

        private void picturePlayer3_Click(object sender, EventArgs e)
        {
            selectedShip = "Ship3";
            picturePlayer3.BorderStyle = BorderStyle.FixedSingle;
            picturePlayer1.BorderStyle = BorderStyle.None;
            picturePlayer2.BorderStyle = BorderStyle.None;
        }

        private void pictureDan1_Click(object sender, EventArgs e)
        {
            selectedWeapon = "Weapon1";
            pictureDan1.BorderStyle = BorderStyle.FixedSingle;
            pictureDan2.BorderStyle = BorderStyle.None;
            pictureDan3.BorderStyle = BorderStyle.None;
        }

        private void pictureDan2_Click(object sender, EventArgs e)
        {
            selectedWeapon = "Weapon2";
            pictureDan2.BorderStyle = BorderStyle.FixedSingle;
            pictureDan1.BorderStyle = BorderStyle.None;
            pictureDan3.BorderStyle = BorderStyle.None;
        }

        private void pictureDan3_Click(object sender, EventArgs e)
        {
            selectedWeapon = "Weapon3";
            pictureDan3.BorderStyle = BorderStyle.FixedSingle;
            pictureDan1.BorderStyle = BorderStyle.None;
            pictureDan2.BorderStyle = BorderStyle.None;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lever gamePlay = new Lever();
            this.Hide();
            gamePlay.ShowDialog();
            this.Close();
        }
    }

}

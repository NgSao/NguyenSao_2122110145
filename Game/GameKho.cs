﻿using System;
using System.Drawing;
using System.Windows.Forms;
using WMPLib;

namespace Game
{
    public partial class GameKho : Form
    {
        private string selectedShip;
        private string selectedWeapon;
        //Thư viện âm nhạc
        WindowsMediaPlayer gameMedia;
        WindowsMediaPlayer shootgMedia;
        WindowsMediaPlayer explostion;



        //Nhân vật
        PictureBox[] stars;
        int playerSpeed;

        int backgroundspeed;
        Random random;

        //Đạn
        PictureBox[] muntitons;
        int MutitonSpeed;


        //Kẻ địch
        PictureBox[] enemies;
        int enemiSpeed;

        //đạn dịch
        PictureBox[] enemiesMutition;
        int enemiesMutitionSpeed;


        int score;
        int level;
        int dificulty;
        bool pause;
        bool gameIsOver;


        public GameKho(string selectedShip, string selectedWeapon)
        {
            InitializeComponent();
            this.selectedShip = selectedShip;
            this.selectedWeapon = selectedWeapon;

        }

        private void GameKho_Load(object sender, EventArgs e)
        {

            score = 0;
            level = 1;
            dificulty = 6;
            pause = false;
            gameIsOver = false;

            backgroundspeed = 4;//Tốc dộ sao băng
            playerSpeed = 10;//Tốc độ nhân vật 
            MutitonSpeed = 20;//tốc dộ đạn ta

            enemiSpeed = 5;//Tốc độ kẻ địch
            enemiesMutitionSpeed = 5;//đạn địch

            random = new Random();



            //// Tải ảnh sao băng
            //Image starImage1 = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\tt1.png");
            //Image starImage2 = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\tt2.png");
            Image starImage1 = Image.FromFile(@"E:\C#\assetgame\maybay\star1.png");
            Image starImage2 = Image.FromFile(@"E:\C#\assetgame\maybay\star2.png");


            if (selectedShip == "Ship1")
            {
                Player.Image = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\game.png");

            }
            else if (selectedShip == "Ship2")
            {
                Player.Image = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\play1.png");
            }
            else if (selectedShip == "Ship3")
            {
                Player.Image = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\play2.png");
            }


            Image muntiton = null;
            if (selectedWeapon == "Weapon1")
                muntiton = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\game.png");
            else if (selectedWeapon == "Weapon2")
                muntiton = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\dany.png");
            else if (selectedWeapon == "Weapon3")
                muntiton = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\play3.png");




            Image bossBulletImage = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\danboss.png");
            Image enemyBulletImage = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\ddy.png");


            Image enemil1 = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\y1.png");
            Image enemil2 = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\y2.png");
            Image enemil3 = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\y3.png");
            Image enemil4 = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\y4.png");
            Image enemil5 = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\y5.png");
            Image enemil6 = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\y6.png");

            Image boss1 = Image.FromFile(@"E:\C#\NguyenSao_Game\NguyenSao_Game\Game\Resources\boost.png");



            //Sao băng
            stars = new PictureBox[15];
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(random.Next(20, 720), random.Next(-20, 600));
                stars[i].Size = new Size(10, 30);
                stars[i].SizeMode = PictureBoxSizeMode.StretchImage;
                stars[i].BackColor = Color.Transparent;


                if (i % 2 == 1)
                {
                    stars[i].Image = starImage1;
                }
                else
                {
                    stars[i].Image = starImage2;
                }

                this.Controls.Add(stars[i]);
            }


            muntitons = new PictureBox[3];


            //Đạn ta
            for (int i = 0; i < muntitons.Length; i++)
            {
                muntitons[i] = new PictureBox();
                muntitons[i].Size = new Size(30, 30);
                muntitons[i].Image = muntiton;
                muntitons[i].SizeMode = PictureBoxSizeMode.Zoom;
                muntitons[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(muntitons[i]);
            }





            //Địch
            enemies = new PictureBox[7];
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Size = new Size(60, 60);
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].Visible = false;
                this.Controls.Add(enemies[i]);
                enemies[i].Location = new Point((i + 1) * 70, -50);
            }
            enemies[0].Image = enemil1;
            enemies[1].Image = enemil2;
            enemies[2].Image = enemil3;
            enemies[3].Image = boss1;
            enemies[4].Image = enemil4;
            enemies[5].Image = enemil5;
            enemies[6].Image = enemil6;


            //Đạn địch
            enemiesMutition = new PictureBox[10];

            for (int i = 0; i < enemiesMutition.Length; i++)
            {
                enemiesMutition[i] = new PictureBox();
                enemiesMutition[i].Size = new Size(20, 30);
                enemiesMutition[i].Visible = false;
                enemiesMutition[i].Image = enemyBulletImage;
                enemiesMutition[i].SizeMode = PictureBoxSizeMode.StretchImage;
                int x = random.Next(0, 7);
                enemiesMutition[i].Location = new Point(enemies[x].Location.X, enemies[x].Location.Y - 20);
                this.Controls.Add(enemiesMutition[i]);
            }







            //Âm nhạc
            gameMedia = new WindowsMediaPlayer();
            shootgMedia = new WindowsMediaPlayer();
            explostion = new WindowsMediaPlayer();

            gameMedia.URL = @"E:\C#\assetgame\songs\GameSong.mp3";
            shootgMedia.URL = @"E:\C#\assetgame\songs\shoot.mp3";
            explostion.URL = @"E:\C#\assetgame\songs\boom.mp3";

            gameMedia.settings.setMode("loop", true);
            gameMedia.settings.volume = 100;
            shootgMedia.settings.volume = 20;
            explostion.settings.volume = 500;


            gameMedia.controls.play();



        }

        private void MoveBgTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Length / 2; i++)
            {
                stars[i].Top += backgroundspeed;
                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top += backgroundspeed - 2;
                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
        }

        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10)
            {
                Player.Left -= playerSpeed;
            }
        }

        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Right < 720)
            {
                Player.Left += playerSpeed;
            }
        }

        private void DownMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 430)
            {
                Player.Top += playerSpeed;
            }
        }

        private void UpMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10)
            {
                Player.Top -= playerSpeed;
            }
        }



        private void GameKho_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pause)
            {
                if (e.KeyCode == Keys.Right)
                {
                    RightMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Left)
                {
                    LeftMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Down)
                {
                    DownMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Up)
                {
                    UpMoveTimer.Start();
                }
            }

        }

        private void GameKho_KeyUp(object sender, KeyEventArgs e)
        {
            RightMoveTimer.Stop();
            LeftMoveTimer.Stop();
            DownMoveTimer.Stop();
            UpMoveTimer.Stop();
            if (e.KeyCode == Keys.Space)
            {
                if (!gameIsOver)
                {
                    if (pause)
                    {
                        StartTimers();
                        label.Visible = false;
                        btnReset.Visible = false;
                        btnMainMenu.Visible = false;
                        gameMedia.controls.play();
                        pause = false;
                    }
                    else
                    {
                        label.Location = new Point((800 - label.Width) / 2, 150);
                        label.Text = "TẠM DỪNG";
                        label.Visible = true;
                        btnReset.Visible = true;
                        btnMainMenu.Visible = true;
                        gameMedia.controls.pause();
                        StopTimers();
                        pause = true;
                    }
                }
            }

        }

        private void MoveMuntitonTimer_Tick(object sender, EventArgs e)
        {
            shootgMedia.controls.play();
            for (int i = 0; i < muntitons.Length; i++)
            {
                if (muntitons[i].Top > 0)
                {
                    muntitons[i].Visible = true;
                    muntitons[i].Top -= MutitonSpeed;
                    Collision();
                }
                else
                {
                    muntitons[i].Visible = false;
                    muntitons[i].Location = new Point(Player.Location.X + (Player.Width / 2) - (muntitons[i].Width / 2), Player.Location.Y - i * 30);

                }
            }
        }

        private void MoveEnemiesTimer_Tick(object sender, EventArgs e)
        {
            MoveEnemies(enemies, enemiSpeed);
        }

        private void MoveEnemies(PictureBox[] array, int speed)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Visible = true;
                array[i].Top += speed;
                if (array[i].Top > this.Height)
                {
                    array[i].Location = new Point((i + 1) * 50, -200);
                }
            }

        }



        private void Collision()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                // Kiểm tra va chạm với đạn
                for (int j = 0; j < muntitons.Length; j++)
                {
                    if (muntitons[j].Visible && muntitons[j].Bounds.IntersectsWith(enemies[i].Bounds))
                    {
                        // Ẩn đạn và reset vị trí của kẻ thù
                        muntitons[j].Visible = false;
                        enemies[i].Location = new Point((i + 1) * 50, -100);

                        // Phát âm thanh nổ và tăng điểm số
                        explostion.controls.play();
                        score += 1;
                        labelScore.Text = (score < 10) ? "0" + score.ToString() : score.ToString();

                        // Tăng cấp độ mỗi 40 điểm
                        if (score % 20 == 0)
                        {
                            // Kiểm tra điều kiện cấp độ tối đa
                            if (level < 6)
                            {
                                level += 1;
                                labelLever.Text = (level < 10) ? "0" + level.ToString() : level.ToString();

                                // Tăng tốc độ theo cấp độ, giới hạn tốc độ tối đa
                                if (enemiSpeed <= 10 && enemiesMutitionSpeed <= 10 && dificulty >= 0)
                                {
                                    dificulty--;
                                    enemiSpeed++;
                                    enemiesMutitionSpeed++;
                                }
                            }
                            else // Kiểm tra điều kiện thắng khi đạt cấp độ tối đa
                            {
                                GameOver("Chúc mừng bạn đã phá đảo game");
                                return;
                            }
                        }
                        break;
                    }
                }

                // Kiểm tra va chạm giữa kẻ thù và người chơi
                if (Player.Visible && Player.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explostion.settings.volume = 500;
                    explostion.controls.play();
                    Player.Visible = false;
                    GameOver("Bạn đã thua");
                    return;
                }
            }
        }


        private void GameOver(String str)
        {
            label.Text = str;
            label.Location = new Point(120, 120);
            label.Visible = true;
            gameMedia.controls.stop();
            StopTimers();
            btnReset.Visible = true;
            btnMainMenu.Visible = true;
        }

        private void StopTimers()
        {
            MoveBgTimer.Stop();
            MoveEnemiesTimer.Stop();
            MoveMuntitonTimer.Stop();
            EnemeiesMuntionTimer.Stop();
        }

        private void StartTimers()
        {
            MoveBgTimer.Start();
            MoveEnemiesTimer.Start();
            MoveMuntitonTimer.Start();
            EnemeiesMuntionTimer.Start();

        }

        private void EnemeiesMuntionTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < (enemiesMutition.Length - dificulty); i++)
            {
                if (enemiesMutition[i].Top < this.Height)
                {
                    enemiesMutition[i].Visible = true;
                    enemiesMutition[i].Top += enemiesMutitionSpeed;
                    CollisionWithEnemisMutition();
                }
                else
                {
                    enemiesMutition[i].Visible = false;
                    int x = random.Next(0, 7);
                    enemiesMutition[i].Location = new Point(enemies[x].Location.X + 20, enemies[x].Location.Y + 30);
                }
            }

        }

        private void CollisionWithEnemisMutition()
        {
            for (int i = 0; i < enemiesMutition.Length; i++)
            {
                if (enemiesMutition[i].Bounds.IntersectsWith(Player.Bounds))
                {
                    enemiesMutition[i].Visible = false;
                    explostion.settings.volume = 500;
                    explostion.controls.play();
                    Player.Visible = false;
                    GameOver("Bạn đã thua");
                }
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnReset.Visible = false;
            btnMainMenu.Visible = false;
            GameKho menu = new GameKho(selectedShip, selectedWeapon);
            menu.ShowDialog();
            this.Close();
        }


        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            GameMenu menu = new GameMenu();
            menu.ShowDialog();
            this.Close();

        }

       
    }
}


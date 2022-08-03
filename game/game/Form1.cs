using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using WMPLib;
namespace game
{
    public partial class Form1 : Form
    {
        public int movementDirection = 0;
        private int currentFrame = 0; 
        private Image CampFire;
        private WindowsMediaPlayer death;
        private PictureBox[] clouds;
        public PictureBox[] bullets;
        private int backgroundspeed;
        private Random rnd;
        private int playerSpeed;
        private int bulletsSspeed;
        public Enemies zombies;
        public Enemies zombies2;
        public int damage;
        public bool gunReady;
        private int fl = 1;
        Health hp;
        private WindowsMediaPlayer shoot;
        private WindowsMediaPlayer maintheme;
        private WindowsMediaPlayer gameOver;
        private WindowsMediaPlayer metalClang;
        private PictureBox[] grenades;
        public double grenadesSpeed;
        public int grenadeStopper;
        public double x1;
        public double y1;
        public double t;
        public Form1()
        {
            Program.f1 = this;
            
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Intersect();
            if (zombies.IsDefeated()&&fl==1)
            {
                fl = 2;
                gra.Stop();
                label1.Text = "WAVE TWO";
                label1.Visible = true;
                gra.Start();
                int[] ehp = {1,1,1,1,1,1};
                zombies = new Enemies(4, rnd.Next(60, 80), 5,Environment.CurrentDirectory + @"\assets\zombie.gif",ehp);
                zombies.spawn(this);
            }
            if (zombies.IsDefeated()&&fl==2)
            {
                fl = 3;
                gra.Stop();
                label1.Text = "WAVE THREE";
                label1.Visible = true;
                gra.Start();
                int[] ehp = {1,1,1,1,1,1,1};
                zombies = new Enemies(4, rnd.Next(60, 80), 8,Environment.CurrentDirectory + @"\assets\zombie.gif",ehp);
                zombies.spawn(this);
            }
            if (zombies.IsDefeated()&&fl==3)
            {
                fl = 4;
                bossHealth.Visible = true;
                bossHealthChecker.Start();
                gra.Stop();
                label1.Text = "BOSS FIGHT";
                label1.Visible = true;
                gra.Start();
                int[] ehp = {10};
                zombies = new Enemies(1, rnd.Next(80,80), 4,Environment.CurrentDirectory + @"\assets\zombie.gif",ehp);
                zombies.spawn(this);
            }
            if (zombies.IsDefeated()&&fl==4)
            {
                bossHealth.Visible = false;
                fl = 4;
                gra.Stop();
                label1.Text = "VICTORY";
                label1.Visible = true;
                gra.Start();
            }
            if (fl==5)
            {
                gameOver = new WindowsMediaPlayer();
                gameOver.URL=Environment.CurrentDirectory + @"\assets\sounds\gameOver.mp3";
                gameOver.settings.volume = 30;
                maintheme.controls.stop();
                gameOver.controls.play();
                gra.Stop();
                label1.Text = "YOU DIED";
                label1.Visible = true;
                gra.Start();
                DeathTimer.Start();
            }
            for (int i = 0; i < clouds.Length; i++)
            {
                clouds[i].Left += backgroundspeed;
                if (clouds[i].Left >= 1920)
                    clouds[i].Left = clouds[i].Height;
            }
            
        }
        private void gra_Tick(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            CampFire = new Bitmap(Environment.CurrentDirectory + @"\assets\fire.png");
            campFire.Image = CampFire;
            timer2.Tick += new EventHandler(fireUpdate);
            timer2.Start();
            hp = new Health(700);
            shoot = new WindowsMediaPlayer();
            shoot.URL = Environment.CurrentDirectory + @"\assets\sounds\pistol.mp3";
            shoot.settings.volume = 20;
            shoot.settings.autoStart = false;
            maintheme = new WindowsMediaPlayer();
            maintheme.URL=Environment.CurrentDirectory + @"\assets\sounds\maintheme.mp3";
            maintheme.settings.setMode("loop",true);
            maintheme.settings.volume = 10;
            metalClang = new WindowsMediaPlayer();
            metalClang.URL=Environment.CurrentDirectory + @"\assets\sounds\metalClang.mp3";
            metalClang.settings.volume = 40;
            StreamReader sr=new StreamReader(Environment.CurrentDirectory + @"\diff.txt");
            string line;
            line=sr.ReadLine();
            sr.Close();
                if(line.Equals("1"))
            damage = 3;
                if(line.Equals("2"))
                    damage = 10;
                if(line.Equals("3"))
                    damage = 25;
            backgroundspeed = 1;
            clouds = new PictureBox[20];
            rnd = new Random();
            playerSpeed = 6;
            gunReady = true;
            bullets = new PictureBox[1];
            bulletsSspeed = 80;
            this.Opacity = 0;
            for (int i = 0; i < 145000; i++)
                this.Opacity += 0.00001;
            
            //grenades physic
            grenades = new PictureBox[1];
            grenadesSpeed =0;
            t = 0;
            for (int i = 0; i < grenades.Length; i++)
            {
                grenades[i] = new PictureBox();
                grenades[i].BorderStyle = BorderStyle.None;
                grenades[i].Size = new Size(150, 150);
                grenades[i].BackColor=Color.Transparent;
                grenades[i].Location = new Point(-150,-150);
                grenades[i].Image=Image.FromFile(Environment.CurrentDirectory + @"\assets\grenade.png");
                grenades[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                grenadeStopper = 1;
                this.Controls.Add(grenades[i]);
            }
            //

            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = new PictureBox();
                bullets[i].BorderStyle = BorderStyle.None;
                bullets[i].Size = new Size(15, 5);
                bullets[i].BackColor = Color.Black;
                this.Controls.Add(bullets[i]);
            }

            label1.Visible = true;
            label1.Text = "WAVE ONE";
            gra.Start();
            int[] ehp = {1,1,1};
            zombies = new Enemies(3, rnd.Next(60, 80), 3,Environment.CurrentDirectory + @"\assets\zombie.gif",ehp);
            zombies.spawn(this);
            
            for (int i = 0; i < clouds.Length; i++)
            {
                clouds[i] = new PictureBox();
                clouds[i].BorderStyle = BorderStyle.None;
                clouds[i].Location = new Point(rnd.Next(-1000, 1280), rnd.Next(140, 320));
                if (i % 2 == 1)
                {
                    clouds[i].Size = new Size(rnd.Next(100, 225), rnd.Next(30, 70));
                    clouds[i].BackColor = Color.FromArgb(rnd.Next(50, 125), 255, 255, 255);
                }
                else
                {
                    clouds[i].Size = new Size(150, 25);
                    clouds[i].BackColor = Color.FromArgb(rnd.Next(50, 125), 255, 255, 255);
                }

                this.Controls.Add(clouds[i]);
            }
            maintheme.controls.play();
        }

        private void Left_Tick(object sender, EventArgs e)
        {
            if (movementDirection==1 && pictureBox1.Left > 60)
            {
                pictureBox1.Left -= playerSpeed;
                pictureBox1.Refresh();
            }
            if (movementDirection==2 && pictureBox1.Left < 1900)
            {
                pictureBox1.Left += playerSpeed;
                pictureBox1.Refresh();
            }
            if (movementDirection==3 && pictureBox1.Top > 20)
            {
                pictureBox1.Top -= playerSpeed;
                pictureBox1.Refresh();
            }
            if (movementDirection==4 && pictureBox1.Top < 720)
            {
                pictureBox1.Top += playerSpeed;
                pictureBox1.Refresh();
            }
        }

        private void Right_Tick(object sender, EventArgs e)
        {
            ;
        }

        private void Up_Tick(object sender, EventArgs e)
        {
            ;
        }
        private void Down_Tick(object sender, EventArgs e)
        {
            ;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            /*if (e.KeyCode == Keys.Left)
            {
                pictureBox1.Image = Properties.Resources.walk_unscreen;
                Left.Start();
            }
            if (e.KeyCode == Keys.Right)
                {
                    pictureBox1.Image = Properties.Resources.walk_unscreen;
                    Right.Start();
                }

                if (e.KeyCode == Keys.Up)
                {
                    pictureBox1.Image = Properties.Resources.walk_unscreen;
                    Up.Start();
                }

                if (e.KeyCode == Keys.Down)
                {
                    pictureBox1.Image = Properties.Resources.walk_unscreen;
                    Down.Start();
                }
                */
            if (e.KeyCode == Keys.Left)
            {
                pictureBox1.Image = Properties.Resources.walk_unscreen;
                movementDirection = 1;
                Left.Start();
            }
            if (e.KeyCode == Keys.Right)
            {
                pictureBox1.Image = Properties.Resources.walk_unscreen;
                movementDirection = 2;
                Left.Start();
            }

            if (e.KeyCode == Keys.Up)
            {
                pictureBox1.Image = Properties.Resources.walk_unscreen;
                movementDirection = 3;
                Left.Start();
            }

            if (e.KeyCode == Keys.Down)
            {
                pictureBox1.Image = Properties.Resources.walk_unscreen;
                movementDirection = 4;
                Left.Start();
            }
                if (e.KeyCode == Keys.Space)
                {
                    if (gunReady)
                    {
                        for (int i = 0; i < bullets.Length; i++)
                        {
                            if (bullets[i].Left > 1920 || (bullets[i].Location.X == 0 && bullets[i].Location.Y == 0))
                            {
                                shoot.controls.play();
                                pictureBox1.Image = Properties.Resources.shoot_unscreen;
                                bullets[i].Location = new Point(pictureBox1.Location.X + 100 + i * 50,
                                    pictureBox1.Location.Y + 30);
                                Bullets.Start();
                            }
                        }

                        gunReady = false;
                        gunCooldown.Start();
                    }
                }

                if (e.KeyCode == Keys.G)
                {
                    grenadeStopper = 1;
                    for (int i = 0; i < grenades.Length; i++)
                    {
                        
                        //grenades[i].Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);
                        x1 =pictureBox1.Location.X+55;
                        y1 = pictureBox1.Location.Y-10;
                        grenades[i].Location = new Point(-150, -150);
                    }
                    grenadesTimer.Start();
                }
        }
        private void grenades_Tick(object sender, EventArgs e)
        {
            if (grenadeStopper == 1)
            {
                t = 3.5;
                grenadesSpeed += 4;
                for (int i = 0; i < grenades.Length; i++)
                {
                    grenades[i].Location = new Point((int) (x1 + grenadesSpeed * Math.Cos(0.2) * t),
                        (int) (y1 + grenadesSpeed * Math.Sin(0.2) * t - 9.8 * t * t / 2));
                    if (grenades[i].Left > 600)
                        grenadeStopper = 0;
                    Explosion();
                }
            }
            Explosion();
        }
        

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (pictureBox1.Image != Properties.Resources.shoot_unscreen)
            {
                pictureBox1.Image = Properties.Resources.idle_1__unscreen;
                Left.Stop();
                movementDirection = 0;
                /*Left.Stop();
                Right.Stop();
                Up.Stop();
                Down.Stop();*/
            }
        }


        private void Bullets_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].Left += bulletsSspeed;
                Intersect();
            }
        }

        private void Enemies_Tick(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = 0; i < zombies.n; i++)
            {
                if (j != 6) j++;
                else j = 0;
                zombies.move(i, j,Wreck.Location);
                //zombies.getEl(i).Refresh();
            }
        }

        public void Intersect()
        {
            if (bullets[0].Bounds.IntersectsWith(Wreck.Bounds))
            {
                bullets[0].Location = new Point(2000, pictureBox1.Location.Y + 50);
                metalClang.controls.play();
            }

            for (int i = 0; i < zombies.n; i++)
                {
                    if (zombies.stopper[i]!=0)
                    {
                        if (bullets[0].Bounds.IntersectsWith(zombies.getEl(i).Bounds))
                        {
                            bullets[0].Location = new Point(2000, pictureBox1.Location.Y + 50);
                            if (zombies.hp[i] == 1)
                                zombies.Eliminate(i);
                            else
                            {
                                zombies.hp[i] -= 1;
                                death = new WindowsMediaPlayer();
                                death.URL = Environment.CurrentDirectory + @"\assets\sounds\enemyDeath.mp3";
                                death.settings.volume = 35;
                                death.controls.play();
                            }
                        }
                    }
                    if (pictureBox1.Bounds.IntersectsWith(zombies.getEl(i).Bounds)&& zombies.stopper[i]!=0)
                    {
                        hp.healthPoints -= damage;
                        //pictureBox1.Visible = false;
                        //fl = 5;
                    }
                }
               
            
        }
        public async void Explosion()
        {
            
            for (int i = 0; i < zombies.n; i++)
            {
                if (grenades[0].Bounds.IntersectsWith(zombies.getEl(i).Bounds)&&zombies.stopper[i]!=0)
                    zombies.Eliminate(i);
            }

            await Task.Delay(8000);
            grenades[0].Location = new Point(-150, -150);
        }
        
        private void gunCooldown_Tick(object sender, EventArgs e)
        {
            gunReady = true;
            gunCooldown.Stop();
        }


        private void DeathTimer_Tick(object sender, EventArgs e)
        {
            DeathTimer.Stop();
            for(int i=0;i<145000;i++)
            this.Opacity = this.Opacity - 0.00001;
            this.Close();
            
        }

        private void HealthChecker_Tick(object sender, EventArgs e)
        {
            Graphics g = HealthBox.CreateGraphics();
            g.Clear(Color.Ivory);
            g.FillRectangle(Brushes.Crimson, new Rectangle(0,0,hp.healthPoints,20));
            if (hp.healthPoints <= 0)
                fl = 5;
        }
        private void bossHealthChecker_Tick(object sender, EventArgs e)
        {
            Graphics g1 = bossHealth.CreateGraphics();
            g1.Clear(Color.Ivory);
            g1.FillRectangle(Brushes.Crimson, new Rectangle(0,0,zombies.hp[0]*70,20));;
        }

        private void WreckTimer_Tick(object sender, EventArgs e)
        {
            if (bullets[0].Bounds.IntersectsWith(Wreck.Bounds)) 
            {
                bullets[0].Location = new Point(2000, pictureBox1.Location.Y + 50);
                metalClang.controls.play();
            }
        }

        
        private void fireUpdate(object sender, EventArgs e)
        {
            
            playAnimation();
            if (currentFrame == 4)
                currentFrame = 0;
            currentFrame++;
        }

        private void playAnimation()
        {
            Image part = new Bitmap(64, 80);
            Graphics g = Graphics.FromImage(part);
           
                g.DrawImage(CampFire, 0, 0, new Rectangle(new Point(64 * currentFrame, 0), new Size(64, 80)),
                    GraphicsUnit.Pixel);
                campFire.Image = part;
        }
    }
}
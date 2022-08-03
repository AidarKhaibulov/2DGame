using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using game;
using Timer = System.Windows.Forms.Timer;

namespace game
{
    
    public class Enemies
    {
        private Image zombieSkin;
        private Bitmap myBitmap;
        private Graphics gr;
        private WindowsMediaPlayer death;
        private int speedBuf;
        public int[] stopper;
        public int[] intellect;

        public int[] hp
        {
            get;
            set;
        }
        
        public PictureBox[] enemies{
            get;
            set;
        }
        
        public int n{
            get;
            set;
        }
        public int size{
            get;
            set;
        }
        public int speed{
            get;
            set;
        }

        public string skin;
            public Random r;

        public Enemies( int enemyCount,int size,int speed, string skinP,int[] hp)
        {
            speedBuf = 5;
            n=enemyCount;
            enemies = new PictureBox[n];
            stopper = new int[n];
            intellect = new int[n];
            this.size = size;
            this.speed = speed;
            skin=skinP;
            this.hp = hp;

        }
        
        public PictureBox getEl(int i)
        {
            return enemies[i];
        }
        

        public void spawn(Form form)
        {
            
            if (n == 1)
                intellect[0] = 0;
            else
            intellect[0]=1;
            for (int i = 0; i < enemies.Length; i++)
            {
                stopper[i] = 1;
                enemies[i] = new PictureBox();
                
                if (i == 0) enemies[i].Size = new Size(70,70);
                else
                    enemies[i].Size = new Size(size, size);
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].BackColor=Color.Transparent;
                enemies[i].Image = Image.FromFile(skin);
            
                r = new Random();
                enemies[i].Location = new Point((i + 1) * r.Next(140, 200) + 1040, r.Next(600, 700));


                /*if (i == 0) enemies[i].Size = new Size(70,70);
                else
                    enemies[i].Size = new Size(size, size);
                myBitmap = new Bitmap(80, 80);
                gr = Graphics.FromImage(myBitmap);
                //Image im= Image.FromFile(skin);
                //gr.DrawImage(zombieSkin, 0,0, new Rectangle(0, 0, 140, 90),GraphicsUnit.Pixel);
                r = new Random();
                enemies[i].Location = new Point((i + 1) * r.Next(140, 200) + 1040, r.Next(600, 700));
                
                enemies[i].Image = myBitmap;*/
                
                
                form.Controls.Add(enemies[i]);
                enemies[i].Refresh();
            }
        }

        public void move(int i,int j,Point wreck)
        {
            if (stopper[i]!=0)
            {
                if (intellect[i] == 1)
                {
                    enemies[i].Refresh();
                    if (wreck.X + 30 < enemies[i].Location.X && wreck.Y-10<enemies[i].Location.Y&&Math.Abs(wreck.Y-enemies[i].Location.Y)>=10)
                        enemies[i].Location = new Point(enemies[i].Location.X, enemies[i].Location.Y - speedBuf);
                    enemies[i].Refresh();
                    if (wreck.X + 30 < enemies[i].Location.X && wreck.Y-10>enemies[i].Location.Y&&Math.Abs(wreck.Y-enemies[i].Location.Y)>=10)
                        enemies[i].Location = new Point(enemies[i].Location.X, enemies[i].Location.Y + speedBuf);
                    enemies[i].Refresh();
                    if (Math.Abs(wreck.Y-enemies[i].Location.Y)<=10/*wreck.Y-10 == enemies[i].Location.Y*/ &&wreck.X + 30 < enemies[i].Location.X)
                        enemies[i].Location = new Point(enemies[i].Location.X-speedBuf, enemies[i].Location.Y);
                    enemies[i].Refresh();
                    if (enemies[i].Location.X - wreck.X <= 30 && enemies[i].Location.Y<=wreck.Y+50)
                        enemies[i].Location = new Point(enemies[i].Location.X, enemies[i].Location.Y+speedBuf);
                    enemies[i].Refresh();
                    if(enemies[i].Location.Y>=wreck.Y+50&&enemies[i].Location.X - wreck.X <= 30)
                        enemies[i].Location = new Point(enemies[i].Location.X-speedBuf, enemies[i].Location.Y);
                    enemies[i].Refresh();

                    if (enemies[i].Left < 10)
                        enemies[i].Location = new Point((i + 1) * r.Next(140, 200) + 1200, r.Next(600, 700));
                    enemies[i].Refresh();
                }
                else
                {
                    enemies[i].Refresh();

                    enemies[i].Left -= speed + (int) (Math.Sin(enemies[i].Left * Math.PI / 250) +
                                                      Math.Cos(enemies[i].Left * Math.PI / 250));
                    enemies[i].Refresh();
                    if (enemies[i].Left < 10)
                    {
                        int sizeEnemy = r.Next(60, 80);
                        enemies[i].Size = new Size(sizeEnemy, sizeEnemy);

                       
                        
                        
                        
                            /*myBitmap = new Bitmap(80, 80);
                            gr = Graphics.FromImage(myBitmap);
                            Image im = Image.FromFile(skin);
                            gr.DrawImage(zombieSkin, 0, 0, new Rectangle(0, 0, 50, 90), GraphicsUnit.Pixel);
                            r = new Random();
                            enemies[i].Location = new Point((i + 1) * r.Next(140, 200) + 1040, r.Next(600, 700));

                            enemies[i].Image = myBitmap;*/
                        

                            
                            
                            
                        enemies[i].Location = new Point((i + 1) * r.Next(140, 200) + 1200, r.Next(600, 700));
                        enemies[i].Refresh();
                    }
                }
            }
            enemies[i].Refresh();
        }

        public async void Eliminate(int i)
        {
            await Task.Run(() => deathAnimation(i));
            enemies[i].Location=new Point(-50, -50);
            enemies[i].Image = null;
        }

        public void deathAnimation(int i)
        {
            death = new WindowsMediaPlayer();
            death.URL = Environment.CurrentDirectory + @"\assets\sounds\enemyDeath.mp3";
            death.settings.volume = 35;
            enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
            enemies[i].Image = Image.FromFile(Environment.CurrentDirectory + @"\assets\blood.gif");
            stopper[i] = 0;
            Thread.Sleep(1300);
        }

        public bool IsDefeated()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].Image != null) return false;
            }
            return true;
        }
    }
}
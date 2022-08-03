using System.Windows.Forms;

namespace game
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Right = new System.Windows.Forms.Timer(this.components);
            this.Left = new System.Windows.Forms.Timer(this.components);
            this.Up = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Down = new System.Windows.Forms.Timer(this.components);
            this.Bullets = new System.Windows.Forms.Timer(this.components);
            this.Enemies = new System.Windows.Forms.Timer(this.components);
            this.gunCooldown = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.gra = new System.Windows.Forms.Timer(this.components);
            this.DeathTimer = new System.Windows.Forms.Timer(this.components);
            this.HealthChecker = new System.Windows.Forms.Timer(this.components);
            this.HealthBox = new System.Windows.Forms.PictureBox();
            this.grenadesTimer = new System.Windows.Forms.Timer(this.components);
            this.WreckTimer = new System.Windows.Forms.Timer(this.components);
            this.Wreck = new System.Windows.Forms.PictureBox();
            this.difficulty = new System.Windows.Forms.TextBox();
            this.bossHealth = new System.Windows.Forms.PictureBox();
            this.bossHealthChecker = new System.Windows.Forms.Timer(this.components);
            this.campFire = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.HealthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.Wreck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.bossHealth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.campFire)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Right
            // 
            this.Right.Interval = 10;
            this.Right.Tick += new System.EventHandler(this.Right_Tick);
            // 
            // Left
            // 
            this.Left.Interval = 10;
            this.Left.Tick += new System.EventHandler(this.Left_Tick);
            // 
            // Up
            // 
            this.Up.Interval = 10;
            this.Up.Tick += new System.EventHandler(this.Up_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::game.Properties.Resources.idle_1__unscreen;
            this.pictureBox1.Location = new System.Drawing.Point(297, 783);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 129);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Down
            // 
            this.Down.Interval = 10;
            this.Down.Tick += new System.EventHandler(this.Down_Tick);
            // 
            // Bullets
            // 
            this.Bullets.Interval = 10;
            this.Bullets.Tick += new System.EventHandler(this.Bullets_Tick);
            // 
            // Enemies
            // 
            this.Enemies.Enabled = true;
            this.Enemies.Interval = 10;
            this.Enemies.Tick += new System.EventHandler(this.Enemies_Tick);
            // 
            // gunCooldown
            // 
            this.gunCooldown.Interval = 1600;
            this.gunCooldown.Tick += new System.EventHandler(this.gunCooldown_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Papyrus", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(788, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(708, 87);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wave 1";
            this.label1.Visible = false;
            // 
            // gra
            // 
            this.gra.Interval = 5000;
            this.gra.Tick += new System.EventHandler(this.gra_Tick);
            // 
            // DeathTimer
            // 
            this.DeathTimer.Tick += new System.EventHandler(this.DeathTimer_Tick);
            // 
            // HealthChecker
            // 
            this.HealthChecker.Enabled = true;
            this.HealthChecker.Tick += new System.EventHandler(this.HealthChecker_Tick);
            // 
            // HealthBox
            // 
            this.HealthBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.HealthBox.Location = new System.Drawing.Point(73, 40);
            this.HealthBox.Name = "HealthBox";
            this.HealthBox.Size = new System.Drawing.Size(930, 22);
            this.HealthBox.TabIndex = 3;
            this.HealthBox.TabStop = false;
            // 
            // grenadesTimer
            // 
            this.grenadesTimer.Tick += new System.EventHandler(this.grenades_Tick);
            // 
            // WreckTimer
            // 
            this.WreckTimer.Enabled = true;
            this.WreckTimer.Tick += new System.EventHandler(this.WreckTimer_Tick);
            // 
            // Wreck
            // 
            this.Wreck.BackColor = System.Drawing.Color.Transparent;
            this.Wreck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Wreck.Location = new System.Drawing.Point(958, 692);
            this.Wreck.Name = "Wreck";
            this.Wreck.Size = new System.Drawing.Size(45, 65);
            this.Wreck.TabIndex = 4;
            this.Wreck.TabStop = false;
            // 
            // difficulty
            // 
            this.difficulty.Location = new System.Drawing.Point(147, 112);
            this.difficulty.Name = "difficulty";
            this.difficulty.Size = new System.Drawing.Size(70, 22);
            this.difficulty.TabIndex = 5;
            this.difficulty.Text = "dd";
            this.difficulty.Visible = false;
            // 
            // bossHealth
            // 
            this.bossHealth.Location = new System.Drawing.Point(1083, 40);
            this.bossHealth.Name = "bossHealth";
            this.bossHealth.Size = new System.Drawing.Size(930, 22);
            this.bossHealth.TabIndex = 6;
            this.bossHealth.TabStop = false;
            this.bossHealth.Visible = false;
            // 
            // bossHealthChecker
            // 
            this.bossHealthChecker.Tick += new System.EventHandler(this.bossHealthChecker_Tick);
            // 
            // campFire
            // 
            this.campFire.BackColor = System.Drawing.Color.Transparent;
            this.campFire.Location = new System.Drawing.Point(12, 658);
            this.campFire.Name = "campFire";
            this.campFire.Size = new System.Drawing.Size(96, 130);
            this.campFire.TabIndex = 8;
            this.campFire.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.campFire);
            this.Controls.Add(this.bossHealth);
            this.Controls.Add(this.difficulty);
            this.Controls.Add(this.Wreck);
            this.Controls.Add(this.HealthBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.HealthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.Wreck)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.bossHealth)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.campFire)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Timer timer2;

        private System.Windows.Forms.PictureBox campFire;

        private System.Windows.Forms.Timer bossHealthChecker;

        private System.Windows.Forms.PictureBox bossHealth;

        public System.Windows.Forms.TextBox difficulty;

        private System.Windows.Forms.PictureBox Wreck;

        private System.Windows.Forms.Timer WreckTimer;

        private System.Windows.Forms.PictureBox pictureBox2;

        private System.Windows.Forms.Timer grenadesTimer;

        private System.Windows.Forms.PictureBox HealthBox;

        private System.Windows.Forms.Timer HealthChecker;

        private System.Windows.Forms.Timer DeathTimer;

        private System.Windows.Forms.Timer gra;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Timer gunCooldown;

        private System.Windows.Forms.Timer Enemies;

        private System.Windows.Forms.Timer Bullets;

        private System.Windows.Forms.Timer Right;
        private System.Windows.Forms.Timer Left;
        private System.Windows.Forms.Timer Up;
        private System.Windows.Forms.Timer Down;
        
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;

        #endregion
    }
}
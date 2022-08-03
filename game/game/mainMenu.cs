using System;
using System.Windows.Forms;
using WMPLib;

namespace game
{
    public partial class mainMenu : Form
    {
        private WindowsMediaPlayer menuTheme;
        public mainMenu()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            options f = new options();
            f.ShowDialog();
        }

        private void mainMenu_Load(object sender, EventArgs e)
        {
            menuTheme = new WindowsMediaPlayer();
            menuTheme.URL = Environment.CurrentDirectory + @"\assets\sounds\mainMenuTheme.mp3";
                //menuTheme.URL=@"C:\Users\79021\RiderProjects\game\game\bin\Debug\assets\sounds\mainMenuTheme.mp3";
            menuTheme.settings.setMode("loop",true);
            menuTheme.settings.volume = 40;
            menuTheme.controls.play();
        }
    }
}
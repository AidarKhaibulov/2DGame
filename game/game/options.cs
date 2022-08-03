using System;
using System.IO;
using System.Windows.Forms;

namespace game
{
    public partial class options : Form
    {
        public options()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            FileStream aFile = new FileStream("diff.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            sw.WriteLine("1");
            sw.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream aFile = new FileStream("diff.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            sw.WriteLine("2");
            sw.Close();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream aFile = new FileStream("diff.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            sw.WriteLine("3");
            sw.Close();
            this.Close();
        }
    }
}
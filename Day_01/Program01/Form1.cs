using System;
using System.Drawing;
using System.Windows.Forms;

namespace Program01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Nút Display
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Welcome C#";
        }

        // Nút Clear
        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        // Nút Exit
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = ""; 
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Yellow;
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }
    }
}
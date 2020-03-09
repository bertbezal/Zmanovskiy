using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMeneger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Icon = SystemIcons.Asterisk;
            this.ShowInTaskbar = false;
            notifyIcon1.MouseDoubleClick += notifyIcon1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(textBox1.Text);
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo crrDir in dirs)
            {
                listBox1.Items.Add(crrDir);
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo crrFile in files)
            {
                listBox1.Items.Add(crrFile);
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Path.GetExtension(Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString())) == "")
            {
                textBox1.Text = Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString());
                listBox1.Items.Clear();
                DirectoryInfo dir = new DirectoryInfo(textBox1.Text);
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo crrDir in dirs)
                {
                    listBox1.Items.Add(crrDir);
                }
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo crrFile in files)
                {
                    listBox1.Items.Add(crrFile);
                }
            }
            else
            {
                Process.Start(Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString()));
            }
    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.Text.Length - 1] == '\\')
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                while (textBox1.Text[textBox1.Text.Length - 1] != '\\')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                }
            }
            else if (textBox1.Text[textBox1.Text.Length - 1] != '\\')
            {
                while (textBox1.Text[textBox1.Text.Length - 1] != '\\')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                }
            }
            listBox1.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(textBox1.Text);
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo crrDir in dirs)
            {
                listBox1.Items.Add(crrDir);
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo crrFile in files)
            {
                listBox1.Items.Add(crrFile);
            }
        }
        private void Form1_FormCLosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }
    }
}

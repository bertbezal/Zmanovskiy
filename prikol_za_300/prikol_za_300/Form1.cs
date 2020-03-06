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


namespace prikol_za_300
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text[metroTextBox1.Text.Length - 1] == '\\')
            {
                metroTextBox1.Text = metroTextBox1.Text.Remove(metroTextBox1.Text.Length - 1, 1);
                while (metroTextBox1.Text[metroTextBox1.Text.Length - 1] != '\\')
                {
                    metroTextBox1.Text = metroTextBox1.Text.Remove(metroTextBox1.Text.Length - 1, 1);
                }
            }
            else if (metroTextBox1.Text[metroTextBox1.Text.Length - 1] != '\\')
            {
                while (metroTextBox1.Text[metroTextBox1.Text.Length - 1] != '\\')
                {
                    metroTextBox1.Text = metroTextBox1.Text.Remove(metroTextBox1.Text.Length - 1, 1);
                }
            }
            listBox1.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(metroTextBox1.Text);
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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(metroTextBox1.Text);
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Path.GetExtension(Path.Combine(metroTextBox1.Text, listBox1.SelectedItem.ToString())) == "")
            {
                metroTextBox1.Text = Path.Combine(metroTextBox1.Text, listBox1.SelectedItem.ToString());
                listBox1.Items.Clear();
                DirectoryInfo dir = new DirectoryInfo(metroTextBox1.Text);
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
                Process.Start(Path.Combine(metroTextBox1.Text, listBox1.SelectedItem.ToString()));
            }
        }
    }
}

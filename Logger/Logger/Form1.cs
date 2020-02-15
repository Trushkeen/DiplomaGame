using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logger
{
    public partial class Form1 : Form
    {
        string LocalAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public Form1()
        {
            InitializeComponent();
            if (File.Exists(LocalAppDataPath + @"\\RSLogger\\username.txt"))
            {
                textBox1.Text = File.ReadAllText(LocalAppDataPath + @"\\RSLogger\\username.txt");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(LocalAppDataPath + @"\\RSLogger\\username.txt"))
            {
                Directory.CreateDirectory(LocalAppDataPath + @"\\RSLogger");
                File.Create(LocalAppDataPath + @"\\RSLogger\\username.txt");
            }
            File.WriteAllText(LocalAppDataPath + @"\\RSLogger\\username.txt", textBox1.Text);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            var changelogFilename = "Changelog.txt";
            if (!File.Exists(changelogFilename))
            {
                File.Create(changelogFilename);
            }
            var previousLog = File.ReadAllText(changelogFilename);
            var currentLog = $"Developer: {textBox1.Text}, Date: {DateTime.Now.ToShortDateString()}, {DateTime.Now.ToShortTimeString()}" +
                "\n>>>Log: " + rtbLogText.Text + "\n\n";
            var newLog = currentLog + previousLog;
            File.WriteAllText(changelogFilename, newLog);
            MessageBox.Show("Залогировано");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace FileManager
{
    public partial class Form4 : Form
    {
        
        public TreeNode node = new TreeNode();
        public TreeNode nodeNew = new TreeNode();
        public string str;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "12.txt")
            {
                try
                {
                    if (File.Exists(str))
                    {

                        File.Delete(str);
                    }

                    using (FileStream fs = File.Create(@"d:\tr\22.txt"))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                        fs.Write(info, 0, info.Length);
                    }
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                if (File.Exists(str))
                {

                    MessageBox.Show("It`s not a folder, it`s a file!");
                }
                else
                {
                    string newName = textBox1.Text;
                    nodeNew.Text = newName;
                    FileSystem.CreateDirectory(str + @"\" + newName);
                    this.Close();
                }
            }
        }
    }
}

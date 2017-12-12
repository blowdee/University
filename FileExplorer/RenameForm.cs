using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
namespace FileManager
{
    public partial class Form2 : Form
    {
        private  string   str;
        private  TreeNode node;
        public Form2(String str1, TreeNode trnd)
        {
            InitializeComponent();
            str = str1;
            node = trnd;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            str = textBox1.Text;
            
            if (File.Exists(node.FullPath))
            {
               FileSystem.RenameFile(node.FullPath,str);
            }
            else
            {
                FileSystem.RenameDirectory(node.FullPath, str);
            }
            node.Text = str;
            this.Close();
        }
    }
}

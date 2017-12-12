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
using System.Text.RegularExpressions;

namespace FileManager
{
    public partial class 
        TextEditorForm : Form
    {

        private String textFilePath;
        public TextEditorForm(String str)
        {
            InitializeComponent();
            textFilePath = str;
            textBox1.ScrollBars = ScrollBars.Vertical;
        }

        private void TextEditorForm_Load(object sender, EventArgs e)
        {
           
            if (textFilePath.EndsWith(".txt") || textFilePath.EndsWith(".html"))
            {
                String allFile = FileSystem.ReadAllText(textFilePath);
                textBox1.Text = allFile;
            }
            else
            {
                Byte[] allFile = FileSystem.ReadAllBytes(textFilePath);
                foreach (var item in allFile)
                {
                    textBox1.Text += Convert.ToString(item,16);
                }
            }          
        }

        private void Save_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(textFilePath, textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = FileSystem.ReadAllText(textFilePath);
            text = text.Replace(".", "");
            text = text.Replace(",", "");
            text = text.ToLower();
            var results = text.Split(' ').Where(x => x.Length > 2)
                                          .GroupBy(x => x)
                                          .Select(x => new { Count = x.Count(), Word = x.Key })
                                          .OrderByDescending(x => x.Count);

            foreach (var item in results)
            {
                if(item.Count > 1)
                MessageBox.Show(String.Format("{0} occured {1} times", item.Word, item.Count));
            }
            }

    }
}

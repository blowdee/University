using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Net;
using System.Linq;


namespace FileManager
{

    public partial class Form1 : Form
    {
        FileManager fe = new FileManager();

        string name;
        int sum = 0;
        bool cutOrCopy;
        string path;
        string[] task3;
        string inf = FileSystem.ReadAllText(@"log.txt");

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {          
            fe.CreateTree(this.trwFileExplorer);
        }
       

        private void trwFileExplorer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "")
            {
                TreeNode node = fe.EnumerateDirectory(e.Node);
            }          
        }
        
        private void trwFileExplorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            String str = this.trwFileExplorer.SelectedNode.FullPath;
            textBox1.ReadOnly = true;
            textBox1.Text = str;            
        }

        private void trwFileExplorer_DoubleClick(object sender, EventArgs e)
        {
            open(sender, e);
        }

        private void trwFileExplorer_MouseDown(object sender, MouseEventArgs e)
        {
            this.trwFileExplorer.SelectedNode = this.trwFileExplorer.GetNodeAt(e.X, e.Y);
        }

        #region ToolStrip Manage
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete(sender, e);           
        }

        private void CopyStripMenuItem1_Click(object sender, EventArgs e)
        {
            copy(sender, e);           
        }
        
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paste(sender, e);            
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cut(sender, e);
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rename(sender, e);
        }
        #endregion

        #region Node Info ToolStrip
        private void firstNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String s = this.trwFileExplorer.SelectedNode.FirstNode.Text;
            MessageBox.Show(s);
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String i = this.trwFileExplorer.SelectedNode.Text;
            MessageBox.Show(i);
        }

        private void existsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String str = this.trwFileExplorer.SelectedNode.FullPath;
            bool b = File.Exists(@str);
            MessageBox.Show(b.ToString());
        }

        private void fullPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String s = this.trwFileExplorer.SelectedNode.FullPath;
            MessageBox.Show(s);
        }
    
        #endregion
        //File Functions
        #region
        private void paste(object sender, EventArgs e)
        {
            if (sum == 0)
            {
                try
                {
                    if (trwFileExplorer.SelectedNode != null)
                    {
                        TreeNode paste = trwFileExplorer.SelectedNode;
                        String str = this.trwFileExplorer.SelectedNode.FullPath;
                        IDataObject data = Clipboard.GetDataObject();
                        if (data.GetDataPresent(typeof(TreeNode)))
                        {
                            TreeNode element = (TreeNode)data.GetData(typeof(TreeNode));
                            TreeNode tn = new TreeNode();
                            tn.Text = element.Text;
                            tn.Name = element.Name;
                            foreach (TreeNode temp in element.Nodes)
                            {
                                TreeNode newTn = new TreeNode(temp.Text);
                                tn.Nodes.Add(newTn);
                            }
                            if (paste.Parent != null)
                            {
                                paste.Parent.Nodes.Insert(paste.Index + 1, tn);
                                paste.ImageIndex = 2;

                            }
                            else
                            {
                                this.trwFileExplorer.Nodes.Insert(paste.Index + 1, tn);
                            }
                        }
                        if (File.Exists(path))
                        {
                           
                            File.Copy(@path, @str + @"\" + name);
                            log(" copied to " + str);
                        }
                        else
                        {
                            DirectoryInfo df = new DirectoryInfo(@path);

                        }
                        if (cutOrCopy)
                        {

                        }
                    }
                }
                catch
                {

                }
            }
            else
            {
                String lol = "";
                path = this.trwFileExplorer.SelectedNode.FullPath;
                for (int i = 0; i < sum; ++i) 
                {
                    for (int j = task3[i].Length - 1; j > 0; --j)
                    {
                        if(task3[i][j] == 92)
                        {
                            for(int z = j+1; z < task3[i].Length; ++z)
                            {
                                name += task3[i][z];
                            }
                            break;
                        }

                    }
                    
                    lol = task3[i];
                    
                    File.Copy(@lol, @path + @"\" + name);
                    name = "";
                }
                sum = 0;
            }
        }
        private void copy(object sender, EventArgs e)
        {
            TreeNode node = this.trwFileExplorer.SelectedNode;
            if (node != null)
            {
                Clipboard.SetDataObject(node, true);
                path = this.trwFileExplorer.SelectedNode.FullPath;
                name = this.trwFileExplorer.SelectedNode.Text;
                cutOrCopy = false;
                inf = inf + DateTime.Now + " File "  + name;
            }
        }

        private void cut(object sender, EventArgs e)
        {
            TreeNode node = this.trwFileExplorer.SelectedNode;
            if (node != null)
            {
                Clipboard.SetDataObject(node, true);
                this.trwFileExplorer.Nodes.Remove(node);
                path = this.trwFileExplorer.SelectedNode.FullPath;
                name = this.trwFileExplorer.SelectedNode.Text;
                cutOrCopy = true;
            }
        }

        private void open(object sender, EventArgs e)
        {
            if (this.trwFileExplorer.SelectedNode.IsSelected && File.Exists(this.trwFileExplorer.SelectedNode.FullPath))
            {
                try
                {
                    string str = this.trwFileExplorer.SelectedNode.FullPath;
                    System.Diagnostics.Process.Start(@str);
                }
                catch (Win32Exception)
                {

                }
            }
        }

        private void delete(object sender, EventArgs e)
        {
            try
            {
                if (this.trwFileExplorer.SelectedNode.IsSelected && this.trwFileExplorer.SelectedNode.Level != 0)
                {
                    String str = this.trwFileExplorer.SelectedNode.FullPath;
                    this.trwFileExplorer.SelectedNode.Remove();

                    if (File.Exists(@str))
                    {
                        FileInfo fs = new FileInfo(@str);
                        fs.Delete();
                        log(DateTime.Now + " File " + fs + " deleted");
                    }
                    else
                    {
                        DirectoryInfo df = new DirectoryInfo(@str);
                        df.Delete();
                        log(DateTime.Now + " Folder " + df + " deleted.");
                    }
                }
                else
                {
                    MessageBox.Show("Sorry , I can't delete it");
                }
            }
            catch (Exception ex)
            {
                log(ex.ToString());
            }
        }

        private void rename(object sender, EventArgs e)
        {
            Form2 renameForm = new Form2(this.trwFileExplorer.SelectedNode.Text, this.trwFileExplorer.SelectedNode);
            renameForm.Show();
        }

        #endregion

      
        private void openTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextEditorForm Editor = new TextEditorForm(this.trwFileExplorer.SelectedNode.FullPath);
            Editor.Show();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.trwFileExplorer.Nodes.Clear();
            fe.CreateTree(this.trwFileExplorer);      
        }

        public static void search(string src, string sbj)
        {
            try
            {
                string[] dirs = Directory.GetFiles(src, sbj);
                string dir = "";
                int c = 0;
                if (dirs.Length > 0)
                {
                    for (int i = 0; i < dirs.Length; ++i)
                    {
                        dir += dirs[i];
                        dir += "\n";
                        c = 1;
                    }
                }
                if (c == 0)
                    MessageBox.Show("There are no such files", "Sorry");
                else
                MessageBox.Show(dir, "Result");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Search_Click(object sender, EventArgs e)
        {
            string dirName = this.trwFileExplorer.SelectedNode.FullPath;
            string toName = SearchTextBox.Text;
            search(dirName, toName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            path = trwFileExplorer.SelectedNode.FullPath;
            string text = FileSystem.ReadAllText(path);
            String subj = textBox2.Text;
            String change = textBox3.Text;
            text = text.Replace(subj, change);
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);
            file.WriteLine(text);
            file.Close();
            log(DateTime.Now + " Context substitution made in file " + path + " : " + subj + " on " + change);
        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 createFolderForm = new Form4();
            createFolderForm.str = this.trwFileExplorer.SelectedNode.FullPath;
            createFolderForm.node = this.trwFileExplorer.SelectedNode;
            createFolderForm.Show();
            this.trwFileExplorer.SelectedNode.Nodes.Add(createFolderForm.nodeNew);  
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 cFF = new Form4();
            cFF.str = this.trwFileExplorer.SelectedNode.FullPath;
            cFF.node = this.trwFileExplorer.SelectedNode;
            cFF.Show();
        }

        public void log (string even)
        {
            inf = inf + even + " ";
            richTextBox1.Text = inf;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void copyAll(string sbj)
        {
            path = this.trwFileExplorer.SelectedNode.FullPath;
            try
            {
                string[] dirs = Directory.GetFiles(path, sbj);
                task3 = dirs;
                int c = 0;
                if (dirs.Length > 0)
                {
                    for (int i = 0; i < dirs.Length; ++i)
                    {
                        task3[i] = dirs[i];
                        task3[i] += "\n";
                        c = 1;
                        sum++;
                    }
                }
                if (c == 0)
                    MessageBox.Show("There are no such files", "Sorry");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void htmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyAll("*.html");
        }

        private void txtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyAll("*.txt");
        }

        private void docxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyAll("*.docx");
        }

    }
}   
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using Microsoft.VisualBasic.FileIO;


namespace FileManager
{
  
    class FileManager
    {
        public FileManager()
        {

        }

        public bool CreateTree(TreeView treeView)
        {
            bool returnValue = false;
                 
            try
            {
                // Create Desktop
                TreeNode desktop = new TreeNode();
                desktop.Text = "Desktop";
                desktop.Tag = "Desktop";
                desktop.Nodes.Add("");
                desktop.ImageIndex = 3;
                desktop.SelectedImageIndex = 3;
                treeView.Nodes.Add(desktop);
                // Get driveInfo
                foreach (DriveInfo drv in DriveInfo.GetDrives())
                {                  
                    TreeNode fChild = new TreeNode();
                    if (drv.DriveType == DriveType.CDRom)
                    {
                        fChild.ImageIndex = 1;
                        fChild.SelectedImageIndex = 1;
                    }

                    fChild.Text = drv.Name;
                    fChild.Nodes.Add("");
                    treeView.Nodes.Add(fChild);
                    returnValue = true;
                }
                               
            }
            catch (Exception)
            {
                returnValue = false;
            }

            return returnValue;
        }

       
        public TreeNode EnumerateDirectory(TreeNode parentNode)
        {
          
            try
            {
                DirectoryInfo rootDir;

                // To fill Desktop
                Char [] arr={'\\'};
                string [] nameList = parentNode.FullPath.Split(arr);
                string path = "";

                if (nameList.GetValue(0).ToString() == "Desktop")
                {
                    path = SpecialDirectories.Desktop+"\\";

                    for (int i = 1; i < nameList.Length; i++)
                    {
                        path = path + nameList[i] + "\\";
                    }

                    rootDir = new DirectoryInfo(path);
                }
             // for other Directories
                else
                {                   
                    rootDir = new DirectoryInfo(parentNode.FullPath + "\\");
                }
                
                parentNode.Nodes[0].Remove();
                foreach (DirectoryInfo dir in rootDir.GetDirectories())
                {
                    
                    TreeNode node = new TreeNode();
                    node.Text = dir.Name;
                    node.Nodes.Add("");
                    parentNode.Nodes.Add(node);
                }
                //Fill files
                foreach (FileInfo file in rootDir.GetFiles())
                {
                    TreeNode node = new TreeNode();
                    node.Text = file.Name;
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 2;
                    parentNode.Nodes.Add(node);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            return parentNode;
        }
    }

}

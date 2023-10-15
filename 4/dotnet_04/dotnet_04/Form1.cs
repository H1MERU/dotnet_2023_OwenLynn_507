using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace dotnet_04
{
    public partial class Form1 : Form
    {
        string selectedFolderPath = @"C:\";
        string disk;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFileOrFolder(object sender, EventArgs e)
        {

        }

        private void ChooseFolderFunc(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件夹";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if(string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示");
                    return;
                }
                selectedFolderPath = dialog.SelectedPath;
                RefreshListView();
                RefreshTreeView();
            }
        }

        //根据选择节点获得路径
        private string GetFolderPath()
        {
            TreeNode now = treeView1.SelectedNode;
            string thisPath = now.Text;
            disk = selectedFolderPath.Substring(0, 3);
            if (now != null)
            {
                TreeNode parentNode = now.Parent;
                while (parentNode != null)
                {
                    thisPath = parentNode.Text + @"\" + thisPath;
                    parentNode = parentNode.Parent;
                }
                thisPath = disk + thisPath;
            }
            return thisPath;
        }

        //树形结构图获取
        private void RefreshTreeView()
        {
            treeView1.Nodes.Clear();
            string disk = selectedFolderPath.Substring(0, 3);
            try
            {
                string[] nowFolders = Directory.GetDirectories(disk);
                LoadChildNode(null, nowFolders);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LoadChildNode(TreeNode root, string[] paths)
        {
            if (root == null)
            {
                foreach (string path in paths)
                {
                    string name = Path.GetFileName(path);
                    TreeNode folderNode = new TreeNode(name);
                    treeView1.Nodes.Add(folderNode);
                    if (selectedFolderPath.Contains(path)) //  && selectedFolderPath != path
                    {
                        string[] nowPaths = Directory.GetDirectories(path);
                        LoadChildNode(folderNode, nowPaths);
                    }
                }
            }
            else
            {
                foreach (string path in paths)
                {
                    string name = Path.GetFileName(path);
                    TreeNode folderNode = new TreeNode(name);
                    root.Nodes.Add(folderNode);
                    if (selectedFolderPath.Contains(path))
                    {
                            string[] nowPaths = Directory.GetDirectories(path);
                            LoadChildNode(folderNode, nowPaths);
                    }
                    root.Expand();
                }
            }
        }

        //展开继续检索树形结构图
        private void ExpandTreeView()
        {
            string thisPath = GetFolderPath();
            string[] folders = Directory.GetDirectories(thisPath);

            TreeNode selectedNode = treeView1.SelectedNode;
            selectedNode.Nodes.Clear();

            LoadChildNode(selectedNode, folders);

            selectedFolderPath = thisPath;

            RefreshListView();
        }

        //列表获取
        private void RefreshListView()
        {
            listView1.Clear();
            listView1.Columns.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("名称", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("类型", 120, HorizontalAlignment.Left);

            try
            {
                string[] files = Directory.GetFiles(selectedFolderPath);

                string[] folders = Directory.GetDirectories(selectedFolderPath);

                foreach (string folder in folders)
                {
                    string folderName = Path.GetFileName(folder);
                    ListViewItem folderItem = new ListViewItem(new string[] { folderName, "文件夹" });
                    listView1.Items.Add(folderItem);
                }

                foreach (string filePath in files)
                {
                    string fileName = Path.GetFileName(filePath);
                    string[] sep = fileName.Split('.');
                    ListViewItem fileItem = new ListViewItem(new string[] { fileName, sep[sep.Length-1]+"文件" });
                    listView1.Items.Add(fileItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.Message);
            }
        }

        private void TreeNodeDClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ExpandTreeView();
        }

        private void RefreshAll(object sender, EventArgs e)
        {
            RefreshListView();
            RefreshTreeView();
        }

        private void OpenAndRun(object sender, MouseEventArgs e)
        {
            ActivateFile();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            ActivateFile();
        }

        private void ActivateFile()
        {
            ListViewItem sel = listView1.SelectedItems[0];
            string name = sel.Text;
            string type = sel.SubItems[1].Text;
            string path = selectedFolderPath + @"\" + name;
            if (type == "文件夹")
            {
                return;
            }

            Process.Start(path);
        }
    }
}

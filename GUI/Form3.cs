using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treeView1.LineColor = Color.Gray;
            treeView1.HideSelection = false;
            create.Visible = false;

            treeView1.ExpandAll();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
        }







        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            var selected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;

            if (selected)
            {
                var font = e.Node.NodeFont ?? e.Node.TreeView.Font;
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                e.DrawDefault = true;
            }

        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            switch (e.Node.Text)
            {
                // Parent nodes {
                case ".NET Core":
                    create.Visible = false;
                    break;

                case "WPF":
                    create.Visible = false;
                    break;

                case "Windows Forms":
                    create.Visible = false;
                    break;

                case "Console Application":
                    create.Visible = false;
                    break;

                case "NodeJS":
                    create.Visible = false;
                    break;
                // }

                // .NET Core {

                // WPF {
                case "WPF with C#":
                    des.Text = "Windows Presentation Foundation(WPF), an open-source, graphical user interface library for Windows, that's part of the .NET Framework. XAML, C#";
                    title.Text = e.Node.Text;
                    create.Visible = true;
                    break;

                case "WPF with Visual Basic":
                    des.Text = "Windows Presentation Foundation(WPF), an open-source, graphical user interface library for Windows, that's part of the .NET Framework. XAML, Visual Basic";
                    title.Text = e.Node.Text;
                    create.Visible = true;
                    break;
                // }

                // Windows Forms {
                case "WinForms with C#":
                    des.Text = "Windows Forms(Winforms), an open-source, graphical user interface library for Windows, that's part of the .NET Framework. C#";
                    title.Text = e.Node.Text;
                    create.Visible = true;
                    break;

                case "WinForms with Visual Basic":
                    des.Text = "Windows Forms(Winforms), an open-source, graphical user interface library for Windows, that's part of the .NET Framework. Visual Basic";
                    title.Text = e.Node.Text;
                    create.Visible = true;
                    break;

                // }

                case "ASP.NET Web App":
                    des.Text = "ASP.NET, an open-source, server-side web-application library for web developement, that's part of the .NET Framework. C#";
                    title.Text = e.Node.Text;
                    create.Visible = true;
                    break;

                case "Blazor Web App":
                    des.Text = "Blazor, an open-source, server-side web-application library for web developement, that's part of the .NET Framework. C#";
                    title.Text = e.Node.Text;
                    create.Visible = true;
                    break;

                // Console Application {
                case "C# Console App":
                    des.Text = "Windows Console Application, a command line interface application with a text - input/output display, that's part of the .NET Framework. C#";
                    title.Text = e.Node.Text;
                    create.Visible = true;
                    break;

                case "F# Console App":
                    des.Text = "Windows Console Application, a command line interface application with a text - input/output display, that's part of the .NET Framework. F#";
                    title.Text = e.Node.Text;
                    create.Visible = true;
                    break;

                case "Visual Basic Console App":
                    des.Text = "Windows Console Application, a command line interface application with a text - input/output display, that's part of the .NET Framework. Visual Basic";
                    title.Text = e.Node.Text;
                    create.Visible = true;
                    break;
                // }

                // }

                case "Python Application":
                    des.Text = "Use built-in Python interpreter to create Desktop Applications.";
                    title.Text = e.Node.Text;
                    create.Visible = true;
                    break;

                case "Java Application":
                    des.Text = "Use built-in Java compiler to create Desktop Applications.";
                    title.Text = e.Node.Text;
                    create.Visible = true;
                    break;

                // NodeJS {
                case "Basic Node Project":
                    des.Text = "NodeJS, a JavaScript runtime for sever-side web developement.";
                    title.Text = e.Node.Text;
                    create.Visible = true;
                    break;

                case "Electron Application":
                    des.Text = "Electron, a Node package for developing Windows desktop applications with HTML/CSS/JS.";
                    title.Text = e.Node.Text;
                    create.Visible = true;
                    break;

                    //

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var openFolder = new CommonOpenFileDialog();
            openFolder.AllowNonFileSystemItems = true;
            openFolder.Multiselect = false;
            openFolder.IsFolderPicker = true;
            openFolder.Title = "Select folder";

            if (openFolder.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var dir = openFolder.FileName;
                path.Text = dir;
                this.WindowState = FormWindowState.Minimized;
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }

            // get all the directories in selected dirctory

        }

        private void create_Click(object sender, EventArgs e)
        {
            string projectType = treeView1.SelectedNode.Text;
            createProject(projectname.Text, path.Text, projectType);
        }

        void createProject(string name, string path, string type)
        {
            string projectlLoc = path + @"\" + name;
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(projectlLoc))
                {
                    MessageBox.Show("Folder already exists.", "Can't create project", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(projectlLoc);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(projectlLoc));

                injectFiles(projectlLoc, name, type);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Can't create project", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void injectFiles(string path, string name, string type)
        {
            string devstudioPfilecontents = "// DevStudio Project file // DO NOT DELETE OR MODIFY" +"{\"project\": {\"name\":\"" + name + "\",\"created\": \"" + DateTime.Now + "\",\"path\": \"" + path + "\"}}";
            MakeFile(name + ".devstudio", devstudioPfilecontents, path);
            bool dotnettypes = type == "WPF with C#" || type == "WPF with Visual Basic" || type == "WinForms with C#" || type == "WinForms with Visual Basic" || type == "ASP.NET Web App" || type == "Blazor Web App" || type == "ASP.NET Web App" || type == "C# Console App" || type == "F# Console App" || type == "Visual Basic Console App";
            if (dotnettypes)
            {
                // nothing needs to be done at project init because all the work is done by .NET Core
                Console.WriteLine("dotnet selected");
            }
            else {

            }
        }
    }
}
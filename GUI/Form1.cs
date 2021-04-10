using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
 using Microsoft.WindowsAPICodePack.Dialogs;
using ScintillaNET;
 using System.Collections.Generic;
using System.ComponentModel;
 using System.Runtime.InteropServices;
 /*
namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static void TabFileLocation(this object str, string a)
        {
            Console.WriteLine("lol works"); 
        }
    }

}*/

namespace GUI
{
    

    public partial class Form1 : Form
    {
        void log(object val)
        {

            Console.WriteLine(val);
        }

        Process cmdProcess = null;
        StreamWriter stdin = null;
 

        public Form1(string value1, string path1)
        {
             
            InitializeComponent();
  
 

            menuStrip1.Renderer = new MyRenderer();
            panel1.Visible = false;
 

            if (value1 != "")
            {
                Console.WriteLine(value1);
            }
            if (value1 == "") { 
            //do nothin
            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(value1);

                if (directoryInfo.Exists)
                {
                    treeView1.AfterSelect += treeView1_AfterSelect;
                    BuildTree(directoryInfo, treeView1.Nodes);
                }

            }
            if (path1 != "")
            {

                if (path1.EndsWith(".html"))
                {
                    generateTab(path1, "html");
                }
                else { generateTab(path1); }
               
            }
            else
            {
            }

        }

 
            ScintillaNET.Scintilla CodeArea;
        private Point DragStartPosition = Point.Empty;
 

 

        private void tabControl1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            Rectangle r = new Rectangle(DragStartPosition, Size.Empty);
            r.Inflate(SystemInformation.DragSize);

            TabPage tp = HoverTab();

            if (tp != null)
            {
                if (!r.Contains(e.X, e.Y))
                    tabControl1.DoDragDrop(tp, DragDropEffects.All);
            }
            DragStartPosition = Point.Empty;
        }


        private void tabControl1_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            TabPage hover_Tab = HoverTab();
            if (hover_Tab == null)
                e.Effect = DragDropEffects.None;
            else
            {
                if (e.Data.GetDataPresent(typeof(TabPage)))
                {
                    e.Effect = DragDropEffects.Move;
                    TabPage drag_tab = (TabPage)e.Data.GetData(typeof(TabPage));

                    if (hover_Tab == drag_tab) return;

                    Rectangle TabRect = tabControl1.GetTabRect(tabControl1.TabPages.IndexOf(hover_Tab));
                    TabRect.Inflate(-3, -3);
                    if (TabRect.Contains(tabControl1.PointToClient(new Point(e.X, e.Y))))
                    {
                        SwapTabPages(drag_tab, hover_Tab);
                        tabControl1.SelectedTab = drag_tab;
                    }
                }
            }
        }


        private TabPage HoverTab()
        {
            for (int index = 0; index <= tabControl1.TabCount - 1; index++)
            {
                if (tabControl1.GetTabRect(index).Contains(tabControl1.PointToClient(Cursor.Position)))
                    return tabControl1.TabPages[index];
            }
            return null;
        }


        private void SwapTabPages(TabPage tp1, TabPage tp2)
        {
            int Index1 = tabControl1.TabPages.IndexOf(tp1);
            int Index2 = tabControl1.TabPages.IndexOf(tp2);
            tabControl1.TabPages[Index1] = tp2;
            tabControl1.TabPages[Index2] = tp1;
        }


        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Add(directoryInfo.Name);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                curNode.Nodes.Add(file.FullName, file.Name);
            }
            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                BuildTree(subdir, curNode.Nodes);
            }
        }

        public void generateTab(string tabpath, string type = "txt")
        {


            /*var txtbox2 = new System.Windows.Forms.RichTextBox();
            txtbox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtbox2.Dock = System.Windows.Forms.DockStyle.Fill;
            txtbox2.Location = new System.Drawing.Point(3, 3);
            txtbox2.Size = new System.Drawing.Size(995, 553);
            txtbox2.TabIndex = 2;
            if (tabpath != "Untitled*")
            {
                //    txtbox2.Text = System.IO.File.ReadAllText(tabpath);

                using (BinaryReader br = new BinaryReader(File.Open(tabpath, FileMode.Open)))
                {
                    var data = br.ReadChars((int)br.BaseStream.Length);
                    StringBuilder sb = new StringBuilder();
                    foreach (char c in data)
                        if ((int)c > 0) sb.Append(c.ToString()); else sb.Append(".");
                    txtbox2.Text = sb.ToString();
                }

                log(System.IO.File.ReadAllBytes(tabpath).ToString());
            }
            txtbox2.BackColor = System.Drawing.Color.FromArgb(27, 28, 38);
            txtbox2.ForeColor = System.Drawing.Color.FromArgb(171, 178, 191);
            txtbox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            TabPage createdtabpage2 = new TabPage(Path.GetFileName(tabpath));
            createdtabpage2.Padding = new System.Windows.Forms.Padding(4);
            createdtabpage2.Name = Path.GetFileName(tabpath);
            tabControl1.SelectedTab = createdtabpage2;
            Console.WriteLine(tabControl1.SelectedIndex);
            Array fulltabsarray = tabControl1.TabPages.Cast<TabPage>().ToArray();
            foreach (var i in fulltabsarray)
            {
                if (i.ToString().Contains(createdtabpage2.ToString()))
                {
                    if (tabpath != "Untitled*")
                    {
                        tabControl1.TabPages.Remove(tabControl1.TabPages[Path.GetFileName(tabpath)]);
                        tabControl1.SelectedTab = tabControl1.TabPages[Path.GetFileName(tabpath)];
                    }
                }
            }
            createdtabpage2.BackColor = System.Drawing.Color.FromArgb(39, 41, 56);
            tabControl1.TabPages.Add(createdtabpage2);
            createdtabpage2.Controls.Add(txtbox2);

            txtbox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CSharp_syntaxHighlighting);
            
            





            tabControl1.SelectedTab = createdtabpage2;
            log(createdtabpage2.Controls);
            if (type == "html") {
                Button previewhtml = new Button();
                previewhtml.Text = "see";
                statusStrip1.Controls.Add(previewhtml);
            }*/






            // expiremental:

            CodeArea = new ScintillaNET.Scintilla();
            CodeArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            CodeArea.Dock = System.Windows.Forms.DockStyle.Fill;
            CodeArea.Location = new System.Drawing.Point(3, 3);
            CodeArea.Size = new System.Drawing.Size(995, 553);
            CodeArea.TabIndex = 2;
            if (tabpath != "Untitled*")
            {
                //    txtbox2.Text = System.IO.File.ReadAllText(tabpath);

                using (BinaryReader br = new BinaryReader(File.Open(tabpath, FileMode.Open)))
                {
                    var data = br.ReadChars((int)br.BaseStream.Length);
                    StringBuilder sb = new StringBuilder();
                    foreach (char c in data)
                        if ((int)c > 0) sb.Append(c.ToString()); else sb.Append(".");
                    CodeArea.Text = sb.ToString();
                }

                log(System.IO.File.ReadAllBytes(tabpath).ToString());
            }
            CodeArea.BackColor = System.Drawing.Color.FromArgb(27, 28, 38);
            CodeArea.WrapMode = ScintillaNET.WrapMode.None;
            CodeArea.IndentationGuides = IndentView.LookBoth;

            initCodeArea();


            CodeArea.ForeColor = System.Drawing.Color.FromArgb(171, 178, 191);
            CodeArea.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            TabPage createdtabpage2 = new TabPage(Path.GetFileName(tabpath));
            createdtabpage2.Padding = new System.Windows.Forms.Padding(4);
            createdtabpage2.Name = Path.GetFileName(tabpath);
            tabControl1.SelectedTab = createdtabpage2;
            Console.WriteLine(tabControl1.SelectedIndex);
            Array fulltabsarray = tabControl1.TabPages.Cast<TabPage>().ToArray();
            
            createdtabpage2.BackColor = System.Drawing.Color.FromArgb(39, 41, 56);
            tabControl1.TabPages.Add(createdtabpage2);
            createdtabpage2.Controls.Add(CodeArea);




            tabControl1.SelectedTab = createdtabpage2;
            log(createdtabpage2.Controls);
            if (type == "html")
            {
                Button previewhtml = new Button();
                previewhtml.Text = "see"; 
                statusStrip1.Controls.Add(previewhtml);

                //  log("html");
            }

            foreach (var i in fulltabsarray)
            {
                if (i.ToString().Contains(createdtabpage2.ToString()))
                {
                    if (tabpath != "Untitled*")
                    {
                        tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                        tabControl1.SelectedTab = tabControl1.TabPages[Path.GetFileName(tabpath)];
                    }
                }
            }


        }

        

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Node.Name != "")
            {

                //  newfile(Path.GetFileName(e.Node.Name));
                generateTab(e.Node.Name);

               
            }
           

        }

        private void newfile(string filelocation)
        {
        }


        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //new file event
            generateTab("Untitled*");

            /* var txtbox2 = new System.Windows.Forms.RichTextBox();
             txtbox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
             txtbox2.Dock = System.Windows.Forms.DockStyle.Fill;
             txtbox2.Location = new System.Drawing.Point(3, 3);
             txtbox2.Size = new System.Drawing.Size(995, 553);
             txtbox2.TabIndex = 2;
             txtbox2.Text = "";
             txtbox2.BackColor = System.Drawing.Color.FromArgb(39, 41, 56);
             txtbox2.ForeColor = System.Drawing.Color.White;

             TabPage createdtabpage = new TabPage(Path.GetFileName("untitled"));
             createdtabpage.Padding = new System.Windows.Forms.Padding(4);
             createdtabpage.BackColor = System.Drawing.Color.FromArgb(39, 41, 56);
             tabControl1.TabPages.Add(createdtabpage);
             createdtabpage.Controls.Add(txtbox2);
             tabControl1.SelectedTab = createdtabpage;*/

        }



        private void fileToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);

            var txtbox = new System.Windows.Forms.RichTextBox();
            txtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtbox.Dock = System.Windows.Forms.DockStyle.Fill;
            txtbox.Location = new System.Drawing.Point(3, 3);
            txtbox.Size = new System.Drawing.Size(995, 553);
            txtbox.TabIndex = 2;
            txtbox.Text = "";
            txtbox.BackColor = System.Drawing.Color.FromArgb(39, 41, 56);
            txtbox.ForeColor = System.Drawing.Color.White;



            TabPage myTabPage = new TabPage(Path.GetFileName(filePath));
            myTabPage.Padding = new System.Windows.Forms.Padding(4);
            myTabPage.BackColor = System.Drawing.Color.FromArgb(39, 41, 56);
            tabControl1.TabPages.Add(myTabPage);
            myTabPage.Controls.Add(txtbox);
            tabControl1.SelectedTab = myTabPage;

        }

        private void folderToolStripMenuItem1_Click(object sender, EventArgs e)
        {



            /*var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            CommonFileDialogResult result = dialog.ShowDialog();*/
            var openFolder = new CommonOpenFileDialog();
            openFolder.AllowNonFileSystemItems = true;
            openFolder.Multiselect = true;
            openFolder.IsFolderPicker = true;
            openFolder.Title = "Select folder";

            if (openFolder.ShowDialog() != CommonFileDialogResult.Ok)
            {
                MessageBox.Show("No Folder selected");
                return;
            }

            // get all the directories in selected dirctory
            var dirs = openFolder.FileNames.ToArray();

            //               System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
            Form1 form = new Form1(openFolder.FileName, "");
            form.Show();
            this.Hide();




        }



        private void lauchTheInstallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var m = new Form2();
            m.Show();
        }




        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void terminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }

        }






        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)

            {


                /*  while (!proc.StandardOutput.EndOfStream)
                  {
                      label4.Text = proc.StandardOutput.ReadLine();
                  }*/


                //   var startInfo = new ProcessStartInfo();
                //    label4.Text = startInfo.WorkingDirectory + ">";

                //    richTextBox1.Text = cmd.StandardOutput.ReadToEnd();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*frmCmdInOut myForm = new frmCmdInOut();
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel1.Controls.Add(myForm);
            myForm.Show();
            panel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            panel1.WrapContents = false;
            Show();*/
            /*var m = new frmCmdInOut();
            m.Show();*/
        }



        private void button6_Click_1(object sender, EventArgs e)
        {
            //start process
            richTextBox1.Text = "";
            button6.Enabled = false;
            StartCmdProcess();
            button7.Enabled = true;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (stdin.BaseStream.CanWrite)
                {
                    stdin.WriteLine("exit");
                    richTextBox1.Text = "";
                }
            }
            catch (Exception a)
            {
                string message = a.Message + "  You may need to start the terminal before running a command";
                string title = "Error:";
                MessageBox.Show(message, title);
            }
            button7.Enabled = false;
            button6.Enabled = true;
            cmdProcess?.Close();
        }


        private void StartCmdProcess()
        {
            int count = 0;
            var pStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                //Batch File Arguments = "/C START /b /WAIT testbatch1.bat",
                //Test: Arguments = "START /WAIT /K ipconfig /all",
                Arguments = "START /WAIT",
                WorkingDirectory = Environment.SystemDirectory,
                // WorkingDirectory = Application.StartupPath,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
            };

            cmdProcess = new Process
            {
                StartInfo = pStartInfo,
                EnableRaisingEvents = true,
                // Test without and with this
                // When SynchronizingObject is set, no need to BeginInvoke()
                //SynchronizingObject = this
            };

            cmdProcess.Start();
            cmdProcess.BeginErrorReadLine();
            cmdProcess.BeginOutputReadLine();
            stdin = cmdProcess.StandardInput;
            stdin.AutoFlush = true;

            cmdProcess.OutputDataReceived += (s, evt) =>
            {
                if (evt.Data != null)
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        count++;
                        richTextBox1.AppendText(evt.Data + Environment.NewLine);
                        //    if (count <= 2) {
                        //   richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.LastIndexOf(Environment.NewLine));
                        //    }

                    /*    try
                        {
                            richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.LastIndexOf(Environment.NewLine));
                        }
                        catch
                        {
                            //                 richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.LastIndexOf("\n"));
                        }
                        if (richTextBox1.Text.Contains(">")) { }
                        else
                        {
                            richTextBox1.AppendText(" > ");
                        }*/
                        richTextBox1.ScrollToCaret();
                        richTextBox1.SelectAll();
                //        
                        richTextBox1.SelectionProtected = true;
        //                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - 1);


                    }));

                }

            };

            cmdProcess.ErrorDataReceived += (s, evt) =>
            {

                if (evt.Data != null)
                {
                    BeginInvoke(new Action(() =>
                    {

                        MessageBox.Show(evt.Data + Environment.NewLine, "Command Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        richTextBox1.ScrollToCaret();

                    }));
                }

            };

            cmdProcess.Exited += (s, evt) =>
            {
                stdin?.Dispose();
                cmdProcess?.Dispose();
            };
        }

        private void textBox1_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBox1.Text == "clear" || textBox1.Text == "Clear")
                {
                    richTextBox1.Text = "";
                }
                if (stdin == null)
                {
                    richTextBox1.AppendText("Process not started" + Environment.NewLine);
                    return;
                }

                e.Handled = true;
                try
                {
                    if (stdin.BaseStream.CanWrite)
                    {
                        stdin.Write(textBox1.Text + Environment.NewLine);
                        stdin.WriteLine();
                        //       Console.WriteLine(pStartInfo.WorkingDirectory);
                    }
                }
                catch (Exception a)
                {
                    string message = a.Message + "  You may need to start the terminal before running a command";
                    string title = "Error:";
                    MessageBox.Show(message, title);
                }
                textBox1.Clear();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            generateTab("Untitled*");

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var textBox = (RichTextBox)tabControl1.SelectedTab.Controls["txtbox2"];
            MessageBox.Show(textBox.Text);
            /*string writeText = createdtabpage;  // Create a text string
            File.WriteAllText("filename.txt", writeText);  // Create a file and write the content of writeText to it

            string readText = File.ReadAllText("filename.txt");  // Read the contents of the file
            Console.WriteLine(readText);*/
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class   MyColors : ProfessionalColorTable
        {

            public override Color MenuItemSelected
            {
                get { return Color.FromArgb(200, 98, 140, 180); }
            }

            public override Color MenuItemBorder
            {
                get { return Color.Gray; }
            }
        }

        private void treeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.Visible == false)
            {
                treeView1.Visible = true;
            }
            else
            {
                treeView1.Visible = false;
            }
        }

        private void projectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var n = new Form3();
            n.Show();
        }


       
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
              /*  openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }*/
         ///       Console.WriteLine(filePath);
                System.IO.Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        Console.WriteLine(saveFileDialog1.FileName);
                    ///    Console.WriteLine(createdtabpage2.Controls.txtbox2.Text);
                        //       File.WriteAllLines("C:/", createdtabpage2.Controls.txtbox2);
                        myStream.Close();
                    }
                }

                
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var n = new Form3();
            n.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var n = new Form3();
            n.Show();
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var n = new Form1("","");
            n.Show();
        }

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            log(btn.Text);
        }

    
         

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 
 
    }
   
}

// 
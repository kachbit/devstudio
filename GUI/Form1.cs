using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace GUI
{
    public partial class Form1 : Form
    {
        Process cmdProcess = null;
        StreamWriter stdin = null;
 
        public Form1(string value1, string path1)
        {




            InitializeComponent();

            panel1.Visible = false;

            fileToolStripMenuItem.MouseEnter += OnMouseEnterfileToolStripMenuItem;
            fileToolStripMenuItem.MouseLeave += OnMouseLeavefileToolStripMenuItem;
           

       
            //  Process proc = Process.Start(startInfo);

            if (value1 != "") {
                Console.WriteLine(value1);
            }
            //newProjectToolStripMenuItem.ShowImageMargin = false;
            if (value1 == null || value1 == "" ) { } else { 
            DirectoryInfo directoryInfo = new DirectoryInfo(value1);
            
            if (directoryInfo.Exists)
            {
                treeView1.AfterSelect += treeView1_AfterSelect;
                BuildTree(directoryInfo, treeView1.Nodes);
            }

            

        }
            if (path1 != ""){
                var txtbox2 = new System.Windows.Forms.RichTextBox();
                txtbox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
                txtbox2.Dock = System.Windows.Forms.DockStyle.Fill;
                txtbox2.Location = new System.Drawing.Point(3, 3);
                txtbox2.Size = new System.Drawing.Size(995, 553);
                txtbox2.TabIndex = 2;
                txtbox2.Text = "";
                txtbox2.BackColor = System.Drawing.Color.FromArgb(39, 41, 56);
                txtbox2.ForeColor = System.Drawing.Color.White;
                TabPage createdtabpage2 = new TabPage(Path.GetFileName(path1));
                createdtabpage2.BackColor = System.Drawing.Color.FromArgb(39, 41, 56); ;
                tabControl1.TabPages.Add(createdtabpage2);
                createdtabpage2.Controls.Add(txtbox2);
                tabControl1.SelectedTab = createdtabpage2;

            }
            else { 
            }

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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            if (e.Node.Name != "") {

              //  newfile(Path.GetFileName(e.Node.Name));




                var txtbox2 = new System.Windows.Forms.RichTextBox();
                txtbox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
                txtbox2.Dock = System.Windows.Forms.DockStyle.Fill;
                txtbox2.Location = new System.Drawing.Point(3, 3);
                txtbox2.Size = new System.Drawing.Size(995, 553);
                txtbox2.TabIndex = 2;
                txtbox2.Text = "";
                txtbox2.BackColor = System.Drawing.Color.FromArgb(39, 41, 56);
                txtbox2.ForeColor = System.Drawing.Color.White;

                // Console.WriteLine(tabControl1.TabPages.Contains(createdtabpage2));
                // Console.WriteLine(createdtabpage2 == null);

                TabPage createdtabpage2 = new TabPage(Path.GetFileName(e.Node.Name));
                createdtabpage2.Padding = new System.Windows.Forms.Padding(4);
                createdtabpage2.Name = Path.GetFileName(e.Node.Name);
                tabControl1.SelectedTab = createdtabpage2;
                 Console.WriteLine(tabControl1.SelectedIndex);
                Array fulltabsarray = tabControl1.TabPages.Cast<TabPage>().ToArray();
                foreach (var i in fulltabsarray)
                {
                    if (i.ToString().Contains(createdtabpage2.ToString()))
                    {
                     //   tabControl1.TabPages.Remove["Path.GetFileName(e.Node.Name)"];
                        tabControl1.SelectedTab = tabControl1.TabPages[Path.GetFileName(e.Node.Name)];
                    }
                }
                createdtabpage2.BackColor = System.Drawing.Color.FromArgb(39, 41, 56);
                tabControl1.TabPages.Add(createdtabpage2);
                createdtabpage2.Controls.Add(txtbox2);

 

                //    tabControl1.TabPages.RemoveByKey("Welcome");

                /*
            //    Console.WriteLine(istab);
                 void checkistab(bool istab)
                {
                    Console.WriteLine(istab);
                }*/
                //     Console.WriteLine(isalreadytab());

                //    createdtabpage2.Padding = new System.Windows.Forms.Padding(4);
                /*   createdtabpage2.BackColor = System.Drawing.Color.FromArgb(39, 41, 56);
                       tabControl1.TabPages.Add(createdtabpage2);
                       createdtabpage2.Controls.Add(txtbox2);*/




                //   Console.WriteLine(createdtabpage2);  
            }
            //      Console.WriteLine(e.Node.Name);
            /*  if (e.Node.Name.EndsWith("txt"))
              {
                  this.richTextBox1.Clear();
                  StreamReader reader = new StreamReader(e.Node.Name);
                  this.richTextBox1.Text = reader.ReadToEnd();
                  reader.Close();
              }*/

        }

        private void newfile(string filelocation)
        {


            /*var txtbox2 = new System.Windows.Forms.RichTextBox();
            txtbox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtbox2.Dock = System.Windows.Forms.DockStyle.Fill;
            txtbox2.Location = new System.Drawing.Point(3, 3);
            txtbox2.Size = new System.Drawing.Size(995, 553);
            txtbox2.TabIndex = 2;
            txtbox2.Text = "";
            txtbox2.BackColor = System.Drawing.Color.FromArgb(39, 41, 56);
            txtbox2.ForeColor = System.Drawing.Color.White;

            // Console.WriteLine(tabControl1.TabPages.Contains(createdtabpage2));
            // Console.WriteLine(createdtabpage2 == null);
            TabPage createdtabpage2 = new TabPage(filelocation);
            createdtabpage2.Padding = new System.Windows.Forms.Padding(4);
            createdtabpage2.Name = filelocation;
            createdtabpage2.BackColor = System.Drawing.Color.FromArgb(39, 41, 56);
            tabControl1.TabPages.Add(createdtabpage2);
            createdtabpage2.Controls.Add(txtbox2);

            Array fulltabsarray = tabControl1.TabPages.Cast<TabPage>().ToArray();
            foreach (var i in fulltabsarray)
            {
                if (i.ToString().Contains(createdtabpage2.ToString()))
                {
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                    tabControl1.SelectedTab = tabControl1.TabPages[filelocation];
                }

            }
*/

        }


        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //new file event
            newfile("Untitled");

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
            panel1.Visible = true;
        }

     

        private void OnMouseEnterfileToolStripMenuItem(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = SystemColors.ControlText; // or Color.Red or whatever you want
        }
        private void OnMouseLeavefileToolStripMenuItem(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
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

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void installer1_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
        {

        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

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

            cmdProcess.OutputDataReceived += (s, evt) => {
                if (evt.Data != null)
                {
                    BeginInvoke(new MethodInvoker(() => {
                        richTextBox1.AppendText(evt.Data + Environment.NewLine);
                        richTextBox1.ScrollToCaret();
                    }));
                }
            };

            cmdProcess.ErrorDataReceived += (s, evt) => {
                
                    if (evt.Data != null)
                {
                    BeginInvoke(new Action(() => {
                        
                        MessageBox.Show(evt.Data + Environment.NewLine, "Command Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        richTextBox1.ScrollToCaret();
                        
                    }));
                }
                
            };

            cmdProcess.Exited += (s, evt) => {
                stdin?.Dispose();
                cmdProcess?.Dispose();
            };
        }

        private void textBox1_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBox1.Text == "clear" || textBox1.Text == "Clear") {
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
            var txtbox2 = new System.Windows.Forms.RichTextBox();
            txtbox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtbox2.Dock = System.Windows.Forms.DockStyle.Fill;
            txtbox2.Location = new System.Drawing.Point(3, 3);
            txtbox2.Size = new System.Drawing.Size(995, 553);
            txtbox2.TabIndex = 2;
            txtbox2.Text = "";
            txtbox2.BackColor = System.Drawing.Color.FromArgb(39, 41, 56);
            txtbox2.ForeColor = System.Drawing.Color.White;
            txtbox2.Name = "txtbox2";
            TabPage createdtabpage = new TabPage(Path.GetFileName("untitled"));
            createdtabpage.Padding = new System.Windows.Forms.Padding(4);
            createdtabpage.BackColor = System.Drawing.Color.FromArgb(39, 41, 56);
            tabControl1.TabPages.Add(createdtabpage);
            createdtabpage.Controls.Add(txtbox2);
            tabControl1.SelectedTab = createdtabpage;
            Console.WriteLine(createdtabpage.Controls);
            

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

    }
    }
 

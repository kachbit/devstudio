using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
// thank you soo much to Jimi on stack overflow
public partial class frmCmdInOut : Form
{
    Process cmdProcess = null;
    StreamWriter stdin = null;

    public frmCmdInOut() => InitializeComponent();

    private void MainForm_Load(object sender, EventArgs e)
    {
        rtbStdIn.Multiline = false;
        rtbStdIn.SelectionIndent = 20;
    }

    private void btnStartProcess_Click(object sender, EventArgs e)
    {
        btnStartProcess.Enabled = false;
        StartCmdProcess();
        btnEndProcess.Enabled = true;
        //stdin.Write((char)13);
    }

    private void btnEndProcess_Click(object sender, EventArgs e)
    {
        if (stdin.BaseStream.CanWrite)
        {
            stdin.WriteLine("exit");
        }
        btnEndProcess.Enabled = false;
        btnStartProcess.Enabled = true;
        cmdProcess?.Close();
    }

    private void rtbStdIn_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            if (stdin == null)
            {
                rtbStdErr.AppendText("Process not started" + Environment.NewLine);
                return;
            }

            e.Handled = true;
            try
            {
                if (stdin.BaseStream.CanWrite)
                {
                    stdin.Write(rtbStdIn.Text + Environment.NewLine);
                    stdin.WriteLine();
                    // To write to a Console app, just 
                    // stdin.WriteLine(rtbStdIn.Text); 
                }
            }
            catch(Exception a) {
                string message = a.Message + "  You may need to start the terminal before running a command";
                string title = "Error:";
                MessageBox.Show(message, title);
            }
            rtbStdIn.Clear();
        }
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
                    rtbStdOut.AppendText(evt.Data + Environment.NewLine);
                    rtbStdOut.ScrollToCaret();
                }));
            }
        };

        cmdProcess.ErrorDataReceived += (s, evt) => {
            if (evt.Data != null)
            {
                BeginInvoke(new Action(() => {
                    rtbStdErr.AppendText(evt.Data + Environment.NewLine);
                    rtbStdErr.ScrollToCaret();
                }));
            }
        };

        cmdProcess.Exited += (s, evt) => {
            stdin?.Dispose();
            cmdProcess?.Dispose();
        };
    }
}

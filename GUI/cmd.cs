using System;

namespace GUI
{
    partial class Form3
    {
        public void RunCmd(string program, string command) {
            /* & Use to separate multiple commands on one command line. Cmd.exe runs the first command, and then the second command.
            && Use to run the command following && only if the command preceding the symbol is successful. Cmd.exe runs the first command, and then runs the second command only if the first command completed successfully.
            || Use to run the command following || only if the command preceding || fails. Cmd.exe runs the first command, and then runs the second command only if the first command did not complete successfully (receives an error code greater than zero).*/

            // first parameter should be cmd.exe of powershell.exe

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = program;
            startInfo.Arguments = @"/C" + command;
            Console.WriteLine(command);
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        public void MakeFile(string name, string contents, string folder) {
            RunCmd("cmd.exe", "echo " + contents + ">" + folder + @"\" + name);
        }
    }

    partial class Form2
    {
        public void RunCmd(string program, string command)
        {
            /* & Use to separate multiple commands on one command line. Cmd.exe runs the first command, and then the second command.
            && Use to run the command following && only if the command preceding the symbol is successful. Cmd.exe runs the first command, and then runs the second command only if the first command completed successfully.
            || Use to run the command following || only if the command preceding || fails. Cmd.exe runs the first command, and then runs the second command only if the first command did not complete successfully (receives an error code greater than zero).*/

            // first parameter should be cmd.exe of powershell.exe

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = program;
            startInfo.Arguments = @"/C" + command;
            Console.WriteLine(command);
            process.StartInfo = startInfo;
            process.Start();
        }
        public void MakeFile(string name, string contents, string folder)
        {
            RunCmd("cmd.exe", "echo " + contents + ">" + folder + @"\" + name);
        }
    }

    partial class Form1
    {
        public void RunCmd(string program, string command)
        {
            /* & Use to separate multiple commands on one command line. Cmd.exe runs the first command, and then the second command.
            && Use to run the command following && only if the command preceding the symbol is successful. Cmd.exe runs the first command, and then runs the second command only if the first command completed successfully.
            || Use to run the command following || only if the command preceding || fails. Cmd.exe runs the first command, and then runs the second command only if the first command did not complete successfully (receives an error code greater than zero).*/

            // first parameter should be cmd.exe of powershell.exe

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = program;
            startInfo.Arguments = @"/C" + command;
            Console.WriteLine(command);
            process.StartInfo = startInfo;
            process.Start();
        }
        public void MakeFile(string name, string contents, string folder)
        {
            RunCmd("cmd.exe", "echo " + contents + ">" + folder + @"\" + name);
        }
    }
}
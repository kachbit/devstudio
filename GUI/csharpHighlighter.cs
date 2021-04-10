
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI
{
	partial class Form1
	{
		private void CSharp_syntaxHighlighting(object sender, EventArgs e)
		{

                RichTextBox controlSender = (RichTextBox)sender;

            string keywords = @"\b(public|private|partial|static|namespace|class|using|void|in)\b";
            MatchCollection keywordMatches = Regex.Matches(controlSender.Text, keywords);

            string statements = @"\b(while|if|for|foreach|else|switch)\b";
            MatchCollection statementsMatches = Regex.Matches(controlSender.Text, statements);

            // getting types/classes from the text 
            string types = @"\b(Console|System|this|bool|byte|sbyte|char|decimal|double|float|int|uint|nint|nuint|long|ulong|short|ushort|object|string|dynamic)\b";
            MatchCollection typeMatches = Regex.Matches(controlSender.Text, types);

            // getting comments (inline or multiline)
            string comments = @"(\/\/.+?$|\/\*.+?\*\/|(?s)/\*.*?\*/)";
            //     string comments = @"";

            MatchCollection commentMatches = Regex.Matches(controlSender.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = "(\".+?\"|\'.+?\')";
            MatchCollection stringMatches = Regex.Matches(controlSender.Text, strings);

            // saving the original caret position + forecolor
            int originalIndex = controlSender.SelectionStart;
            int originalLength = controlSender.SelectionLength;
            Color originalColor = Color.White;

            // MANDATORY - focuses a label before highlighting (avoids blinking)
            treeView1.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            controlSender.SelectionStart = 0;
            controlSender.SelectionLength = controlSender.Text.Length;
            controlSender.SelectionColor = originalColor;

            // scanning...
            foreach (Match m in keywordMatches)
            {
                controlSender.SelectionStart = m.Index;
                controlSender.SelectionLength = m.Length;
                controlSender.SelectionColor = Color.FromArgb(209, 160, 200);
            }

            foreach (Match m in statementsMatches)
            {
                controlSender.SelectionStart = m.Index;
                controlSender.SelectionLength = m.Length;
                controlSender.SelectionColor = Color.FromArgb(79, 175, 228);
            }

            foreach (Match m in typeMatches)
            {
                controlSender.SelectionStart = m.Index;
                controlSender.SelectionLength = m.Length;
                controlSender.SelectionColor = Color.DarkCyan;
            }


            foreach (Match m in commentMatches)
            {
                controlSender.SelectionStart = m.Index;
                controlSender.SelectionLength = m.Length;
                controlSender.SelectionColor = Color.FromArgb(87, 166, 74);
            }

            foreach (Match m in stringMatches)
            {
                controlSender.SelectionStart = m.Index;
                controlSender.SelectionLength = m.Length;
                controlSender.SelectionColor = Color.FromArgb(214, 157, 133);
            }

            // restoring the original colors, for further writing
            controlSender.SelectionStart = originalIndex;
            controlSender.SelectionLength = originalLength;
            controlSender.SelectionColor = originalColor;

            // giving back the focus
            controlSender.Focus();

        }
	}
}
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
using ScintillaNET.Demo.Utils;

namespace GUI
{
	partial class Form1
	{
		private void initCodeArea()
		{
            InitColors();
            InitSyntaxColoring();

            // NUMBER MARGIN
            InitNumberMargin();

            // BOOKMARK MARGIN
            InitBookmarkMargin();

            // CODE FOLDING MARGIN
            InitCodeFolding();

            // DRAG DROP
            InitDragDropFile();


            // INIT HOTKEYS
            InitHotkeys();

            CodeArea.CaretForeColor = Color.White;
    }


        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }



        private void InitColors()
        {
            // se

            CodeArea.SetSelectionBackColor(true, IntToColor(0x114D9C));

        }



        private void InitSyntaxColoring()
        {

            // Configure the default style
            CodeArea.StyleResetDefault();
            CodeArea.Styles[Style.Default].Font = "Consolas";
            CodeArea.Styles[Style.Default].Size = 10;
            CodeArea.Styles[Style.Default].BackColor = Color.FromArgb(27, 28, 38);
            CodeArea.Styles[Style.Default].ForeColor = IntToColor(0xFFFFFF);
            CodeArea.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            CodeArea.Styles[Style.Cpp.Identifier].ForeColor = IntToColor(0xD0DAE2);
            CodeArea.Styles[Style.Cpp.Comment].ForeColor = IntToColor(0xBD758B);
            CodeArea.Styles[Style.Cpp.CommentLine].ForeColor = IntToColor(0x40BF57);
            CodeArea.Styles[Style.Cpp.CommentDoc].ForeColor = IntToColor(0x2FAE35);
            CodeArea.Styles[Style.Cpp.Number].ForeColor = IntToColor(0xFFFF00);
            CodeArea.Styles[Style.Cpp.String].ForeColor = IntToColor(0xFFFF00);
            CodeArea.Styles[Style.Cpp.Character].ForeColor = IntToColor(0xE95454);
            CodeArea.Styles[Style.Cpp.Preprocessor].ForeColor = IntToColor(0x8AAFEE);
            CodeArea.Styles[Style.Cpp.Operator].ForeColor = IntToColor(0xE0E0E0);
            CodeArea.Styles[Style.Cpp.Regex].ForeColor = IntToColor(0xff00ff);
            CodeArea.Styles[Style.Cpp.CommentLineDoc].ForeColor = IntToColor(0x77A7DB);
            CodeArea.Styles[Style.Cpp.Word].ForeColor = IntToColor(0x48A8EE);
            CodeArea.Styles[Style.Cpp.Word2].ForeColor = IntToColor(0xF98906);
            CodeArea.Styles[Style.Cpp.CommentDocKeyword].ForeColor = IntToColor(0xB3D991);
            CodeArea.Styles[Style.Cpp.CommentDocKeywordError].ForeColor = IntToColor(0xFF0000);
            CodeArea.Styles[Style.Cpp.GlobalClass].ForeColor = IntToColor(0x48A8EE);

            CodeArea.Lexer = Lexer.Html;
            initHTMLlexer("a abbr address area article aside audio b base bdi bdo blockquote body br button canvas caption cite code col colgroup data datalist dd del details dfn dialog div dl dt em embed fieldset figcaption figure footer form h1 h2 h3 h4 h5 h6 head header hgroup hr html i iframe img input ins kbd label legend li link main map mark math menu menuitem meta meter nav noscript object ol optgroup option output p param picture pre progress q rb rp rt rtc ruby s samp script section select slot small source span strong sub summary sup svg table tbody td template textarea tfoot th thead time title tr track u ul var video wbr");
            CodeArea.Lexer = Lexer.Html;
            CodeArea.SetKeywords(1, "");
            // CodeArea.SetKeywords(0, "class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
            // CodeArea.SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");

        }

        private void initHTMLlexer(string v,         string w = "")
        {
            
            CodeArea.SetKeywords(0, v);
        }

        private const int BACK_COLOR = 0x2A211C;

        /// <summary>
        /// default text color of the text area
        /// </summary>
        private const int FORE_COLOR = 0xB7B7B7;

        /// <summary>
        /// change this to whatever margin you want the line numbers to show in
        /// </summary>
        private const int NUMBER_MARGIN = 1;

        /// <summary>
        /// change this to whatever margin you want the bookmarks/breakpoints to show in
        /// </summary>
        private const int BOOKMARK_MARGIN = 2;
        private const int BOOKMARK_MARKER = 2;

        /// <summary>
        /// change this to whatever margin you want the code folding tree (+/-) to show in
        /// </summary>
        private const int FOLDING_MARGIN = 3;

        /// <summary>
        /// set this true to show circular buttons for code folding (the [+] and [-] buttons on the margin)
        /// </summary>
        private const bool CODEFOLDING_CIRCULAR = true;
        private void InitNumberMargin()
        {

            CodeArea.Styles[Style.LineNumber].BackColor = Color.FromArgb(39, 41, 56);
            CodeArea.Styles[Style.LineNumber].ForeColor = Color.White;
            CodeArea.Styles[Style.IndentGuide].ForeColor = IntToColor(FORE_COLOR);
            CodeArea.Styles[Style.IndentGuide].BackColor = IntToColor(BACK_COLOR);

            var nums = CodeArea.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;

            CodeArea.MarginClick += TextArea_MarginClick;
        }

        private void TextArea_MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == BOOKMARK_MARGIN)
            {
                // Do we have a marker for this line?
                const uint mask = (1 << BOOKMARK_MARKER);
                var line = CodeArea.Lines[CodeArea.LineFromPosition(e.Position)];
                if ((line.MarkerGet() & mask) > 0)
                {
                    // Remove existing bookmark
                    line.MarkerDelete(BOOKMARK_MARKER);
                }
                else
                {
                    // Add bookmark
                    line.MarkerAdd(BOOKMARK_MARKER);
                }
            }
        }



        private void InitBookmarkMargin()
        {

            //TextArea.SetFoldMarginColor(true, IntToColor(BACK_COLOR));

            var margin = CodeArea.Margins[BOOKMARK_MARGIN];
            margin.Width = 0;
            margin.Sensitive = true;
            margin.Type = MarginType.Symbol;
            margin.Mask = (1 << BOOKMARK_MARKER);
            //margin.Cursor = MarginCursor.Arrow;

            var marker = CodeArea.Markers[BOOKMARK_MARKER];
            marker.Symbol = MarkerSymbol.Circle;
            marker.SetBackColor(IntToColor(0xFF003B));
            marker.SetForeColor(IntToColor(0x000000));
            marker.SetAlpha(100);

        }

        private void InitCodeFolding()
        {

            CodeArea.SetFoldMarginColor(true, Color.FromArgb(39, 41, 56));
            CodeArea.SetFoldMarginHighlightColor(true, Color.FromArgb(39, 41, 56));

            // Enable code folding
            CodeArea.SetProperty("fold", "1");
            CodeArea.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            CodeArea.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
            CodeArea.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;
            CodeArea.Margins[FOLDING_MARGIN].Sensitive = true;
            CodeArea.Margins[FOLDING_MARGIN].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                CodeArea.Markers[i].SetForeColor(IntToColor(BACK_COLOR)); // styles for [+] and [-]
                CodeArea.Markers[i].SetBackColor(IntToColor(FORE_COLOR)); // styles for [+] and [-]
            }

            // Configure folding markers with respective symbols
            CodeArea.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            CodeArea.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            CodeArea.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            CodeArea.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            CodeArea.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;
            CodeArea.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            CodeArea.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            CodeArea.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

        }

        public void InitDragDropFile()
        {

            CodeArea.AllowDrop = true;
            CodeArea.DragEnter += delegate (object sender, DragEventArgs e) {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            };
            CodeArea.DragDrop += delegate (object sender, DragEventArgs e) {

                // get file drop
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {

                    Array a = (Array)e.Data.GetData(DataFormats.FileDrop);
                    if (a != null)
                    {
                        string path = a.GetValue(0).ToString();
                    }
                }
            };

        }
        private void InitHotkeys()
        {


            // remove conflicting hotkeys from scintilla
            CodeArea.ClearCmdKey(Keys.Control | Keys.F);
            CodeArea.ClearCmdKey(Keys.Control | Keys.R);
            CodeArea.ClearCmdKey(Keys.Control | Keys.H);
            CodeArea.ClearCmdKey(Keys.Control | Keys.L);
            CodeArea.ClearCmdKey(Keys.Control | Keys.U);

        }



    }
}
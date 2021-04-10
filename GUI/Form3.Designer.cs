
namespace GUI
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("WPF with C#");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("WPF with Visual Basic");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("WPF", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("WinForms with C#");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("WinForms with Visual Basic");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Windows Forms", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("ASP.NET Web App");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Blazor Web App");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("C# Console App");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("F# Console App");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Visual Basic Console App");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Console Application", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode(".NET Core", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Python Application");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Java Application");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Basic Node Project");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Electron Application");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("NodeJS", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17});
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Project";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(-1, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type:";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.SystemColors.Window;
            this.treeView1.LineColor = System.Drawing.Color.White;
            this.treeView1.Location = new System.Drawing.Point(3, 113);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node2";
            treeNode1.Text = "WPF with C#";
            treeNode2.Name = "Node3";
            treeNode2.Text = "WPF with Visual Basic";
            treeNode3.Name = "Node1";
            treeNode3.Text = "WPF";
            treeNode4.Name = "Node5";
            treeNode4.Text = "WinForms with C#";
            treeNode5.Name = "Node6";
            treeNode5.Text = "WinForms with Visual Basic";
            treeNode6.Name = "Node4";
            treeNode6.Text = "Windows Forms";
            treeNode7.Name = "Node7";
            treeNode7.Text = "ASP.NET Web App";
            treeNode8.Name = "Node8";
            treeNode8.Text = "Blazor Web App";
            treeNode9.Name = "Node10";
            treeNode9.Text = "C# Console App";
            treeNode10.Name = "Node11";
            treeNode10.Text = "F# Console App";
            treeNode11.Name = "Node12";
            treeNode11.Text = "Visual Basic Console App";
            treeNode12.Name = "Node9";
            treeNode12.Text = "Console Application";
            treeNode13.Name = "Node0";
            treeNode13.SelectedImageKey = "(default)";
            treeNode13.Text = ".NET Core";
            treeNode14.Name = "Node13";
            treeNode14.Text = "Python Application";
            treeNode15.Name = "Node14";
            treeNode15.Text = "Java Application";
            treeNode16.Name = "Node16";
            treeNode16.Text = "Basic Node Project";
            treeNode17.Name = "Node17";
            treeNode17.Text = "Electron Application";
            treeNode18.Name = "Node15";
            treeNode18.Text = "NodeJS";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode18});
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(784, 393);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(252, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 368);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project Settings";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(0, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(787, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "_________________________________________________________________________________" +
    "_________________________________________________";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(800, 518);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
    }
}
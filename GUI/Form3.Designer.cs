
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
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("WPF with C#");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("WPF with Visual Basic");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("WPF", new System.Windows.Forms.TreeNode[] {
            treeNode37,
            treeNode38});
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("WinForms with C#");
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("WinForms with Visual Basic");
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Windows Forms", new System.Windows.Forms.TreeNode[] {
            treeNode40,
            treeNode41});
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("ASP.NET Web App");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Blazor Web App");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("C# Console App");
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("F# Console App");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Visual Basic Console App");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Console Application", new System.Windows.Forms.TreeNode[] {
            treeNode45,
            treeNode46,
            treeNode47});
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode(".NET Core", new System.Windows.Forms.TreeNode[] {
            treeNode39,
            treeNode42,
            treeNode43,
            treeNode44,
            treeNode48});
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("Python Application");
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("Java Application");
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("Basic Node Project");
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("Electron Application");
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("NodeJS", new System.Windows.Forms.TreeNode[] {
            treeNode52,
            treeNode53});
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.projectname = new System.Windows.Forms.TextBox();
            this.des = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.create = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            treeNode37.Name = "Node2";
            treeNode37.Text = "WPF with C#";
            treeNode38.Name = "Node3";
            treeNode38.Text = "WPF with Visual Basic";
            treeNode39.Name = "Node1";
            treeNode39.Text = "WPF";
            treeNode40.Name = "Node5";
            treeNode40.Text = "WinForms with C#";
            treeNode41.Name = "Node6";
            treeNode41.Text = "WinForms with Visual Basic";
            treeNode42.Name = "Node4";
            treeNode42.Text = "Windows Forms";
            treeNode43.Name = "Node7";
            treeNode43.Text = "ASP.NET Web App";
            treeNode44.Name = "Node8";
            treeNode44.Text = "Blazor Web App";
            treeNode45.Name = "Node10";
            treeNode45.Text = "C# Console App";
            treeNode46.Name = "Node11";
            treeNode46.Text = "F# Console App";
            treeNode47.Name = "Node12";
            treeNode47.Text = "Visual Basic Console App";
            treeNode48.Name = "Node9";
            treeNode48.Text = "Console Application";
            treeNode49.ImageIndex = -2;
            treeNode49.Name = "Node0";
            treeNode49.Text = ".NET Core";
            treeNode50.Name = "Node13";
            treeNode50.Text = "Python Application";
            treeNode51.Name = "Node14";
            treeNode51.Text = "Java Application";
            treeNode52.Name = "Node16";
            treeNode52.Text = "Basic Node Project";
            treeNode53.Name = "Node17";
            treeNode53.Text = "Electron Application";
            treeNode54.Name = "Node15";
            treeNode54.Text = "NodeJS";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode49,
            treeNode50,
            treeNode51,
            treeNode54});
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(784, 393);
            this.treeView1.TabIndex = 3;
            this.treeView1.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView1_DrawNode);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(48)))));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.path);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.projectname);
            this.groupBox1.Controls.Add(this.des);
            this.groupBox1.Controls.Add(this.title);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(252, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 302);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Project Location";
            // 
            // path
            // 
            this.path.BackColor = System.Drawing.Color.LightSlateGray;
            this.path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.path.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.path.ForeColor = System.Drawing.Color.White;
            this.path.Location = new System.Drawing.Point(16, 201);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(234, 21);
            this.path.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(256, 199);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Project Name";
            // 
            // projectname
            // 
            this.projectname.BackColor = System.Drawing.Color.LightSlateGray;
            this.projectname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.projectname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectname.ForeColor = System.Drawing.Color.White;
            this.projectname.Location = new System.Drawing.Point(15, 130);
            this.projectname.Name = "projectname";
            this.projectname.Size = new System.Drawing.Size(140, 21);
            this.projectname.TabIndex = 3;
            // 
            // des
            // 
            this.des.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.des.Location = new System.Drawing.Point(8, 64);
            this.des.Name = "des";
            this.des.Size = new System.Drawing.Size(488, 33);
            this.des.TabIndex = 1;
            this.des.Text = "...";
            // 
            // title
            // 
            this.title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.title.Cursor = System.Windows.Forms.Cursors.Default;
            this.title.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.title.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(0, 15);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(502, 32);
            this.title.TabIndex = 0;
            this.title.Text = "Select a project type";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // create
            // 
            this.create.BackColor = System.Drawing.Color.Black;
            this.create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.create.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.create.Location = new System.Drawing.Point(646, 446);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(108, 41);
            this.create.TabIndex = 6;
            this.create.Text = "Create";
            this.create.UseVisualStyleBackColor = false;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(800, 518);
            this.Controls.Add(this.create);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Project";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label des;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox projectname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button create;
    }
}
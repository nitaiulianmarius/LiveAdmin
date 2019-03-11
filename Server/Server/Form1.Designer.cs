namespace Server
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lockProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unlockProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lockScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unlockScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.logOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.getInfo = new System.Windows.Forms.Button();
            this.getProcessList = new System.Windows.Forms.Button();
            this.getLockedProcess = new System.Windows.Forms.Button();
            this.ShowHide = new System.Windows.Forms.Button();
            this.getImage = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView1.ForeColor = System.Drawing.SystemColors.Info;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(12, 46);
            this.listView1.Name = "listView1";
            this.listView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listView1.Size = new System.Drawing.Size(141, 418);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lockProcessToolStripMenuItem,
            this.unlockProcessToolStripMenuItem,
            this.toolStripSeparator2,
            this.lockScreenToolStripMenuItem,
            this.unlockScreenToolStripMenuItem,
            this.toolStripSeparator1,
            this.logOffToolStripMenuItem,
            this.shutdownToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 148);
            // 
            // lockProcessToolStripMenuItem
            // 
            this.lockProcessToolStripMenuItem.Name = "lockProcessToolStripMenuItem";
            this.lockProcessToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.lockProcessToolStripMenuItem.Text = "Lock process";
            this.lockProcessToolStripMenuItem.Click += new System.EventHandler(this.lockProcessToolStripMenuItem_Click);
            // 
            // unlockProcessToolStripMenuItem
            // 
            this.unlockProcessToolStripMenuItem.Name = "unlockProcessToolStripMenuItem";
            this.unlockProcessToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.unlockProcessToolStripMenuItem.Text = "Unlock process";
            this.unlockProcessToolStripMenuItem.Click += new System.EventHandler(this.unlockProcessToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // lockScreenToolStripMenuItem
            // 
            this.lockScreenToolStripMenuItem.Name = "lockScreenToolStripMenuItem";
            this.lockScreenToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.lockScreenToolStripMenuItem.Text = "Lock screen";
            this.lockScreenToolStripMenuItem.Click += new System.EventHandler(this.lockScreenToolStripMenuItem_Click);
            // 
            // unlockScreenToolStripMenuItem
            // 
            this.unlockScreenToolStripMenuItem.Name = "unlockScreenToolStripMenuItem";
            this.unlockScreenToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.unlockScreenToolStripMenuItem.Text = "Unlock screen";
            this.unlockScreenToolStripMenuItem.Click += new System.EventHandler(this.unlockScreenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // logOffToolStripMenuItem
            // 
            this.logOffToolStripMenuItem.Name = "logOffToolStripMenuItem";
            this.logOffToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.logOffToolStripMenuItem.Text = "Log off";
            this.logOffToolStripMenuItem.Click += new System.EventHandler(this.logOffToolStripMenuItem_Click);
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.shutdownToolStripMenuItem.Text = "Shutdown";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.shutdownToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pc.png");
            // 
            // getInfo
            // 
            this.getInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.getInfo.ForeColor = System.Drawing.Color.White;
            this.getInfo.Location = new System.Drawing.Point(159, 46);
            this.getInfo.Margin = new System.Windows.Forms.Padding(1);
            this.getInfo.Name = "getInfo";
            this.getInfo.Size = new System.Drawing.Size(107, 42);
            this.getInfo.TabIndex = 1;
            this.getInfo.Text = "Computer info >";
            this.getInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.getInfo.UseVisualStyleBackColor = false;
            this.getInfo.Click += new System.EventHandler(this.getInfo_Click);
            // 
            // getProcessList
            // 
            this.getProcessList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.getProcessList.ForeColor = System.Drawing.Color.White;
            this.getProcessList.Location = new System.Drawing.Point(159, 140);
            this.getProcessList.Margin = new System.Windows.Forms.Padding(1);
            this.getProcessList.Name = "getProcessList";
            this.getProcessList.Size = new System.Drawing.Size(107, 42);
            this.getProcessList.TabIndex = 2;
            this.getProcessList.Text = "Process list >";
            this.getProcessList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.getProcessList.UseVisualStyleBackColor = false;
            this.getProcessList.Click += new System.EventHandler(this.getProcessList_Click);
            // 
            // getLockedProcess
            // 
            this.getLockedProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.getLockedProcess.ForeColor = System.Drawing.Color.White;
            this.getLockedProcess.Location = new System.Drawing.Point(159, 234);
            this.getLockedProcess.Margin = new System.Windows.Forms.Padding(1);
            this.getLockedProcess.Name = "getLockedProcess";
            this.getLockedProcess.Size = new System.Drawing.Size(107, 42);
            this.getLockedProcess.TabIndex = 3;
            this.getLockedProcess.Text = "Locked process >";
            this.getLockedProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.getLockedProcess.UseVisualStyleBackColor = false;
            this.getLockedProcess.Click += new System.EventHandler(this.getLockedProcess_Click);
            // 
            // ShowHide
            // 
            this.ShowHide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ShowHide.ForeColor = System.Drawing.Color.White;
            this.ShowHide.Location = new System.Drawing.Point(159, 422);
            this.ShowHide.Margin = new System.Windows.Forms.Padding(1);
            this.ShowHide.Name = "ShowHide";
            this.ShowHide.Size = new System.Drawing.Size(107, 42);
            this.ShowHide.TabIndex = 4;
            this.ShowHide.Text = "Show / Hide >";
            this.ShowHide.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ShowHide.UseVisualStyleBackColor = false;
            this.ShowHide.Click += new System.EventHandler(this.ShowHide_Click);
            // 
            // getImage
            // 
            this.getImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.getImage.ForeColor = System.Drawing.Color.White;
            this.getImage.Location = new System.Drawing.Point(159, 328);
            this.getImage.Margin = new System.Windows.Forms.Padding(1);
            this.getImage.Name = "getImage";
            this.getImage.Size = new System.Drawing.Size(107, 42);
            this.getImage.TabIndex = 5;
            this.getImage.Text = "View screenshot";
            this.getImage.UseVisualStyleBackColor = false;
            this.getImage.Click += new System.EventHandler(this.getImage_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(272, 46);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(340, 420);
            this.listBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Idle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Connected computers";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(624, 477);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.getImage);
            this.Controls.Add(this.ShowHide);
            this.Controls.Add(this.getLockedProcess);
            this.Controls.Add(this.getProcessList);
            this.Controls.Add(this.getInfo);
            this.Controls.Add(this.listView1);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 515);
            this.MinimumSize = new System.Drawing.Size(287, 515);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Live admin - server";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button getInfo;
        private System.Windows.Forms.Button getProcessList;
        private System.Windows.Forms.Button getLockedProcess;
        private System.Windows.Forms.Button ShowHide;
        private System.Windows.Forms.Button getImage;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem lockProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unlockProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unlockScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

    }
}


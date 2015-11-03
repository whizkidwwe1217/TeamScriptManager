namespace GitTest
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
            this.btnAddWorkingCopy = new System.Windows.Forms.Button();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.txtWorkingPath = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnClone = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnListBranches = new System.Windows.Forms.Button();
            this.btnDiff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddWorkingCopy
            // 
            this.btnAddWorkingCopy.Location = new System.Drawing.Point(13, 13);
            this.btnAddWorkingCopy.Name = "btnAddWorkingCopy";
            this.btnAddWorkingCopy.Size = new System.Drawing.Size(112, 23);
            this.btnAddWorkingCopy.TabIndex = 0;
            this.btnAddWorkingCopy.Text = "Add a working copy";
            this.btnAddWorkingCopy.UseVisualStyleBackColor = true;
            this.btnAddWorkingCopy.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtb
            // 
            this.rtb.Location = new System.Drawing.Point(12, 82);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(932, 597);
            this.rtb.TabIndex = 1;
            this.rtb.Text = "";
            // 
            // txtWorkingPath
            // 
            this.txtWorkingPath.Location = new System.Drawing.Point(131, 15);
            this.txtWorkingPath.Name = "txtWorkingPath";
            this.txtWorkingPath.Size = new System.Drawing.Size(264, 20);
            this.txtWorkingPath.TabIndex = 2;
            this.txtWorkingPath.Text = "C:\\Users\\whizk\\Documents\\Trash";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(401, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnClone
            // 
            this.btnClone.Location = new System.Drawing.Point(869, 12);
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(75, 23);
            this.btnClone.TabIndex = 4;
            this.btnClone.Text = "Clone";
            this.btnClone.UseVisualStyleBackColor = true;
            this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(482, 14);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(381, 20);
            this.txtUrl.TabIndex = 5;
            this.txtUrl.Text = "http://wendell@main:1880/scm/git/jps";
            // 
            // btnListBranches
            // 
            this.btnListBranches.Location = new System.Drawing.Point(13, 42);
            this.btnListBranches.Name = "btnListBranches";
            this.btnListBranches.Size = new System.Drawing.Size(112, 23);
            this.btnListBranches.TabIndex = 6;
            this.btnListBranches.Text = "List Branches";
            this.btnListBranches.UseVisualStyleBackColor = true;
            this.btnListBranches.Click += new System.EventHandler(this.btnListFiles_Click);
            // 
            // btnDiff
            // 
            this.btnDiff.Location = new System.Drawing.Point(131, 41);
            this.btnDiff.Name = "btnDiff";
            this.btnDiff.Size = new System.Drawing.Size(113, 23);
            this.btnDiff.TabIndex = 7;
            this.btnDiff.Text = "Diff";
            this.btnDiff.UseVisualStyleBackColor = true;
            this.btnDiff.Click += new System.EventHandler(this.btnDiff_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 691);
            this.Controls.Add(this.btnDiff);
            this.Controls.Add(this.btnListBranches);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.btnClone);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtWorkingPath);
            this.Controls.Add(this.rtb);
            this.Controls.Add(this.btnAddWorkingCopy);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddWorkingCopy;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.TextBox txtWorkingPath;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnClone;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnListBranches;
        private System.Windows.Forms.Button btnDiff;
    }
}


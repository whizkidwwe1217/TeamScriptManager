namespace FileIntegrityVerifier
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
            this.btn1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.btn2 = new System.Windows.Forms.Button();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.btnVerify = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblOneSize = new System.Windows.Forms.Label();
            this.lblTwoSize = new System.Windows.Forms.Label();
            this.btnCalculateChecksum = new System.Windows.Forms.Button();
            this.txtChecksum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(527, 3);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(27, 23);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "...";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "File 2:";
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(53, 6);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(468, 20);
            this.txt1.TabIndex = 3;
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(527, 43);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(27, 23);
            this.btn2.TabIndex = 0;
            this.btn2.Text = "...";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(53, 45);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(468, 20);
            this.txt2.TabIndex = 3;
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(53, 103);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 4;
            this.btnVerify.Text = "&Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(215, 108);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 13);
            this.lblResult.TabIndex = 5;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(53, 84);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(501, 13);
            this.progressBar.TabIndex = 6;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(134, 103);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblOneSize
            // 
            this.lblOneSize.AutoSize = true;
            this.lblOneSize.Location = new System.Drawing.Point(50, 29);
            this.lblOneSize.Name = "lblOneSize";
            this.lblOneSize.Size = new System.Drawing.Size(80, 13);
            this.lblOneSize.TabIndex = 8;
            this.lblOneSize.Text = "No file selected";
            // 
            // lblTwoSize
            // 
            this.lblTwoSize.AutoSize = true;
            this.lblTwoSize.Location = new System.Drawing.Point(50, 68);
            this.lblTwoSize.Name = "lblTwoSize";
            this.lblTwoSize.Size = new System.Drawing.Size(80, 13);
            this.lblTwoSize.TabIndex = 8;
            this.lblTwoSize.Text = "No file selected";
            // 
            // btnCalculateChecksum
            // 
            this.btnCalculateChecksum.Location = new System.Drawing.Point(216, 102);
            this.btnCalculateChecksum.Name = "btnCalculateChecksum";
            this.btnCalculateChecksum.Size = new System.Drawing.Size(125, 23);
            this.btnCalculateChecksum.TabIndex = 9;
            this.btnCalculateChecksum.Text = "Calculate Checksum";
            this.btnCalculateChecksum.UseVisualStyleBackColor = true;
            this.btnCalculateChecksum.Click += new System.EventHandler(this.btnCalculateChecksum_Click);
            // 
            // txtChecksum
            // 
            this.txtChecksum.Location = new System.Drawing.Point(347, 104);
            this.txtChecksum.Name = "txtChecksum";
            this.txtChecksum.Size = new System.Drawing.Size(207, 20);
            this.txtChecksum.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 135);
            this.Controls.Add(this.txtChecksum);
            this.Controls.Add(this.btnCalculateChecksum);
            this.Controls.Add(this.lblTwoSize);
            this.Controls.Add(this.lblOneSize);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "File Integrity Verifier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblOneSize;
        private System.Windows.Forms.Label lblTwoSize;
        private System.Windows.Forms.Button btnCalculateChecksum;
        private System.Windows.Forms.TextBox txtChecksum;
    }
}


namespace UI
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
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.openCSVFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelFilesCreated = new System.Windows.Forms.Label();
            this.labelDirectories = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(460, 27);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(95, 23);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File Name :";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(97, 29);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(357, 20);
            this.textBoxFileName.TabIndex = 2;
            // 
            // openCSVFileDialog
            // 
            this.openCSVFileDialog.FileName = "openFileDialogCSV";
            // 
            // labelFilesCreated
            // 
            this.labelFilesCreated.AutoSize = true;
            this.labelFilesCreated.Location = new System.Drawing.Point(64, 72);
            this.labelFilesCreated.Name = "labelFilesCreated";
            this.labelFilesCreated.Size = new System.Drawing.Size(0, 13);
            this.labelFilesCreated.TabIndex = 3;
            // 
            // labelDirectories
            // 
            this.labelDirectories.AutoSize = true;
            this.labelDirectories.Location = new System.Drawing.Point(97, 103);
            this.labelDirectories.Name = "labelDirectories";
            this.labelDirectories.Size = new System.Drawing.Size(0, 13);
            this.labelDirectories.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 143);
            this.Controls.Add(this.labelDirectories);
            this.Controls.Add(this.labelFilesCreated);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBrowse);
            this.Name = "Form1";
            this.Text = "CSV Splitter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.OpenFileDialog openCSVFileDialog;
        private System.Windows.Forms.Label labelFilesCreated;
        private System.Windows.Forms.Label labelDirectories;
    }
}


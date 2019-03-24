namespace WindowsFormsApp1
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
            this.createDatabasebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createDatabasebutton
            // 
            this.createDatabasebutton.Location = new System.Drawing.Point(74, 65);
            this.createDatabasebutton.Name = "createDatabasebutton";
            this.createDatabasebutton.Size = new System.Drawing.Size(122, 23);
            this.createDatabasebutton.TabIndex = 0;
            this.createDatabasebutton.Text = "Create database";
            this.createDatabasebutton.UseVisualStyleBackColor = true;
            this.createDatabasebutton.Click += new System.EventHandler(this.createDatabaseButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 152);
            this.Controls.Add(this.createDatabasebutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create database";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createDatabasebutton;
    }
}


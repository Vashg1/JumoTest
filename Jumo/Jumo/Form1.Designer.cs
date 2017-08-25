namespace Jumo
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
            this.Process = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Process
            // 
            this.Process.Location = new System.Drawing.Point(297, 127);
            this.Process.Name = "Process";
            this.Process.Size = new System.Drawing.Size(91, 51);
            this.Process.TabIndex = 1;
            this.Process.Text = "Execute";
            this.Process.UseVisualStyleBackColor = true;
            this.Process.Click += new System.EventHandler(this.Process_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 471);
            this.Controls.Add(this.Process);
            this.Name = "Form1";
            this.Text = "Loan ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Process;
    }
}


namespace PerryHMK03
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
            this.ClickMe = new System.Windows.Forms.Button();
            this.PressMe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ClickMe
            // 
            this.ClickMe.Location = new System.Drawing.Point(16, 36);
            this.ClickMe.Margin = new System.Windows.Forms.Padding(4);
            this.ClickMe.Name = "ClickMe";
            this.ClickMe.Size = new System.Drawing.Size(171, 52);
            this.ClickMe.TabIndex = 0;
            this.ClickMe.Text = "Click Me";
            this.ClickMe.UseVisualStyleBackColor = true;
            this.ClickMe.Click += new System.EventHandler(this.ClickMe_Click);
            // 
            // PressMe
            // 
            this.PressMe.Location = new System.Drawing.Point(195, 36);
            this.PressMe.Margin = new System.Windows.Forms.Padding(4);
            this.PressMe.Name = "PressMe";
            this.PressMe.Size = new System.Drawing.Size(168, 52);
            this.PressMe.TabIndex = 1;
            this.PressMe.Text = "Press Me";
            this.PressMe.UseVisualStyleBackColor = true;
            this.PressMe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PressMe_MouseDown);
            this.PressMe.MouseLeave += new System.EventHandler(this.PressMe_MouseLeave);
            this.PressMe.MouseHover += new System.EventHandler(this.PressMe_MouseHover);
            this.PressMe.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PressMe_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 119);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 2;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(379, 164);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PressMe);
            this.Controls.Add(this.ClickMe);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Perry HMK03";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClickMe;
        private System.Windows.Forms.Button PressMe;
        private System.Windows.Forms.Label label1;
    }
}


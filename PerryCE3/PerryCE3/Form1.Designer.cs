namespace PerryCE3
{
    partial class CE3
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
            this.ContinentalBreakfastCheckBox = new System.Windows.Forms.CheckBox();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.NumberOfGuestsText = new System.Windows.Forms.TextBox();
            this.NumberOfNightsText = new System.Windows.Forms.TextBox();
            this.ReservationCostText = new System.Windows.Forms.TextBox();
            this.TaxText = new System.Windows.Forms.TextBox();
            this.TotalCostText = new System.Windows.Forms.TextBox();
            this.NumberOfGuestsLabel = new System.Windows.Forms.Label();
            this.NumberOfNightsLabel = new System.Windows.Forms.Label();
            this.ResevationCostLabel = new System.Windows.Forms.Label();
            this.TaxLabel = new System.Windows.Forms.Label();
            this.TotalCostLabel = new System.Windows.Forms.Label();
            this.KingRadioButton = new System.Windows.Forms.RadioButton();
            this.QueenRadioButton = new System.Windows.Forms.RadioButton();
            this.TwoDoublesRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // ContinentalBreakfastCheckBox
            // 
            this.ContinentalBreakfastCheckBox.AutoSize = true;
            this.ContinentalBreakfastCheckBox.Location = new System.Drawing.Point(13, 96);
            this.ContinentalBreakfastCheckBox.Name = "ContinentalBreakfastCheckBox";
            this.ContinentalBreakfastCheckBox.Size = new System.Drawing.Size(138, 18);
            this.ContinentalBreakfastCheckBox.TabIndex = 0;
            this.ContinentalBreakfastCheckBox.Text = "Continental Breakfast";
            this.ContinentalBreakfastCheckBox.UseVisualStyleBackColor = true;
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(13, 122);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(214, 28);
            this.CalculateButton.TabIndex = 1;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // NumberOfGuestsText
            // 
            this.NumberOfGuestsText.Location = new System.Drawing.Point(146, 12);
            this.NumberOfGuestsText.Name = "NumberOfGuestsText";
            this.NumberOfGuestsText.Size = new System.Drawing.Size(81, 21);
            this.NumberOfGuestsText.TabIndex = 2;
            // 
            // NumberOfNightsText
            // 
            this.NumberOfNightsText.Location = new System.Drawing.Point(146, 40);
            this.NumberOfNightsText.Name = "NumberOfNightsText";
            this.NumberOfNightsText.Size = new System.Drawing.Size(81, 21);
            this.NumberOfNightsText.TabIndex = 3;
            // 
            // ReservationCostText
            // 
            this.ReservationCostText.Location = new System.Drawing.Point(149, 158);
            this.ReservationCostText.Name = "ReservationCostText";
            this.ReservationCostText.ReadOnly = true;
            this.ReservationCostText.Size = new System.Drawing.Size(78, 21);
            this.ReservationCostText.TabIndex = 4;
            // 
            // TaxText
            // 
            this.TaxText.Location = new System.Drawing.Point(149, 186);
            this.TaxText.Name = "TaxText";
            this.TaxText.ReadOnly = true;
            this.TaxText.Size = new System.Drawing.Size(78, 21);
            this.TaxText.TabIndex = 5;
            // 
            // TotalCostText
            // 
            this.TotalCostText.Location = new System.Drawing.Point(149, 214);
            this.TotalCostText.Name = "TotalCostText";
            this.TotalCostText.ReadOnly = true;
            this.TotalCostText.Size = new System.Drawing.Size(78, 21);
            this.TotalCostText.TabIndex = 6;
            // 
            // NumberOfGuestsLabel
            // 
            this.NumberOfGuestsLabel.AutoSize = true;
            this.NumberOfGuestsLabel.Location = new System.Drawing.Point(39, 15);
            this.NumberOfGuestsLabel.Name = "NumberOfGuestsLabel";
            this.NumberOfGuestsLabel.Size = new System.Drawing.Size(101, 14);
            this.NumberOfGuestsLabel.TabIndex = 7;
            this.NumberOfGuestsLabel.Text = "Number of guests";
            // 
            // NumberOfNightsLabel
            // 
            this.NumberOfNightsLabel.AutoSize = true;
            this.NumberOfNightsLabel.Location = new System.Drawing.Point(40, 43);
            this.NumberOfNightsLabel.Name = "NumberOfNightsLabel";
            this.NumberOfNightsLabel.Size = new System.Drawing.Size(100, 14);
            this.NumberOfNightsLabel.TabIndex = 8;
            this.NumberOfNightsLabel.Text = "Number of nights";
            // 
            // ResevationCostLabel
            // 
            this.ResevationCostLabel.AutoSize = true;
            this.ResevationCostLabel.Location = new System.Drawing.Point(54, 161);
            this.ResevationCostLabel.Name = "ResevationCostLabel";
            this.ResevationCostLabel.Size = new System.Drawing.Size(89, 14);
            this.ResevationCostLabel.TabIndex = 9;
            this.ResevationCostLabel.Text = "Resevation cost";
            // 
            // TaxLabel
            // 
            this.TaxLabel.AutoSize = true;
            this.TaxLabel.Location = new System.Drawing.Point(91, 189);
            this.TaxLabel.Name = "TaxLabel";
            this.TaxLabel.Size = new System.Drawing.Size(52, 14);
            this.TaxLabel.TabIndex = 10;
            this.TaxLabel.Text = "Tax (9%)";
            // 
            // TotalCostLabel
            // 
            this.TotalCostLabel.AutoSize = true;
            this.TotalCostLabel.Location = new System.Drawing.Point(85, 217);
            this.TotalCostLabel.Name = "TotalCostLabel";
            this.TotalCostLabel.Size = new System.Drawing.Size(58, 14);
            this.TotalCostLabel.TabIndex = 11;
            this.TotalCostLabel.Text = "Total cost";
            // 
            // KingRadioButton
            // 
            this.KingRadioButton.AutoSize = true;
            this.KingRadioButton.Location = new System.Drawing.Point(13, 72);
            this.KingRadioButton.Name = "KingRadioButton";
            this.KingRadioButton.Size = new System.Drawing.Size(49, 18);
            this.KingRadioButton.TabIndex = 12;
            this.KingRadioButton.TabStop = true;
            this.KingRadioButton.Text = "King";
            this.KingRadioButton.UseVisualStyleBackColor = true;
            // 
            // QueenRadioButton
            // 
            this.QueenRadioButton.AutoSize = true;
            this.QueenRadioButton.Location = new System.Drawing.Point(68, 72);
            this.QueenRadioButton.Name = "QueenRadioButton";
            this.QueenRadioButton.Size = new System.Drawing.Size(60, 18);
            this.QueenRadioButton.TabIndex = 13;
            this.QueenRadioButton.TabStop = true;
            this.QueenRadioButton.Text = "Queen";
            this.QueenRadioButton.UseVisualStyleBackColor = true;
            // 
            // TwoDoublesRadioButton
            // 
            this.TwoDoublesRadioButton.AutoSize = true;
            this.TwoDoublesRadioButton.Location = new System.Drawing.Point(134, 72);
            this.TwoDoublesRadioButton.Name = "TwoDoublesRadioButton";
            this.TwoDoublesRadioButton.Size = new System.Drawing.Size(93, 18);
            this.TwoDoublesRadioButton.TabIndex = 14;
            this.TwoDoublesRadioButton.TabStop = true;
            this.TwoDoublesRadioButton.Text = "Two Doubles";
            this.TwoDoublesRadioButton.UseVisualStyleBackColor = true;
            // 
            // CE3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(239, 248);
            this.Controls.Add(this.TwoDoublesRadioButton);
            this.Controls.Add(this.QueenRadioButton);
            this.Controls.Add(this.KingRadioButton);
            this.Controls.Add(this.TotalCostLabel);
            this.Controls.Add(this.TaxLabel);
            this.Controls.Add(this.ResevationCostLabel);
            this.Controls.Add(this.NumberOfNightsLabel);
            this.Controls.Add(this.NumberOfGuestsLabel);
            this.Controls.Add(this.TotalCostText);
            this.Controls.Add(this.TaxText);
            this.Controls.Add(this.ReservationCostText);
            this.Controls.Add(this.NumberOfNightsText);
            this.Controls.Add(this.NumberOfGuestsText);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.ContinentalBreakfastCheckBox);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CE3";
            this.Text = "CE3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ContinentalBreakfastCheckBox;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.TextBox NumberOfGuestsText;
        private System.Windows.Forms.TextBox NumberOfNightsText;
        private System.Windows.Forms.TextBox ReservationCostText;
        private System.Windows.Forms.TextBox TaxText;
        private System.Windows.Forms.TextBox TotalCostText;
        private System.Windows.Forms.Label NumberOfGuestsLabel;
        private System.Windows.Forms.Label NumberOfNightsLabel;
        private System.Windows.Forms.Label ResevationCostLabel;
        private System.Windows.Forms.Label TaxLabel;
        private System.Windows.Forms.Label TotalCostLabel;
        private System.Windows.Forms.RadioButton KingRadioButton;
        private System.Windows.Forms.RadioButton QueenRadioButton;
        private System.Windows.Forms.RadioButton TwoDoublesRadioButton;
    }
}


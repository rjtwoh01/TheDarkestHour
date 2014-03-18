namespace The_Darkest_Hour.GUIForm
{
    partial class DarkestHourWindow
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.ClassLabel = new System.Windows.Forms.Label();
            this.CommandsBox = new System.Windows.Forms.TextBox();
            MessageFeed = new System.Windows.Forms.Label();
            this.BarBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BarBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.Location = new System.Drawing.Point(619, 12);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            // 
            // ClassLabel
            // 
            this.ClassLabel.Location = new System.Drawing.Point(619, 25);
            this.ClassLabel.Name = "ClassLabel";
            this.ClassLabel.Size = new System.Drawing.Size(35, 13);
            this.ClassLabel.TabIndex = 1;
            this.ClassLabel.Text = "Profession";
            // 
            // CommandsBox
            // 
            this.CommandsBox.Location = new System.Drawing.Point(12, 450);
            this.CommandsBox.Name = "CommandsBox";
            this.CommandsBox.Size = new System.Drawing.Size(600, 20);
            this.CommandsBox.TabIndex = 2;
            
            this.CommandsBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommandsBox_KeyDown);
            // 
            // MessageFeed
            // 
            MessageFeed.AutoSize = true;
            MessageFeed.Location = new System.Drawing.Point(12, 12);
            MessageFeed.MaximumSize = new System.Drawing.Size(600, 420);
            MessageFeed.MinimumSize = new System.Drawing.Size(600, 420);
            MessageFeed.Name = "MessageFeed";
            MessageFeed.Size = new System.Drawing.Size(600, 420);
            MessageFeed.TabIndex = 3;
            MessageFeed.Text = "GameFeed";
            // 
            // BarBox
            // 
            this.BarBox.Location = new System.Drawing.Point(620, 40);
            this.BarBox.MinimumSize = new System.Drawing.Size(100, 60);
            this.BarBox.Name = "BarBox";
            this.BarBox.Size = new System.Drawing.Size(154, 60);
            this.BarBox.TabIndex = 5;
            this.BarBox.TabStop = false;
            // 
            // DarkestHourWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 565);
            this.Controls.Add(this.BarBox);
            this.Controls.Add(MessageFeed);
            this.Controls.Add(this.CommandsBox);
            this.Controls.Add(this.ClassLabel);
            this.Controls.Add(this.NameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "DarkestHourWindow";
            this.Text = "The Darkest Hour";
            ((System.ComponentModel.ISupportInitialize)(this.BarBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label ClassLabel;
        private System.Windows.Forms.TextBox CommandsBox;
        private static System.Windows.Forms.Label MessageFeed;
        private System.Windows.Forms.PictureBox BarBox;
    }
}
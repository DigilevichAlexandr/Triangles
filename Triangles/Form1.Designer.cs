namespace Triangles
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            customrtb1 = new CustomRTB();
            button1 = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LawnGreen;
            panel1.Location = new Point(368, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(420, 426);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // customrtb1
            // 
            customrtb1.Location = new Point(12, 12);
            customrtb1.Name = "customrtb1";
            customrtb1.Size = new Size(350, 302);
            customrtb1.TabIndex = 0;
            customrtb1.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(12, 320);
            button1.Name = "button1";
            button1.Size = new Size(350, 118);
            button1.TabIndex = 0;
            button1.Text = "Нарисовать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(customrtb1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private CustomRTB customrtb1;
        private Button button1;
    }
}
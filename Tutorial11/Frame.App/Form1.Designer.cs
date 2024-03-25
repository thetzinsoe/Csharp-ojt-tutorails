namespace Frame.App
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
            rtxtTest = new RichTextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // rtxtTest
            // 
            rtxtTest.Location = new Point(169, 133);
            rtxtTest.Name = "rtxtTest";
            rtxtTest.Size = new Size(485, 96);
            rtxtTest.TabIndex = 0;
            rtxtTest.Text = "";
            rtxtTest.TextChanged += rtxtTest_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(276, 289);
            button1.Name = "button1";
            button1.Size = new Size(273, 69);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(rtxtTest);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtxtTest;
        private Button button1;
    }
}

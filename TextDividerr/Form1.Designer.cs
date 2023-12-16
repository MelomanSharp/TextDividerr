namespace TextDividerr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            button1 = new Button();
            Previous = new Button();
            Next = new Button();
            label1 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(26, 26);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(593, 235);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(26, 314);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(593, 235);
            richTextBox2.TabIndex = 1;
            richTextBox2.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(283, 276);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Divide";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Previous
            // 
            Previous.Location = new Point(199, 575);
            Previous.Name = "Previous";
            Previous.Size = new Size(75, 19);
            Previous.TabIndex = 3;
            Previous.Text = "Previous";
            Previous.UseVisualStyleBackColor = true;
            Previous.Visible = false;
            Previous.Click += button2_Click;
            // 
            // Next
            // 
            Next.Location = new Point(366, 574);
            Next.Name = "Next";
            Next.Size = new Size(75, 20);
            Next.TabIndex = 4;
            Next.Text = "Next";
            Next.UseVisualStyleBackColor = true;
            Next.Visible = false;
            Next.Click += Nrcy_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(307, 579);
            label1.Name = "label1";
            label1.Size = new Size(24, 15);
            label1.TabIndex = 5;
            label1.Text = "0/0";
            label1.Visible = false;
            // 
            // button3
            // 
            button3.Location = new Point(283, 611);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 6;
            button3.Text = "Options";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 649);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(Next);
            Controls.Add(Previous);
            Controls.Add(button1);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Flemming Text Divider";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private Button button1;
        private Button Previous;
        private Button Next;
        private Label label1;
        private Button button3;
    }
}
namespace WinFormsApp001
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
            btn_Bigbutton = new Button();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            button3 = new Button();
            btn_finish = new Button();
            SuspendLayout();
            // 
            // btn_Bigbutton
            // 
            btn_Bigbutton.Location = new Point(12, 12);
            btn_Bigbutton.Name = "btn_Bigbutton";
            btn_Bigbutton.Size = new Size(270, 212);
            btn_Bigbutton.TabIndex = 0;
            btn_Bigbutton.Text = "button1";
            btn_Bigbutton.UseVisualStyleBackColor = true;
            btn_Bigbutton.Click += btn_Bigbutton_Click_1;
            // 
            // button1
            // 
            button1.Location = new Point(288, 26);
            button1.Name = "button1";
            button1.Size = new Size(178, 184);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("맑은 고딕", 14F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(501, 35);
            button2.Name = "button2";
            button2.Size = new Size(152, 145);
            button2.TabIndex = 2;
            button2.Text = "절대 누르지 마세요~!!";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(90, 266);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(238, 23);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button3
            // 
            button3.Location = new Point(422, 256);
            button3.Name = "button3";
            button3.Size = new Size(148, 72);
            button3.TabIndex = 4;
            button3.Text = "내용 지우기 ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // btn_finish
            // 
            btn_finish.Location = new Point(168, 317);
            btn_finish.Name = "btn_finish";
            btn_finish.Size = new Size(179, 78);
            btn_finish.TabIndex = 5;
            btn_finish.Text = "튼종료버";
            btn_finish.UseVisualStyleBackColor = true;
            btn_finish.Click += btn_finish_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_finish);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btn_Bigbutton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Bigbutton;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Button button3;
        private Button btn_finish;
    }
}
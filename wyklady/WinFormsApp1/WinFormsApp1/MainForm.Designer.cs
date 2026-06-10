namespace WinFormsApp1
{
    partial class MainForm
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
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button1.Location = new Point(22, 72);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.Size = new Size(1228, 75);
            button1.TabIndex = 1;
            button1.Text = "Kliknij mnie";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OnClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 22);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(371, 45);
            label1.TabIndex = 0;
            label1.Text = "Witaj w Windows Forms!";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button2.Location = new Point(22, 155);
            button2.Name = "button2";
            button2.Size = new Size(1230, 75);
            button2.TabIndex = 2;
            button2.Text = "Okno stworzone w kodzie";
            button2.UseVisualStyleBackColor = true;
            button2.Click += OpenForm;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button3.Location = new Point(22, 317);
            button3.Name = "button3";
            button3.Size = new Size(1228, 75);
            button3.TabIndex = 4;
            button3.Text = "Lista osób";
            button3.UseVisualStyleBackColor = true;
            button3.Click += OpenPersonList;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button4.Location = new Point(24, 398);
            button4.Name = "button4";
            button4.Size = new Size(1228, 75);
            button4.TabIndex = 5;
            button4.Text = "Animacja piłeczki";
            button4.UseVisualStyleBackColor = true;
            button4.Click += OpenPong;
            // 
            // button5
            // 
            button5.Location = new Point(24, 236);
            button5.Name = "button5";
            button5.Size = new Size(1228, 75);
            button5.TabIndex = 3;
            button5.Text = "Kalkulator";
            button5.UseVisualStyleBackColor = true;
            button5.Click += OpenCalc;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(18F, 45F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PowderBlue;
            ClientSize = new Size(1264, 629);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Margin = new Padding(5);
            Name = "MainForm";
            Text = "Główne okno";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}

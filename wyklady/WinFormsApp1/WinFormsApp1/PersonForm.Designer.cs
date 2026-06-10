namespace WinFormsApp1
{
    partial class PersonForm
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
            txtName = new TextBox();
            txtAge = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnOk = new Button();
            btnAnuluj = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(118, 12);
            txtName.Name = "txtName";
            txtName.Size = new Size(797, 55);
            txtName.TabIndex = 0;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(118, 85);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(797, 55);
            txtAge.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(89, 48);
            label1.TabIndex = 2;
            label1.Text = "Imię";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 88);
            label2.Name = "label2";
            label2.Size = new Size(100, 48);
            label2.TabIndex = 3;
            label2.Text = "Wiek";
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(417, 162);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(245, 92);
            btnOk.TabIndex = 4;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += OnOk;
            // 
            // btnAnuluj
            // 
            btnAnuluj.DialogResult = DialogResult.Cancel;
            btnAnuluj.Location = new Point(668, 162);
            btnAnuluj.Name = "btnAnuluj";
            btnAnuluj.Size = new Size(247, 92);
            btnAnuluj.TabIndex = 5;
            btnAnuluj.Text = "Anuluj";
            btnAnuluj.UseVisualStyleBackColor = true;
            // 
            // PersonForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(20F, 48F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnAnuluj;
            ClientSize = new Size(927, 382);
            Controls.Add(btnAnuluj);
            Controls.Add(btnOk);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAge);
            Controls.Add(txtName);
            Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Margin = new Padding(6, 6, 6, 6);
            Name = "PersonForm";
            Text = "Wprowadź dane osoby";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtAge;
        private Label label1;
        private Label label2;
        private Button btnOk;
        private Button btnAnuluj;
    }
}
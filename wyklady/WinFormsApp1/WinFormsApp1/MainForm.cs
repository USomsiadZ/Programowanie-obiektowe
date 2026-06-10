namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, EventArgs e)
        {
            MessageBox.Show("Hello, world!");
        }

        private void OpenForm(object sender, EventArgs e)
        {
            Form form = new Form
            {
                Text = "Witaj w Windows Forms",
                Width = 600,
                Height = 500,
                Font = new Font("Segoe UI", 22)
            };

            Label label = new Label
            {
                Left = 20,
                Top = 20,
                AutoSize = true,
                Text = "Hello, World!"
            };
            form.Controls.Add(label);

            form.Show();
        }

        private void OpenPersonList(object sender, EventArgs e)
        {
            new PersonEditor().Show();
        }

        private void OpenPong(object sender, EventArgs e)
        {
            new PongForm().Show();
        }

        private void OpenCalc(object sender, EventArgs e)
        {
            Form form = new Form
            {
                Text = "Kalkulator",
                Width = 600,
                Height = 500,
                Font = new Font("Segoe UI", 22)
            };

            TextBox textBox1 = new TextBox
            {
                Left = 20,
                Top = 20,
                Width = 260
            };
            form.Controls.Add(textBox1);

            TextBox textBox2 = new TextBox
            {
                Left = 300,
                Top = 20,
                Width = 260
            };
            form.Controls.Add(textBox2);

            Button button = new Button
            {
                Text = "Oblicz sumê",
                Left = 20,
                Top = 100,
                AutoSize = true
            };
            form.Controls.Add(button);

            Label label = new Label
            {
                Left = 20,
                Top = 190,
                AutoSize = true,
                Text = "Wynik: "
            };
            form.Controls.Add(label);

            textBox1.Width = form.ClientSize.Width - 40;
            textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Left = 20;
            textBox2.Top = 20 + textBox1.Bounds.Bottom;
            textBox2.Width = form.ClientSize.Width - 40;
            textBox2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button.Top = 20 + textBox2.Bounds.Bottom;
            button.Anchor = AnchorStyles.Left;
            label.Top = 20 + button.Bounds.Bottom;
            label.Anchor = AnchorStyles.Left;


            button.Click += (sender, e) =>
            {
                // próbujemy przeparsowaæ obie wartoœci
                if (double.TryParse(textBox1.Text, out double num1) &&
                double.TryParse(textBox2.Text, out double num2))
                {
                    // obliczamy sumê
                    double suma = num1 + num2;
                    // wpisujemy wynik do kontrolki
                    label.Text = $"Wynik: {suma}";
                }
                else
                {
                    // Komunikat w razie niepowodzenia
                    label.Text = "WprowadŸ poprawne liczby.";
                }
            };


            form.Show();
        }
    }
}

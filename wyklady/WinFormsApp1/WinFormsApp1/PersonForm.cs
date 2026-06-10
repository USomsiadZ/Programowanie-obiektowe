using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class PersonForm : Form
    {
        public PersonForm()
        {
            InitializeComponent();
        }

        public PersonForm(Person person): this()
        {
            txtName.Text = person.Name;
            txtAge.Text = person.Age.ToString();
        }

        public Person Result { get; private set; }

        private void OnOk(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (!int.TryParse(txtAge.Text.Trim(), out int age))
            {
                MessageBox.Show("Wiek musi być liczbą całkowitą.");
                this.DialogResult = DialogResult.None; // Zablokuj zamknięcie
                return;
            }

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Imię nie może być puste.");
                this.DialogResult = DialogResult.None;
                return;
            }

            Result = new Person { Name = name, Age = age };
        }
    }
}

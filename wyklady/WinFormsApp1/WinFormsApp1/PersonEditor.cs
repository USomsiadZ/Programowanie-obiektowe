using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class PersonEditor : Form
    {
        public PersonEditor()
        {
            InitializeComponent();
        }

        private List<Person> people = new List<Person>
        {
            new Person { Name = "Anna", Age = 30 },
            new Person { Name = "Tomek", Age = 25 },
            new Person { Name = "Basia", Age = 40 }
        };

        private void OnLoad(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            listBox.Items.Clear();
            foreach (var person in people)
            {
                listBox.Items.Add(person);
            }
        }

        private void OnDodaj(object sender, EventArgs e)
        {
            //people.Add(new Person { Name = "Jan", Age = 21 });
            //RefreshList();

            PersonForm dlg = new PersonForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Person newPerson = dlg.Result;
                people.Add(newPerson);
                RefreshList();
            }
        }

        private void OnEdit(object sender, EventArgs e)
        {
            if (listBox.SelectedItem is not Person personToEdit)
            {
                MessageBox.Show("Wybierz osobę do edycji.");
                return;
            }

            PersonForm dlg = new PersonForm(personToEdit);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                personToEdit.Name = dlg.Result.Name;
                personToEdit.Age = dlg.Result.Age;

                int index = listBox.SelectedIndex;
                listBox.Items[index] = listBox.Items[index];
            }
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (listBox.SelectedItem is not Person selectedPerson)
            {
                MessageBox.Show("Najpierw wybierz osobę do usunięcia.");
                return;
            }

            // Potwierdzenie od użytkownika
            var result = MessageBox.Show(
                $"Czy na pewno chcesz usunąć {selectedPerson.Name} ({selectedPerson.Age} lat)?",
                "Potwierdzenie usunięcia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                people.Remove(selectedPerson);
                RefreshList();
            }
        }

        private void OnSave(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Pliki JSON (*.json)|*.json|Wszystkie pliki (*.*)|*.*";
                saveDialog.Title = "Zapisz listę osób";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = saveDialog.FileName;

                    // ... zapisujemy dane do pliku
                    try
                    {
                        string json = JsonSerializer.Serialize(people,
                                      new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(path, json);

                        //MessageBox.Show("Zapisano pomyślnie.", "Sukces",
                        //MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Błąd podczas zapisu:\n{ex.Message}", "Błąd",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void OnOpen(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Pliki JSON (*.json)|*.json|Wszystkie pliki (*.*)|*.*";
                openDialog.Title = "Wczytaj listę osób";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = openDialog.FileName;

                    try
                    {
                        string json = File.ReadAllText(path);
                        var loadedPeople = JsonSerializer.Deserialize<List<Person>>(json);

                        if (loadedPeople != null)
                        {
                            people = loadedPeople;
                            RefreshList();
                            //MessageBox.Show("Wczytano pomyślnie.", "Sukces",
                            //MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Nie udało się odczytać danych z pliku.", "Błąd",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Błąd podczas odczytu:\n{ex.Message}", "Błąd",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

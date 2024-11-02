using Microsoft.Win32;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GlassRegister
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<GlassType> glassTypes = new List<GlassType>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddGlassButton_Click(object sender, RoutedEventArgs e)
        {
            // Validează și adaugă un nou tip de sticlă
            if (string.IsNullOrEmpty(NameTextBox.Text) ||
                !float.TryParse(PriceTextBox.Text, out float price) ||
                !int.TryParse(ThicknessTextBox.Text, out int thickness) ||
                ColorComboBox.SelectedIndex == -1 ||
                WorkTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields correctly.");
                return;
            }

            GlassType glassType = new GlassType
            {
                Name = NameTextBox.Text,
                GlassColor = (GlassColorEnum)ColorComboBox.SelectedIndex,
                Price = new PriceType
                {
                    GlassWorkType = (GlassWorkTypeEnum)WorkTypeComboBox.SelectedIndex,
                    Price = price
                },
                Thickness = thickness
            };

            glassTypes.Add(glassType);
            GlassListBox.Items.Add(glassType.Name); // Afișează doar numele

            // Resetează câmpurile după adăugare
            ClearFields();
        }

        private void RemoveGlassButton_Click(object sender, RoutedEventArgs e)
        {
            if (GlassListBox.SelectedItem != null)
            {
                var selectedItem = GlassListBox.SelectedItem.ToString();
                glassTypes.RemoveAll(g => g.Name == selectedItem);
                GlassListBox.Items.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("Please select a glass type to remove.");
            }
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Import Glass Types"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string json = File.ReadAllText(openFileDialog.FileName);
                glassTypes = JsonConvert.DeserializeObject<List<GlassType>>(json);
                GlassListBox.Items.Clear();
                foreach (var glass in glassTypes)
                {
                    GlassListBox.Items.Add(glass.Name);
                }
                MessageBox.Show("Glass types imported successfully.");
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(glassTypes, Formatting.Indented);
            File.WriteAllText("glassTypes.json", json);
            MessageBox.Show("Data exported to glassTypes.json successfully!");
        }

        private void ClearFields()
        {
            NameTextBox.Clear();
            PriceTextBox.Clear();
            ThicknessTextBox.Clear();
            ColorComboBox.SelectedIndex = -1;
            WorkTypeComboBox.SelectedIndex = -1;
        }

        private void GlassListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (GlassListBox.SelectedItem != null)
            {
                var selectedName = GlassListBox.SelectedItem.ToString();
                var selectedGlass = glassTypes.Find(g => g.Name == selectedName);

                if (selectedGlass != null)
                {
                    NameTextBox.Text = selectedGlass.Name;
                    ColorComboBox.SelectedIndex = (int)selectedGlass.GlassColor;
                    WorkTypeComboBox.SelectedIndex = (int)selectedGlass.Price.GlassWorkType;
                    PriceTextBox.Text = selectedGlass.Price.Price.ToString();
                    ThicknessTextBox.Text = selectedGlass.Thickness.ToString();
                }
            }
        }
    }
}
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

namespace Orai0317
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class mainWindow : Window
    {
        public static List<Pet> petsLista = new();
        public DataGrid dgKedvencek;
        public mainWindow()
        {
            InitializeComponent();

            string allomany = "Allatok.txt";
            Beolvas(allomany);

            dgKedvencek = new()
            {
                Name = "dgKedvencek",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(10, 10, 10, 10),
                IsReadOnly = true,
                ItemsSource = petsLista,
            };

            Grid.SetRow(dgKedvencek, 1);
            stckpKijelzo.Children.Add(dgKedvencek);

        }

        private void Beolvas(string allomany)
        {
            try
            {
                using (StreamReader olvas = new(allomany))
                {
                    olvas.ReadLine();

                    while (!olvas.EndOfStream)
                    {
                        petsLista.Add(new Pet(olvas.ReadLine()));
                    }
                    MessageBox.Show("Sikeres beolvasás!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sikertelen beolvasás " + ex.Message);
            }

        }

        private void FelvetelClick(object sender, RoutedEventArgs e)
        {
            FelvetelWindow felvetelWindow = new(this);
            felvetelWindow.ShowDialog();
        }

        private void KijelentkezesClick(object sender, RoutedEventArgs e)
        {
            KijelentkezesWindow kijelentkezesWindow = new(this);
            kijelentkezesWindow.ShowDialog();
        }

        private void KilepesClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult eredmeny = MessageBox.Show("Biztos ki akarsz lépni?", "Kilépés", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (eredmeny == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
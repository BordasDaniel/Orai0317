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
    public partial class MainWindow : Window
    {
        static List<Pet> petsLista = new();
        public MainWindow()
        {
            InitializeComponent();

            string allomany = "Pets.txt";
            Beolvas(allomany);
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
    }
}
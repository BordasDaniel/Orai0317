using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Orai0317
{
    /// <summary>
    /// Interaction logic for KijelentkezesWindow.xaml
    /// </summary>
    public partial class KijelentkezesWindow : Window
    {
        private mainWindow mainWindow1;
        public KijelentkezesWindow(mainWindow mainWindow)
        {
            mainWindow1 = mainWindow;
            InitializeComponent();
        }

        private void KijelentkezesClick(object sender, RoutedEventArgs e)
        {
            bool Ellenorzes()
            {
                if (!string.IsNullOrEmpty(tbxNev.Text) &&
                    !string.IsNullOrEmpty(tbxFaj.Text) &&
                    !string.IsNullOrEmpty(tbxFajta.Text)
                    )
                {
                    return true;
                }
                return false;
            }

            if (!Ellenorzes())
            {
                MessageBox.Show("Minden mező kitöltése kötelező!");
                return;
            }

            foreach (Pet pet in mainWindow.petsLista)
            {
                if (pet.Nev == tbxNev.Text && pet.Faj == tbxFaj.Text && pet.Fajta == tbxFajta.Text)
                {
                    mainWindow.petsLista.Remove(pet);

                    mainWindow1.dgKedvencek.Items.Refresh();
                    MessageBox.Show("Sikeres kijelentkezés!");
                    return;
                }
            }
            MessageBox.Show("Nem található ilyen állat!");
        }

        private void MegseClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult eredmeny = MessageBox.Show("Biztos ki akarsz lépni?", "Kilépés", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (eredmeny == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}

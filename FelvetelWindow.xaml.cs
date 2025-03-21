using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for FelvetelWindow.xaml
    /// </summary>
    public partial class FelvetelWindow : Window
    {
        private mainWindow mainWindow1;
        public FelvetelWindow(mainWindow mainWindow)
        {
            InitializeComponent();
            mainWindow1 = mainWindow;
        }

        private void MegseClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult eredmeny = MessageBox.Show("Biztos ki akarsz lépni?", "Kilépés", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (eredmeny == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void FelvetelClick(object sender, RoutedEventArgs e)
        {
            // Ellenőrzi, hogy minden kötelező mező ki van-e töltve.
            bool Ellenorzes()
            {
                if (!string.IsNullOrEmpty(tbxNev.Text) &&
                    !string.IsNullOrEmpty(tbxFaj.Text) &&
                    !string.IsNullOrEmpty(tbxFajta.Text) &&
                    !string.IsNullOrEmpty(tbxNem.Text) &&
                    !string.IsNullOrEmpty(tbxSzin.Text) &&
                    !string.IsNullOrEmpty(dpSzul.Text.ToString()) &&
                    !string.IsNullOrEmpty(tbxSuly.Text)
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


            Pet ujKedvenc = new(tbxNev.Text, tbxFaj.Text, tbxFajta.Text, tbxNem.Text, tbxSzin.Text, DateTime.Parse(dpSzul.Text), int.Parse(tbxSuly.Text), tbxEtel.Text, tbxJatek.Text);

            mainWindow.petsLista.Add(ujKedvenc);
            mainWindow1.dgKedvencek.Items.Refresh();

            MessageBox.Show("Sikeres felvétel!");

        }

        // Regex kikötés
        private void tbxSuly_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tbx = sender as TextBox;

            Regex minta = new(@"\D");

            int pos = tbx.SelectionStart;
            tbx.Text = minta.Replace(tbx.Text, "");
            tbx.SelectionStart = pos;

        }
    }
}

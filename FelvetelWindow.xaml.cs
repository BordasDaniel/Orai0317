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
    /// Interaction logic for FelvetelWindow.xaml
    /// </summary>
    public partial class FelvetelWindow : Window
    {
        public FelvetelWindow()
        {
            InitializeComponent();
        }

        private void MegseClick(object sender, RoutedEventArgs e)
        {
            
            Close();
        }

        private void FelvetelClick(object sender, RoutedEventArgs e)
        {
            // A kötelező mezők ellenőrzése (HF)
            // Ha ki vannak töltve, akkor a Pet példány létrehozása
            Pet ujKedvenc = new(tbxNev.Text, tbxFaj.Text, tbxFajta.Text, tbxNem.Text, tbxSzin.Text, DateTime.Parse(dpSzul.Text), int.Parse(tbxSuly.Text), tbxEtel.Text, tbxJatek.Text);

            // Majd a példány hozzáadása a petsLista listához
            MainWindow.petsLista.Add(ujKedvenc);
            MessageBox.Show("Sikeres felvétel!");

            // Végül a felület bezárása
            Close();
        }
    }
}

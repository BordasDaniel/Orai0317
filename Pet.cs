using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orai0317
{
    public class Pet
    {

        public string Nev { get; set; }
        public string Faj { get; set; }
        public string Fajta { get; set; }
        public string Nem { get; set; }
        public string Szin { get; set; }
        public DateTime SzuletesiDatum { get; set; }
        public int Suly { get; set; }
        public string? KedvencÉtel { get; set; }
        public string? KedvencJáték { get; set; }

        /// <summary>
        /// Paraméter nélküli konstruktor.
        /// </summary>
        public Pet() { }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public Pet(string nev, string faj, string fajta, string nem, string szin, DateTime szuletesiDatum, int suly, string kedvencÉtel, string kedvencJáték)
        {
            Nev = nev;
            Faj = faj;
            Fajta = fajta;
            Nem = nem;
            Szin = szin;
            SzuletesiDatum = szuletesiDatum;
            Suly = suly;
            KedvencÉtel = kedvencÉtel;
            KedvencJáték = kedvencJáték;
        }

        /// <summary>
        /// A bemeneti állományt feldolgozó konstruktor.
        /// </summary>
        public Pet(string sor)
        {
            string[] adatok = sor.Split(';');
            Nev = adatok[0];
            Faj = adatok[1];
            Fajta = adatok[2];
            Nem = adatok[3];
            Szin = adatok[4];
            SzuletesiDatum = DateTime.Parse(adatok[5]);
            Suly = int.Parse(adatok[6]);
            KedvencÉtel = adatok[7];
            KedvencJáték = adatok[8];
        }

        public override string ToString()
        {
            return $"{Nev} {Faj} {Fajta} {Nem} {Szin} {SzuletesiDatum} {Suly} {KedvencÉtel} {KedvencJáték}";
        }

        /// <summary>
        /// Az állat életkorát számoló függvény.
        /// </summary>
        /// <returns>Az életkor egész évben.</returns>
        public int Eletkor()
        {
            //return (DateTime.Now.Day - SzuletesiDatum.Day)/365;
            if (DateTime.Now.Month < SzuletesiDatum.Month)
            {
                return DateTime.Now.Year - SzuletesiDatum.Year;
            }
            else if (DateTime.Now.Month > SzuletesiDatum.Month)
            {
                return DateTime.Now.Year - SzuletesiDatum.Year - 1;
            }
            else
            {
                if (DateTime.Now.Day <= SzuletesiDatum.Day)
                {
                    return DateTime.Now.Year - SzuletesiDatum.Year;
                }
                else
                {
                    return DateTime.Now.Year - SzuletesiDatum.Year - 1;

                }
            }
        }
    }
}


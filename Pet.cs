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
        public DateOnly SzuletesiDatum { get; set; }
        public int Suly { get; set; }
        public  string KedvencÉtel { get; set; }
        public string KedvencJáték { get; set; }

        public Pet(string nev, string faj, string fajta, string nem, string szin, DateOnly szuletesiDatum, int suly, string kedvencÉtel, string kedvencJáték)
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

        public Pet(string sor)
        {
            string[] adatok = sor.Split(';');
            Nev = adatok[0];
            Faj = adatok[1];
            Fajta = adatok[2];
            Nem = adatok[3];
            Szin = adatok[4];
            SzuletesiDatum = DateOnly.Parse(adatok[5]);
            Suly = int.Parse(adatok[6]);
            KedvencÉtel = adatok[7];
            KedvencJáték = adatok[8];
        }

        public override string ToString()
        {
            return $"{Nev} {Faj} {Fajta} {Nem} {Szin} {SzuletesiDatum} {Suly} {KedvencÉtel} {KedvencJáték}";
        }

    }



}

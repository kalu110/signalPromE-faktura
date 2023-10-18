
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SignalProm
{
    class Klijent
    {
        int id;
        string ime;
        string adresa;
        string pib;
        string racun;
        string tel;
        string faks;


        public Klijent(int id,
        string ime,
        string adresa,
        string pib,
        string racun,
        string tel,
        string faks)
        {
            this.id = id;
            this.ime = ime;
            this.adresa = adresa;
            this.pib = pib;
            this.racun = racun;
            this.tel = tel;
            this.faks = faks;
        }

        public int Id { get => id; set => id = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public string Pib { get => pib; set => pib = value; }
        public string Racun { get => racun; set => racun = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Faks { get => faks; set => faks = value; }

        protected void addKlijent(int id, string ime, string adresa, string pib, string racun, string tel, string faks)
        {
            var klijent = new Klijent(id, ime, adresa, pib, racun, tel, faks);
        }

    }
    

}
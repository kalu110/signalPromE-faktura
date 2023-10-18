using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProm
{
    class klijentSkr
    {
        public string usluga;
        public string jedmere;
        public string kol;
        public string cena;

       

        public klijentSkr(string usluga, string jedmere, string kol, string cena)
        {
            this.usluga = usluga;
            this.jedmere = jedmere;
            this.kol = kol;
            this.cena = cena;
        }


        public string Usluga { get => usluga; set => usluga = value; }
        public string Jedmere { get => jedmere; set => jedmere = value; }
        public string Kol { get => kol; set => kol = value; }
        public string Cena { get => cena; set => cena = value; }


        public void AddKlijent(string usluga, string jedmere, string kol, string cena) {
            List<klijentSkr> lista = new List<klijentSkr>();
            lista.Add(new klijentSkr(usluga, jedmere, kol, cena));
        }


        public void SeeKlijent(string html,List<klijentSkr>lista)
        {
            foreach (var row in lista) {
                html += row;
            }

        }



    }
}

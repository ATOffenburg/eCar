using e_Cars.Datenbank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Cars.UI.Kartenverwaltung
{
    public class KartenInfo
    {

        public Karte k { get; set; }
        public KartenInfo(Karte k)
        {
            this.k = k;
        }

        public int Karten_ID
        {
            get
            {
                return k.Karten_ID;
            }
            set
            {
                k.Karten_ID = value;
            }
        }

        public int Kunde_ID
        {
            get
            {
                return k.Kunde_ID;
            }
            set
            {
                k.Kunde_ID = value;
            }
        }

        public bool Aktiv
        {
            get
            {
                return k.Aktiv;
            }
            set
            {
                k.Aktiv = value;
            }
        }

        public Nullable<System.DateTime> Sperrdatum
        {
            get
            {
                return k.Sperrdatum;
            }
            set
            {
                k.Sperrdatum = value;
            }
        }


        public string Sperrvermerk
        {
            get
            {
                return k.Sperrvermerk;
            }
            set
            {
                k.Sperrvermerk = value;
            }
        }
    }
}
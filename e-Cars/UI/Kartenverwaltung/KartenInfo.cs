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
        /// <summary>
        /// Entity Objekt Karte
        /// </summary>
        public Karte k { get; set; }

        /// <summary>
        /// Konstruktor von KartenInfo
        /// </summary>
        /// <param name="k"></param>
        public KartenInfo(Karte k)
        {
            this.k = k;
        }

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Karten_ID
        /// </summary>
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

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Kunden_ID
        /// </summary>
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
        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Aktiv
        /// </summary>
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
        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Sperrdatum
        /// </summary>
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

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Sperrvermerk
        /// </summary>
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
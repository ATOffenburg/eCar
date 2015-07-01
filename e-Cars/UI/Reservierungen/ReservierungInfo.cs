using e_Cars.Datenbank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Cars.UI.Reservierungen
{
    /// <summary>
    /// Helfer Klasse für die daten einer Reservierung
    /// </summary>
    public class ReservierungInfo
    {

        /// <summary>
        /// Reservierung
        /// </summary>
        public Reservierung res { get; set; }
        /// <summary>
        /// Tankstelle
        /// </summary>
        public Tankstelle Abholort { get; set; }
        /// <summary>
        /// Tankstelle
        /// </summary>
        public Tankstelle Abgabeort { get; set; }

        /// <summary>
        /// Kunde
        /// </summary>
        public Kunde k { get; set; }

        /// <summary>
        /// Fahrzeug
        /// </summary>
        public Car c { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="res"></param>
        public ReservierungInfo(Reservierung res)
        {
            this.res = res;
            Abholort = res.Tankstelle1;
            Abgabeort = res.Tankstelle;
            c = res.Car;
            k = res.Kunde;

        }

        /// <summary>
        /// Gibt die Seriennummer des Fahrzeugs zurück. 
        /// </summary>
        public String Car
        {
            get { return c.Seriennummer; }
            set { }

        }

        /// <summary>
        /// Gibt die startzeit
        /// </summary>
        public DateTime Startzeit
        {
            get { return res.Startzeit; }
        }

        /// <summary>
        /// Gibt die Endzeit
        /// </summary>
        public DateTime? Endzeit
        {
            get { return res.Endzeit;  }
        }

        /// <summary>
        /// Gibt den Tankstellennamen
        /// </summary>
        public string AbholortName
        {
            get
            {
                if (Abholort != null)
                {
                    return Abholort.Name;
                }

                return null;
            }
        }

        /// <summary>
        /// Gibt den Tankstellennamen
        /// </summary>
        public string AbgabeortName
        {
            get
            {
                if (Abgabeort != null)
                {
                    return Abgabeort.Name;
                }
                return null;
            }
        }

        /// <summary>
        /// Zeitpunkt der Reservierung
        /// </summary>
        public DateTime Zeitstempel
        {
            get { return res.Zeitstempel; }
        }

        /// <summary>
        /// Gibt den Namen des Kunden
        /// </summary>
        public string KundeName
        {
            get
            {
                if (k != null)
                {
                    return k.Kunde_ID + " - " + k.Vorname + ", " + k.Name;
                }
                return null;
            }
        }

        /// <summary>
        /// Gibt die Seriennummer der Fahrzeugs
        /// </summary>
        public string CarSeriennummer
        {
            get
            {
                if (c != null)
                {
                    return c.Seriennummer;
                }
                return null;
            }
        }

    }
}

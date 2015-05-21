using e_Cars.Datenbank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Cars.UI.Tankstellen
{
    public class TankstelleInfo
    {
        /// <summary>
        /// Entity Objekt Tankstelle
        /// </summary>
        /// 
        public Tankstelle tankstelle { get; set; }

        /// <summary>
        /// Konstruktor von Tankstelleninfo
        /// </summary>
        /// <param name="t"></param>
        public TankstelleInfo(Tankstelle t)
        {
            this.tankstelle = t;
        }

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Tankstellen_ID
        /// </summary>
        public int ID
        {
            get
            {
                return tankstelle.Tankstelle_ID;
            }
            set
            {
                tankstelle.Tankstelle_ID = value;
            }
        }
        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Breitengrad
        /// </summary>
        public double? Breitengrad
        {
            get
            {
                return tankstelle.breitengrad;
            }
            set
            {
                tankstelle.breitengrad = value;
            }
        }
        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Längengrad
        /// </summary>
        public double? Längengrad
        {
            get
            {
                return tankstelle.laengengrad;
            }
            set
            {
                tankstelle.laengengrad = value;
            }
        }
        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von PLZ
        /// </summary>
        public string PLZ
        {
            get
            {
                return tankstelle.PLZ;
            }
            set
            {
                tankstelle.PLZ = value;
            }
        }

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Ort
        /// </summary>
        public string Ort
        {
            get
            {
                return tankstelle.Ort;
            }
            set
            {
                tankstelle.Ort = value;
            }
        }
        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Straße
        /// </summary>
        public string Strasse
        {
            get
            {
                return tankstelle.Stasse;
            }
            set
            {
                tankstelle.Stasse = value;
            }
        }
        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Tankstellen-Name
        /// </summary>
        public string Name
        {
            get
            {
                return tankstelle.Name;
            }
            set
            {
                tankstelle.Name = value;
            }
        }




    }
}

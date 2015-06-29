using e_Cars.Datenbank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Cars.UI.Kunden
{
    public class UserInfo
    {

        /// <summary>
        /// Entity Objekt Kunde
        /// </summary>
        public Kunde kunde { get; set; }

        /// <summary>
        /// Entity Objekt Adresse
        /// </summary>
        public Adresse adress { get; set; }

        /// <summary>
        /// Entity Objekt Bank
        /// </summary>
        public Bank bank { get; set; }

        /// <summary>
        /// Konstruktor UserInfo
        /// </summary>
        /// <param name="k"></param>
        public UserInfo(Kunde k)
        {
            if (k != null)
            {
                kunde = k;
                adress = kunde.Adresse;
                bank = kunde.Bank;
                if (kunde.FKopie == null)
                    Führerscheinkopie = false;
                else
                    Führerscheinkopie = true;
                
            }
        }

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Kunden_Name
        /// </summary>
        public String Name
        {
            get { return kunde.Name; }
        }

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Kunden_ID
        /// </summary>
        public String ID
        {
            get { return "" + kunde.Kunde_ID; }
        }

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Kunden_Vorname
        /// </summary>
        public String Vorname
        {
            get { return kunde.Vorname; }
        }

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von EMail
        /// </summary>
        public String Email
        {
            get { return kunde.Email; }
        }

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Passwort
        /// </summary>
        public String Passwort
        {
            get { return kunde.Passwort; }
        }

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Ort
        /// </summary>
        public String Ort
        {
            get { return adress.Ort; }
        }

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von PlZ
        /// </summary>
        public String PLZ
        {
            get { return adress.PLZ; }
        }

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Hausnummer
        /// </summary>
        public String Hausnummer
        {
            get { return adress.Hausnummer; }
        }

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Straße
        /// </summary>

        public String Strasse
        {
            get { return adress.Strasse; }
        }

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von BIC
        /// </summary>
        public String BIC
        {
            get { return bank.BIC; }
        }

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von IBAN
        /// </summary>
        public String IBAN
        {
            get { return bank.IBAN; }
        }

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von FKopie
        /// </summary>
        public byte[] FKopie
        {
            get { return kunde.FKopie; }

            set { kunde.FKopie = value; }
        }


        private bool führescheinkopie;

        /// <summary>
        /// Accessor-Methode für die Abfrage-Variable ob FKopie gefüllt ist oder nicht
        /// Dient für die Anzeige der Combo-Box in der UserOverview
        /// </summary>
        public bool Führerscheinkopie
        {
            get
            {
                return führescheinkopie;
            }
            set
            {
                führescheinkopie = value;
            }
        }

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Gesperrt
        /// </summary>
        public bool Gesperrt
        {
            get { return kunde.Gesperrt; }

            set { kunde.Gesperrt = value; }
        }

    }
}

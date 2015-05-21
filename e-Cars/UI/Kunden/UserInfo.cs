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
        public Kunde kunde { get; set; }
        public Adresse adress { get; set; }
        public Bank bank { get; set; }

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

        public String Name
        {
            get { return kunde.Name; }
        }

        public String Vorname
        {
            get { return kunde.Vorname; }
        }

        public String Email
        {
            get { return kunde.Email; }
        }

        public String Passwort
        {
            get { return kunde.Passwort; }
        }

        public String Ort
        {
            get { return adress.Ort; }
        }

        public String PLZ
        {
            get { return adress.PLZ; }
        }

        public String Hausnummer
        {
            get { return adress.Hausnummer; }
        }

        public String Strasse
        {
            get { return adress.Strasse; }
        }

        public String BIC
        {
            get { return bank.BIC; }
        }

        public String IBAN
        {
            get { return bank.IBAN; }
        }

        public byte[] FKopie
        {
            get { return kunde.FKopie; }

            set { kunde.FKopie = value; }
        }


        private bool führescheinkopie;

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

        public bool Gesperrt
        {
            get { return kunde.Gesperrt; }

            set { kunde.Gesperrt = value; }
        }

    }
}

using e_Cars.Datenbank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Cars.UI.Reservierungen
{
    public class ReservierungInfo
    {

        public Reservierung res { get; set; }
        public Tankstelle Abholort { get; set; }
        public Tankstelle Abgabeort { get; set; }

        public Kunde k { get; set; }


        public Car c { get; set; }

        public ReservierungInfo(Reservierung res)
        {
            this.res = res;
            Abholort = res.Tankstelle;
            Abgabeort = res.Tankstelle1;
            c = res.Car;
            k = res.Kunde;

        }

        public String Car
        {
            get { return c.Seriennummer; }
            set { }

        }

        public DateTime Startzeit
        {
            get { return res.Startzeit; }
        }

        public DateTime? Endzeit
        {
            get { return res.Endzeit;  }
        }

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

        public DateTime Zeitstempel
        {
            get { return res.Zeitstempel; }
        }

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

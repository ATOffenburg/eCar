using e_Cars.Datenbank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Cars.UI.Cars
{

    /// <summary>
    /// Helfer Klasse für die Daten zu einem Fahrzeug
    /// </summary>
    public class CarInfo
    {

        /// <summary>
        /// Konstruktor für CarInfo
        /// </summary>
        /// <param name="c"></param>
        public CarInfo(Car c)
        {
            // Todo hier noch die daten prüfen
            this.c = c;
            this.status = c.Status;
        }

        /// <summary>
        /// Hält das Car 
        /// </summary>
        public Car c { get; set; }

        public Status status { get; set;}

        /// <summary>
        /// die Seriennummer
        /// </summary>
        public string Seriennummer
        {
            get { return c.Seriennummer; }
            set { c.Seriennummer = value; }
        }

        /// <summary>
        /// Der Wartungstermin
        /// </summary>
        public string Wartungstermin
        {
            get
            {
                if (c.Wartungstermin.HasValue)
                {
                    return c.Wartungstermin.GetValueOrDefault().ToLongDateString();
                }
                return null;
            }
        }


        /// <summary>
        ///  Der Status
        /// </summary>
        public string Status
        {
            get
            {
                if (c.Status_ID != null)
                {
                    return c.Status_ID.GetValueOrDefault(0).ToString();
                }
                return null;
            }
        }

        /// <summary>
        ///  Der Status
        /// </summary>
        public string StatusText
        {
            get
            {
                if (status != null)
                {
                    return status.Statusbezeichnung;
                }
                return null;
            }
        }

        /// <summary>
        ///  Der Kilometer
        /// </summary>
        public string Kilometer
        {
            get
            {
                if (c.Kilometerstand.HasValue)
                {
                    return c.Kilometerstand.GetValueOrDefault().ToString();
                }
                return null;
            }
        }

        /// <summary>
        /// Die Batterieladung
        /// </summary>
        public string Batterieladung
        {
            get
            {
                if (c.Batterieladung.HasValue)
                {
                    return c.Batterieladung.GetValueOrDefault().ToString() + "%";
                }
                return null;
            }
        }

        /// <summary>
        /// Die Tankvorgänge
        /// </summary>
        public string Tankvorgaenge
        {
            get
            {
                return c.Tankvorgaenge.ToString();
            }
        }

        /// <summary>
        /// Das Gesperrtkennzeichen
        /// </summary>
        public bool Gesperrt
        {
            get
            {
                return c.Gesperrt.GetValueOrDefault(false);
            }
            // Wegen Binding mit der Oberfläche
            set { }
        }

        /// <summary>
        /// Das Reservierunggesperrtkennzeichen
        /// </summary>
        public bool ReservierungGesperrt
        {
            get
            {
                return c.ReservierungGesperrt.GetValueOrDefault(false);
            }
            // Wegen Binding mit der Oberfläche
            set { }
        }

        /// <summary>
        /// Das Spontanenutzunggesperrtkennzeichen
        /// </summary>
        public bool SpontaneNutzungGesperrt
        {
            get
            {
                return c.SpontaneNutzungGesperrt.GetValueOrDefault(false);
            }
            // Wegen Binding mit der Oberfläche
            set { }
        }


        /// <summary>
        /// Das Spontanenutzunggesperrtkennzeichen
        /// </summary>
        public bool Gestohlen
        {
            get
            {
                return c.Gestohlen.GetValueOrDefault(false);
            }
            // Wegen Binding mit der Oberfläche
            set { }
        }

    }
}

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

        public Tankstelle tankstelle { get; set; }
        public TankstelleInfo(Tankstelle t)
        {
            this.tankstelle = t;
        }

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

        public double? breitengrad
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

        public double? laengengrad
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

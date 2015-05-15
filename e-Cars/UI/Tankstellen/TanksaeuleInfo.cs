using e_Cars.Datenbank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Cars.UI.Tankstellen
{
    public class TanksaeuleInfo
    {
         public Tanksaeule tanksaeule { get; set; }
         public TanksaeuleInfo(Tanksaeule t)
        {
            this.tanksaeule = t;
        }

        public int Tanksaeulen_ID
        {
            get
            {
                return tanksaeule.Tanksaeule_ID;
            }
            set
            {
                tanksaeule.Tanksaeule_ID = value;
            }
        }

        public int Tankstelle_ID
        {
            get
            {
                return tanksaeule.Tankstelle_ID;
            }
            set
            {
                tanksaeule.Tankstelle_ID = value;
            }
        }

        public int Tanksaeulen_Nr
        {
            get
            {
                return tanksaeule.Tanksaeule_Nr;
            }
            set
            {
                tanksaeule.Tanksaeule_Nr = value;
            }
        }

        public int? Car_ID
        {
            get
            {
                return tanksaeule.Car_ID;
            }
            set
            {
                tanksaeule.Car_ID = value;
            }
        }


    }
}

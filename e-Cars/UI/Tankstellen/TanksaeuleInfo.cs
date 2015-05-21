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
        /// <summary>
        /// Entity Objekt Tanksäule
        /// </summary>
        public Tanksaeule tanksaeule { get; set; }
        /// <summary>
        /// Konstruktor TanksäulenInfo
        /// </summary>
        /// <param name="t"></param>
        public TanksaeuleInfo(Tanksaeule t)
        {
            this.tanksaeule = t;
        }

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Tanksäule_ID
        /// </summary>
        public int Tanksäule_ID
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

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Tankstelle_ID
        /// </summary>
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

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Tankstellen_Nr
        /// </summary>
        public int Nr
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

        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Car_ID
        /// </summary>
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

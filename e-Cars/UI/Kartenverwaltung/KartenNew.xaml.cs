using e_Cars.Datenbank;
using e_Cars.nunithelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace e_Cars.UI.Kartenverwaltung
{
    /// <summary>
    /// Interaktionslogik für KartenNew.xaml
    /// </summary>
    public partial class KartenNew : Window, INotifyPropertyChanged
    {
        /// <summary>
        /// Accessor Methode für mw
        /// </summary>
        MainWindow mw { get; set; }

        /// <summary>
        /// Ein wichtiges globales Objekt das später nach der Anlage der Karte zu kAngelegt kopiert wird
        /// </summary>
        private KartenInfo ki { get; set; }

        /// <summary>
        /// hier wird eine DB Connection übergeben die dann lokal gespeichert wird
        /// </summary>
        public Projekt2Entities connect = null;

        /// <summary>
        /// Konstruktor KartenNew
        /// </summary>
        /// <param name="mw"></param>
        /// Mainwindow
        /// <param name="con"></param>
        /// Die DB Connection
        public KartenNew(MainWindow mw, Projekt2Entities con)
        {

            this.mw = mw;
            this.ki = new KartenInfo(new Karte());
            ki.Aktiv = true;

            this.DataContext = this;

            connect = con;

            if (!UnitTestDetector.IsRunningFromNunit)
            {
                InitializeComponent();
            }

        }

        /// <summary>
        /// Schließt das Window und kehrt somit zur Overview zurück
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        /// <summary>
        /// Accessor Methode für Karten_ID 
        /// U.a Benötigt für das Füllen des Objekt ki
        /// </summary>
        public int Karten_ID
        {
            get
            {
                return ki.Karten_ID;
            }

            set
            {
                ki.Karten_ID = value;
                NotifyPropertyChanged("Karten_ID");
            }
        }

        /// <summary>
        /// Accessor Methode für Kunde_ID 
        /// U.a Benötigt für das Füllen des Objekt ki
        /// </summary>
        public int Kunde_ID
        {
            get
            {
                return ki.Kunde_ID;

            }
            set
            {
                ki.Kunde_ID = value;
                NotifyPropertyChanged("Kunde_ID");
            }
        }

        /// <summary>
        /// Accessor Methode für das "Aktiv" Feld 
        /// U.a Benötigt für das Füllen des Objekt ki
        /// </summary>
        public bool Aktiv
        {
            get
            {
                return ki.Aktiv;
            }
            set
            {
                ki.Aktiv = value;
                NotifyPropertyChanged("Aktiv");
            }
        }
        /// <summary>
        /// Accessor Methode für Sperrdatum 
        /// U.a Benötigt für das Füllen des Objekt ki
        /// </summary>
        public Nullable<System.DateTime> Sperrdatum
        {
            get
            {
                return ki.Sperrdatum;
            }
            set
            {
                ki.Sperrdatum = value;
                NotifyPropertyChanged("Sperrdatum");
            }
        }

        /// <summary>
        /// Accessor Methode für Sperrvermerk 
        /// U.a Benötigt für das Füllen des Objekt ki
        /// </summary>
        public String Sperrvermerk
        {
            get
            {
                return ki.Sperrvermerk;
            }
            set
            {
                ki.Sperrvermerk = value;
                NotifyPropertyChanged("Sperrvermerk");
            }
        }
        /// <summary>
        /// Delegate für die Oberflächenaktualisierung
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// sobald sich das eins der Accesor-Methoden ändert wird diese Methode getriggert
        /// </summary>
        /// <param name="info"></param>
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }


        /// <summary>
        /// Checked die Eingabefelder auf Ihre Richtigkeit
        /// </summary>
        /// <returns></returns>
        public bool checkData()
        {
            bool bData = false;

            if (Kunde_ID == 0)
            {
                bData = true;
            }

            return bData;
        }

        /// <summary>
        /// Gibt an ob eine Karte angelegt wurde. Dann kann die Liste in KartenOverview
        /// aktualisiert werden
        /// </summary>
        public bool sthChanged = false;

        /// <summary>
        /// Hier werden die Daten gespeichert. Wird aufgerufen sobald der Speichern Button betätigt wird.
        /// </summary>
        public void saveOperation()
        {
            Karte ka = new Karte();

            ka.Karten_ID = ki.Karten_ID;
            ka.Kunde_ID = ki.Kunde_ID;
            ka.Aktiv = ki.Aktiv;
            ka.Sperrdatum = ki.Sperrdatum;
            ka.Sperrvermerk = ki.Sperrvermerk;

            connect.Karte.Add(ka);

            connect.SaveChanges();
            Karten_ID = ka.Karten_ID;
            kAngelegt = ki;
            sthChanged = true;
        }

        /// <summary>
        /// Speichert die neue Karte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (checkData())
            {
                MessageBox.Show("Die Daten müssen vollständig sein bevor sie gespeichert werden können.");
                return;
            }

            saveOperation();
            MessageBox.Show("Die Karte wurde erfolgreich angelegt");
 
        }

        /// <summary>
        /// Globale Variable zum Aktualiseren der Liste in KartenOverview
        /// </summary>
        public KartenInfo kAngelegt = null;

        /// <summary>
        /// Löscht die Inhalte der einzelnen Textboxes
        /// </summary>
        public void clearFields()
        {            
            ki = new KartenInfo(new Karte());

            //   Karten_ID = 0;
            // TBKart_ID = null;
            Kunde_ID = 0;
            //  TBKund_ID.Text = null;
            Aktiv = true;
            Sperrdatum = null;
            Sperrvermerk = "";

        }

        /// <summary>
        /// Startet clearFields()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            clearFields();
        }


    }
}

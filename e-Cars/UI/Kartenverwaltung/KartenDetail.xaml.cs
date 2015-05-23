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
    /// Interaktionslogik für KartenDetail.xaml
    /// </summary>
    public partial class KartenDetail : Window, INotifyPropertyChanged
    {
        /// <summary>
        /// Accessor Methode für mw
        /// </summary>
        MainWindow mw { get; set; }

        /// <summary>
        /// Ein wichtiges globales Objekt das später zum aktualisieren 
        /// der listKartenInfo in der KartenOverview dient
        /// </summary>
        public KartenInfo ki { get; set; }

        /// <summary>
        /// hier wird eine DB Connection übergeben die dann lokal gespeichert wird
        /// </summary>
        public Projekt2Entities connect = null;

        /// <summary>
        /// Konstruktor KartenDetail
        /// </summary>
        /// <param name="mw"></param>
        /// Mainwindow
        /// <param name="ki"></param>
        /// Die zu ändernde Karte
        /// <param name="con"></param>
        /// Die DB Connection
        public KartenDetail(MainWindow mw, KartenInfo ki , Projekt2Entities con)
        {

            this.mw = mw;
            this.ki = ki;

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
            }
            
        }

        /// <summary>
        /// Accessor Methode für Kunde_ID 
        /// U.a Benötigt für das Füllen des Objekt ki
        /// </summary>
        public int Kunden_ID
        {
            get
            {
                return ki.Kunde_ID;

            }
            set
            {
                ki.Kunde_ID = value;
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
        /// Gibt an ob eine Karte geändert wurde. Dann kann die Liste in KartenOverview
        /// aktualisiert werden
        /// </summary>
        public bool sthChanged = false;


        /// <summary>
        /// Speichert die Änderungen an der Karte
        /// </summary>
        public void saveOperation()
        {
            var query = from kart in connect.Karte
                        where kart.Karten_ID == ki.Karten_ID
                        && kart.Kunde_ID == ki.Kunde_ID
                        select kart;

            foreach (Karte kart in query)
            {
                kart.Aktiv = ki.Aktiv;
                kart.Sperrdatum = ki.Sperrdatum;
                kart.Sperrvermerk = ki.Sperrvermerk;
            }

            connect.SaveChanges();
            
            sthChanged = true;
        }

        /// <summary>
        /// Triggert saveOperation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            saveOperation();
            MessageBox.Show("Erfolgreich gespeichert!", "Speichern", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Setzt die Felder Sperrfelder wieder zurück "Entsperren"
        /// </summary>
        public void clearFields()
        {
            Sperrdatum = null;
            Aktiv = true;
            Sperrvermerk = null;
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clearFields();
        }


      

    }
}

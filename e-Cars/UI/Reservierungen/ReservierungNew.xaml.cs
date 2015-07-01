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

namespace e_Cars.UI.Reservierungen
{
    /// <summary>
    /// Interaktionslogik für ReservierungNew.xaml
    /// </summary>
    public partial class ReservierungNew : UserControl, INotifyPropertyChanged
    {

        private MainWindow mw;

        private List<Kunde> listekunden;
        /// <summary>
        /// Accessor Methode für eine Liste mit allen Kunden
        /// </summary>
        public List<Kunde> listeKunden
        {
            get { return listekunden; }
            set
            {
                listekunden = value;
                NotifyPropertyChanged("listeKunden");
            }
        }

        private Kunde selecteduser;
        /// <summary>
        /// Accessor Methode für den ausgewählten Kunden
        /// </summary>
        public Kunde selectedUser
        {
            get { return selecteduser; }
            set
            {
                selecteduser = value;
                NotifyPropertyChanged("selectedUser");
            }
        }

        private List<Tankstelle> listetankstellen;
        /// <summary>
        /// Accessor Methode für eine Liste mit allen Tankstellen
        /// </summary>
        public List<Tankstelle> listeTankstellen
        {
            get { return listetankstellen; }
            set
            {
                listetankstellen = value;
                NotifyPropertyChanged("listeTankstellen");
            }
        }

        private Tankstelle selectedtankstelle;
        /// <summary>
        /// Accessor Methode für die ausgewählte Tankstelle
        /// </summary>
        public Tankstelle selectedTankstelle
        {
            get { return selectedtankstelle; }
            set
            {
                selectedtankstelle = value;
                NotifyPropertyChanged("selectedTankstelle");
            }
        }

        private DateTime reservierungstart;

        /// <summary>
        /// Accessor Methode für das Start Datum der Reservierung
        /// </summary>
        public DateTime ReservierungStart
        {

            get { return reservierungstart; }
            set
            {
                reservierungstart = value;
                NotifyPropertyChanged("ReservierungStart");
            }
        }

        private DateTime reservierungende;

        /// <summary>
        /// Accessor Methode für das Start Datum der Reservierung
        /// </summary>
        public DateTime ReservierungEnde
        {

            get { return reservierungende; }
            set
            {
                reservierungende = value;
                NotifyPropertyChanged("ReservierungEnde");
            }
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="mw"></param>
        public ReservierungNew(MainWindow mw)
        {
            this.mw = mw;

            if (!UnitTestDetector.IsRunningFromNunit)
            {
                InitializeComponent();
            }

            this.DataContext = this;
            ReservierungStart = DateTime.Now;
            ReservierungEnde = DateTime.Now;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            using (Projekt2Entities con = new Projekt2Entities())
            {
                listeTankstellen = con.Tankstelle.ToList();
                listeKunden = con.Kunde.Where(s => s.Gesperrt != true).ToList();
            }
        }

        private void ButtonAnlegen_Click(object sender, RoutedEventArgs e)
        {

            if (selectedUser == null)
            {
                MessageBox.Show("User fehlt.");
                return;
            }

            if (ReservierungStart == null)
            {
                MessageBox.Show("Das Datum fehlt.");
                return;
            }

            if (ReservierungStart.CompareTo(DateTime.Now) <= 0)
            {
                MessageBox.Show("Die Reservierung liegt in der Vergangenheit.");
                return;
            }

            if (ReservierungStart.CompareTo(DateTime.Now.AddMonths(3)) > 0)
            {
                MessageBox.Show("Die Reservierung liegt weiter als 3 Monate in der Zukunft");
                return;
            }

            if (ReservierungEnde.CompareTo(ReservierungStart) < 0)
            {
                MessageBox.Show("Das Ende ist vor dem Start!");
                return;
            }

            if (selectedTankstelle == null)
            {
                MessageBox.Show("Abholort fehlt.");
                return;
            }

            if (checkData())
            {
                MessageBox.Show("Eingabe unvollständig bitte Daten prüfen.");
                return;
            }

            Reservierung res = new Reservierung();
            res.Abholort = selectedTankstelle.Tankstelle_ID;
            res.Startzeit = ReservierungStart;
            res.Kunde_ID = selectedUser.Kunde_ID;
            res.ResStatus_ID = 1;
            res.Zeitstempel = DateTime.Now;

            using (Projekt2Entities con = new Projekt2Entities())
            {
                con.Reservierung.Add(res);
                con.SaveChanges();
            }

            MessageBox.Show("Die Reservierung wurde erfolgreich erstellt.");

            clearFields();
        }

        public void clearFields()
        {
            selectedUser = null;
            selectedTankstelle = null;
            ReservierungStart = DateTime.Now;
        }

        public bool checkData()
        {


            bool data = false;

            if (selectedTankstelle == null)
            {
                data = true;
            }



            return data;

        }


        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            mw.setReservierungOverview();
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

    }
}

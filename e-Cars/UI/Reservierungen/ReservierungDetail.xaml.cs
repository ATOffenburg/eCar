using e_Cars.Datenbank;
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
    /// Interaktionslogik für ReservierungDetail.xaml
    /// </summary>
    public partial class ReservierungDetail : UserControl, INotifyPropertyChanged
    {

        private MainWindow mw;
        private ReservierungInfo ri;

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

        private List<Tankstelle> listetankstellen2;
        /// <summary>
        /// Accessor Methode für eine Liste mit allen Tankstellen
        /// </summary>
        public List<Tankstelle> listeTankstellen2
        {
            get { return listetankstellen2; }
            set
            {
                listetankstellen2 = value;
                NotifyPropertyChanged("listeTankstellen2");
            }
        }

        private Tankstelle selectedtankstelle2;
        /// <summary>
        /// Accessor Methode für die ausgewählte Tankstelle
        /// </summary>
        public Tankstelle selectedTankstelle2
        {
            get { return selectedtankstelle2; }
            set
            {
                selectedtankstelle2 = value;
                NotifyPropertyChanged("selectedTankstelle2");
            }
        }

        private List<ResStatus> listeresstatus;
        /// <summary>
        /// Accessor Methode für eine Liste mit allen Tankstellen
        /// </summary>
        public List<ResStatus> listeResStatus
        {
            get { return listeresstatus; }
            set
            {
                listeresstatus = value;
                NotifyPropertyChanged("listeResStatus");
            }
        }

        private ResStatus selectedresstatus;
        /// <summary>
        /// Accessor Methode für die ausgewählte Tankstelle
        /// </summary>
        public ResStatus selectedResStatus
        {
            get { return selectedresstatus; }
            set
            {
                selectedresstatus = value;
                NotifyPropertyChanged("selectedResStatus");
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
        /// <param name="ri"></param>
        public ReservierungDetail(MainWindow mw, ReservierungInfo ri)
        {
            this.mw = mw;
            this.ri = ri;

            using (Projekt2Entities con = new Projekt2Entities())
            {
                listeTankstellen = con.Tankstelle.ToList();
                listeTankstellen2 = con.Tankstelle.ToList();

                listeResStatus = con.ResStatus.ToList();
                listeKunden = con.Kunde.ToList();

                InitializeComponent();
                this.DataContext = this;

                ReservierungStart = ri.Startzeit;

                ReservierungEnde = ri.Endzeit.GetValueOrDefault();

                if (ri.Abholort != null)
                {
                    selectedTankstelle = listeTankstellen.SingleOrDefault(s => s.Tankstelle_ID == ri.Abholort.Tankstelle_ID);
                }

                if (ri.Abgabeort != null)
                {
                    selectedTankstelle2 = listeTankstellen2.SingleOrDefault(s => s.Tankstelle_ID == ri.Abgabeort.Tankstelle_ID);
                }

                if (ri.res != null)
                {
                    selectedResStatus = listeResStatus.SingleOrDefault(s => s.ResStatus_ID == ri.res.ResStatus_ID);
                }

                selectedUser = listeKunden.SingleOrDefault(s => s.Kunde_ID == ri.k.Kunde_ID);
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            mw.setReservierungOverview();
        }

        private void ButtonAenderungenSpeichern_Click(object sender, RoutedEventArgs e)
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

            if (selectedTankstelle == null)
            {
                MessageBox.Show("Abholort fehlt.");
                return;
            }

            using (Projekt2Entities con = new Projekt2Entities())
            {
                Reservierung res = con.Reservierung.SingleOrDefault(s => s.Reservierung_ID == ri.res.Reservierung_ID);

                if (res != null)
                {
                    res.Abholort = selectedTankstelle.Tankstelle_ID;
                    res.Startzeit = ReservierungStart;
                    res.Kunde_ID = selectedUser.Kunde_ID;
                    res.Zeitstempel = DateTime.Now;

                    con.Entry(res).State = System.Data.Entity.EntityState.Modified;
                    con.SaveChanges();
                    MessageBox.Show("Die Reservierung wurde erfolgreich geändert.");
                }
                else
                {
                    MessageBox.Show("Die Änderungen konnten nicht gespeichert werden.");

                }
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
    }
}

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

        public DateTime ReservierungStart
        {

            get { return reservierungstart; }
            set
            {
                reservierungstart = value;
                NotifyPropertyChanged("ReservierungStart");
            }
        }

        public ReservierungDetail(MainWindow mw, ReservierungInfo ri)
        {
            this.mw = mw;
            this.ri = ri;

            using (Projekt2Entities con = new Projekt2Entities())
            {
                listeTankstellen = con.Tankstelle.ToList();
                listeKunden = con.Kunde.ToList();

                InitializeComponent();
                this.DataContext = this;

                ReservierungStart = ri.Startzeit;
                selectedTankstelle = listeTankstellen.SingleOrDefault(s => s.Tankstelle_ID == ri.Abholort.Tankstelle_ID);
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}

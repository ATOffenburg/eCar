using e_Cars.Datenbank;
using e_Cars.nunithelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace e_Cars.UI.Cars
{
    /// <summary>
    /// Interaktionslogik für CarsDetails.xaml
    /// </summary>
    public partial class CarDetail : UserControl, INotifyPropertyChanged
    {

        private CarInfo ci { get; set; }
        private MainWindow mw { get; set; }

        private string seriennummer;
        /// <summary>
        /// Accessor Methode für die Seriennummer
        /// </summary>
        public String Seriennummer
        {
            get { return seriennummer; }
            set
            {
                seriennummer = value;
                if (seriennummer != null)
                {
                    seriennummer = seriennummer.Trim();
                }
                NotifyPropertyChanged("Seriennummer");
            }
        }

        private bool gesperrt;
        /// <summary>
        /// Accessor Methode für das Gesperrt Kennzeichen
        /// </summary>
        public bool Gesperrt
        {
            get { return gesperrt; }
            set
            {
                gesperrt = value;
                NotifyPropertyChanged("Gesperrt");
            }
        }

        private bool reservierunggesperrt;
        /// <summary>
        /// Accessor Methode für das ResevierungGesperrt Kennzeichen
        /// </summary>
        public bool ReservierungGesperrt
        {
            get { return reservierunggesperrt; }
            set
            {
                reservierunggesperrt = value;
                NotifyPropertyChanged("ReservierungGesperrt");
            }
        }

        private bool spontanenutzunggesperrt;
        /// <summary>
        /// Accessor Methode für das SpontaneNutzungGesperrt Kennzeichen
        /// </summary>
        public bool SpontaneNutzungGesperrt
        {
            get { return spontanenutzunggesperrt; }
            set
            {
                spontanenutzunggesperrt = value;
                NotifyPropertyChanged("SpontaneNutzungGesperrt");
            }
        }

        private DateTime? wartungstermin;
        /// <summary>
        /// Accessor Methode für den Wartungstermin
        /// </summary>
        public DateTime? WartungsTermin
        {
            get { return wartungstermin; }
            set
            {
                wartungstermin = value;
                NotifyPropertyChanged("WartungsTermin");
            }
        }

        private double? kilometerstand;
        /// <summary>
        /// Accessor Methode für den Kilometerstand
        /// </summary>
        public double? Kilometerstand
        {
            get { return kilometerstand; }
            set
            {
                kilometerstand = value;
                NotifyPropertyChanged("Kilometerstand");
            }
        }

        private int tankvorgaenge;
        /// <summary>
        /// Accessor Methode für die Anzahl der Tankvorgänge
        /// </summary>
        public int Tankvorgaenge
        {
            get { return tankvorgaenge; }
            set
            {
                tankvorgaenge = value;
                NotifyPropertyChanged("Tankvorgaenge");
            }
        }

        private int batterieladung = 0;
        /// <summary>
        /// Accessor Methode für die prozentuale Ladung der Batterie
        /// </summary>
        public int Batterieladung
        {
            get { return batterieladung; }
            set
            {
                batterieladung = value;
                NotifyPropertyChanged("Batterieladung");
            }
        }

        private List<Status> liststatus;
        /// <summary>
        /// Accessor Methode für eine Liste der Status
        /// </summary>
        public List<Status> listStatus
        {
            get { return liststatus; }
            set
            {
                liststatus = value;
                NotifyPropertyChanged("listStatus");
            }
        }

        private Status selectedstatus;
        /// <summary>
        /// Accessor Methode für den gewählten Status
        /// </summary>
        public Status selectedStatus
        {
            get { return selectedstatus; }
            set
            {
                if (selectedstatus != value)
                {
                    selectedstatus = value;
                    NotifyPropertyChanged("selectedStatus");
                }
            }
        }

        private List<Tanksaeule> listtanksaeule;
        /// <summary>
        /// Accessor Methode für eine Liste der Zapfsaeulen
        /// </summary>
        public List<Tanksaeule> listTanksaeule
        {
            get { return listtanksaeule; }
            set
            {
                listtanksaeule = value;
                NotifyPropertyChanged("listTanksaeule");
            }
        }

        private Tanksaeule selectedtanksaeule;
        /// <summary>
        /// Accessor Methode für den gewählte Zapfsaeule
        /// </summary>
        public Tanksaeule selectedTanksaeule
        {
            get { return selectedtanksaeule; }
            set
            {
                if (selectedtanksaeule != value)
                {
                    selectedtanksaeule = value;
                    NotifyPropertyChanged("selectedTanksaeule");
                }
            }
        }

        private bool gestohlen;
        /// <summary>
        /// Accessor Methode für das Gestohlen Kennzeichen
        /// </summary>
        public bool Gestohlen
        {
            get { return gestohlen; }
            set
            {
                gestohlen = value;
                NotifyPropertyChanged("Gestohlen");
            }
        }


        /// <summary>
        /// Konstruktor für die CarDetail Klasse
        /// </summary>
        /// <param name="mw"></param>
        /// <param name="ci"></param>
        public CarDetail(MainWindow mw, CarInfo ci)
        {
            this.mw = mw;
            this.ci = ci;

            if (!UnitTestDetector.IsRunningFromNunit)
            {
                InitializeComponent();
            }

            using (Projekt2Entities con = new Projekt2Entities())
            {
                listStatus = con.Status.ToList();
                listTanksaeule = con.Tanksaeule.ToList();
            }

            this.DataContext = this;

            if (this.ci != null)
            {
                Seriennummer = ci.c.Seriennummer;
                Gesperrt = ci.c.Gesperrt.GetValueOrDefault(false);
                ReservierungGesperrt = ci.c.ReservierungGesperrt.GetValueOrDefault(false);
                SpontaneNutzungGesperrt = ci.c.SpontaneNutzungGesperrt.GetValueOrDefault(false);

                WartungsTermin = ci.c.Wartungstermin;
                Batterieladung = ci.c.Batterieladung.GetValueOrDefault(0);
                Kilometerstand = ci.c.Kilometerstand;

                Tankvorgaenge = ci.c.Tankvorgaenge;

                Gestohlen = ci.c.Gestohlen.GetValueOrDefault(false);

                selectedStatus = listStatus.SingleOrDefault(s => s.Status_ID == ci.c.Status_ID);

                selectedTanksaeule = listTanksaeule.SingleOrDefault(s => s.Car_ID == ci.c.Car_ID);

            }
        }

        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            mw.setCarOverview();
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

        public static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(text);
        }

        private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void Event_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void ButtonAenderungenSpeichern_Click(object sender, RoutedEventArgs e)
        {

            bool bChanged = saveOperation();
            

            if (bChanged)
            {
                MessageBox.Show("Änderungen gespeichert.");
            }
            else
            {
                MessageBox.Show("Keine Änderungen");
            }

        }

        private void ButtonFahrzeugOrten_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonFahrtenliste_Click(object sender, RoutedEventArgs e)
        {
            mw.setCarFahrtenliste(ci);
        }

        private void ButtonReservierung_Click(object sender, RoutedEventArgs e)
        {
            mw.setCarReservierungen(ci);
        }

        private void TextBoxKilometerstand_LostFocus(object sender, RoutedEventArgs e)
        {
            Kilometerstand = Kilometerstand;
        }

        private void TextBoxTankvorgaenge_LostFocus(object sender, RoutedEventArgs e)
        {
            Tankvorgaenge = Tankvorgaenge;
        }

        public bool saveOperation()
        {
            using (Projekt2Entities con = new Projekt2Entities())
            {
                Car c = con.Car.Single(s => s.Car_ID == ci.c.Car_ID);
                bool bTanksaeuleChanged = false;

                if (selectedTanksaeule != null)
                {

                    if (c.Tanksaeule.FirstOrDefault() != null){

                        if (c.Tanksaeule.FirstOrDefault().Tanksaeule_ID != selectedTanksaeule.Tanksaeule_ID)
                        {
                            bTanksaeuleChanged = true;
                        }
                    } else {
                        bTanksaeuleChanged = true;
                    }
                }

                // Prüfe ob Seriennummer geändert
                if (
                    !Equals(ci.c.Seriennummer, Seriennummer)
                    || !Equals(ci.c.Kilometerstand, Kilometerstand)
                    || !Equals(ci.c.Batterieladung, Batterieladung)
                    || !Equals(ci.c.Wartungstermin, WartungsTermin)

                    || !Equals(ci.c.Gesperrt, Gesperrt)
                    || !Equals(ci.c.SpontaneNutzungGesperrt, SpontaneNutzungGesperrt)
                    || !Equals(ci.c.ReservierungGesperrt, ReservierungGesperrt)

                    || !Equals(ci.c.Tankvorgaenge, Tankvorgaenge)

                    || !Equals(ci.c.Status_ID, selectedStatus.Status_ID)

                    || !Equals(ci.c.Gestohlen, Gestohlen)

                    || bTanksaeuleChanged
                    )
                {
                    // Wenn ja die Änderungen speichern...
                    c.Seriennummer = Seriennummer;
                    c.Kilometerstand = Kilometerstand;
                    c.Batterieladung = Batterieladung;
                    c.Wartungstermin = WartungsTermin;

                    c.Gesperrt = Gesperrt;
                    c.ReservierungGesperrt = ReservierungGesperrt;
                    c.SpontaneNutzungGesperrt = SpontaneNutzungGesperrt;

                    c.Tankvorgaenge = Tankvorgaenge;

                    c.Status_ID = selectedStatus.Status_ID;

                    c.Tanksaeule.Clear();
                    if (selectedTanksaeule != null)
                    {
                        c.Tanksaeule.Add(con.Tanksaeule.SingleOrDefault(s => s.Tanksaeule_ID == selectedTanksaeule.Tanksaeule_ID));
                    }

                    c.Gestohlen = Gestohlen;

                    con.Entry(c).State = System.Data.Entity.EntityState.Modified;
                    con.SaveChanges();

                    //c.Status_ID = status.Status_ID;

                    ci.c = c;

                    return true;
                }

            }
            return false;
        }
    }
}

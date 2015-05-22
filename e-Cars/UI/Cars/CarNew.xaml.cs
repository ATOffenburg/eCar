using e_Cars.Datenbank;
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
    /// Interaktionslogik für CarNew.xaml
    /// </summary>
    public partial class CarNew : UserControl, INotifyPropertyChanged
    {

        private string seriennummer;

        /// <summary>
        /// Die Seriennummer des Fahrzeugs
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

        private DateTime? wartungstermin;
        /// <summary>
        /// Der Wartungstermin des Fahrzeugs
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
        /// Der Kilometerstand
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
        /// Die Anzahl der Tankvorgänge 
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
        /// Der prozentuale Ladestand des Akkus
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

        private List<Status> liststatus = new List<Status>();
        /// <summary>
        /// Eine Liste mit allen Status eines Fahrzeugs
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
        /// Der momentan selektierte Status
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

        private Tankstelle selectedtankstelle;
        /// <summary>
        /// Die ausgewählte Tankstelle
        /// </summary>
        public Tankstelle selectedTankstelle
        {
            get { return selectedtankstelle; }
            set
            {
                if (selectedtankstelle != value)
                {
                    selectedtankstelle = value;
                    NotifyPropertyChanged("selectedTankstelle");
                }
            }
        }

        private List<Tankstelle> listtankstelle = new List<Tankstelle>();
        /// <summary>
        /// Eine Liste mit allen Tankstellen
        /// </summary>
        public List<Tankstelle> listTankstelle
        {
            get { return listtankstelle; }
            set
            {
                listtankstelle = value;
                NotifyPropertyChanged("listTankstelle");
            }
        }

        private MainWindow mw { get; set; }

        /// <summary>
        /// Konstruktor erstellt das Usercontrol CarNew
        /// </summary>
        /// <param name="mw">Das zu übergebende MainWindow</param>
        public CarNew(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();
            this.DataContext = this;

            using (Projekt2Entities con = new Projekt2Entities())
            {
                listStatus = con.Status.ToList();
                listTankstelle = con.Tankstelle.ToList();
            }
            clearFields();
        }

        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            mw.setCarOverview();
        }

        private void ButtonAnlegen_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrWhiteSpace(Seriennummer))
            {
                MessageBox.Show("Keine Seriennummer erfasst!");
                TextBoxSeriennummer.Focus();
                return;
            }

            if (checkData())
            {
                MessageBox.Show("Die Daten sind nicht richtig!");
                return;
            }

            Car c = new Car();
            c.Seriennummer = TextBoxSeriennummer.Text.Trim();

            using (Projekt2Entities con = new Projekt2Entities())
            {
                if (con.Car.Any(s => s.Seriennummer == c.Seriennummer))
                {
                    MessageBox.Show("Seriennummer bereits vergeben!");
                    TextBoxSeriennummer.Focus();
                    return;
                }

                c.Batterieladung = Batterieladung;
                c.Kilometerstand = Kilometerstand;
                c.Status_ID = selectedStatus.Status_ID;
                c.Tankvorgaenge = Tankvorgaenge;
                c.Wartungstermin = WartungsTermin;

                con.Car.Add(c);
                con.SaveChanges();
                MessageBox.Show("Das Fehrzeug wurde angelegt!");
                clearFields();
            }
        }

        private bool checkData()
        {

            bool bData = false;

            if (String.IsNullOrWhiteSpace(Seriennummer))
            {
                bData = true;
            }

            if (WartungsTermin == null)
            {
                bData = true;
            }

            if (Batterieladung < 0 || Batterieladung > 100)
            {
                bData = true;
            }

            if (Kilometerstand == null)
            {
                bData = true;
            }

            if (selectedStatus == null)
            {
                bData = true;
            }

            if (selectedTankstelle == null)
            {
                bData = true;
            }

            return bData;
        }

        private void clearFields()
        {
            Seriennummer = null;
            WartungsTermin = null;
            Batterieladung = 0;
            Tankvorgaenge = 0;
            selectedStatus = null;
            Kilometerstand = null;

        }

        /// <summary>
        /// Delegiert den Event an die Oberfläche
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Macht Änderungen der Eigenschaften der Oberfläche bekannt
        /// </summary>
        /// <param name="info"></param>
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private static bool IsTextAllowed(string text)
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

        private void TextBoxKilometerstand_LostFocus(object sender, RoutedEventArgs e)
        {
            Kilometerstand = Kilometerstand;
        }

        private void TextBoxTankvorgaenge_LostFocus(object sender, RoutedEventArgs e)
        {
            Tankvorgaenge = Tankvorgaenge;
        }

    }
}

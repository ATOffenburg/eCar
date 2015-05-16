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

namespace e_Cars.UI.Kunden
{
    /// <summary>
    /// Interaktionslogik für UserNew.xaml
    /// </summary>
    public partial class UserNew : Window, INotifyPropertyChanged
    {

        private MainWindow mw { get; set; }

        private string name;
        public String Nname
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Nname");
            }
        }

        private string vorname;
        public String Vorname
        {
            get { return vorname; }
            set
            {
                vorname = value;
                NotifyPropertyChanged("Vorname");
            }
        }

        private string email;
        public String Email
        {
            get { return email; }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }

        private string passwort;
        public String Passwort
        {
            get { return passwort; }
            set
            {
                passwort = value;
                NotifyPropertyChanged("Passwort");
            }
        }


        private string ort;
        public String Ort
        {
            get { return ort; }
            set
            {
                ort = value;
                NotifyPropertyChanged("Ort");
            }
        }

        private string plz;
        public String PLZ
        {
            get { return plz; }
            set
            {
                plz = value;
                NotifyPropertyChanged("PLZ");
            }
        }

        private string hausnummer;
        public String Hausnummer
        {
            get { return hausnummer; }
            set
            {
                hausnummer = value;
                NotifyPropertyChanged("Hausnummer");
            }
        }

        private string strasse;
        public String Strasse
        {
            get { return strasse; }
            set
            {
                strasse = value;
                NotifyPropertyChanged("Strasse");
            }
        }

        private string bic;
        public String BIC
        {
            get { return bic; }
            set
            {
                bic = value;
                NotifyPropertyChanged("BIC");
            }
        }

        private string iban;
        public String IBAN
        {
            get { return iban; }
            set
            {
                iban = value;
                NotifyPropertyChanged("IBAN");
            }
        }


        public UserNew(MainWindow mw)
        {
            this.mw = mw;
            this.DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clearFields()
        {

            Nname = "";
            Vorname = "";
            Email = "";
            Passwort = "";
            PLZ = "";
            Ort = "";
            Strasse = "";
            Hausnummer = "";
            BIC = "";
            IBAN = "";

        }


        private bool checkData()
        {

            bool bData = false;

            if (String.IsNullOrWhiteSpace(Nname))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(Vorname))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(PLZ))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(Ort))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(Strasse))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(Hausnummer))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(BIC))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(IBAN))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(Email))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(Passwort))
            {
                bData = true;
            }
            return bData;

        }
        public UserInfo ui = null;

        public bool sthChanged = false;        
        private void ButtonAnlegen_Click(object sender, RoutedEventArgs e)
        {

            if (checkData())
            {
                MessageBox.Show("Die Daten müssen vollständig sein bevor sie gespeichert werden können.");
                return;
            }

            Kunde k = new Kunde();
            k.Name = Nname;
            k.Vorname = Vorname;
            k.Email = Email;
            k.Passwort = Passwort;

            Adresse a = new Adresse();
            a.Ort = Ort;
            a.PLZ = PLZ;
            a.Strasse = Strasse;
            a.Hausnummer = Hausnummer;

            Bank b = new Bank();
            b.BIC = BIC;
            b.IBAN = IBAN;

            using (var con = new Projekt2Entities())
            {

                con.Adresse.Add(a);
                con.Bank.Add(b);
                con.SaveChanges();

                k.Bank_ID = b.Bank_ID;
                k.Adress_ID = a.Adress_ID;

                k = con.Kunde.Add(k);
                ui = new UserInfo(k);
                con.SaveChanges();
                sthChanged = true;
                
            }

            clearFields();

        }
    }
}

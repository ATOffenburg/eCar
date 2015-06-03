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
using System.IO;
using System.Diagnostics;

namespace e_Cars.UI.Kunden
{
    /// <summary>
    /// Interaktionslogik für UserNew.xaml
    /// </summary>
    public partial class UserNew : Window, INotifyPropertyChanged
    {
        /// <summary>
        /// Accessor Methode für mw
        /// </summary>
        private MainWindow mw { get; set; }

        private string name;
        /// <summary>
        /// Accessor Methode für KundenName 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
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
        /// <summary>
        /// Accessor Methode für Vorname 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
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
        /// <summary>
        /// Accessor Methode für Email 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
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
        /// <summary>
        /// Accessor Methode für Passwort 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
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
        /// <summary>
        /// Accessor Methode für Ort 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
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
        /// <summary>
        /// Accessor Methode für PlZ 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
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
        /// <summary>
        /// Accessor Methode für Hausnummer 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
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
        /// <summary>
        /// Accessor Methode für Straße 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
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
        /// <summary>
        /// Accessor Methode für BIC 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
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
        /// <summary>
        /// Accessor Methode für IBAN 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
        public String IBAN
        {
            get { return iban; }
            set
            {
                iban = value;
                NotifyPropertyChanged("IBAN");
            }
        }

        /// <summary>
        /// Konstruktor UserNew
        /// </summary>
        /// <param name="mw"></param>
        public UserNew(MainWindow mw)
        {
            this.mw = mw;
            this.DataContext = this;

            if (!UnitTestDetector.IsRunningFromNunit)
            {
                InitializeComponent();
            }

            this.ui = new UserInfo(new Kunde());
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
        /// Schließt das Window und kehrt somit zur Overview zurück
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Löscht die Inhalte der einzelnen Textboxes
        /// </summary>
        public void clearFields()
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

        /// <summary>
        /// Checked die Eingabefelder auf Ihre Richtigkeit
        /// </summary>
        /// <returns></returns>
        public bool checkData()
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
        /// <summary>
        /// Ein wichtiges globales Objekt das später zum aktualisieren 
        /// der listUserInfo in der UserOverview dient
        /// </summary>
        public UserInfo ui = null;


        /// <summary>
        /// Gibt an ob ein Kunde angelegt wurde. Dann kann die Liste in KundenOverview
        /// aktualisiert werden
        /// </summary>
        public bool sthChanged = false;

        /// <summary>
        /// Speichert den neuen Kunden
        /// </summary>
        public void saveOperation()
        {
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
                k.FKopie = ui.FKopie;
                bool temp = ui.Führerscheinkopie;
                ui = new UserInfo(k);
                ui.Führerscheinkopie = temp;
                con.SaveChanges();
                sthChanged = true;

            }
            try { 
            File.Delete(@"c:\temp\fkopietemp.pdf");
                }
            catch (Exception)
            {

            }


        }

        /// <summary>
        /// Speichert den neuen Kunden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAnlegen_Click(object sender, RoutedEventArgs e)
        {
            if (checkData())
            {
                MessageBox.Show("Die Daten müssen vollständig sein bevor sie gespeichert werden können.");
                return;
            }

            saveOperation();

            MessageBox.Show("Änderungen gespeichert!");

            clearFields();
        }
        /// <summary>
        /// Hier wird eine Kopie des Füherscheins entweder in JPG oder in PDF hochgeladen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Hochladen(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".pdf|.jpg";
            dlg.Filter = "Pdf documents (.pdf)|*.pdf|Pictures (.jpg)|*.jpg";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;

                ui.FKopie = System.IO.File.ReadAllBytes(filename);
                ui.Führerscheinkopie = true;
            }
        }

        /// <summary>
        /// Zeigt die in der DB gespeicherte Kopie des Führerscheins
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Anzeigen(object sender, RoutedEventArgs e)
        {

            if (ui.FKopie != null)
            {
                string tempPath = System.IO.Path.GetTempPath();

                string filepath = tempPath + "fkopietemp.pdf";
                if (ui.FKopie.ElementAt<byte>(0) == 37 && ui.FKopie.ElementAt<byte>(1) == 80 && ui.FKopie.ElementAt<byte>(2) == 68 && ui.FKopie.ElementAt<byte>(3) == 70)
                    filepath = tempPath + "fkopietemp.pdf";
                else
                    filepath = tempPath + "fkopietemp.jpg";

                File.WriteAllBytes(filepath, ui.FKopie);

                Process.Start(filepath);

            }
        }

        /// <summary>
        /// Löscht die in der DB gespeicherte Führerscheinkopie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Loeschen(object sender, RoutedEventArgs e)
        {
            ui.FKopie = null;
            ui.Führerscheinkopie = false;
        }
    }
}

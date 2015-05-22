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
using System.IO;
using System.Diagnostics;

namespace e_Cars.UI.Kunden
{
    /// <summary>
    /// Interaktionslogik für UserDetail.xaml
    /// </summary>
    public partial class UserDetail : Window
    {
        /// <summary>
        /// Accessor-Methode für das Entity Objekt
        /// zum Füllen oder holen des Wertes von Karten_ID
        /// </summary>
        public MainWindow mw { get; set; }

        /// <summary>
        /// Ein wichtiges globales Objekt das später zum aktualisieren 
        /// der listUserInfo in der UserOverview dient
        /// </summary>
        public UserInfo ui { get; set; }

        /// <summary>
        /// Accesor-Methode für das Entity-Objekt Kunde
        /// </summary>
        private Kunde k { get; set; }

        /// <summary>
        /// Accesor-Methode für das Entity-Objekt Adresse
        /// </summary>
        private Adresse a { get; set; }

        /// <summary>
        /// Accesor-Methode für das Entity-Objekt Bank
        /// </summary>
        private Bank b { get; set; }

        /// <summary>
        /// Accessor Methode für KundenName 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
        private string name;
        public String KundeName
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("KundeName");
            }
        }

        /// <summary>
        /// Accessor Methode für Vorname 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
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

        /// <summary>
        /// Accessor Methode für Email 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
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

        /// <summary>
        /// Accessor Methode für Passwort 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
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

        /// <summary>
        /// Accessor Methode für Ort 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
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

        /// <summary>
        /// Accessor Methode für PLZ 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
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

        /// <summary>
        /// Accessor Methode für Hausnummer 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
        private string hausnummer;
        public String HausNummer
        {
            get { return hausnummer; }
            set
            {
                hausnummer = value;
                NotifyPropertyChanged("HausNummer");
            }
        }

        /// <summary>
        /// Accessor Methode für Straße 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
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

        /// <summary>
        /// Accessor Methode für Gesperrt 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
        private bool gesperrt;

        public bool Gesperrt
        {
            get { return gesperrt; }
            set
            {
                gesperrt = value;
                NotifyPropertyChanged("Gesperrt");
            }
        }

        /// <summary>
        /// Accessor Methode für BIC 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
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

        /// <summary>
        /// Accessor Methode für IBAN 
        /// U.a Benötigt für das Füllen des Objekt ui
        /// </summary>
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
        /// Konstrukot von UserDetail welches den übergebenen Kunden erhällt
        /// und u.a. die Felder mit dessen Daten initialisiert
        /// </summary>
        /// <param name="mw"></param>
        /// <param name="ui"></param>
        public UserDetail(MainWindow mw, UserInfo ui)
        {

            this.mw = mw;
            this.ui = ui;

            if (ui != null)
            {
                using (Projekt2Entities con = new Projekt2Entities())
                {

                    k = con.Kunde.SingleOrDefault(s => s.Kunde_ID == ui.kunde.Kunde_ID);
                    a = k.Adresse;
                    b = k.Bank;

                    KundeName = k.Name;
                    Vorname = k.Vorname;
                    Email = k.Email;
                    Passwort = k.Passwort;
                    Gesperrt = k.Gesperrt;

                    if (a != null)
                    {
                        Strasse = a.Strasse;
                        HausNummer = a.Hausnummer;
                        Ort = a.Ort;
                        PLZ = a.PLZ;
                    }
                    else
                    {
                        Strasse = "";
                        HausNummer = "";
                        Ort = "";
                        PLZ = "";
                    }

                    if (b != null)
                    {
                        BIC = b.BIC;
                        IBAN = b.IBAN;
                    }
                    else
                    {
                        BIC = "";
                        IBAN = "";
                    }
                }
            }

            this.DataContext = this;
            InitializeComponent();

        }
        /// <summary>
        /// Schließt das Window und kehrt somit zur Overview zurück
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            //mw.setUserOverview();
            this.Close();
        }

        /// <summary>
        /// Checked die Eingabefelder auf Ihre Richtigkeit
        /// </summary>
        /// <returns></returns>
        private bool checkData()
        {

            bool bData = false;

            if (String.IsNullOrWhiteSpace(KundeName))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(Vorname))
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
            if (String.IsNullOrWhiteSpace(HausNummer))
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

            return bData;

        }

        public bool sthChanged = false;

        /// <summary>
        /// Speichert die an einem Kunden vorgenommenen Änderungen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

            if (checkData())
            {
                MessageBox.Show("Die Daten müssen vollständig sein bevor die Änderungen gespeichert werden können.");
                return;
            }

            using (Projekt2Entities con = new Projekt2Entities())
            {

                Kunde knew = con.Kunde.Single(s => s.Kunde_ID == k.Kunde_ID);

                Adresse anew = con.Adresse.SingleOrDefault(s => s.Adress_ID == knew.Adress_ID);
                if (anew == null)
                {
                    anew = new Adresse();
                    anew.Hausnummer = HausNummer;
                    anew.Ort = Ort;
                    anew.PLZ = PLZ;
                    anew.Strasse = Strasse;

                    con.Adresse.Add(anew);
                    con.SaveChanges();
                }

                anew.Hausnummer = HausNummer;
                anew.Ort = Ort;
                anew.PLZ = PLZ;
                anew.Strasse = Strasse;

                con.Entry(anew).State = System.Data.Entity.EntityState.Modified;

                Bank bnew = con.Bank.SingleOrDefault(s => s.Bank_ID == knew.Bank_ID);
                if (bnew == null)
                {
                    bnew = new Bank();
                    bnew.BIC = BIC;
                    bnew.IBAN = IBAN;

                    con.Bank.Add(bnew);
                    con.SaveChanges();
                }

                bnew.BIC = BIC;
                bnew.IBAN = IBAN;

                con.Entry(bnew).State = System.Data.Entity.EntityState.Modified;
                knew.Adress_ID = anew.Adress_ID;
                knew.Bank_ID = bnew.Bank_ID;
                knew.Name = KundeName;
                knew.Vorname = Vorname;
                knew.Email = Email;
                knew.Passwort = Passwort;
                knew.Gesperrt = Gesperrt;
                knew.FKopie = ui.FKopie;

                bool temp = ui.Führerscheinkopie;
                ui = new UserInfo(knew);
                ui.Führerscheinkopie = temp;

                con.Entry(knew).State = System.Data.Entity.EntityState.Modified;
                con.SaveChanges();

                sthChanged = true;

                MessageBox.Show("Änderungen gespeichert!");


            }
        }

        /// <summary>
        /// Zeigt die in der DB gespeicherte Kopie des Führerscheins
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
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
        /// Hier wird eine Kopie des Füherscheins entweder in JPG oder in PDF hochgeladen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
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
        /// Löscht die in der DB gespeicherte Führerscheinkopie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ui.FKopie = null;
            ui.Führerscheinkopie = false;
        }      

    }
}

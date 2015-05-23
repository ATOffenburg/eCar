using e_Cars.UI.Helper;
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
using System.Text.RegularExpressions;

namespace e_Cars.UI.Tankstellen
{
    /// <summary>
    /// Interaktionslogik für TankstelleDetail.xaml
    /// </summary>
    public partial class TankstelleDetail : Window
    {
        /// <summary>
        /// Accessor Methode für mw
        /// </summary>
        MainWindow mw { get; set; }

        /// <summary>
        /// Accessor Methode für TankstellenInfo ti
        /// Ein wichtiges globales Objekt das später zum aktualisieren 
        /// der listTankstellenInfo in der TankstellenOverView dient
        /// </summary>
        public TankstelleInfo ti { get; set; }

        /// <summary>
        /// Es wird eine Connection zur DB übergeben die hier lokal gespeichert wird
        /// </summary>
        public Projekt2Entities connect = null;

        /// <summary>
        /// Konstruktor von TankstelleDetail.
        /// </summary>
        /// <param name="mw"></param>
        /// MainWindow
        /// <param name="ti"></param>
        /// Die zu ändernde Tankstelle
        /// <param name="con"></param>
        /// Die Datenbank Connection
        public TankstelleDetail(MainWindow mw, TankstelleInfo ti, Projekt2Entities con)
        {

            this.mw = mw;
            this.ti = ti;

            this.DataContext = this;

            List<TanksaeuleInfo> listTanksaeule = new List<TanksaeuleInfo>();

            var tanks = from t in con.Tanksaeule
                        where t.Tankstelle_ID == ti.ID
                        select t;

                foreach (var vt in tanks)
                {
                    TanksaeuleInfo tsi = new TanksaeuleInfo(vt);
                    listTanksaeule.Add(tsi);
                }
                listTanksaeuleInfo = listTanksaeule;

                connect = con;

                if (!UnitTestDetector.IsRunningFromNunit)
                {
                    InitializeComponent();
                }
        }

        private List<TanksaeuleInfo> listtanksaeuleinfo = null;

        /// <summary>
        /// Accessor Methode für die Liste TanksäulenInfo
        /// </summary>
        public List<TanksaeuleInfo> listTanksaeuleInfo
        {
            get { return listtanksaeuleinfo; }
            set
            {
                listtanksaeuleinfo = value;
                NotifyPropertyChanged("listTanksaeuleInfo");
            }
        }

        /// <summary>
        /// Schließt das Window und kehrt somit zur Overview zurück
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            //mw.setTankstelleOverview();
            this.Close();
        }

        /// <summary>
        /// Accessor Methode für ID 
        /// U.a. benötigt für das Füllen des Objekt ti oder TB Felder
        /// </summary>
        public int ID
        {
            get
            {
                return ti.ID;
                
            }
            set
            {
                ti.ID = value;
                NotifyPropertyChanged("ID");
            }
        }

        /// <summary>
        /// Accessor Methode für Breitengrad 
        /// U.a. benötigt für das Füllen des Objekt ti oder TB Felder
        /// </summary>
        public Double? breitengrad
        {
            get
            {
                return ti.Breitengrad;
            }
            set
            {
                ti.Breitengrad = value;
                NotifyPropertyChanged("breitengrad");
            }
        }

        /// <summary>
        /// Accessor Methode für Längengrad 
        /// U.a. benötigt für das Füllen des Objekt ti oder TB Felder
        /// </summary>
        public Double? laengengrad
        {
            get
            {
                return ti.Längengrad;
            }
            set
            {
                ti.Längengrad = value;
                NotifyPropertyChanged("laengengrad");            
            }
        }

        /// <summary>
        /// Accessor Methode für PLZ 
        /// U.a. benötigt für das Füllen des Objekt ti oder TB Felder
        /// </summary>
        public String PLZ
        {
            get
            {
                return ti.PLZ;
            }
            set
            {
                ti.PLZ = value;
                NotifyPropertyChanged("PLZ");
            }
        }

        /// <summary>
        /// Accessor Methode für Ort 
        /// U.a. benötigt für das Füllen des Objekt ti oder TB Felder
        /// </summary>
        public String Ort
        {
            get
            {
                return ti.Ort;
            }
            set
            {
                ti.Ort = value;
                NotifyPropertyChanged("Ort");
            }
        }

        /// <summary>
        /// Accessor Methode für Straße 
        /// U.a. benötigt für das Füllen des Objekt ti oder TB Felder
        /// </summary>
        public String Strasse
        {
            get
            {
                return ti.Strasse;
            }
            set
            {
                ti.Strasse = value;
                NotifyPropertyChanged("Strasse");
            }
        }

        /// <summary>
        /// Accessor Methode für Tankstellen Name 
        /// U.a. benötigt für das Füllen des Objekt ti oder TB Felder
        /// </summary>
        public String TName
        {
            get
            {
                return ti.Name;
            }
            set
            {
                ti.Name = value;
                NotifyPropertyChanged("TName");
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
        /// Sortieren der Tabelle durch klicken auf einer der Spalten
        /// </summary>

        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;

        private GridViewColumnHeader _CurSortCol = null;
        private SortAdorner _CurAdorner = null;

        /// <summary>
        /// Legt die Sortierrichtung fest durch anklicken der Spalte in der Listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GridViewColumnHeaderClickedHandler(object sender,
                                                RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked =
                  e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    string header = headerClicked.Column.Header as string;

                    if (_CurAdorner != null)
                        AdornerLayer.GetAdornerLayer(_CurSortCol).Remove(_CurAdorner);
                    _CurSortCol = headerClicked;
                    _CurAdorner = new SortAdorner(_CurSortCol, direction);
                    AdornerLayer.GetAdornerLayer(_CurSortCol).Add(_CurAdorner);
                    String field = headerClicked.Tag as String;
                    Sort(header, direction);


                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }

                    // Remove arrow from previously sorted header
                    if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
                    {
                        _lastHeaderClicked.Column.HeaderTemplate = null;
                    }


                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }

        /// <summary>
        /// Startet das Sortieren anhand der Parameter
        /// </summary>
        /// <param name="sortBy"></param> Nach was Sortiert wird
        /// <param name="direction"></param> Die Richtung Ascending/Descending
        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(myListView.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

        /// <summary>
        /// Checked die Eingabefelder auf Ihre Richtigkeit
        /// </summary>
        /// <returns></returns>
        public bool checkData()
        {
            bool bData = false;
            double test;

            if (String.IsNullOrWhiteSpace(ID.ToString()))
            {
                bData = true;
            }
            if (!Double.TryParse(TBBreitengrad.Text, out test))
            {
                bData = true;
            }
            if (!Double.TryParse(TBLängengrad.Text, out test))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(TName))
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

            return bData;
        }

        /// <summary>
        /// Gibt an ob eine Tankstelle geändert wurde. Dann kann die Liste in TankstellenOverview
        /// aktualisiert werden
        /// </summary>

        public bool sthChanged = false;

        /// <summary>
        /// Speichert die Änderungen an der Tankstelle
        /// </summary>
        public void saveOperation()
        {
            Tankstelle ta = connect.Tankstelle.SingleOrDefault(s => s.Tankstelle_ID == ID);

            ta.Tankstelle_ID = ID;
            ta.breitengrad = breitengrad;
            ta.laengengrad = laengengrad;
            ta.Name = TName;
            ta.Ort = Ort;
            ta.Stasse = Strasse;
            ta.PLZ = PLZ;

            connect.Entry(ta).State = System.Data.Entity.EntityState.Modified;
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
            

            if (checkData())
            {
                MessageBox.Show("Die Daten müssen vollständig sein bevor die Änderungen gespeichert werden können.");
                return;
            }

            saveOperation();
            
            MessageBox.Show("Änderungen gespeichert!");
        }

    }
}

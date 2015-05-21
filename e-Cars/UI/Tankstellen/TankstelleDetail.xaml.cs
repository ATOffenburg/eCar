using e_Cars.UI.Helper;
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
using System.Text.RegularExpressions;

namespace e_Cars.UI.Tankstellen
{
    /// <summary>
    /// Interaktionslogik für TankstelleDetail.xaml
    /// </summary>
    public partial class TankstelleDetail : Window
    {

        MainWindow mw { get; set; }

        public TankstelleInfo ti { get; set; }

        public Projekt2Entities connect = null;

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

            InitializeComponent();
        }

        private List<TanksaeuleInfo> listtanksaeuleinfo = null;


        public List<TanksaeuleInfo> listTanksaeuleInfo
        {
            get { return listtanksaeuleinfo; }
            set
            {
                listtanksaeuleinfo = value;
                NotifyPropertyChanged("listTanksaeuleInfo");
            }
        }

        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            //mw.setTankstelleOverview();
            this.Close();
        }

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
       

        public event PropertyChangedEventHandler PropertyChanged;

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

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(myListView.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

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

        

        public bool sthChanged = false;

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            

            if (checkData())
            {
                MessageBox.Show("Die Daten müssen vollständig sein bevor die Änderungen gespeichert werden können.");
                return;
            }

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
            MessageBox.Show("Änderungen gespeichert!");
        }

    }
}

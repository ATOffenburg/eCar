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

namespace e_Cars.UI.Tankstellen
{
    /// <summary>
    /// Interaktionslogik für TankstelleNew.xaml
    /// </summary>
    public partial class TankstelleNew : Window, INotifyPropertyChanged
    {
        MainWindow mw { get; set; }

        private TankstelleInfo ti { get; set; }

        public Projekt2Entities connect = null;

        public TankstelleNew(MainWindow mw, Projekt2Entities con)
        {

            this.mw = mw;
            this.ti = new TankstelleInfo(new Tankstelle());

            this.DataContext = this;

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
                String s = TBBreitengrad.Text;

                for (int i = 0; i < s.Length; i++)
                {
                    Char c = s[i];
                    if (!Char.IsNumber(c))
                    {
                        MessageBox.Show("Bitte nur Zahlen eingeben", "Achtung!", MessageBoxButton.OK, MessageBoxImage.Hand);
                        continue;
                    }

                }
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

            if (String.IsNullOrWhiteSpace(ID.ToString()))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(breitengrad.ToString()))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(laengengrad.ToString()))
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
                MessageBox.Show("Die Daten müssen vollständig sein bevor sie gespeichert werden können.");
                return;
            }

            Tankstelle ta = new Tankstelle();
            ta.Name = ti.Name;
            ta.breitengrad = ti.Breitengrad;
            ta.laengengrad = ti.Längengrad;
            ta.Ort = ti.Ort;
            ta.PLZ = ti.PLZ;
            ta.Stasse = ti.Strasse;
            ta.Tankstelle_ID = ti.ID;

            ta = connect.Tankstelle.Add(ta);
            connect.SaveChanges();
            MessageBox.Show("Die Tankstelle wurde erfolgreich angelegt");
            List<TanksaeuleInfo> listTanksaeule = new List<TanksaeuleInfo>();

            ti.ID = ta.Tankstelle_ID;

            var tanks = from t in connect.Tanksaeule
                        where t.Tankstelle_ID == ti.ID
                        select t;

            foreach (var vt in tanks)
            {
                TanksaeuleInfo tsi = new TanksaeuleInfo(vt);
                listTanksaeule.Add(tsi);
            }
            listTanksaeuleInfo = listTanksaeule;
            myListView.Items.Refresh();

            sthChanged = true;


        }

        public TankstelleInfo tAngelegt = null;

        private void clearFields()
        {
            tAngelegt = ti;
            ti = new TankstelleInfo(new Tankstelle());

            ID = 0;
            breitengrad = null;
            laengengrad = null;
            Ort = "";
            PLZ = "";
            Strasse = "";
            TName = "";

        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            clearFields();
        }

    }
}

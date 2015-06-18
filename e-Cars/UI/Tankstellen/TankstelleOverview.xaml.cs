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
    /// Interaktionslogik für TankstellenOverview.xaml
    /// </summary>
    public partial class TankstelleOverview : UserControl, INotifyPropertyChanged
    {

        private MainWindow mw { get; set; }


        private List<TankstelleInfo> listtankstelleinfo = null;

        /// <summary>
        /// Accessor Methode für die TankstellenInfo Liste
        /// </summary>
        public List<TankstelleInfo> listTankstelleInfo
        {
            get { return listtankstelleinfo; }
            set
            {
                listtankstelleinfo = value;
                NotifyPropertyChanged("listTankstelleInfo");
            }
        }

        /// <summary>
        /// Konstruktor für die TankstelleOverview
        /// </summary>
        /// <param name="mw"></param>

        public TankstelleOverview(MainWindow mw)
        {
            this.mw = mw;
            this.DataContext = this;
            InitializeComponent();
        }
        /// <summary>
        /// Der Zurück Button: Wechselt wieder in das Menu Stammdatenverwaltung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            mw.setMenuStammdatenVerwaltung();
        }
        /// <summary>
        /// Der Neu-Anlegen Button: Öffnet ein neues Fenster in dem eine Tankstelle angelegt werden kann (TankstelleNew)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreateNew_Click(object sender, RoutedEventArgs e)
        {
            using (Projekt2Entities con = new Projekt2Entities())
            {
                TankstelleNew tnew = new TankstelleNew(mw, con);

                tnew.ShowDialog();

                if (tnew.sthChanged != false)
                {

                    listTankstelleInfo = getListOfTankstelleInfo(null);

                    //listTankstelleInfo.Add(tnew.tAngelegt);
                    //myListView.Items.Refresh();
                }
            }
        }
        /// <summary>
        /// Befüllt die Liste listTankstellenInfo mit Tankstellen aus der DB
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        private List<TankstelleInfo> getListOfTankstelleInfo(string filter)
        {
            List<TankstelleInfo> listTankstelleInfo = new List<TankstelleInfo>();
            using (Projekt2Entities con = new Projekt2Entities())
            {
                foreach (Tankstelle t in con.Tankstelle)
                {
                    TankstelleInfo ti = new TankstelleInfo(t);
                    listTankstelleInfo.Add(ti);
                }
            }
            return listTankstelleInfo;
        }
        /// <summary>
        /// Delegate für die Oberflächenaktualisierung
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Meldet wenn sich die Liste listTankstellenInfo geändert hat
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
        /// Wenn die Ansicht geladen wurde wird die Liste  gefüllt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listTankstelleInfo = getListOfTankstelleInfo(null);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                listTankstelleInfo = getListOfTankstelleInfo(null);
            }
        }


        /// <summary>
        /// Beim "Doppelklick" auf eine Element der myListView wird die Detailansicht geöffnet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as TankstelleInfo;
            if (item != null)
            {
                using (Projekt2Entities con = new Projekt2Entities())
                {
                    TankstelleDetail td = new TankstelleDetail(mw, item, con);
                    td.ShowDialog();

                    if (td.sthChanged != false)
                    {
                        int index = listtankstelleinfo.FindIndex(s => s.tankstelle.Tankstelle_ID == td.ti.ID);
                        listtankstelleinfo[index] = td.ti;

                        ICollectionView view = CollectionViewSource.GetDefaultView(listtankstelleinfo);
                        view.Refresh();
                    }
                }

                myListView.Items.Refresh();
            }
        }



        /// <summary>
        /// Legt die Sortierrichtung fest und startet das Sortieren
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
        /// <summary>
        /// Sortieren der ListView
        /// </summary>
        /// <param name="sortBy"></param> Was sortiert werden soll
        /// <param name="direction"></param> In welche Richtung..
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
        /// Sobald sich der Text im Filter ändert wird diese Methode getriggert die wieder um den UserFilter triggert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(myListView.ItemsSource).Filter = UserFilter;
            CollectionViewSource.GetDefaultView(myListView.ItemsSource).Refresh();
        }
        /// <summary>
        /// Filtert anhand der Eingabe die zur Filterung angegebenen Spalten
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(TextBoxFilter.Text))
                return true;
            else
            {
                var userI = (TankstelleInfo)item;
                return (userI.Name.StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                    userI.ID.ToString().StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                    userI.Breitengrad.ToString().StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                    userI.Längengrad.ToString().StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                    userI.PLZ.StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                    userI.Ort.StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                    userI.Strasse.StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase));
            }
        }


    }


}

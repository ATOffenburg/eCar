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

namespace e_Cars.UI.Kartenverwaltung
{
    /// <summary>
    /// Interaktionslogik für TankstellenOverview.xaml
    /// </summary>
    public partial class KartenOverview : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Accessor Methode von der Variable MainWindow
        /// </summary>
        private MainWindow mw { get; set; }


        private List<KartenInfo> listkarteninfo = null;

        /// <summary>
        /// Accesor-Methode von listKartenInfo
        /// </summary>
        public List<KartenInfo> listKartenInfo
        {
            get { return listkarteninfo; }
            set
            {
                listkarteninfo = value;
                NotifyPropertyChanged("listKartenInfo");
            }
        }
        /// <summary>
        /// Konstruktor für KartenOverview
        /// </summary>
        /// <param name="mw"></param>

        public KartenOverview(MainWindow mw)
        {
            this.mw = mw;
            this.DataContext = this;
            InitializeComponent();
        }

        /// <summary>
        /// Zurückkehren zum Menur Stammdatenverwaltung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            mw.setMenuStammdatenVerwaltung();
        }
        /// <summary>
        /// Öffnet das KartenNew Fenster um neue Karten anzulegen. Diese speichert diese dann in der Datenbank.
        /// Die Liste wird lokal ohne DB Abfrage aktualisiert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreateNew_Click(object sender, RoutedEventArgs e)
        {
            using (Projekt2Entities con = new Projekt2Entities())
            {
                KartenNew knew = new KartenNew(mw, con);

                knew.ShowDialog();

                if (knew.sthChanged != false)
                {
                    listKartenInfo.Add(knew.kAngelegt);
                    myListView.Items.Refresh();
                }
            }
        }
        /// <summary>
        /// holt die Daten aus der Datenbank
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        private List<KartenInfo> getListOfKartenInfo(string filter)
        {
            List<KartenInfo> listKartenInfo = new List<KartenInfo>();
            using (Projekt2Entities con = new Projekt2Entities())
            {
                foreach (Karte k in con.Karte)
                {
                    KartenInfo ki = new KartenInfo(k);
                    listKartenInfo.Add(ki);
                }
            }
            return listKartenInfo;
        }
        /// <summary>
        /// Delegate für die Oberflächenaktualisierung
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Meldet wenn sich die Liste listKartenInfo geändert hat
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
        /// Sobald die Ansicht geladen wird, startet das Füllen der Liste mit Daten aus der DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listKartenInfo = getListOfKartenInfo(null);
        }
        /// <summary>
        /// Beim "Doppelklick" auf eine Element der myListView wird die Detailansicht geöffnet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as KartenInfo;
            if (item != null)
            {
                using (Projekt2Entities con = new Projekt2Entities())
                {
                    KartenDetail kd = new KartenDetail(mw, item, con);
                    kd.ShowDialog();

                    if (kd.sthChanged != false)
                    {
                        int index = listkarteninfo.FindIndex(s => s.Karten_ID == kd.Karten_ID);
                        listkarteninfo[index] = kd.ki;

                        ICollectionView view = CollectionViewSource.GetDefaultView(listkarteninfo);
                        view.Refresh();
                        myListView.Items.Refresh();
                    }
                }

                
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
        /// Sobald eine Eingabe getätigt wird, soll nach dem Gefiltert werden
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
                var kartI = (KartenInfo)item;
                return (
                    kartI.Karten_ID.ToString().StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                    kartI.Kunde_ID.ToString().StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                    kartI.Sperrdatum.ToString().StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                    kartI.Sperrvermerk.StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase));
            }
        }


    }


}

using e_Cars.UI.Helper;
using e_Cars.Datenbank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    /// Interaktionslogik für UserOverview.xaml
    /// </summary>
    public partial class UserOverview : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Accessor Methode von der Variable MainWindow
        /// </summary>
        private MainWindow mw { get; set; }

        /// <summary>
        /// Konstruktor für UserOverview
        /// </summary>
        /// <param name="mw"></param>
        public UserOverview(MainWindow mw)
        {
            this.mw = mw;
            this.DataContext = this;
            InitializeComponent();


        }

        private static List<UserInfo> listuserinfo = null;
        /// <summary>
        /// Accesor-Methode von listUserInfo
        /// </summary>
        public List<UserInfo> listUserInfo
        {
            get { return listuserinfo; }
            set
            {
                listuserinfo = value;
                NotifyPropertyChanged("listUserInfo");
            }
        }

        /// <summary>
        /// Delegate für die Oberflächenaktualisierung
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Meldet wenn sich die Liste listUserInfo geändert hat
        /// </summary>
        /// <param name="info"></param>
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private ProgressDialog pg = null;

        /// <summary>
        /// Aufgrund der großen Ladedauer vom einmaligen holen der Daten aus der DB
        /// wird das Laden auf einen Thread ausgelagert und ein Progressdialog zur 
        /// Informartion für den User gestartet. So wird das Programm nicht lahm gelegt.
        /// </summary>
        private void loadData()
        {
            // Hier die User Daten laden...
            if (listuserinfo == null)
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(workerDoWork);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerRunWorkerCompleted);
                worker.RunWorkerAsync();
                pg = new ProgressDialog();
                pg.ShowDialog();

            }
        }
        /// <summary>
        /// Die Arbeit für den Backgroundworker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void workerDoWork(object sender, DoWorkEventArgs e)
        {
            listUserInfo = getListOfUserInfo(null);
        }
        /// <summary>
        /// Wenn der Thread fertig ist wird der Progressdialog geschlossen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void workerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pg.Close();

        }
        /// <summary>
        /// holt die Daten aus der Datenbank
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        private List<UserInfo> getListOfUserInfo(string filter)
        {

            List<UserInfo> listUserInfo = new List<UserInfo>();
            using (Projekt2Entities con = new Projekt2Entities())
            {
                foreach (Kunde k in con.Kunde)
                {
                    UserInfo ui = new UserInfo(k);
                    listUserInfo.Add(ui);
                }
            }

            return listUserInfo;
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
        /// Öffnet das UserNew Fenster um neue Kunden anzulegen. Diese speichert diese dann in der Datenbank.
        /// Die Liste wird lokal ohne DB Abfrage aktualisiert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ButtonCreateNew_Click(object sender, RoutedEventArgs e)
        {
            //mw.setUserNew();
            UserNew unew = new UserNew(mw);

            unew.ShowDialog();

            if (unew.sthChanged != false)
            {
                listuserinfo.Add(unew.ui);
                myListView.Items.Refresh();
            }

        }
        /// <summary>
        /// Sobald die Ansicht geladen wird, startet der Thread zum holen der Daten aus der DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();
        }
        /// <summary>
        /// Beim "Doppelklick" auf eine Element der myListView wird die Detailansicht geöffnet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as UserInfo;
            if (item != null)
            {
                //mw.setUserDetail(item);

                UserDetail uDt = new UserDetail(mw, item);
                // Damit es im Vordergrun bleibt...
                uDt.Owner = mw;
                // Damit man erkennt das ein Dialog geöffnet ist...
                uDt.ShowInTaskbar = true;                
                uDt.ShowDialog();

                if (uDt.sthChanged != false)
                {
                    int index = listuserinfo.FindIndex(s => s.kunde.Kunde_ID == uDt.ui.kunde.Kunde_ID);
                    listuserinfo[index] = uDt.ui;

                    ICollectionView view = CollectionViewSource.GetDefaultView(listuserinfo);
                    view.Refresh();
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
                var userI = (UserInfo)item;
                return (userI.Name.StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                    userI.Vorname.StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                    userI.Ort.StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                    userI.Strasse.StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                    userI.PLZ.StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                    userI.Hausnummer.StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                    userI.BIC.StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                    userI.IBAN.StartsWith(TextBoxFilter.Text, StringComparison.OrdinalIgnoreCase));
            }
        }




    }
}

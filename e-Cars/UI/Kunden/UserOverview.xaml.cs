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

        private MainWindow mw { get; set; }
        public UserOverview(MainWindow mw)
        {
            this.mw = mw;
            this.DataContext = this;
            InitializeComponent();
        }

        private List<UserInfo> listuserinfo = null;

        public List<UserInfo> listUserInfo
        {
            get { return listuserinfo; }
            set
            {
                listuserinfo = value;
                NotifyPropertyChanged("listUserInfo");
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

        public ProgressDialog pg = null;

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

        void workerDoWork(object sender, DoWorkEventArgs e)
        {
            listUserInfo = getListOfUserInfo(null);
        }

        void workerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pg.Close();
        }

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

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            mw.setMenuStammdatenVerwaltung();
        }

        private void ButtonCreateNew_Click(object sender, RoutedEventArgs e)
        {
            mw.setUserNew();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        private void myListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as UserInfo;
            if (item != null)
            {
                mw.setUserDetail(item);
            }
        }

        private void TextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;

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



    }
}

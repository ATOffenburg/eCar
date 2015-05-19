using e_Cars.Datenbank;
using e_Cars.UI.Helper;
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

namespace e_Cars.UI.Reservierungen
{
    /// <summary>
    /// Interaktionslogik für ReservierungOverview.xaml
    /// </summary>
    public partial class ReservierungOverview : UserControl, INotifyPropertyChanged
    {

        private GridViewColumnHeader _CurSortCol = null;
        private SortAdorner _CurAdorner = null;

        private bool reservierunggesperrt;
        public bool ReservierungGesperrt
        {
            get { return reservierunggesperrt; }
            set
            {
                reservierunggesperrt = value;
                NotifyPropertyChanged("ReservierungGesperrt");
            }
        }

        private DateTime? anzeigedatum;
        public DateTime? AnzeigeDatum
        {
            get { return anzeigedatum; }
            set
            {
                anzeigedatum = value;
                NotifyPropertyChanged("AnzeigeDatum");
            }
        }

        private List<ReservierungInfo> listreservierunginfo = null;
        public List<ReservierungInfo> listReservierungInfo
        {
            get { return listreservierunginfo; }
            set
            {
                listreservierunginfo = value;
                NotifyPropertyChanged("listReservierungInfo");
            }
        }

        public MainWindow mw { get; set; }
        public ReservierungOverview(MainWindow mw)
        {
            this.mw = mw;
            this.DataContext = this;

            InitializeComponent();

            AnzeigeDatum = DateTime.Now;

            listReservierungInfo = loadReservierungsListe(null);
        }

        private List<ReservierungInfo> loadReservierungsListe(String filter)
        {

            List<ReservierungInfo> listReservierungInfo = new List<ReservierungInfo>();
            Projekt2Entities con = new Projekt2Entities();

            foreach (Reservierung res in con.Reservierung.Where(s =>
                                                            s.Startzeit.Year == AnzeigeDatum.Value.Year &&
                                                            s.Startzeit.Month == AnzeigeDatum.Value.Month &&
                                                            s.Startzeit.Day == AnzeigeDatum.Value.Day))
            {
                ReservierungInfo ri = new ReservierungInfo(res);
                listReservierungInfo.Add(ri);
            }

            return listReservierungInfo;
        }


        private void ButtonCreateNew_Click(object sender, RoutedEventArgs e)
        {
            checkReservierungGesperrt();

            if (ReservierungGesperrt)
            {
                MessageBox.Show("Reservierungen sind gesperrt!");
                return;
            }

            mw.setReservierungNew();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            mw.setMenu();
        }

        private void myListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private void CheckBoxReservierung_Click(object sender, RoutedEventArgs e)
        {
            ReservierungGesperrtHelper.setReservierungGesperrt(ReservierungGesperrt);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            checkReservierungGesperrt();
        }

        private void checkReservierungGesperrt()
        {
            ReservierungGesperrt = ReservierungGesperrtHelper.IsReservierungGesperrt();
        }

        private void DatepickerDatum_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            listReservierungInfo = loadReservierungsListe(null);
        }

        private void SortClick(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = sender as GridViewColumnHeader;
            String field = column.Tag as String;

            if (_CurSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(_CurSortCol).Remove(_CurAdorner);
                myListView.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (_CurSortCol == column && _CurAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            _CurSortCol = column;
            _CurAdorner = new SortAdorner(_CurSortCol, newDir);
            AdornerLayer.GetAdornerLayer(_CurSortCol).Add(_CurAdorner);
            myListView.Items.SortDescriptions.Add(new SortDescription(field, newDir));
        }

    }
}

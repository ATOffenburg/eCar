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
        /// <summary>
        /// Gibt an ob neue Reservierungen angelegt werden dürfen
        /// </summary>
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
        /// <summary>
        /// Das Datum für die Angezeigten Reservierungen
        /// </summary>
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
        /// <summary>
        /// eine Liste mit den Reservierungen
        /// </summary>
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
        /// <summary>
        /// Konstruktor
        /// </summary>
        public ReservierungOverview(MainWindow mw)
        {
            this.mw = mw;
            this.DataContext = this;

            InitializeComponent();

            AnzeigeDatum = DateTime.Now;


        }






        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                listReservierungInfo = loadReservierungsListe(null);
            }
        }

        private List<ReservierungInfo> loadReservierungsListe(String filter)
        {

            List<ReservierungInfo> listReservierungInfo = new List<ReservierungInfo>();
            using (Projekt2Entities con = new Projekt2Entities())
            {
                foreach (Reservierung res in con.Reservierung.Where(s =>
                                                                s.Startzeit.Year == AnzeigeDatum.Value.Year &&
                                                                s.Startzeit.Month == AnzeigeDatum.Value.Month &&
                                                                s.Startzeit.Day == AnzeigeDatum.Value.Day))
                {
                    ReservierungInfo ri = new ReservierungInfo(res);

                    if (UseFilter(filter, ri)) { 

                    listReservierungInfo.Add(ri);
                    }
                    
                    }
            }
            return listReservierungInfo;
        }


        private bool UseFilter(String filter, ReservierungInfo ri)
        {

            if (String.IsNullOrWhiteSpace(filter))
                return true;

            foreach (var sel in filter.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {

                if (ri.Startzeit != null)
                {
                    if (containsWithException(ri.Startzeit.ToLongDateString(), sel))
                        return true;
                }

                if (ri.Endzeit != null)
                {
                    if (containsWithException(ri.Endzeit.GetValueOrDefault().ToLongDateString(), sel))
                        return true;
                }

                if (ri.AbgabeortName != null)
                {
                    if (containsWithException(ri.AbgabeortName, sel))
                        return true;
                }

                if (ri.AbholortName != null)
                {
                    if (containsWithException(ri.AbholortName, sel))
                        return true;
                }

                if (ri.status != null)
                {
                    if (containsWithException(ri.status.Statusbezeichnung, sel))
                        return true;
                }

                if (ri.KundeName != null)
                {
                    if (containsWithException(ri.KundeName, sel))
                        return true;
                }

            }
            return false;
        }

        private bool containsWithException(String s1, String s2)
        {
            try
            {
                if (s1.ToLower().Contains(s2.ToLower()))
                {
                    return true;
                }
            }
            catch (Exception)
            {
            }

            return false;
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
            var item = ((FrameworkElement)e.OriginalSource).DataContext as ReservierungInfo;
            if (item != null)
            {
                mw.setReservierungDetail(item);
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

        private void CheckBoxReservierung_Click(object sender, RoutedEventArgs e)
        {
            ReservierungGesperrtHelper.setReservierungGesperrt(ReservierungGesperrt);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            listReservierungInfo = loadReservierungsListe(null);

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




        private void TextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox != null)
            {
                listReservierungInfo = loadReservierungsListe(textbox.Text);
            }
        }

    }
}

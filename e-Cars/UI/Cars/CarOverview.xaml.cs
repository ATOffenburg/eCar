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

namespace e_Cars.UI.Cars
{
    /// <summary>
    /// Interaktionslogik für CarOverview.xaml
    /// </summary>
    public partial class CarOverview : UserControl, INotifyPropertyChanged
    {

        private GridViewColumnHeader _CurSortCol = null;
        private SortAdorner _CurAdorner = null;

        private MainWindow mw { get; set; }
        /// <summary>
        /// Konstruktor für die Caroverview Klasse
        /// </summary>
        /// <param name="mw"></param>
        public CarOverview(MainWindow mw)
        {
            this.mw = mw;
            this.DataContext = this;
            InitializeComponent();
        }

        private List<CarInfo> listcarsinfo = null;

        /// <summary>
        /// Accessor Methode für eine Liste mit den Fahrzeugen
        /// </summary>
        public List<CarInfo> listCarsInfo
        {
            get
            {
                return listcarsinfo;
            }
            set
            {
                listcarsinfo = value;
                NotifyPropertyChanged("listCarsInfo");
            }
        }

        private void loadData()
        {
            // Hier die Car Daten laden...
            listCarsInfo = getListOfCarsInfo(TextBoxFilter.Text);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                listCarsInfo = getListOfCarsInfo(TextBoxFilter.Text);
                //myListView.Items.Refresh();
            }
        }

        private List<CarInfo> getListOfCarsInfo(string filter)
        {
            List<CarInfo> listCarsInfo = new List<CarInfo>();
            using (Projekt2Entities con = new Projekt2Entities())
            {
                foreach (Car c in con.Car)
                {
                    CarInfo ci = new CarInfo(c);
                    if (UseFilter(filter, ci))
                    {
                        listCarsInfo.Add(ci);
                    }
                }
            }
            return listCarsInfo;
        }

        private void myListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as CarInfo;
            if (item != null)
            {
                mw.setCarDetail(item);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            mw.setMenuStammdatenVerwaltung();
        }

        private void ButtonCreateNew_Click(object sender, RoutedEventArgs e)
        {
            mw.setCarNew();
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
               listCarsInfo = getListOfCarsInfo(textbox.Text);
            }

        }

        private bool UseFilter(String filter, CarInfo ci)
        {
            
            if (String.IsNullOrWhiteSpace(filter))
                return true;

            foreach (var sel in filter.Split(new Char[] { ' ' } , StringSplitOptions.RemoveEmptyEntries))
            {

                if (containsWithException(ci.Kilometer, sel))
                    return true;

                if (containsWithException(ci.Seriennummer, sel))
                    return true;

                if (containsWithException(ci.Tankvorgaenge, sel))
                    return true;

                if (containsWithException(ci.Wartungstermin, sel))
                    return true;

            }
            return false;
        }

        private bool containsWithException(String s1, String s2){
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

    }

}

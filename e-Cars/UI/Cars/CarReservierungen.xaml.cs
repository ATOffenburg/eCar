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
    /// Interaktionslogik für CarReservierungen.xaml
    /// </summary>
    public partial class CarReservierungen : UserControl, INotifyPropertyChanged
    {

        private GridViewColumnHeader _CurSortCol = null;
        private SortAdorner _CurAdorner = null;

        private MainWindow mw { get; set; }

        private CarInfo ci { get; set; }

        private List<Reservierung> listereservierungen;
        /// <summary>
        /// Accessor Methode für die Fahrten
        /// </summary>
        public List<Reservierung> listeReservierungen
        {
            get { return listereservierungen; }
            set
            {
                listereservierungen = value;

                NotifyPropertyChanged("listeReservierungen");
            }
        }


        private Projekt2Entities con;

        public CarReservierungen(MainWindow mw, CarInfo ci)
        {

            this.mw = mw;
            
            InitializeComponent();
            this.DataContext = this;


            con = new Projekt2Entities();
                var carid = (int?) ci.c.Car_ID;
                listeReservierungen = con.Reservierung.Where(s => s.Car_ID == carid).ToList();
                
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            mw.setCarDetail();
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
    }
}

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
    /// Interaktionslogik für CarFahrtenliste.xaml
    /// </summary>
    public partial class CarFahrtenliste : UserControl, INotifyPropertyChanged
    {

        private GridViewColumnHeader _CurSortCol = null;
        private SortAdorner _CurAdorner = null;


        private List<Fahrt> listefahrten;

        public List<Fahrt> listeFahrten
        {
            get { return listefahrten; }
            set { listefahrten = value;

            NotifyPropertyChanged("listeFahrten");
            }
        }

         private MainWindow mw { get; set; }
            
        public CarFahrtenliste(MainWindow mw, CarInfo ci)
        {
            this.mw = mw;
            this.DataContext = this;
            
            InitializeComponent();

            if (ci != null)
            {

                Projekt2Entities con = new Projekt2Entities();

                listeFahrten = con.Fahrt.Where(s => s.Car_ID == ci.c.Car_ID).ToList();

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

    }
}

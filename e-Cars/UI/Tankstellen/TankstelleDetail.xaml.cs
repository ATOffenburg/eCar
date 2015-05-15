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
    /// Interaktionslogik für TankstelleDetail.xaml
    /// </summary>
    public partial class TankstelleDetail : Window
    {

        MainWindow mw { get; set; }

        public TankstelleInfo ti { get; set; }


        public TankstelleDetail(MainWindow mw, TankstelleInfo ti, Projekt2Entities con)
        {

            this.mw = mw;
            this.ti = ti;

            this.DataContext = this;

            InitializeComponent();
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
                return ti.breitengrad;
            }
            set
            {
                ti.breitengrad = value;
                NotifyPropertyChanged("breitengrad");
            }
        }

        public Double? laengengrad
        {
            get
            {
                return ti.laengengrad;
            }
            set
            {
                ti.laengengrad = value;
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

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}

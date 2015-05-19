using e_Cars.UI.Cars;
using e_Cars.UI.Kunden;
using e_Cars.UI.Map;
using e_Cars.UI.Reservierungen;
using e_Cars.UI.Tankstellen;
using e_Cars.UI.Kartenverwaltung;
using System;
using System.Collections.Generic;
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

namespace e_Cars
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private CarOverview co { get; set; }
        private UserOverview uo { get; set; }
        private TankstelleOverview to { get; set; }
        private ReservierungOverview ro { get; set; }
        private KartenOverview ko { get; set; }

        private CarDetail cd { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            setMenu();
        }

        internal void setMenu()
        {
            MainGrid.Children.Clear();
            Menu m = new Menu(this);
            MainGrid.Children.Add(m);
        }

        internal void setMenuStammdatenVerwaltung()
        {
            MainGrid.Children.Clear();
            MenuStammdatenVerwalten msv = new MenuStammdatenVerwalten(this);
            MainGrid.Children.Add(msv);
        }

        internal void setCarOverview(bool reset = false)
        {
            MainGrid.Children.Clear();

            if (reset == true)
            {
                this.co = null;
            }

            if (this.co == null)
            {
                this.co = new CarOverview(this);
            }

            MainGrid.Children.Add(co);
        }

        internal void setCarNew()
        {
            MainGrid.Children.Clear();
            CarNew cn = new CarNew(this);
            MainGrid.Children.Add(cn);
        }

        internal void setCarDetail(CarInfo ci)
        {
            MainGrid.Children.Clear();
            cd = new CarDetail(this, ci);
            MainGrid.Children.Add(cd);
        }

        internal void setCarDetail()
        {
            MainGrid.Children.Clear();
            if (cd != null)
            {
                MainGrid.Children.Add(cd);
            }
            else
            {
                MainGrid.Children.Add(co);
            }
        }

        internal void setCarFahrtenliste(CarInfo ci)
        {
            MainGrid.Children.Clear();
            CarFahrtenliste cf = new CarFahrtenliste(this, ci);
                MainGrid.Children.Add(cf);
        }

        internal void setUserOverview(bool reset = false)
        {
            MainGrid.Children.Clear();
            if (reset == true)
            {
                this.uo = null;
            }
            if (this.uo == null)
            {
                this.uo = new UserOverview(this);
            }
            MainGrid.Children.Add(uo);
        }

        internal void setKartenOverview(bool reset = false)
        {
            MainGrid.Children.Clear();
            if (reset == true)
            {
                this.ko = null;
            }
            if (this.ko == null)
            {
                this.ko = new KartenOverview(this);
            }
            MainGrid.Children.Add(ko);
        }


        internal void setTankstelleOverview(bool reset = false)
        {
            MainGrid.Children.Clear();
            if (reset == true)
            {
                this.to = null;
            }
            if (this.to == null)
            {
                this.to = new TankstelleOverview(this);
            }
            MainGrid.Children.Add(to);
        }


        internal void setGMaps()
        {
            MainGrid.Children.Clear();
            GMaps map = new GMaps(this);
            MainGrid.Children.Add(map);
        }

        internal void setReservierungOverview(bool reset = false)
        {
            MainGrid.Children.Clear();
            if (reset == true)
            {
                this.ro = null;
            }
            if (this.ro == null)
            {
                this.ro = new ReservierungOverview(this);
            }
            MainGrid.Children.Add(ro);
        }

        internal void setReservierungNew()
        {
            MainGrid.Children.Clear();
            ReservierungNew rn = new ReservierungNew(this);
            MainGrid.Children.Add(rn);
        }

        internal void setReservierungDetail(ReservierungInfo item)
        {
            MainGrid.Children.Clear();
            ReservierungDetail rd = new ReservierungDetail(this, item);
            MainGrid.Children.Add(rd);
        }
    }
}

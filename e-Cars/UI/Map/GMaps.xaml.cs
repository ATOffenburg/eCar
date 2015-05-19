using e_Cars.Datenbank;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
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

namespace e_Cars.UI.Map
{
    /// <summary>
    /// Interaktionslogik für GMaps.xaml
    /// </summary>
    public partial class GMaps : UserControl
    {


        String sURL = AppDomain.CurrentDomain.BaseDirectory + "html/GMaps.html";
        private MainWindow mw { get; set; }

        public GMaps(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();

            Uri uri = new Uri(sURL);
            webBrowser1.Navigate(uri);
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            webBrowser1.InvokeScript("deleteMarkers");
            webBrowser1.InvokeScript("setMarker", new String[] { "76.23334", "45.2342344", "Test" });
            webBrowser1.InvokeScript("zoomOnMarkers");
        }

        private void webBrowser1_Loaded(object sender, RoutedEventArgs e)
        {
            ((WebBrowser)sender).ObjectForScripting = new HtmlInteropInternalTestClass();
        }

        private void loadData(int selection)
        {
            if (selection == 0)
            {
                webBrowser1.InvokeScript("deleteMarkers");
                // Tankstellen
                using (Projekt2Entities con = new Projekt2Entities())
                {
                    foreach (Tankstelle ts in con.Tankstelle)
                    {
                        string[] sarr = new String[] { ts.breitengrad.GetValueOrDefault(0).ToString(CultureInfo.InvariantCulture), ts.laengengrad.GetValueOrDefault(0).ToString(CultureInfo.InvariantCulture), ts.Name };
                        webBrowser1.InvokeScript("setMarker", sarr);
                    }
                }
                webBrowser1.InvokeScript("zoomOnMarkers");
            }
            else if (selection == 1)
            {
                // Verfügbare Fahrzeuge
                webBrowser1.InvokeScript("deleteMarkers");
                using (Projekt2Entities con = new Projekt2Entities())
                {
                    foreach (Car c in con.Car)
                    {
                        if (c.Status_ID == 4)
                        {
                            Fahrt f = c.Fahrt.OrderByDescending(s => s.Endzeit).FirstOrDefault();
                            if (f != null)
                            {
                                string[] sarr = new String[] { f.Tanksaeule.Tankstelle.breitengrad.GetValueOrDefault(0).ToString(CultureInfo.InvariantCulture), f.Tanksaeule.Tankstelle.laengengrad.GetValueOrDefault(0).ToString(CultureInfo.InvariantCulture), f.Tanksaeule.Tankstelle.Name };
                                webBrowser1.InvokeScript("setMarker", sarr);
                            }

                        }
                    }
                }
                //string[] sarr = new String[] { "48.359708", "7.819914", "Test Verfügbare Fahrzeuge" };
                //webBrowser1.InvokeScript("setMarker", sarr);                
                webBrowser1.InvokeScript("zoomOnMarkers");
            }
            else if (selection == 2)
            {
                // Gestohlene Fahrzeuge
                webBrowser1.InvokeScript("deleteMarkers");
                string[] sarr = new String[] { "53.548058", "9.961822", "Test Gestohlene Fahrzeuge 1" };
                webBrowser1.InvokeScript("setMarker", sarr);
                webBrowser1.InvokeScript("zoomOnMarkers");
            }

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            mw.setMenu();
        }

        private void ComboBoxTankst_Fahrz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {

                string text = (e.AddedItems[0] as ComboBoxItem).Content as string;

                if (text.Equals("Tankstellen"))
                {
                    loadData(0);
                }
                else if (text.Equals("Verfügbare Fahrzeuge"))
                {
                    loadData(1);
                }
                else if (text.Equals("Gestohlene Fahrzeuge"))
                {
                    loadData(2);
                }

            }
        }
    }

    // Object used for communication from JS -> WPF
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class HtmlInteropInternalTestClass
    {
        //public void endDragMarkerCS(Decimal Lat, Decimal Lng)
        //{
        //    ((MainWindow)Application.Current.MainWindow).tbLocation.Text = Math.Round(Lat, 5) + "," + Math.Round(Lng, 5);
        //}
    }

}

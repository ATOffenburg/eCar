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

namespace e_Cars.UI.Kundenverwaltung
{
    /// <summary>
    /// Interaktionslogik für UserNew.xaml
    /// </summary>
    public partial class ProgressDialog : Window, INotifyPropertyChanged
    {

        private MainWindow mw { get; set; }

       
        
        public ProgressDialog()
        {
            
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        
    }
}

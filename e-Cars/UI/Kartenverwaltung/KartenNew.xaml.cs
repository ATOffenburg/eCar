﻿using e_Cars.Datenbank;
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

namespace e_Cars.UI.Kartenverwaltung
{
    /// <summary>
    /// Interaktionslogik für KartenNew.xaml
    /// </summary>
    public partial class KartenNew : Window, INotifyPropertyChanged
    {
        MainWindow mw { get; set; }

        private KartenInfo ki { get; set; }

        public Projekt2Entities connect = null;

        public KartenNew(MainWindow mw, Projekt2Entities con)
        {

            this.mw = mw;
            this.ki = new KartenInfo(new Karte());

            this.DataContext = this;

            connect = con;
            InitializeComponent();
        }


        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        public int Karten_ID
        {
            get
            {
                return ki.Karten_ID;

            }
            set
            {
                ki.Karten_ID = value;
                NotifyPropertyChanged("Karten_ID");
            }
        }

        public int Kunden_ID
        {
            get
            {
                return ki.Kunde_ID;

            }
            set
            {
                ki.Kunde_ID = value;
                NotifyPropertyChanged("Kunde_ID");
            }
        }

        public bool Aktiv
        {
            get
            {
                return ki.Aktiv;
            }
            set
            {
                ki.Aktiv = value;
                NotifyPropertyChanged("Aktiv");
            }
        }

        public Nullable<System.DateTime> Sperrdatum
        {
            get
            {
                return ki.Sperrdatum;
            }
            set
            {
                ki.Sperrdatum = value;
                NotifyPropertyChanged("Sperrdatum");
            }
        }


        public String Sperrvermerk
        {
            get
            {
                return ki.Sperrvermerk;
            }
            set
            {
                ki.Sperrvermerk = value;
                NotifyPropertyChanged("Sperrvermerk");
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

        

        public bool checkData()
        {
            bool bData = false;

            if (String.IsNullOrWhiteSpace(Karten_ID.ToString()))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(Kunden_ID.ToString()))
            {
                bData = true;
            }
            
            if (String.IsNullOrWhiteSpace(Sperrdatum.ToString()))
            {
                bData = true;
            }
            if (String.IsNullOrWhiteSpace(Sperrvermerk))
            {
                bData = true;
            }
            
            return bData;
        }

        public bool sthChanged = false;

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (checkData())
            {
                MessageBox.Show("Die Daten müssen vollständig sein bevor sie gespeichert werden können.");
                return;
            }

            Karte ka = new Karte();
            ka.Karten_ID = ki.Karten_ID;
            ka.Kunde_ID = ki.Kunde_ID;
            ka.Aktiv = ki.Aktiv;
            ka.Sperrdatum = ki.Sperrdatum;
            ka.Sperrvermerk = ki.Sperrvermerk;
            
            ka = connect.Karte.Add(ka);
            connect.SaveChanges();
            MessageBox.Show("Die Karte wurde erfolgreich angelegt");
            clearFields();
            sthChanged = true;

        }

        public KartenInfo kAngelegt = null;

        private void clearFields()
        {
            kAngelegt = ki;
            ki = new KartenInfo(new Karte());

            Karten_ID = 0;
            Kunden_ID = 0;
            Aktiv = false;
            Sperrdatum = null;
            Sperrvermerk = "";
            
        }


    }
}

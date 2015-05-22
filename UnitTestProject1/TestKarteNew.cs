using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using e_Cars.UI.Kartenverwaltung;
using e_Cars.Datenbank;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using e_Cars;


namespace UnitTestProject1
{
    [TestClass]
    public class TestKarteNew
    {


       /* [ClassInitialize]
        public void TestKarteNewSetUp()
        {
            con = new Projekt2Entities();
        }*/

        /// <summary>
        /// Testet die Methode ClearFields in KarteNew
        /// </summary>
        [TestMethod]
        public void TestClearFields()
        {

                Projekt2Entities con = new Projekt2Entities();
                
                KartenNew knew = new KartenNew(null, null);
                
                // Karten_ID wird automatisch bei der Anlage erzeugt 
                // und kann weder manuell festgelegt nocht geändert werden

                knew.Kunde_ID = 470;
                knew.Sperrdatum = new DateTime(2015,05,23);
                knew.Sperrvermerk = "Wir sperren gerne und alles";
                knew.Aktiv = false;

                knew.clearFields();

                Assert.AreEqual(0, knew.Kunde_ID);
                Assert.AreEqual(null, knew.Sperrdatum);
                Assert.AreEqual("",knew.Sperrvermerk);
                Assert.AreEqual(true, knew.Aktiv);
            
            
        }

        
    }
}

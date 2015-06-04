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
        public static Projekt2Entities con;

        [ClassInitialize]
        public static void TestKarteNewSetUp(TestContext context)
        {
            con = new Projekt2Entities();
        }

        /// <summary>
        /// Testet die Methode ClearFields in KarteNew
        /// </summary>
        [TestMethod]
        public void TestClearFields()
        {
                KartenNew knew = new KartenNew(null, null);
                
                // Karten_ID wird automatisch bei der Anlage erzeugt 
                // und kann weder manuell festgelegt nocht geändert werden

                knew.Kunde_ID = 470;
                knew.Sperrdatum = new DateTime(2015,05,23);
                knew.Sperrvermerk = "Wir sperren gerne und alles";
                knew.Seriennummer = "Seriennummer XYZ";
                knew.Aktiv = false;

                knew.clearFields();

                Assert.AreEqual(0, knew.Kunde_ID);
                Assert.AreEqual(null, knew.Sperrdatum);
                Assert.AreEqual("",knew.Sperrvermerk);
                Assert.AreEqual(true, knew.Aktiv);            
        }

        [TestMethod]
        public void TestCheckData()
        {
            KartenNew knew = new KartenNew(null, null);

            bool ret;

            // positiver Fall 

            knew.Kunde_ID = 0;
            
            ret = knew.checkData();

            Assert.AreEqual(true, ret);

            // negativer Fall

            knew.Kunde_ID = 231;

            ret = knew.checkData();

            Assert.AreEqual(false, ret);
        }

        [TestMethod]
        public void TestSaveOperation()
        {
            KartenNew knew = new KartenNew(null, con);

            knew.Kunde_ID = 433;
            knew.Sperrdatum = new DateTime(2015, 05, 23);
            knew.Sperrvermerk = "Wir sperren gerne und alles";
            knew.Seriennummer = "Seriennummer XYZ";
            knew.Aktiv = false;

            knew.saveOperation();
                        
            Assert.AreEqual(knew.Kunde_ID,knew.kAngelegt.Kunde_ID);
            Assert.AreEqual(knew.Sperrdatum, knew.kAngelegt.Sperrdatum);
            Assert.AreEqual(knew.Sperrvermerk, knew.kAngelegt.Sperrvermerk);
            Assert.AreEqual(knew.Aktiv, knew.kAngelegt.Aktiv);

            Assert.AreNotEqual(0, knew.kAngelegt.Karten_ID);

        }
        
    }
}

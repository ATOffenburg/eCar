using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using e_Cars.UI.Kartenverwaltung;
using e_Cars.Datenbank;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using e_Cars;

namespace UnitTestProject1.TestKarten
{
    [TestClass]
    public class TestKarteDetail
    {

        public static Projekt2Entities con;

        [ClassInitialize]
        public static void TestKarteDetailSetUp(TestContext context)
        {
            con = new Projekt2Entities();
        }

        [TestMethod]
        public void TestClearFields()
        {
            Karte ka = con.Karte.SingleOrDefault(s => s.Karten_ID == 311);
            KartenDetail kdetail = new KartenDetail(null, new KartenInfo(ka), con);

            kdetail.clearFields();

            Assert.AreEqual(null, kdetail.Sperrdatum);
            Assert.AreEqual(null, kdetail.Sperrvermerk);
            Assert.AreEqual(true, kdetail.Aktiv);
        }

        [TestMethod]
        public void TestSaveOperation()
        {
            Karte ka = con.Karte.SingleOrDefault(s => s.Karten_ID == 311);
            KartenDetail kdetail = new KartenDetail(null, new KartenInfo(ka), con);

            kdetail.clearFields();

            kdetail.saveOperation();

            ka = con.Karte.SingleOrDefault(s => s.Karten_ID == 311);
            kdetail = new KartenDetail(null, new KartenInfo(ka), con);

            Assert.AreEqual(null, kdetail.Sperrdatum);
            Assert.AreEqual(null, kdetail.Sperrvermerk);
            Assert.AreEqual(true, kdetail.Aktiv);

            // Karte für erneuten Test wieder sperren

            kdetail.Sperrvermerk = "Wieder gesperrt";
            kdetail.Sperrdatum = new DateTime(2015, 05, 30);
            kdetail.Aktiv = false;

            kdetail.saveOperation();

            ka = con.Karte.SingleOrDefault(s => s.Karten_ID == 311);
            kdetail = new KartenDetail(null, new KartenInfo(ka), con);
            
            Assert.AreEqual("Wieder gesperrt", kdetail.Sperrvermerk);
            Assert.AreEqual(new DateTime(2015, 05, 30), kdetail.Sperrdatum);
            Assert.AreEqual(false, kdetail.Aktiv);

        }

    }
}

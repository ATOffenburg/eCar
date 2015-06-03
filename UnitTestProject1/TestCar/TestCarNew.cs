using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using e_Cars.Datenbank;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using e_Cars;
using e_Cars.UI.Cars;


namespace UnitTestProject1.TestCar
{
    [TestClass]
    public class TestCarNew
    {
        public static Projekt2Entities con;

        [ClassInitialize]
        public static void TestCarNewSetUp(TestContext context)
        {
            con = new Projekt2Entities();
        }

        /// <summary>
        /// Testet die Methode ClearFields in KarteNew
        /// </summary>
        [TestMethod]
        public void TestClearFields()
        {

            CarNew cnew = new CarNew(null);

            cnew.Seriennummer = "Test";
            Status s = new Status();
            cnew.selectedStatus = s;
            cnew.Gesperrt = true;
            cnew.SpontaneNutzungGesperrt = true;
            cnew.ReservierungGesperrt = true;
            cnew.Tankvorgaenge = 1;
            cnew.Kilometerstand = 123;
            cnew.Batterieladung = 23;
            cnew.WartungsTermin = DateTime.Now;
            
            cnew.clearFields();

            Assert.AreEqual(null, cnew.Seriennummer);
            Assert.AreEqual(null, cnew.selectedStatus);
            Assert.AreEqual(false, cnew.Gesperrt);
            Assert.AreEqual(false, cnew.ReservierungGesperrt);
            Assert.AreEqual(false, cnew.SpontaneNutzungGesperrt);
            Assert.AreEqual(0, cnew.Tankvorgaenge);
            Assert.AreEqual(null, cnew.Kilometerstand);
            Assert.AreEqual(0, cnew.Batterieladung);
            Assert.AreEqual(null, cnew.WartungsTermin);

        }

        [TestMethod]
        public void TestCheckData()
        {
            bool ret;
            CarNew cnew = new CarNew(null);

            // positiver Fall 
            cnew.Seriennummer = "Test";
            Status s = new Status();
            cnew.selectedStatus = s;
            cnew.Gesperrt = true;
            cnew.SpontaneNutzungGesperrt = true;
            cnew.ReservierungGesperrt = true;
            cnew.Tankvorgaenge = 1;
            cnew.Kilometerstand = 123;
            cnew.Batterieladung = 23;
            cnew.WartungsTermin = DateTime.Now;
            Tankstelle t = new Tankstelle();
            cnew.selectedTankstelle = t;
            ret = cnew.checkData();

            Assert.AreEqual(false, ret);

            // negativer Fall
            cnew.Seriennummer = null;
            cnew.selectedStatus = null;
            cnew.Tankvorgaenge = 0;
            cnew.Kilometerstand = null;
            cnew.Batterieladung = 0;
            cnew.WartungsTermin = null;
            ret = cnew.checkData();

            Assert.AreEqual(true, ret);
        }

    }
}

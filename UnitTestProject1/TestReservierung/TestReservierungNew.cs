using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using e_Cars.Datenbank;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using e_Cars;
using e_Cars.UI.Cars;
using e_Cars.UI.Reservierungen;


namespace UnitTestProject1.TestReservierung
{
    [TestClass]
    public class TestReservierungNew
    {
        public static Projekt2Entities con;

        [ClassInitialize]
        public static void TestReservierungNewSetUp(TestContext context)
        {
            con = new Projekt2Entities();
        }

        /// <summary>
        /// Testet die Methode ClearFields in KarteNew
        /// </summary>
        [TestMethod]
        public void TestClearFields()
        {

            ReservierungNew rn = new ReservierungNew(null);
            rn.selectedUser = new Kunde();
            rn.selectedTankstelle = new Tankstelle();
            rn.ReservierungStart = new DateTime();

            rn.clearFields();

            Assert.AreEqual(rn.selectedUser, null);
            Assert.AreEqual(rn.selectedTankstelle, null);

        }

      

    }
}

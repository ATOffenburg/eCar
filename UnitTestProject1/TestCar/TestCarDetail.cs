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
    public class TestCarDetail
    {

        public static Projekt2Entities con;

        [ClassInitialize]
        public static void TestCarDetailSetUp(TestContext context)
        {
            con = new Projekt2Entities();
        }

        [TestMethod]
        public void TestSaveOperation()
        {

            Car c = con.Car.SingleOrDefault(s => s.Car_ID == 15);
            CarDetail cdetail = new CarDetail(null, new CarInfo(c));
            double saveKilometerstand = c.Kilometerstand.GetValueOrDefault(0);

            c.Kilometerstand = 5;
            cdetail.saveOperation();
            c = con.Car.SingleOrDefault(s => s.Car_ID == 15);
            Assert.AreEqual(5, c.Kilometerstand);

            // Änderungen wider rückgangig machen...
            cdetail = new CarDetail(null, new CarInfo(c));
            c.Kilometerstand = saveKilometerstand;
            cdetail.saveOperation();

        }


        [TestMethod]
        public void TestIsTextAllowed()
        {

            Assert.AreEqual(CarDetail.IsTextAllowed("0A2sc"), false);
            Assert.AreEqual(CarDetail.IsTextAllowed("Absnc"), false);
            Assert.AreEqual(CarDetail.IsTextAllowed("123456"), true); 

        }


    }
}

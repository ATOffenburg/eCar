using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using e_Cars.UI.Tankstellen;
using e_Cars.Datenbank;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using e_Cars;

namespace UnitTestProject1.TestTankstellen
{
    [TestClass]
    public class TestTankstelleDetail
    {

        public static Projekt2Entities con;

        [ClassInitialize]
        public static void TestTankstelleDetailSetUp(TestContext context)
        {
            con = new Projekt2Entities();
        }

        [TestMethod]
        public void TestCheckData()
        {
            TankstelleInfo ti = new TankstelleInfo(new Tankstelle());

            ti.ID = 22;
            ti.Breitengrad = 42.22;
            ti.Längengrad = 23.65;
            ti.Ort = "Offenburg";
            ti.PLZ = "77656";
            ti.Strasse = "Strasse";
            ti.Name = "DIE TestTankstelle";

            TankstelleDetail tdet = new TankstelleDetail(null, ti, con);

            

            Assert.AreEqual(false, tdet.checkData());

            //Assert.AreEqual(true, tdet.checkData());
        }
        
        [TestMethod]
        public void TestSaveOperation()
        {
            TankstelleInfo ti = new TankstelleInfo(new Tankstelle());

            ti.ID = 26;
            ti.Breitengrad = 42.22;
            ti.Längengrad = 23.65;
            ti.Ort = "Offenburg";
            ti.PLZ = "77656";
            ti.Strasse = "Strasse";
            ti.Name = "DIE TestTankstelle";

            TankstelleDetail tdet = new TankstelleDetail(null, ti, con);

            tdet.breitengrad = 0;
            tdet.laengengrad = 0;
            tdet.Ort = "Freiburg";

            tdet.saveOperation();

           Tankstelle t = con.Tankstelle.SingleOrDefault(s => s.Tankstelle_ID == ti.ID);

            Assert.AreEqual(tdet.ti.Breitengrad, t.breitengrad);
            Assert.AreEqual(tdet.ti.Längengrad, t.laengengrad);
            Assert.AreEqual(tdet.ti.Ort, t.Ort);

            //tdet.breitengrad = 42.22;
            //tdet.laengengrad = 23.65;
            //tdet.Ort = "Offenburg";

            //tdet.saveOperation();

            //t = con.Tankstelle.SingleOrDefault(s => s.Tankstelle_ID == ti.ID);

            //Assert.AreEqual(tdet.ti.Breitengrad, t.breitengrad);
            //Assert.AreEqual(tdet.ti.Längengrad, t.laengengrad);
            //Assert.AreEqual(tdet.ti.Ort, t.Ort);
        }
    }
}

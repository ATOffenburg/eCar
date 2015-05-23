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
    public class TestTankstelleNew
    {
        public static Projekt2Entities con;

        [ClassInitialize]
        public static void TestTankstelleNewSetUp(TestContext context)
        {
            con = new Projekt2Entities();
        }

        [TestMethod]
        public void TestCheckData()
        {
            TankstelleNew tnew = new TankstelleNew(null, null);

            tnew.ID = 12;
            tnew.breitengrad = 42.22;
            tnew.laengengrad = 23.65;
            tnew.Ort = "Offenburg";
            tnew.PLZ = "77656";
            tnew.Strasse = "Strasse";
            tnew.TName = "DIE Tankstelle";

            Assert.AreEqual(false, tnew.checkData());

            tnew.clearFields();

            Assert.AreEqual(true, tnew.checkData());
        }

        [TestMethod]
        public void TestClearFields()
        {
            TankstelleNew tnew = new TankstelleNew(null, null);

            tnew.ID = 12;
            tnew.breitengrad = 42.22;
            tnew.laengengrad = 23.65;
            tnew.Ort = "Offenburg";
            tnew.PLZ = "77656";
            tnew.Strasse = "Strasse";
            tnew.TName = "DIE Tankstelle";

            tnew.clearFields();

            Assert.AreEqual(0, tnew.ID);
            Assert.AreEqual(null, tnew.breitengrad);
            Assert.AreEqual(null, tnew.laengengrad);
            Assert.AreEqual("", tnew.Ort);
            Assert.AreEqual("", tnew.PLZ);
            Assert.AreEqual("", tnew.Strasse);
            Assert.AreEqual("", tnew.TName);
        }

        [TestMethod]
        public void TestSaveOperation()
        {
            Tankstelle t = new Tankstelle();
            TankstelleInfo ti = new TankstelleInfo(new Tankstelle());
            TankstelleNew tnew = new TankstelleNew(null, con);

            tnew.breitengrad = 42.22;
            tnew.laengengrad = 23.65;
            tnew.Ort = "Offenburg";
            tnew.PLZ = "77656";
            tnew.Strasse = "Strasse";
            tnew.TName = "DIE TestTankstelle";

            tnew.saveOperation();

            t = con.Tankstelle.SingleOrDefault(s => s.Tankstelle_ID == tnew.tAngelegt.ID);

            Assert.AreEqual(tnew.tAngelegt.Name, t.Name);
            Assert.AreEqual(tnew.tAngelegt.Breitengrad, t.breitengrad);
            Assert.AreEqual(tnew.tAngelegt.Längengrad, t.laengengrad);
            Assert.AreEqual(tnew.tAngelegt.Ort, t.Ort);
            Assert.AreEqual(tnew.tAngelegt.PLZ, t.PLZ);
            Assert.AreEqual(tnew.tAngelegt.Strasse, t.Stasse);
        }
    }
}

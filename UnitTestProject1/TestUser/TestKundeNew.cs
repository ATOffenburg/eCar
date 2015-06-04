using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using e_Cars.UI.Kunden;
using e_Cars.Datenbank;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using e_Cars;

namespace UnitTestProject1.TestUser
{
    [TestClass]
    public class TestKundeNew
    {
        public static Projekt2Entities con;

        [ClassInitialize]
        public static void TestKundeNewSetup(TestContext context)
        {
            con = new Projekt2Entities();
        }

        [TestMethod]
        public void TestKundeNewCheckData()
        {
            UserNew unew = new UserNew(null);

            unew.Nname = "Mayer";
            unew.Vorname = "Hans";
            unew.Email = "Mayer.Hans@gmail.com";
            unew.Passwort = "Passwort";
            unew.PLZ = "77656";
            unew.Ort = "Offenburg";
            unew.Strasse = "Strasse";
            unew.Hausnummer = "22a";
            unew.BIC = "GENOCE00044563";
            unew.IBAN = "VielZuLangUmZuTippen";
                        
            Assert.AreEqual(false, unew.checkData());

            unew.clearFields();

            Assert.AreEqual(true, unew.checkData());

        }

        [TestMethod]
        public void TestKundeNewSaveOperation()
        {
            UserNew unew = new UserNew(null);

            unew.Nname = "TEST";
            unew.Vorname = "KUNDE";
            unew.Email = "Mayer.Hans@gmail.com";
            unew.Passwort = "Passwort";
            unew.PLZ = "77656";
            unew.Ort = "Offenburg";
            unew.Strasse = "Strasse";
            unew.Hausnummer = "22a";
            unew.BIC = "GENOCE00044563";
            unew.IBAN = "VielZuLangUmZuTippen";

            unew.saveOperation();

            Assert.AreEqual(unew.ui.Name, unew.Nname);
            Assert.AreEqual(unew.ui.Vorname, unew.Vorname);
            Assert.AreEqual(unew.ui.Email, unew.Email);
            Assert.AreEqual(unew.ui.Passwort, unew.Passwort);
            Assert.AreEqual(unew.ui.PLZ, unew.PLZ);
            Assert.AreEqual(unew.ui.Ort, unew.Ort);
            Assert.AreEqual(unew.ui.Strasse, unew.Strasse);
            Assert.AreEqual(unew.ui.Hausnummer, unew.Hausnummer);
            Assert.AreEqual(unew.ui.BIC, unew.BIC);
            Assert.AreEqual(unew.ui.IBAN, unew.IBAN);
            
        }

        [TestMethod]
        public void TestKundeNewClearFields()
        {
            UserNew unew = new UserNew(null);

            unew.Nname = "Mayer";
            unew.Vorname = "Hans";
            unew.Email = "Mayer.Hans@gmail.com";
            unew.Passwort = "Passwort";
            unew.PLZ = "77656";
            unew.Ort = "Offenburg";
            unew.Strasse = "Strasse";
            unew.Hausnummer = "22a";
            unew.BIC = "GENOCE00044563";
            unew.IBAN = "VielZuLangUmZuTippen";

            unew.clearFields();
            
            Assert.AreEqual("", unew.Nname);
            Assert.AreEqual("", unew.Vorname);
            Assert.AreEqual("", unew.Email);
            Assert.AreEqual("", unew.Passwort);
            Assert.AreEqual("", unew.PLZ);
            Assert.AreEqual("", unew.Ort);
            Assert.AreEqual("", unew.Strasse);
            Assert.AreEqual("", unew.Hausnummer);
            Assert.AreEqual("", unew.BIC);
            Assert.AreEqual("", unew.IBAN);

        }

    }
}

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
    public class TestKundenDetail
    {
        public static Projekt2Entities con;

        [ClassInitialize]
        public static void TestKundenDetailSetUp(TestContext context)
        {
            con = new Projekt2Entities();
        }

        [TestMethod]
        public void TestKundeDetailCheckData()
        {
            Kunde k = new Kunde();
            Adresse a = new Adresse();
            Bank b = new Bank();

            k.Kunde_ID = 440;
            k.Name = "Mayer";
            k.Vorname = "Hans";
            k.Email = "Mayer.Hans@gmail.com";
            k.Passwort = "Passwort";
            a.PLZ = "77656";
            a.Ort = "Offenburg";
            a.Strasse = "Strasse";
            a.Hausnummer = "22a";
            b.BIC = "GENOCE00044563";
            b.IBAN = "VielZuLangUmZuTippen";
            k.Adresse = a;
            k.Bank = b;

            UserInfo ui = new UserInfo(k);
            UserDetail udetail = new UserDetail(null, ui);

            Assert.AreEqual(false, udetail.checkData());

            udetail.Name = "";
            udetail.Vorname = "";
            udetail.Email = "";
            udetail.Passwort = "";
            udetail.PLZ = "";
            udetail.Ort = "";
            udetail.Strasse = "";
            udetail.HausNummer = "";
            udetail.BIC = "";
            udetail.IBAN = "";

            Assert.AreEqual(true, udetail.checkData());

        }

        [TestMethod]
        public void TestKundeDetailSaveOperation()
        {
            Kunde k = new Kunde();

            k = con.Kunde.SingleOrDefault(s => s.Kunde_ID == 440);

            UserInfo ui = new UserInfo(k);
            UserDetail udetail = new UserDetail(null, ui);

            udetail.KundeName = "Müller";
            udetail.Vorname = "Eduard";
            udetail.Email = "Müller.Eddi@gmail.com";
            udetail.Passwort = "Passwort";
            udetail.PLZ = "77656";
            udetail.Ort = "Offenburg";
            udetail.Strasse = "Strasse";
            udetail.HausNummer = "22a";
            udetail.BIC = "GENOCE00044563";
            udetail.IBAN = "VielZuLangUmZuTippen";

            udetail.saveOperation();

            k = con.Kunde.SingleOrDefault(s => s.Kunde_ID == 440);

            ui = new UserInfo(k);
            UserDetail udetailNew = new UserDetail(null, ui);

            Assert.AreEqual(udetail.KundeName, udetailNew.KundeName);
            Assert.AreEqual(udetail.Vorname, udetailNew.Vorname);
            Assert.AreEqual(udetail.Email, udetailNew.Email);
            Assert.AreEqual(udetail.Passwort, udetailNew.Passwort);
            Assert.AreEqual(udetail.PLZ, udetailNew.PLZ);
            Assert.AreEqual(udetail.Ort, udetailNew.Ort);
            Assert.AreEqual(udetail.Strasse, udetailNew.Strasse);
            Assert.AreEqual(udetail.HausNummer, udetailNew.HausNummer);
            Assert.AreEqual(udetail.BIC, udetailNew.BIC);
            Assert.AreEqual(udetail.IBAN, udetailNew.IBAN);

            // Daten wieder zurücksetzen

            udetail.KundeName = "Mayer";
            udetail.Vorname = "Hans";
            udetail.Email = "Mayer.Hans@gmail.com";
            udetail.Passwort = "Passwort";
            udetail.PLZ = "77656";
            udetail.Ort = "Offenburg";
            udetail.Strasse = "Strasse";
            udetail.HausNummer = "22a";
            udetail.BIC = "GENOCE00044563";
            udetail.IBAN = "VielZuLangUmZuTippen";

            udetail.saveOperation();

            k = con.Kunde.SingleOrDefault(s => s.Kunde_ID == 440);

            ui = new UserInfo(k);
            udetailNew = new UserDetail(null, ui);

            Assert.AreEqual(udetail.KundeName, udetailNew.KundeName);
            Assert.AreEqual(udetail.Vorname, udetailNew.Vorname);
            Assert.AreEqual(udetail.Email, udetailNew.Email);
            Assert.AreEqual(udetail.Passwort, udetailNew.Passwort);
            Assert.AreEqual(udetail.PLZ, udetailNew.PLZ);
            Assert.AreEqual(udetail.Ort, udetailNew.Ort);
            Assert.AreEqual(udetail.Strasse, udetailNew.Strasse);
            Assert.AreEqual(udetail.HausNummer, udetailNew.HausNummer);
            Assert.AreEqual(udetail.BIC, udetailNew.BIC);
            Assert.AreEqual(udetail.IBAN, udetailNew.IBAN);

            

        }
    }
}

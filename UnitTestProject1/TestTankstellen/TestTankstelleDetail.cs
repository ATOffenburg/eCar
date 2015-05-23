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

        }
        
        [TestMethod]
        public void TestSaveOperation()
        {

        }
    }
}

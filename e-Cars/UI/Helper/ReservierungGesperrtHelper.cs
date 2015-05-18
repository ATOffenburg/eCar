﻿using e_Cars.Datenbank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Cars.UI.Helper
{
    public class ReservierungGesperrtHelper
    {

        static string Schluessel = "GlobalReservierungGesperrt";

        public static bool IsReservierungGesperrt(){

            Projekt2Entities con = new Projekt2Entities();
            GlobaleEinstellungen ge = con.GlobaleEinstellungen.SingleOrDefault(s => s.Schluessel == Schluessel);
            if (ge == null)
            {
                return false;
            }
            return ge.Wert.Equals("true");
        }

        public static void setReservierungGesperrt(bool isReservierungGesperrt)
        {

            Projekt2Entities con = new Projekt2Entities();
            GlobaleEinstellungen ge = con.GlobaleEinstellungen.SingleOrDefault(s => s.Schluessel == "GlobalReservierungGesperrt");
            if (ge == null)
            {

                ge = new GlobaleEinstellungen();
                ge.Schluessel = Schluessel;

                if (isReservierungGesperrt == true){
                    ge.Wert = "true";
                } else {
                    ge.Wert = "false";
                }

                ge.Standard = "false";

                con.GlobaleEinstellungen.Add(ge);
                con.SaveChanges();

                return;
            }

            if (isReservierungGesperrt == true)
            {
                ge.Wert = "true";
            }
            else
            {
                ge.Wert = "false";
            }

            con.Entry(ge).State = System.Data.Entity.EntityState.Modified;
            con.SaveChanges();

        }


    }
}

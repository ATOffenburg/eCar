//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace e_Cars.Datenbank
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bank
    {
        public Bank()
        {
            this.Kunde = new HashSet<Kunde>();
        }
    
        public int Bank_ID { get; set; }
        public string BIC { get; set; }
        public string IBAN { get; set; }
    
        public virtual ICollection<Kunde> Kunde { get; set; }
    }
}

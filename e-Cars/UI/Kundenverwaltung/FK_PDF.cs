using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace e_Cars.UI.Kundenverwaltung
{
    public partial class FK_PDF : UserControl
    {
        public FK_PDF(byte[] fkopie)
        {
            InitializeComponent();

            if (fkopie != null)
            {
                File.WriteAllBytes(@"c:\temp\fkopietemp.pdf", fkopie);
                this.axFoxitCtl1.OpenFile(@"c:\temp\fkopietemp.pdf");
                
                                
            }

        }
    }
}

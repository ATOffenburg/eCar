using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Cars.UI.Kunden
{
    public partial class FK_PDF : UserControl
    {
        public FK_PDF(string filename)
        {
            InitializeComponent();
            this.axFoxitCtl1.OpenFile(filename);
        }
    }
}

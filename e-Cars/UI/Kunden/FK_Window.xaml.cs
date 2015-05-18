using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace e_Cars.UI.Kunden
{
    /// <summary>
    /// Interaktionslogik für FK_Window.xaml
    /// </summary>
    public partial class FK_Window : Window
    {
        public FK_Window()
        {
            InitializeComponent();

            var fk = new FK_PDF(@"D:\Maschinennahe Programmierung\Werkzeugkasten 2.2\LiesMich.pdf");
            this.WindowsFormsHost.Child = fk;
        }
    }
}

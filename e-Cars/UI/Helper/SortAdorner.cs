using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace e_Cars.UI.Helper
{
    /// <summary>
    /// Helfer Klasse für die Sortierung in einer Listview
    /// </summary>
    public class SortAdorner : Adorner
    {
        private readonly static Geometry _AscGeometry =
            Geometry.Parse("M 0,0 L 10,0 L 5,5 Z");

        private readonly static Geometry _DescGeometry =
            Geometry.Parse("M 0,5 L 10,5 L 5,0 Z");

        public ListSortDirection Direction { get; private set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="element"></param>
        /// <param name="dir"></param>
        public SortAdorner(UIElement element, ListSortDirection dir)
            : base(element)
        { Direction = dir; }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (AdornedElement.RenderSize.Width < 20)
                return;

            drawingContext.PushTransform(
                new TranslateTransform(
                  AdornedElement.RenderSize.Width - 15,
                  (AdornedElement.RenderSize.Height - 5) / 2));

            drawingContext.DrawGeometry(Brushes.Black, null,
                Direction == ListSortDirection.Ascending ?
                  _AscGeometry : _DescGeometry);

            drawingContext.Pop();
        }
    }
}

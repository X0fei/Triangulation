using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangulation.Models
{
    /// <summary>
    /// Представляет приёмник. 
    /// </summary>
    public class Receiver
    {
        /// <summary>
        /// Получает или задаёт значение координат приёмника по X.
        /// </summary>
        /// <value>Координата приёмника по X.</value>
        public double X { get; set; }

        /// <summary>
        /// Получает или задаёт значение координат приёмника по Y.
        /// </summary>
        /// <value>Координата приёмника по Y.</value>
        public double Y { get; set; }

        /// <summary>
        /// Эллипс, представляющий приёмник.
        /// </summary>
        /// <value>Приёмник (эллипс).</value>
        public Ellipse Point { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Receiver"/>.
        /// </summary>
        /// <param name="x">Координата приёмника по X.</param>
        /// <param name="y">Координата приёмника по Y.</param>
        public Receiver(double x, double y)
        {
            X = x;
            Y = y;

            //Создаём визуальный элемент для приёмника
            Point = new Ellipse
            {
                Width = 10,
                Height = 10,
                Fill = Brushes.Red
            };
        }
    }
}

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
    /// Представляет вышку. 
    /// </summary>
    public class Tower
    {
        /// <summary>
        /// Получает или задаёт значение координат вышки по X.
        /// </summary>
        /// <value>Координата вышки по X.</value>
        public double X { get; set; }

        /// <summary>
        /// Получает или задаёт значение координат вышки по Y.
        /// </summary>
        /// <value>Координата вышки по Y.</value>
        public double Y { get; set; }

        /// <summary>
        /// Получает или задаёт значение радиуса покрытия вышки.
        /// </summary>
        /// <value>Радиус покрытия вышки.</value>
        public double Radius { get; set; }

        /// <summary>
        /// Эллипс, представляющий радиус покрытия вышки.
        /// </summary>
        /// <value>Радиус покрытия вышки (эллипс).</value>
        public Ellipse Coverage { get; set; }

        /// <summary>
        /// Эллипс, представляющий центр вышки.
        /// </summary>
        /// <value>Радиус покрытия вышки (эллипс).</value>
        public Ellipse Center { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Tower"/>.
        /// </summary>
        /// <param name="x">Координата вышки по X.</param>
        /// <param name="y">Координата вышки по Y.</param>
        /// <param name="radius">Радиус покрытия вышки.</param>
        public Tower(double x, double y, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;

            // Создаём визуальные элементы для радиуса и центра
            Coverage = new Ellipse
            {
                Width = radius * 2,
                Height = radius * 2,
                Fill = Brushes.Green,
                Opacity = 0.3,
                Stroke = Brushes.DarkGreen,
                StrokeThickness = 2
            };

            Center = new Ellipse
            {
                Width = 10,
                Height = 10,
                Fill = Brushes.Black
            };
        }
    }
}

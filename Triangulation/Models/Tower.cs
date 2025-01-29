using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangulation.Models
{
    /// <summary>
    /// Представляет модель вышки. 
    /// </summary>
    public class Tower
    {
        /// <summary>
        /// Получает или задаёт значение координат модели вышки по X.
        /// </summary>
        /// <value>Координата модели вышки по X.</value>
        public double X { get; set; }

        /// <summary>
        /// Получает или задаёт значение координат модели вышки по Y.
        /// </summary>
        /// <value>Координата модели вышки по Y.</value>
        public double Y { get; set; }

        /// <summary>
        /// Получает или задаёт значение радиуса покрытия модели вышки.
        /// </summary>
        /// <value>Радиус покрытия вышки.</value>
        public double Radius { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Tower"/>.
        /// </summary>
        /// <param name="x">Координата модели вышки по X.</param>
        /// <param name="y">Координата модели вышки по Y.</param>
        /// <param name="radius">Радиус покрытия модели вышки.</param>
        public Tower(double x, double y, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }
    }
}

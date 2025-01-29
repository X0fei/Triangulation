using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangulation.Models
{
    /// <summary>
    /// Представляет модель приёмника. 
    /// </summary>
    public class Receiver
    {
        /// <summary>
        /// Получает или задаёт значение координат модели приёмника по X.
        /// </summary>
        /// <value>Координата модели приёмника по X.</value>
        double X { get; set; }

        /// <summary>
        /// Получает или задаёт значение координат модели приёмника по Y.
        /// </summary>
        /// <value>Координата модели приёмника по Y.</value>
        double Y { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Receiver"/>.
        /// </summary>
        /// <param name="x">Координата модели приёмника по X.</param>
        /// <param name="y">Координата модели приёмника по Y.</param>
        public Receiver(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Triangulation.Models;

namespace Triangulation.Services
{
    /// <summary>
    /// Сервис для выполнения триангуляции.
    /// </summary>
    public static class TriangulationService
    {
        /// <summary>
        /// Вычисляет координаты приёмника на основе данных трёх ближайших вышек.
        /// </summary>
        /// <param name="towers">Список из трёх ближайших вышек.</param>
        /// <returns>Координаты приёмника, если триангуляция успешна.</returns>
        public static (double X, double Y)? CalculateReceiverPosition(List<Tower> towers)
        {
            if (towers.Count != 3) return null;

            var (x1, y1, r1) = (towers[0].X, towers[0].Y, towers[0].Radius);
            var (x2, y2, r2) = (towers[1].X, towers[1].Y, towers[1].Radius);
            var (x3, y3, r3) = (towers[2].X, towers[2].Y, towers[2].Radius);

            double A = 2 * (x2 - x1);
            double B = 2 * (y2 - y1);
            double C = r1 * r1 - r2 * r2 - x1 * x1 + x2 * x2 - y1 * y1 + y2 * y2;

            double D = 2 * (x3 - x1);
            double E = 2 * (y3 - y1);
            double F = r1 * r1 - r3 * r3 - x1 * x1 + x3 * x3 - y1 * y1 + y3 * y3;

            double denominator = A * E - B * D;
            if (denominator == 0) return null; // Точки слишком близко или лежат на одной прямой

            double x = (C * E - F * B) / denominator;
            double y = (A * F - D * C) / denominator;

            return (x, y);
        }
    }
}

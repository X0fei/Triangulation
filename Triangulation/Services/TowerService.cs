using Avalonia.Controls.Shapes;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triangulation.Models;

namespace Triangulation.Services
{
    /// <summary>
    /// Сервис для работы с вышками и их отображением на холсте.
    /// </summary>
    public class TowerService
    {
        private static List<Tower> _towers = new List<Tower>();

        /// <summary>
        /// Добавляет новую вышку в список.
        /// </summary>
        /// <param name="tower">Объект вышки, который нужно добавить.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если радиус вышки меньше или равен 0, или координаты X и Y отрицательные.</exception>
        public static void AddTower(Tower tower)
        {
            if (tower.Radius <= 0 || tower.X < 0 || tower.Y < 0)
            {
                throw new ArgumentException("Неправильные данные вышки");
            }

            _towers.Add(tower);
        }

        /// <summary>
        /// Добавляет радиус покрытия вышки на холст в виде окружности.
        /// </summary>
        /// <param name="tower">Объект вышки, для которой нужно создать окружность радиуса покрытия.</param>
        /// <returns>Возвращает объект <see cref="Ellipse"/>, представляющий радиус покрытия вышки.</returns>
        public static Ellipse AddTowerCoverageRadiusToCanvas(Tower tower)
        {
            Ellipse towerCoverageRadius = new Ellipse
            {
                Width = tower.Radius * 2,
                Height = tower.Radius * 2,
                Fill = Brushes.Green,
                Opacity = 100,
                Stroke = Brushes.DarkGreen,
                StrokeThickness = 2
            };

            Canvas.SetLeft(towerCoverageRadius, tower.X - towerCoverageRadius.Width / 2);
            Canvas.SetTop(towerCoverageRadius, tower.Y - towerCoverageRadius.Height / 2);

            return towerCoverageRadius;
        }

        /// <summary>
        /// Добавляет центр вышки на холст в виде маленькой черной окружности.
        /// </summary>
        /// <param name="tower">Объект вышки, для которой нужно создать точку центра.</param>
        /// <returns>Возвращает объект <see cref="Ellipse"/>, представляющий центр вышки.</returns>
        public static Ellipse AddTowerCenterToCanvas(Tower tower)
        {
            Ellipse towerCenter = new Ellipse
            {
                Width = 10,
                Height = 10,
                Fill = Brushes.Black
            };

            Canvas.SetLeft(towerCenter, tower.X - towerCenter.Width / 2);
            Canvas.SetTop(towerCenter, tower.Y - towerCenter.Height / 2);

            return towerCenter;
        }
    }
}

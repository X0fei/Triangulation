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
    public static class TowerService
    {
        /// <summary>
        /// Список для хранения объектов класса <see cref="Tower"/>.
        /// </summary>
        /// /// <value>Список вышек.</value>
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
        /// Добавляет вышку (с её радиусом и центром) на Canvas.
        /// </summary>
        /// <param name="canvas">Canvas, на который нужно добавить вышку.</param>
        /// <param name="tower">Вышка, которую нужно добавить.</param>
        public static void AddTowerToCanvas(Canvas canvas, Tower tower)
        {
            // Устанавливаем позиции для радиуса и центра
            Canvas.SetLeft(tower.Coverage, tower.X - tower.Coverage.Width / 2);
            Canvas.SetTop(tower.Coverage, tower.Y - tower.Coverage.Height / 2);
            Canvas.SetLeft(tower.Center, tower.X - tower.Center.Width / 2);
            Canvas.SetTop(tower.Center, tower.Y - tower.Center.Height / 2);

            // Добавляем элементы на Canvas
            canvas.Children.Add(tower.Coverage);
            canvas.Children.Add(tower.Center);
        }
    }
}

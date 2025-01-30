using Avalonia.Controls;
using System;
using Triangulation.Models;

namespace Triangulation.Services
{
    /// <summary>
    /// Сервис для работы с приёмником и его отображением на холсте.
    /// </summary>
    public static class ReceiverService
    {
        private static Receiver? _receiver;

        /// <summary>
        /// Устанавливает новый приймник.
        /// </summary>
        /// <param name="receiver">Объект приёмника, который нужно установить.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если координаты X и Y отрицательные.</exception>
        public static void SetReceiver(Receiver receiver)
        {
            if (receiver.X < 0 || receiver.Y < 0)
            {
                throw new ArgumentException("Неправильные данные вышки");
            }

            _receiver = receiver;
        }

        /// <summary>
        /// Добавляет приёмник на Canvas.
        /// </summary>
        /// <param name="canvas">Canvas, на который нужно добавить приёмник.</param>
        /// <param name="receiver">Приёмник, который нужно добавить.</param>
        public static void AddReceiverToCanvas(Canvas canvas, Receiver receiver)
        {
            // Устанавливаем позицию для приёмника
            Canvas.SetLeft(receiver.Point, receiver.X - receiver.Point.Width / 2);
            Canvas.SetTop(receiver.Point, receiver.Y - receiver.Point.Height / 2);

            // Добавляем приёмник на Canvas
            canvas.Children.Add(receiver.Point);
        }
    }
}

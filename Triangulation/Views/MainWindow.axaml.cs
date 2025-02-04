using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Triangulation.Behaviors;
using Triangulation.Models;
using Triangulation.Services;

namespace Triangulation
{
    /// <summary>
    /// Главное окно приложения, содержащее все элементы интерфейса и логику работы с вышками.
    /// </summary>
    public partial class MainWindow : Window
    {
        private DraggablePointBehavior _draggablePointBehavior;
        
        /// <summary>
        /// Инициализирует новое окно и компоненты интерфейса.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _draggablePointBehavior = new DraggablePointBehavior();
            AddReceiver();
        }

        /// <summary>
        /// Обработчик события для добавления нового приёмника.
        /// </summary>
        private void AddReceiver()
        {
            var canvasWidth = MainCanvas.Width;
            var canvasHeight = MainCanvas.Height;

            double centerX = canvasWidth / 2;
            double centerY = canvasHeight / 2;

            Receiver newReceiver = new Receiver(centerX, centerY);
            ReceiverService.SetReceiver(newReceiver);
            ReceiverService.AddReceiverToCanvas(MainCanvas, newReceiver);
            //_draggablePointBehavior.Attach(ReceiverService.GetReceiver());
        }

        /// <summary>
        /// Обработчик события для добавления новой вышки при клике на кнопку.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Параметры события.</param>
        private void AddTowerButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Tower newTower = new Tower(200, 200, 100);
            TowerService.AddTower(newTower);
            TowerService.AddTowerToCanvas(MainCanvas, newTower);

            foreach (Tower tower in TowerService.GetAllTowers())
            {
                _draggablePointBehavior.Attach(tower.Center);
            }
        }
    }
}
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Triangulation.Models;
using Triangulation.Services;

namespace Triangulation
{
    /// <summary>
    /// ������� ���� ����������, ���������� ��� �������� ���������� � ������ ������ � �������.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// �������������� ����� ���� � ���������� ����������.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            AddReceiver();
        }

        /// <summary>
        /// ���������� ������� ��� ���������� ������ ��������.
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
        }

        /// <summary>
        /// ���������� ������� ��� ���������� ����� ����� ��� ����� �� ������.
        /// </summary>
        /// <param name="sender">������, ��������� �������.</param>
        /// <param name="e">��������� �������.</param>
        private void AddTowerButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Tower newTower = new Tower(200, 200, 100);
            TowerService.AddTower(newTower);
            TowerService.AddTowerToCanvas(MainCanvas, newTower);
        }
    }
}
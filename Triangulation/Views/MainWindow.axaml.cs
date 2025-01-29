using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Triangulation.Models;
using Triangulation.Services;

namespace Triangulation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddTowerButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Tower newTower = new Tower(200, 200, 100);
            TowerService.AddTower(newTower);
            AddTowerToCanvas(newTower);
        }

        private void AddTowerToCanvas(Tower tower)
        {
            MainCanvas.Children.Add(TowerService.AddTowerCoverageRadiusToCanvas(tower));
            MainCanvas.Children.Add(TowerService.AddTowerCenterToCanvas(tower));
        }
    }
}
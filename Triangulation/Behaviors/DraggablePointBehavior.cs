using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.VisualTree;
using System;
using System.Collections.Generic;
using Triangulation.Models;
using Triangulation.Services;

namespace Triangulation.Behaviors
{
    /// <summary>
    /// Позволяет перемещать объект с помощью мыши.
    /// </summary>
    public class DraggablePointBehavior
    {
        private bool _isDragging = false; // Флаг, отслеживающий, тянем ли объект
        private Control? _target; // Объект, который мы перетаскиваем
        private List<Control> _targets = new List<Control>();
        private Point _startMousePosition; // Начальная позиция мыши при начале перетаскивания
        private Point _startControlPosition; // Начальная позиция объекта

        /// <summary>
        /// Подключает поведение перетаскивания к переданному элементу.
        /// </summary>
        /// <param name="control">Элемент, который будет перемещаться.</param>
        public void Attach(Control control)
        {
            _targets.Add(control);
            int id = _targets.Count - 1;

            _target = control;

            //"Подписываем" объект на события
            _target.PointerPressed += OnPointerPressed;
            _target.PointerMoved += OnPointerMoved;
            _target.PointerReleased += OnPointerReleased;
            _target.PointerEntered += OnPointerEnter;
            _target.PointerExited += OnPointerLeave;

            _targets[id].PointerPressed += OnPointerPressed;
            _targets[id].PointerMoved += OnPointerMoved;
            _targets[id].PointerReleased += OnPointerReleased;
            _targets[id].PointerEntered += OnPointerEnter;
            _targets[id].PointerExited += OnPointerLeave;
        }

        private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (_target == null) return;

            _isDragging = true;
            _startMousePosition = e.GetPosition(_target.Parent as Visual);
            _startControlPosition = new Point(Canvas.GetLeft(_target), Canvas.GetTop(_target));
            _target.Cursor = new Cursor(StandardCursorType.Hand);
        }

        private void OnPointerMoved(object? sender, PointerEventArgs e)
        {
            if (_isDragging == true && _target != null)
            {
                Point currentMousePosition = e.GetPosition(_target.Parent as Visual);
                double offsetX = currentMousePosition.X - _startMousePosition.X;
                double offsetY = currentMousePosition.Y - _startMousePosition.Y;

                Tower? tower = TowerService.GetTowerByCoordinates(_startControlPosition);
                TowerService.UpdateTowerCanvas(tower, offsetX, offsetY, true);
            }
        }

        private void OnPointerReleased(object? sender, PointerReleasedEventArgs e)
        {
            if (_target == null) return;

            // Завершаем перетаскивание
            _isDragging = false;

            // Получаем финальную позицию объекта
            Point finalPosition = e.GetPosition(_target.Parent as Visual);

            double offsetX = finalPosition.X - _startMousePosition.X;
            double offsetY = finalPosition.Y - _startMousePosition.Y;

            Tower? tower = TowerService.GetTowerByCoordinates(_startControlPosition);
            TowerService.UpdateTowerCanvas(tower, offsetX, offsetY, false);
        }

        private void OnPointerEnter(object? sender, PointerEventArgs e)
        {
            if (_target != null)
                _target.Cursor = new Cursor(StandardCursorType.Hand);
        }

        private void OnPointerLeave(object? sender, PointerEventArgs e)
        {
            if (_target != null && !_isDragging)
                _target.Cursor = new Cursor(StandardCursorType.Arrow);
        }
    }
}

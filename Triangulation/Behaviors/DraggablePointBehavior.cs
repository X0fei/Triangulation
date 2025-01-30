using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.VisualTree;
using System;

namespace Triangulation.Behaviors
{
    public class DraggablePointBehavior
    {
        private bool _isDragging = false;
        private Control? _target;
        private Avalonia.Point _startMousePosition;
        private Avalonia.Point _startControlPosition;

        public event Action<double, double>? OnDragEnded;

        public void Attach(Control control)
        {
            _target = control;
            _target.PointerPressed += OnPointerPressed;
            _target.PointerMoved += OnPointerMoved;
            _target.PointerReleased += OnPointerReleased;
        }

        private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (_target == null) return;

            var parent = _target.GetVisualParent();
            if (parent == null) return;

            _isDragging = true;
            _startMousePosition = e.GetPosition(parent);
            _startControlPosition = new Avalonia.Point(Canvas.GetLeft(_target), Canvas.GetTop(_target));

            _target.Cursor = new Cursor(StandardCursorType.Hand);
        }

        private void OnPointerMoved(object? sender, PointerEventArgs e)
        {
            if (!_isDragging || _target == null) return;

            var parent = _target.GetVisualParent();
            if (parent == null) return;

            var currentMousePosition = e.GetPosition(parent);
            var offsetX = currentMousePosition.X - _startMousePosition.X;
            var offsetY = currentMousePosition.Y - _startMousePosition.Y;

            Canvas.SetLeft(_target, _startControlPosition.X + offsetX);
            Canvas.SetTop(_target, _startControlPosition.Y + offsetY);
        }

        private void OnPointerReleased(object? sender, PointerReleasedEventArgs e)
        {
            if (_target == null) return;

            _isDragging = false;
            _target.Cursor = new Cursor(StandardCursorType.Arrow);

            var x = Canvas.GetLeft(_target);
            var y = Canvas.GetTop(_target);
            OnDragEnded?.Invoke(x, y);
        }
    }
}

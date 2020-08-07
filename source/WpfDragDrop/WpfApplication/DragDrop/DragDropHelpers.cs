using System.Windows;

namespace WpfApplication.DragDrop
{
    internal static class DragDropHelpers
    {
        #region EnableDragDrop Attached DependencyProperty

        public static readonly DependencyProperty EnableDragDropProperty =
            DependencyProperty.RegisterAttached("EnableDragDrop", typeof(bool), typeof(DragDropHelpers), new PropertyMetadata(false, OnEnableDragDropPropertyChanged));

        public static bool GetEnableDragDrop(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableDragDropProperty);
        }
        public static void SetEnableDragDrop(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableDragDropProperty, value);
        }

        private static void OnEnableDragDropPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uiElement = d as UIElement;
            if (uiElement == null) 
                return;

            if ((bool)e.NewValue == true)
            {
                uiElement.AllowDrop = true;
                uiElement.Drop += OnDrop;
            }
            else
            {
                uiElement.AllowDrop = false;
                uiElement.Drop -= OnDrop;
            }
        }
        private static void OnDrop(object sender, DragEventArgs e)
        {
            SetDragDropData(sender as DependencyObject, e.Data);
        }

        #endregion

        #region DragDropData Attached DependencyProperty 

        public static readonly DependencyProperty DragDropDataProperty =
            DependencyProperty.RegisterAttached("DragDropData", typeof(IDataObject), typeof(DragDropHelpers), new PropertyMetadata(null));

        public static IDataObject GetDragDropData(DependencyObject obj)
        {
            return (IDataObject)obj.GetValue(DragDropDataProperty);
        }
        public static void SetDragDropData(DependencyObject obj, IDataObject value)
        {
            obj.SetValue(DragDropDataProperty, value);
        }
        #endregion
    }
}

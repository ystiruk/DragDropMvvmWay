# DragDropMvvmWay
WPF implementation of Drag&amp;Drop in MVVM way

## How it works

### 1 Retrieve drop data

*DragDropHelpers.cs* contains definition of the **EnableDragDrop** attached dependency property. You can attach this property on any *UIElement*.
```xaml
<Grid x:Name="dragTarget" dd:DragDropHelpers.EnableDragDrop="True" /> 
```
Once its value is set to true, element's property *AllowDrop* is also set to true and *OnDrop* event handler is subscribed to *Drop* event.

```csharp
if ((bool)e.NewValue == true)
{
  uiElement.AllowDrop = true;
  uiElement.Drop += OnDrop;
}
```
When *Drop* event fires, data (of type *System.Windows.IDataObject*) is passed to **DragDropData** attached dependency property.

As you can see in the example, given a simple ViewModel class,
```csharp
public class MainWindowViewModel : ViewModelBase
{
  private IDataObject _dragData;
  public IDataObject DragData
  {
    get { return _dragData; }
    set { SetProperty(ref _dragData, value); }
  }
}
```
you can retrieve dropped data via binding to *DragData* property this way:
```xaml
<Grid x:Name="dragTarget" dd:DragDropHelpers.EnableDragDrop="True" 
                          dd:DragDropHelpers.DragDropData="{Binding DropData, Mode=OneWayToSource} />
```
:warning: I'd recommend to explicitly use *OneWayToSource* mode in order to clarify the fact that ViewModel's property *DropData* is only SET here.

### 2 Transform and use drop data

Suppose we need to get name of the dropped file. Firstly, we bind to already set *DropData* property of the ViewModel:

```xaml
<TextBlock Text="{Binding Path=DropData, 
                          Converter={StaticResource dataObjectConverter}, 
                          StringFormat={}Path: \'{0}\'}" />
```

Here we use custom IValueConverter to get first file name:
```csharp
public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
{
    IDataObject dataObject = value as IDataObject;

    if (dataObject == null) 
        return null;

    string[] fileNames = dataObject.GetData(DataFormats.FileDrop) as string[];
    if (fileNames == null)
        return null;

    return fileNames[0];
}
```

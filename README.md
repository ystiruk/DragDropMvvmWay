# DragDropMvvmWay
WPF implementation of Drag&amp;Drop in MVVM way

1 Add *DragDropHelpers.EnableDragDrop="True"* attached dependency property to UIElement you want to expose the drag data

2 To bind retrieved data add *DragDropHelpers.DragDropData="{Binding DragData, Mode=OneWayToSource}"*, where *DragData* is property of underlying ViewModel 

See example:
Drag file to the coloured rectangle and find dragged file name in textbox.

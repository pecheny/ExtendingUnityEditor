## Animation Sample

![](https://raw.githubusercontent.com/pecheny/ExtendingUnityEditor/master/Assets/08-CustomInspector/AnimationSample/Preview/preview.png)

In this sample you will able to control state of the children list filtered by bit mask.
I. e. you set "channel" values for child and for controller and if controller and child have at least one same channel, the controller would handle such child.
The custom inspector includes a button which would create child with all controller channels selected.
This sample also involves custom propert fileld drawer and OnValidate().

## Reorderable List

![](https://raw.githubusercontent.com/pecheny/ExtendingUnityEditor/master/Assets/08-CustomInspector/ReorderableList/Preview/preview.png)

It's internal unity utility class which allows to change order of list elements in the inspector by dragging and dropping.
Details http://va.lent.in/unity-make-your-lists-functional-with-reorderablelist/
This sample shows how to draw default inspector for list's elements.

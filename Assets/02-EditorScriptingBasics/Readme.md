## Several scripts for everyday use

### Build and run current scene (Windows-only)

Sets up the build configuration to include the opened scene only, add name, make build and run it.
Can be fount in menu "Build tools/Build and run current scene" or by pressing alt+x.

### Distribute objects by name

Script for processing scenes (from asset store for example) which consist a lot of objects of several types.
Objects can be separated by name into groups. You need to define pattern to define a part of the name which would be used as basis for grouping.
For example, you have objects:

1. Wall (1)
2. Wall (2)
3. Fence (1)
4. Fence (2)

In this case you may want to group objecs by part before first whitespace or "(" character.
Open "02-EditorScriptingBasics.unity" scene, select objects and call "Window/Distribute items by name" menu item.

### Distribute objects in space

Distributes items in space on equal distances between first and last object (according ti the scene hierarchy).
Correct working granted only if all selected objects have same parent.

### Group objects

Makes new gameobject calles "Group" and puts all selected ones to it as a children. Press Ctrl+g or select in the menu.


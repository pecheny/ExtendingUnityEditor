# Extending Unity Editor

When i just started to work with Unity i'd tried to extend Unity editor several times in order to do my current work faster.
I couldn't find structured and complite guide on conding for the editor. There was a lot of articles about particular issues
but it would not help me in my current task so i rather got back to manual work on my current tasks in order to finish them in time.
There also were cases when i resolved some tasks but in an ugly way and with inappropriate tools or APIs since i didn't know about
those which can fit my needs.

Spending more time on working with editor i had learned more and more ways to use it. I think the best developement manual is working example.
But only in case if it clean and short. So i decided to collect examples of appliance different ways of extending Unity in hope you can examine it
all and choose appropriate for you tasks. So i guess i can call it a little Cookbook for extending Unity editor.

### Table of contents

1. Intro. Exploring abilities of standard inspector.
2. Extending basics. Call editor code through menu items.
3. Using OnValidate().
4. ExecuteInEditMode. The interaction which acts the same in edit and play mode.
5. Other ways to make interactive tools in editor.
6. Laying out the GUI.
7. Property drawers - defining custom inspector for fields of exact type.
8. Writing custom inspectors for yours MonoBehaviours.


## Standard Inspector

Demonstration of the standard inspector abilities based on built-it Unity types and meta-attributes.

![](https://raw.githubusercontent.com/pecheny/ExtendingUnityEditor/master/Assets/01-Intro/Preview/preview.png)


## Several scripts for everyday use

### Build and run current scene (Windows-only)

![](https://raw.githubusercontent.com/pecheny/ExtendingUnityEditor/master/Assets/02-EditorScriptingBasics/Preview/preview-01.png)

Sets up the build configuration to include the opened scene only, adds name, makes build and runs it.
Can be found in menu "Build tools/Build and run current scene" or by pressing alt+x.

![](https://raw.githubusercontent.com/pecheny/ExtendingUnityEditor/master/Assets/02-EditorScriptingBasics/Preview/preview-03.png)

### Distribute objects by name

![](https://raw.githubusercontent.com/pecheny/ExtendingUnityEditor/master/Assets/02-EditorScriptingBasics/Preview/preview-02.png)

Script for processing scenes (from asset store for example) which consist of many objects of several types.
Objects can be separated by name into groups. You need to define pattern to define a part of the name which would be used as basis for grouping.
For example, you have objects:

1. Wall (1)
2. Wall (2)
3. Fence (1)
4. Fence (2)

In this case you may want to group objecs by part before first whitespace or "(" character.
Open "02-EditorScriptingBasics.unity" scene, select objects and call "Window/Distribute items by name" menu item.

### Distribute objects in space

![](https://raw.githubusercontent.com/pecheny/ExtendingUnityEditor/master/Assets/02-EditorScriptingBasics/Preview/preview-05.png)

Distributes items in space on equal distances between first and last object (according ti the scene hierarchy).
Correct working granted only if all selected objects have same parent.

### Group objects

![](https://raw.githubusercontent.com/pecheny/ExtendingUnityEditor/master/Assets/02-EditorScriptingBasics/Preview/preview-04.png)

Makes new gameobject called "Group" and puts all selected ones to it as a children. Press Ctrl+g or choose in the menu.


## OnValidate() usage example

![](https://raw.githubusercontent.com/pecheny/ExtendingUnityEditor/master/Assets/03-OnValidate/Preview/preview.png)

## [ExecuteInEditMode] usage example

![](https://raw.githubusercontent.com/pecheny/ExtendingUnityEditor/master/Assets/04-ExecuteInEditMode/Preview/preview.png)

The original content from http://forum.unity3d.com/threads/set-up-ik-in-editor.332035/

This script allows to use Mecanim inverse kinematics in edit mode.


## Samples of interactive tools in Unity editor

### Pathway

![](https://raw.githubusercontent.com/pecheny/ExtendingUnityEditor/master/Assets/05-Interactive/Pathway/Preview/preview.png)

The pathway represented by List of Vector3 points and can be edited as if each point would be separate GameObject with it's own transform handler/

### Piegrid

![](https://raw.githubusercontent.com/pecheny/ExtendingUnityEditor/master/Assets/05-Interactive/PieGrid/Preview/preview.png)

Custom radial grid with sector subdivision and snapping for children.

## GUI

The example of laying out most common GUI elements in Unity editor.

![](https://raw.githubusercontent.com/pecheny/ExtendingUnityEditor/master/Assets/06-EditorGUI/Preview/preview.png)

## Custom property drawer

![](https://raw.githubusercontent.com/pecheny/ExtendingUnityEditor/master/Assets/07-PropertyDrawer/Preview/preview.png)

This example shows how to make customization for renderind field of exact type in any MonoBehaviour. In this case it would be bit mask picker (like unity layers) where you can mark channels on different objects and then check if any two of them crosses or not.
You can see the application of this property drawer in the following sample "08-CustomInspector/AnimationSample"

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



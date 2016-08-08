using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;


/// <summary>
/// Let you have a scene (from asset store) which consists of a LOT of different objects.
/// The objects named according to their types but placed in scene in chaotic manner.
/// If you wish to work with groups of objects according to their types you need to divide them into groups.
/// So here is the script to do so.
///
/// Go to scene "02-EditorScriptingBasics", select all objects and call the menu item.
/// </summary>
public class DistributeObjectsByName {
    // Mask for detecting common part of the name to combine objects to groups.
    // Depends on your needs. For example, the scene can contain "Wall_1 (1)", "Wall_1 (2)", "Wall_2 (1)" and so on.
    // Choose if you need all "walls" in one group, or separated by wall kind and modify the regex.
    static Regex namePrefix = new Regex("([A-Za-z]+)([\\s\\d()]*)");

    [MenuItem("Window/Distribute items by name &1")]
    static void Distribute () {
        var items = Selection.transforms;
        for (int i = 0; i < items.Length; i++ ) {
            var item = items[i];
            var parent = GetTargetParent(item.name);
            Undo.SetTransformParent(item, parent, "Put item " + item.name + " to group.");
        }
    }

    static Transform GetTargetParent(string objName) {
        Match m = namePrefix.Match(objName);
        string parentName = "G-" + m.Groups[1].Value;
        var parent = GameObject.Find(parentName);
        if (parent == null) {
            parent = new GameObject(parentName);
            Undo.RegisterCreatedObjectUndo(parent, "Create group for objects of " + parentName);
        }
        return parent.transform;
    }
}

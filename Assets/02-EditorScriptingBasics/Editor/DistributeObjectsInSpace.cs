using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class DistributeObjectsInSpace {
    ///
    /// Distributes items in space on equal distances between first and last object (according ti the scene hierarchy).
    /// Correct working granted only if all selected objects have same parent.
    ///
    [MenuItem("Window/Distribute items &1")]
    static void Distribute() {
        var items = Selection.transforms;
        Array.Sort(items, new HierarchyComparer());
        var start = items[0].position;
        var end = items[items.Length - 1].position;
        Undo.RecordObjects(items, "Store positions before distribute");
        for (int i = 0; i < items.Length; i++ ) {
            var item = items[i];
//            Debug.Log(item.name);
            item.position = Vector3.Lerp(start, end, (float)i / (float)(items.Length - 1));
        }
    }

    static int GetIndex(Transform child) {
        if (child.parent == null) {
            return GetRootIndex(child);
        } else {
            return GetChildIndex(child);
        }
    }

    static int GetChildIndex(Transform child) {
        for (int i = 0; i < child.parent.childCount; i++) {
            if (child == child.parent.GetChild(i)) return i;
        }
        throw new Exception("It should not be happen.");
    }

    static int GetRootIndex(Transform child) {
        var prop = new HierarchyProperty(HierarchyType.GameObjects);
        var expanded = new int[0];
        int index = 0;
        while (prop.Next(expanded)) {
            GameObject go = (GameObject) prop.pptrValue;
            if (child == go.transform) return index;
            index++;
        }
        throw new Exception("It should not be happen.");
    }

    class HierarchyComparer : IComparer {
        public int Compare(object x, object y) {
            return GetIndex((Transform) x) - GetIndex((Transform) y);
        }
    }
}

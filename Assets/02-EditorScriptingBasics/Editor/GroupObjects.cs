using UnityEditor;
using UnityEngine;

public class GroupObjects {
    [MenuItem("Edit/Group Selected %g")]
    static void Group() {
        var group = new GameObject("Group").transform;
        Undo.RegisterCreatedObjectUndo(group.gameObject, "New group");
        var first = Selection.transforms[0];
        group.SetParent(first.parent);
        group.position = first.position;
        var items = Selection.transforms;
        for (int i = 0; i < items.Length; i++ ) {
            var item = items[i];
            Undo.SetTransformParent(item, group, "");
        }
    }

}

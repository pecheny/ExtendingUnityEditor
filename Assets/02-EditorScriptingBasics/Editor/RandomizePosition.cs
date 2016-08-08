using UnityEditor;
using UnityEngine;

public class RandomizePosition {
    const float R = 30;
    [MenuItem("Window/Randomize positions")]
    static void RandomizePos() {
        Transform tempHolder = new GameObject().transform;
        var items = Selection.transforms;
        Undo.RecordObjects(items, "Store positions before distribute");
        for (int i = 0; i < items.Length; i++ ) {
            var obj = items[i];
            tempHolder.rotation = obj.rotation;
            obj.SetParent(tempHolder);
            obj.localPosition = Vector3.forward * R * Random.Range(0.3f,1f);
            tempHolder.Rotate(Random.Range(-180, 180), Random.Range(-180, 180), 0);
            obj.SetParent(null);
        }
        GameObject.DestroyImmediate(tempHolder.gameObject);
    }
}

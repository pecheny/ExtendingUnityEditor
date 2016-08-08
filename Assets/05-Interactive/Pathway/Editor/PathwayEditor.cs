using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Pathway))]
public class PathwayEditor : Editor {

    void OnSceneGUI() {
        Pathway pathway = target as Pathway;
        for (int i = 0; i < pathway.waypoints.Count; i++) {
            EditorGUI.BeginChangeCheck();
            var point = pathway.transform.TransformPoint(pathway.waypoints[i]);
            point = Handles.PositionHandle(point, Quaternion.identity);
            if ( EditorGUI.EndChangeCheck()) {
                Undo.RecordObject(target, "Changed waypoint position");
                pathway.waypoints[i] = pathway.transform.InverseTransformPoint(point);
            }
        }
    }

}

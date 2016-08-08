using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pathway : MonoBehaviour {
    public List<Vector3> waypoints = new List<Vector3>();
    void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        for (var i = 0; i < waypoints.Count; i++) {
            var point = waypoints[i];
            Gizmos.DrawSphere(transform.TransformPoint(point), 0.5f);
            if (i > 0) {
                var prevPoint = waypoints[i-1];
                Handles.DrawLine(transform.TransformPoint(prevPoint), transform.TransformPoint(point));
            }
        }
    }
}

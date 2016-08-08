using System;
using UnityEngine;
public class PieGrid : MonoBehaviour {
    #if UNITY_EDITOR
    public const float angleOffset = Mathf.PI / 2;
    public int numSeg = 5;

    public float R1 = 4;
    public float R2 = 10;

    float sectorSize {
        get {
            return 2f * Mathf.PI / numSeg;
        }
    }

    void OnDrawGizmos() {
        for (int i = 0; i < numSeg; i++ ) { // 0 - center segment
            var segIdx = i + 1;
            DrawSegment(R1, R2, GetFromAngle(segIdx), GetToAngle(segIdx));
        }
        AlignChildrenToGrid();
    }

    public void AlignChildrenToGrid() {
        for (int i = 0; i < transform.childCount; i++ ) {
            var child = transform.GetChild(i);
            var pos = GetSegmentPos(GetSegmentIdx(child.localPosition));
            pos.z = child.transform.localPosition.z;
            child.transform.localPosition = pos;
        }
    }

    void DrawSegment(float rmin, float rmax, float fromAngle, float toAngle) {
        var p1 = CalcPoint(rmax, fromAngle);
        var p2 = CalcPoint(rmax, toAngle);
        var p3 = CalcPoint(rmin, toAngle);
        var p4 = CalcPoint(rmin, fromAngle);
        UnityEditor.Handles.DrawLine(transform.TransformPoint(p1), transform.TransformPoint(p2));
        UnityEditor.Handles.DrawLine(transform.TransformPoint(p2), transform.TransformPoint(p3));
        UnityEditor.Handles.DrawLine(transform.TransformPoint(p3), transform.TransformPoint(p4));
    }

    int GetSegmentIdx(Vector3 coord) {
        coord.z = 0;
        if (coord.magnitude < R1) return 0;
        var angle = Mathf.Atan2(coord.y, coord.x) - angleOffset + Mathf.PI * 2;
        var toInt = Mathf.FloorToInt(angle / sectorSize);
        return toInt < 1 ? numSeg : toInt;
    }

    Vector3 GetSegmentPos(int idx) {
        if (idx == 0) return  Vector3.zero;
        var fromAngle = GetFromAngle(idx);
        var toAngle = GetToAngle(idx);
        if (toAngle > fromAngle) {
            var angle = (fromAngle + toAngle) / 2;
            var r = R1 + (R2 - R1) / 2;
            return CalcPoint(r, angle);
        }
        throw new Exception("To ang (" + toAngle + ") <= than fr ang (" + fromAngle + ") at idx " + idx);
    }

    float GetFromAngle(int idx) {
        return sectorSize * (float)idx + angleOffset;
    }

    float GetToAngle(int idx) {
        return sectorSize * (float)(idx + 1) + angleOffset;
    }

    Vector3 CalcPoint(float r, float angle) {
        var x = Mathf.Cos(angle) * r;
        var y = Mathf.Sin(angle) * r;
        return new Vector3(x, y, 0);
    }
    #endif
}
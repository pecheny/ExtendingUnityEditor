using UnityEngine;

public class XAnimation : MonoBehaviour{
    [Range(0,1)]
    public float t;

    public float startX;
    public float endX;

    void OnValidate() {
        var lpos = transform.localPosition;
        lpos.x = Mathf.Lerp(startX, endX, t);
        transform.localPosition = lpos;
    }
}
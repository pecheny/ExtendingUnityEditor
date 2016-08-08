using UnityEngine;

public class XAnimationWithChannel : MonoBehaviour{
    public AnimationChannel animationChannel;

    [Range(0,1)]
    public float t;

    public float startX;
    public float endX;

    void OnValidate() {
        SetT(t);
    }

    public void SetT(float t) {
        var lpos = transform.localPosition;
        lpos.x = Mathf.Lerp(startX, endX, t);
        transform.localPosition = lpos;
    }
}
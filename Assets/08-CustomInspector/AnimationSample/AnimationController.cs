using UnityEngine;
using System.Linq;

public class AnimationController : MonoBehaviour{
    public string controllerName;
    public AnimationChannel animationChannel;
    [Range(0,1)]
    public float t;

    void OnValidate() {
        var children = GetChildrenFilteredByChannel();
        foreach (var child in children) {
            child.SetT(t);
        }
    }

    XAnimationWithChannel[] GetChildrenFilteredByChannel() {
        return GetComponentsInChildren<XAnimationWithChannel>().Where((xa)=>AnimationChannelCross.Cross(xa.animationChannel, animationChannel)).ToArray<XAnimationWithChannel>();
    }

}
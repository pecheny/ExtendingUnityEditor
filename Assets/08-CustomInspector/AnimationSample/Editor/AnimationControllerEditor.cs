using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(AnimationController))]
public class AnimationControllerEditor : Editor{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("Create animation item")) {
            CreateAnimationItem();
        }
    }

    void CreateAnimationItem() {
        AnimationController animController = (AnimationController) target;
        var item = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Undo.RegisterCreatedObjectUndo(item, "New animation item");
        item.transform.SetParent(animController.transform);
        var anim = item.AddComponent<XAnimationWithChannel>();
        anim.startX = -5;
        anim.endX = 5;
        anim.animationChannel = animController.animationChannel;
    }
}

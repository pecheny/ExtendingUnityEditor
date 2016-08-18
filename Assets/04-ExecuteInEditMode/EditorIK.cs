using UnityEngine;

[ExecuteInEditMode]
public class EditorIK : MonoBehaviour {
    Animator animator;
    public bool enabledIK = false;

    public GameObject leftFootIKGoal = null;
    public GameObject rightFootIKGoal = null;
    public GameObject leftHandIKGoal = null;
    public GameObject rightHandIKGoal = null;

    public float leftFootPositionWeight = 0;
    public float rightFootPositionWeight = 0;
    public float leftHandPositionWeight = 0;
    public float rightHandPositionWeight = 0;

    public float leftFootRotationWeight = 0;
    public float rightFootRotationWeight = 0;
    public float leftHandRotationWeight = 0;
    public float rightHandRotationWeight = 0;


    protected GameObject CreateIKGoal(string name) {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        obj.name = name;
        obj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        return obj;
    }

    void Start() {
        animator = GetComponent<Animator>();

        if (leftFootIKGoal == null)  leftFootIKGoal = CreateIKGoal("LeftFootGoal");
        if (rightFootIKGoal == null) rightFootIKGoal = CreateIKGoal("RightFootGoal");
        if (leftHandIKGoal == null) leftHandIKGoal = CreateIKGoal("LeftHandGoal");
        if (rightHandIKGoal == null) rightHandIKGoal = CreateIKGoal("RightHandGoal");
    }

    void Update() {
        Debug.Log("EditorIK.Update()");
        animator.Update(0);
    }

    void OnAnimatorIK(int layerIndex) {
        Debug.Log("EditorIK.OnAnimatorIK()");
        animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootPositionWeight);
        animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootPositionWeight);
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandPositionWeight);
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandPositionWeight);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, leftFootRotationWeight);
        animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, rightFootRotationWeight);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandRotationWeight);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandRotationWeight);
        if (enabledIK)        {
            animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootIKGoal.transform.position);
            animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootIKGoal.transform.rotation);
            animator.SetIKPosition(AvatarIKGoal.RightFoot, rightFootIKGoal.transform.position);
            animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootIKGoal.transform.rotation);
            animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandIKGoal.transform.position);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandIKGoal.transform.rotation);
            animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandIKGoal.transform.position);
            animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandIKGoal.transform.rotation);
        } else {
            leftFootIKGoal.transform.position = animator.GetIKPosition(AvatarIKGoal.LeftFoot);
            leftFootIKGoal.transform.rotation = animator.GetIKRotation(AvatarIKGoal.LeftFoot);
            rightFootIKGoal.transform.position = animator.GetIKPosition(AvatarIKGoal.RightFoot);
            rightFootIKGoal.transform.rotation = animator.GetIKRotation(AvatarIKGoal.RightFoot);
            leftHandIKGoal.transform.position = animator.GetIKPosition(AvatarIKGoal.LeftHand);
            leftHandIKGoal.transform.rotation = animator.GetIKRotation(AvatarIKGoal.LeftHand);
            rightHandIKGoal.transform.position = animator.GetIKPosition(AvatarIKGoal.RightHand);
            rightHandIKGoal.transform.rotation = animator.GetIKRotation(AvatarIKGoal.RightHand);
        }
    }
}

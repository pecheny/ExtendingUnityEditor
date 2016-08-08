using System;
using UnityEngine;

/// <summary>
/// Standard inspector usage examples
/// </summary>
public class Unit : MonoBehaviour {

    [Tooltip("Hover the mouse over field name in the inspector and you will see this tooltip.")]
    public Health health;

    [Tooltip("This value can be edited in the inspector but not from code ouutside this class.")]
    [SerializeField] Power power;

    [Tooltip("Range attributw restricts values which can be entered in the inspector and adds slider.")]
    [Range(0, 5)]
    public float distance;

    public Color color;
    public AnimationCurve animationCurve;

    [Header("Title")]
    [Tooltip("This field has it's own title in the inspector.")]
    public int titledField = 0;

    [Space(20)]
    [Tooltip("This field has top margin in the inspector.")]
    public int anotherUselessVar = 0;

    [HideInInspector]
    public int hiddenVar = 5; // Open "01-Intro" scene and click play to check the value

    [NonSerialized]
    public int anotherHiddenVar = 5; // A kind of more predictable public field which would not store value within unity scene

    [MultilineAttribute]
    [Tooltip("String field where you can enter several lines.")]
    public string longString;

    [TextArea(2, 3)]
    [Tooltip("Text area 2 lines in height at least. Scrollbar will shown if there would be more than 3 lines of text.")]
    public string fewLinesOfText;

    [Tooltip("Enums field looks like dropdown list.")]
    public MyEnum myEnum;

    void Awake() {
        Debug.Log("hiddenVar = " + hiddenVar);
    }
}

[Serializable]
public class Health {
    public int value;
    public int maxValue;
}

[Serializable]
public struct Power {
    public int value;
    public int maxValue;
}

public enum MyEnum {
    Value_one,
    Value_two,
}
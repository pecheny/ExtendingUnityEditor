using System;
using System.Collections.Generic;
using UnityEngine;

public class ReorderableListSample : MonoBehaviour {
    public List<SampleUnit> list = new List<SampleUnit>();
}

[Serializable]
public class SampleUnit {
    public int id;
    public string name;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VariableDataContainer : ScriptableObject {

    public List<ExFloat> floats;
    public List<ExBool> bools;
    public List<ExInt> ints;

}

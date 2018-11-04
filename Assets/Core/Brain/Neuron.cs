using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neuron : ScriptableObject {
    public int Value { get; private set; }
    public int Index { get; private set; }

    public Neuron(int index)
    {
        Value = 0;
        Index = index;
    }

    public void Fire(int strength)
    {
        Value = strength;
    }
}

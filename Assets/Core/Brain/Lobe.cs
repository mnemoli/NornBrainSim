using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lobe : ScriptableObject {

    private int LobeID;
    public Vector2Int Location { get; private set; }
    public Vector2Int Dimension { get; private set; }
    public int Size
    {
        get { return Neurons.Count; }
    }
    private List<Neuron> Neurons;

    public static Lobe CreateNew(int lobeID, Vector2Int location, Vector2Int dimension)
    {
        Lobe Lobe = ScriptableObject.CreateInstance<Lobe>();
        Lobe.Init(lobeID, location, dimension);
        return Lobe;
    }

    public void FireNeuron(int neuronIndex)
    {
        Neurons[neuronIndex].Fire(255);
    }

    public Neuron GetFiringNeuron()
    {
        return Neurons.OrderByDescending(n => n.Value).First();
    }

    private void Init(int lobeID, Vector2Int location, Vector2Int dimension)
    {
        this.LobeID = lobeID;
        this.Location = location;
        this.Dimension = dimension;

        Neurons = SetUpNeurons(Dimension.x, Dimension.y);
    }

    private List<Neuron> SetUpNeurons(int x, int y)
    {
        return Enumerable.Range(0, x * y).Select(n => new Neuron(n)).ToList();
    }
}

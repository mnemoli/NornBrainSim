using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class LobeTest
{
    private Brain Brain;
    private Lobe SourceLobe;
    private Lobe DestLobe;
    
    [UnityTest]
    public IEnumerator GetValuesFromDendrites()
    {
        SourceLobe.FireNeuron(0);
        SourceLobe.Process();
        DestLobe.Process();

        var FiringNeurons = DestLobe.GetFiringNeurons();

        Assert.AreEqual(1, FiringNeurons.Count);

        yield return null;

    }

    [SetUp]
    public void MakeBrain()
    {
        var OpCodes = new List<OpCode.IOpCode>
        {
            new OpCode.Type0()
        };
        var Type0SVRule = new SVRule(OpCodes);
        var StateSVRule = new SVRule(new List<OpCode.IOpCode>
        {
            new OpCode.State()
        });
        var Type0NeuronGene = new NeuronGene(0, 0, 255, Type0SVRule);
        var StateNeuronGene = new NeuronGene(0, 0, 255, StateSVRule);
        var DendriteDynamics = new DendriteDynamicsGene(0, 0, StateSVRule);
        DendriteGene DendriteGene = new DendriteGene(BrainLobeType.Drive, DendriteGene.SpreadType.Flat, 0, new Vector2Int(1, 1), new Vector2Int(255, 255), new Vector2Int(255, 255), DendriteDynamics);
        DendriteGene DendriteGeneNoDendrites = new DendriteGene(BrainLobeType.Perception, DendriteGene.SpreadType.Flat, 0, new Vector2Int(0, 0), new Vector2Int(1, 1), new Vector2Int(1, 1), DendriteDynamics);
        // Destination lobe
        var LobeGene1 = new LobeGene(BrainLobeID.Perception, new Vector2Int(1, 1), new Vector2Int(1, 1), DendriteGene, DendriteGene, Type0NeuronGene, 0, 0);
        // Source lobe
        var LobeGene2 = new LobeGene(BrainLobeID.Drive, new Vector2Int(1, 1), new Vector2Int(1, 1), DendriteGeneNoDendrites, DendriteGeneNoDendrites, StateNeuronGene, 0, 0);

        Brain = new Brain();
        DestLobe = LobeBuilder.BuildFromGene(LobeGene1, 1, 1);
        SourceLobe = LobeBuilder.BuildFromGene(LobeGene2, 1, 1);
        Brain.AddLobe(DestLobe);
        Brain.AddLobe(SourceLobe);

        DestLobe.SetUpDendrites(Brain);
    }
}

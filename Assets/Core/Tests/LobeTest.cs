using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Creatures;

public class LobeTest
{
    Lobe Lobe;
    [SetUp]
    public void MakeLobe()
    {
        Gene LobeGene = new Gene(new byte[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 3, 4 });
        LobeInterpreter LobeInterpreter = ScriptableObject.CreateInstance<LobeInterpreter>();
        Lobe = LobeInterpreter.LobeFromGene(LobeGene);
    }

    [UnityTest]
    public IEnumerator FireNeuron()
    {
        Lobe.FireNeuron(5);
        Assert.AreEqual(5, Lobe.GetFiringNeuron().Index);
        yield return null;
    }
}

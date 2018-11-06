using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class BrainBuilderTest
{
    [UnityTest]
    public IEnumerator BuildBrain()
    {
        LobeGene Gene = new LobeGene(0, new Vector2Int(0, 0), new Vector2Int(1, 2), null, null, null);
        List<LobeGene> Genes = new List<LobeGene> { Gene };

        GameObject go = new GameObject("Dummy game object");

        Brain Brain = BrainBuilder.Build(go, Genes);
        Assert.AreEqual(1, Brain.NumLobes);
        yield return null;
    }
}

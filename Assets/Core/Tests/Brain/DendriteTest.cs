using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Linq;

public class DendriteTest
{
    private static readonly float FixedUpdateTime = Time.fixedDeltaTime;

    [UnityTest]
    public IEnumerator LTWZeroToOne()
    {
        var LTWGainRate = 16;
        var DynamicsGene = new DendriteDynamicsGene(LTWGainRate);
        DendriteGene DendriteGene = new DendriteGene(0, DendriteGene.SpreadType.Flat, new Vector2Int(0,0), new Vector2Int(0, 0), new Vector2Int(1, 1), DynamicsGene);
        Dendrite Dendrite = new Dendrite(0, 0, DendriteGene);
        Dendrite.MockSTW(1);
        // Process assumes it is being called in FixedUpdate
        // i.e. 10 times a second
        foreach(var i in Enumerable.Range(0, 5))
        {
            Dendrite.Process();
        }
        Assert.AreEqual(1, Mathf.RoundToInt(Dendrite.LTW));

        yield return null;
    }

    [UnityTest]
    public IEnumerator LTW255ToZero()
    {
        var LTWGainRate = 16;
        var Start = 255;
        var End = 2;
        var DynamicsGene = new DendriteDynamicsGene(LTWGainRate);
        DendriteGene DendriteGene = new DendriteGene(0, DendriteGene.SpreadType.Flat, new Vector2Int(0, 0), new Vector2Int(Start, Start), new Vector2Int(1, 1), DynamicsGene);
        Dendrite Dendrite = new Dendrite(0, 0, DendriteGene);
        Dendrite.MockSTW(1);
        // Process assumes it is being called in FixedUpdate
        // i.e. 10 times a second
        foreach (var i in Enumerable.Range(0, 10))
        {
            Dendrite.Process();
        }
        Assert.AreEqual(End, Mathf.RoundToInt(Dendrite.LTW));

        yield return null;
    }
}

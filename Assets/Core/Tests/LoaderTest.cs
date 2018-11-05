using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class LoaderTest {
    
    const string FileLocation = "F:\\Jade\\Documents\\Unity Projects\\BrainSim2\\Assets\\Genes\\norn.gen";
    List<RawGene> Genes;

    [SetUp]
    public void GetGenes()
    {
        Genes = GeneFileLoader.LoadGenes(FileLocation);
    }
    
    [UnityTest]
    public IEnumerator NumberOfGenes() {
        Assert.AreEqual(787, Genes.Count);
        yield return null;
    }

    [UnityTest]
    public IEnumerator FirstGene()
    {
        byte[] FirstGene = { 0x02, 0x01, 0x01, 0x00, 0x00, 0x00, 0x80, 0x00, 0x74, 0x6f, 0x62, 0x79, 0x73, 0x6a, 0x67, 0x6c };
        CheckGene(Genes[0], 16, FirstGene);
        yield return null;
    }

    [UnityTest]
    public IEnumerator LastGene()
    {
        byte[] LastGene = { 0x02, 0x04, 0x0f, 0x00, 0x00, 0x00, 0x80, 0x0e, 0x7d, 0x7e, 0x7f, 0x80, 0x81, 0x82, 0x81, 0x82 };
        CheckGene(Genes[Genes.Count - 1], 16, LastGene);
        yield return null;
    }

    private void CheckGene(RawGene gene, int geneLength, byte[] expectedBytes)
    {
        Assert.AreEqual(geneLength, gene.Count);
        Assert.AreEqual(expectedBytes, gene);
    }
}

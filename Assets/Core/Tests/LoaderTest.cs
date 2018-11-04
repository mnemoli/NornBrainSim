using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Creatures;

public class LoaderTest {

    public GeneFileLoader g;

    [SetUp]
    public void MakeGeneLoader()
    {
        const string FileLocation = "F:\\Jade\\Documents\\Unity Projects\\BrainSim2\\Assets\\Genes\\norn.gen";
        g = GeneFileLoader.CreateNew(FileLocation);
    }
    
    [UnityTest]
    public IEnumerator NumberOfGenes() {
        Assert.AreEqual(787, g.Genes.Count);
        yield return null;
    }

    [UnityTest]
    public IEnumerator FirstGene()
    {
        byte[] FirstGene = { 0x02, 0x01, 0x01, 0x00, 0x00, 0x00, 0x80, 0x00, 0x74, 0x6f, 0x62, 0x79, 0x73, 0x6a, 0x67, 0x6c };
        CheckGene(g.Genes[0], 16, FirstGene);
        yield return null;
    }

    [UnityTest]
    public IEnumerator LastGene()
    {
        byte[] LastGene = { 0x02, 0x04, 0x0f, 0x00, 0x00, 0x00, 0x80, 0x0e, 0x7d, 0x7e, 0x7f, 0x80, 0x81, 0x82, 0x81, 0x82 };
        CheckGene(g.Genes[g.Genes.Count - 1], 16, LastGene);
        yield return null;
    }

    private void CheckGene(Gene gene, int geneLength, byte[] expectedBytes)
    {
        Assert.AreEqual(geneLength, gene.Count);
        Assert.AreEqual(expectedBytes, gene);
    }
}

using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using GeneIndexList = System.Collections.Generic.IEnumerable<int>;

public class GeneFileLoader : ScriptableObject
{
    public static List<RawGene> LoadGenes(string filepath)
    {
        FileStream Filestream = ReadFile(filepath);
        List<RawGene> GeneList = new List<RawGene>();
        const int GenePrefixLength = 4;

        List<int> GeneIndexes = new List<int>(FindGeneIndexes(Filestream));

        for (int i = 0; i < GeneIndexes.Count - 1; i++)
        {
            int StartOfGeneIndex = GeneIndexes[i] + GenePrefixLength;
            int GeneLength = GeneIndexes[i + 1] - StartOfGeneIndex;
            byte[] GeneBytes = new byte[GeneLength];
            Filestream.Seek(StartOfGeneIndex, SeekOrigin.Begin);
            Filestream.Read(GeneBytes, 0, GeneLength);
            GeneList.Add(new RawGene(GeneBytes));
        }
        return GeneList;

    }

    private static FileStream ReadFile(string GeneFileLocation)
    {
        return File.OpenRead(GeneFileLocation);
    }

    private static GeneIndexList FindGeneIndexes(FileStream filestream)
    {
        StreamReader Reader = new StreamReader(filestream, System.Text.Encoding.ASCII);

        string GenAsString = Reader.ReadToEnd();
        MatchCollection Matches = Regex.Matches(GenAsString, "(gene|gend)");
        foreach (Match Match in Matches)
        {
            yield return Match.Index;
        }
    }
}


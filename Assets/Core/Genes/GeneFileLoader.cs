using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using GeneIndexList = System.Collections.Generic.IEnumerable<int>;

namespace Creatures
{
    public class GeneFileLoader : ScriptableObject
    {

        public string GeneFileLocation; // must be public to expose to Unity Editor
        public List<Gene> Genes { get; private set; }

        public static GeneFileLoader CreateNew(string geneFileLocation)
        {
            GeneFileLoader GeneFileLoader = ScriptableObject.CreateInstance<GeneFileLoader>();
            GeneFileLoader.GeneFileLocation = geneFileLocation;
            GeneFileLoader.Init();
            return GeneFileLoader;
        }

        public void Init()
        {
            // assumes that GeneFileLocation has been set
            this.Genes = LoadGenes(ReadFile(GeneFileLocation));
        }

        private List<Gene> LoadGenes(FileStream filestream)
        {
            List<Gene> GeneList = new List<Gene>();
            const int GenePrefixLength = 4;

            List<int> GeneIndexes = new List<int>(FindGeneIndexes(filestream));

            for (int i = 0; i < GeneIndexes.Count - 1; i++)
            {
                int StartOfGeneIndex = GeneIndexes[i] + GenePrefixLength;
                int GeneLength = GeneIndexes[i + 1] - StartOfGeneIndex;
                byte[] GeneBytes = new byte[GeneLength];
                filestream.Seek(StartOfGeneIndex, SeekOrigin.Begin);
                filestream.Read(GeneBytes, 0, GeneLength);
                GeneList.Add(new Gene(GeneBytes));
            }
            return GeneList;

        }

        private FileStream ReadFile(string GeneFileLocation)
        {
            return File.OpenRead(GeneFileLocation);
        }

        private GeneIndexList FindGeneIndexes(FileStream filestream)
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

}


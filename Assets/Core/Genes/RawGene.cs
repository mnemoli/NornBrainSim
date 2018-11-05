using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawGene : List<byte>
{
    public RawGene(byte[] bytes) : base(bytes)
    {
    }

    public RawGene() : base()
    {

    }

    public RawGene(int capacity) : base(capacity)
    {

    }
}

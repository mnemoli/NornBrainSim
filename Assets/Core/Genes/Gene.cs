using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gene : List<byte>
{
    public Gene(byte[] bytes) : base(bytes)
    {
    }

    public Gene() : base()
    {

    }

    public Gene(int capacity) : base(capacity)
    {

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

abstract class SVNode
{
    private readonly List<SVNode> Children;
    
    public SVNode(List<SVNode> children)
    {
        Children = children;
    }

public abstract float Evaluate(SVDataPacket dataPacket);

}

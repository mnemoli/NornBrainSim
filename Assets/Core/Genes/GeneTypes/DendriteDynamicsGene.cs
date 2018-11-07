using System;
using System.Collections.Generic;
using System.Linq;

public class DendriteDynamicsGene
{
    public readonly int LTWGainRate;
    public readonly int SusceptibilityRelaxRate;
    public readonly SVRule SusceptibilitySVRule;

    public DendriteDynamicsGene(int lTWGainRate, int susceptibilityRelaxRate, SVRule susceptibilitySVRule)
    {
        LTWGainRate = lTWGainRate;
        SusceptibilityRelaxRate = susceptibilityRelaxRate;
        SusceptibilitySVRule = susceptibilitySVRule;
    }
}
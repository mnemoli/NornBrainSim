using System;
using System.Collections.Generic;
using System.Linq;

public class DendriteDynamicsGene
{
    public readonly int LTWGainRate;
    public readonly int STWGainRate;
    public readonly int SusceptibilityRelaxRate;
    public readonly SVRule SusceptibilitySVRule;
    public readonly int StrengthGain;
    public readonly SVRule StrengthGainSVRule;
    public readonly int StrengthLoss;
    public readonly SVRule StrengthLossSVRule;
    public readonly SVRule ReinforcementRule;
    public readonly int MigrateWhen;

    public DendriteDynamicsGene(int lTWGainRate, int stwGainRate, int susceptibilityRelaxRate, SVRule susceptibilitySVRule, int strengthGain, SVRule strengthGainSVRule, int strengthLoss, SVRule strengthLossSVRule, SVRule reinforcementRule, int migrateWhen)
    {
        LTWGainRate = lTWGainRate;
        STWGainRate = stwGainRate;
        SusceptibilityRelaxRate = susceptibilityRelaxRate;
        SusceptibilitySVRule = susceptibilitySVRule;
        StrengthGain = strengthGain;
        StrengthGainSVRule = strengthGainSVRule;
        StrengthLoss = strengthLoss;
        StrengthLossSVRule = strengthLossSVRule;
        ReinforcementRule = reinforcementRule;
        MigrateWhen = migrateWhen;
    }
}
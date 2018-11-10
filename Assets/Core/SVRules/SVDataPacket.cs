﻿using System.Collections.Generic;

public class SVDataPacket {

    public float State;
    public float Result;
    public int NeuronOutput;
    public int Susceptibility;
    public List<Dendrite> d0;
    public List<Dendrite> d1;

    public SVDataPacket()
    {
    }
}

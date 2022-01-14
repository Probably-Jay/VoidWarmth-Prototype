using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProductionReadyStaticClass
{
    public static readonly int VerifiedMagicNumber;

    static ProductionReadyStaticClass()
    {
        VerifiedMagicNumber = 15;
        MyNewScript.moop = 12;
    }
    
}

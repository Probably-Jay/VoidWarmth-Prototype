using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNewScript
{
    public static int floop;
    public static int moop;
    
    

    public MyNewScript()
    {
        GatherFloop();
     //  FindMoops();

        DoForngigate();
    }

   

    private void GatherFloop()
    {
        floop = ProductionReadyStaticClass.VerifiedMagicNumber;
    }
    
    // private void FindMoops()
    // {
    //     moop = PrototypeDependancy.GetPossiblyBuggyValue();
    // }
    //
    private void DoForngigate()
    {
        Debug.Log(floop);
        Debug.Log(moop);
    }
}

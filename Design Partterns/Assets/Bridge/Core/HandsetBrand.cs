using UnityEngine;
using System.Collections;

public abstract class HandsetBrand 
{
    protected HandsetSoftware software;

    public void SetHandsetSoftware(HandsetSoftware software)
    {
        this.software = software;
    }
    public abstract void Run();
}

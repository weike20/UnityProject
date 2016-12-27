using UnityEngine;
using System.Collections;

public class BridgeDemo : MonoBehaviour
{
    void Start()
    {
        HandsetBrand hb;
        hb = new HandsetBrandN();

        hb.SetHandsetSoftware(new HandsetGame());
        hb.Run();

        hb.SetHandsetSoftware(new HandsetAdressList());
        hb.Run();

        hb = new HandsetBrandM();
        hb.SetHandsetSoftware(new HandsetGame());
        hb.Run();

        hb.SetHandsetSoftware(new HandsetAdressList());
        hb.Run();
    }
}

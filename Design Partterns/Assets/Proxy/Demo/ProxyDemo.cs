using UnityEngine;
using System.Collections;

public class ProxyDemo : MonoBehaviour
{
    void Start()
    {
        Proxy proxy = new Proxy();
        proxy.Request();
    }
}

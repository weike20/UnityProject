using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;
    public static Singleton Instance
    {
        get
        {
            if(instance ==null)
            {
                return new Singleton();
            }
            return instance;
        }
    }


    void Awake()
    {
        if(instance !=null && instance !=this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
}

using UnityEngine;
using System.Collections;

public class DDemo : MonoBehaviour
{
    void Start()
    {
        DResume a = new DResume("weike");
        a.SetPersonalInfo("0", "22");
        a.SetWorkExperience("1992~2002", "aaa公司");

        DResume b = (DResume)a.Clone();
        b.SetWorkExperience("2002~2003", "bbb公司");

        DResume c = (DResume)a.Clone();
        c.SetWorkExperience("2003~2005", "ccc公司");


        a.Show();
        b.Show();
        c.Show();
    }
}

using UnityEngine;
using System.Collections;

public class SDemo : MonoBehaviour
{
    void Start()
    {
        SResume a = new SResume("weike");
        a.SetPersonalInfo("0", "22");
        a.SetWorkExperience("1992~2002", "aaa公司");

        SResume b = (SResume)a.Clone();
        b.SetWorkExperience("2002~2003", "bbb公司");

        SResume c = (SResume)b.Clone();
        b.SetWorkExperience("2003~2005", "ccc公司");


        a.Show();
        b.Show();
        c.Show();
    }
}

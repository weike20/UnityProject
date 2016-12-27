using UnityEngine;
using System.Collections;
using System;
public class SWorkExperience
{
    private string workDate;
    private string company;
    public string WorkDate
    {
        get
        {
            return workDate;
        }
        set
        {
            workDate = value;
        }
    }
    public string Company
    {
        get
        {
            return company;
        }
        set
        {
            company = value;
        }

    }
}

public class SResume :ICloneable
{
    private string name;
    private string sex;
    private string age;

    private SWorkExperience experience = new SWorkExperience();
    public SResume(string name)
    {
        this.name = name;
    }
    public void SetPersonalInfo(string sex,string age)
    {
        this.sex = sex;
        this.age = age;
    }
    public void SetWorkExperience(string workDate,string company)
    {
        experience.WorkDate = workDate;
        experience.Company = company;
    }
    public void Show()
    {
        Debug.Log(string.Format("{0} {1} {2}", name, sex, age));
        Debug.Log(string.Format("工作经历:{0} {1}", experience.WorkDate, experience.Company));
    }

    public object Clone()
    {
        return (object)base.MemberwiseClone();
    }
}

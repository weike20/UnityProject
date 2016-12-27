using UnityEngine;
using System.Collections;
using System;

public class DWorkExperience :ICloneable
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
    public object Clone()
    {
        return (object)base.MemberwiseClone();
    }
    
}
public class DResume : ICloneable
{
    private string name;
    private string sex;
    private string age;

    private DWorkExperience experience = new DWorkExperience();
    public DResume(string name)
    {
        this.name = name;
    }
    private DResume(DWorkExperience experience)
    {
        this.experience = (DWorkExperience)experience.Clone();
    }
    public void SetPersonalInfo(string sex, string age)
    {
        this.sex = sex;
        this.age = age;
    }
    public void SetWorkExperience(string workDate, string company)
    {
        this.experience.WorkDate = workDate;
        this.experience.Company = company;
    }
    public void Show()
    {
        Debug.Log(string.Format("{0} {1} {2}", name, sex, age));
        Debug.Log(string.Format("工作经历:{0} {1}", experience.WorkDate, experience.Company));
    }

    public object Clone()
    {
        DResume obj = new DResume(experience);
        obj.name = this.name;
        obj.sex = this.sex;
        obj.age = this.age;
        return obj;
    }
}

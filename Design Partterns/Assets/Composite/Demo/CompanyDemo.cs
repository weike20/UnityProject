using UnityEngine;
using System.Collections;

public class CompanyDemo : MonoBehaviour
{
    void Start()
    {
        ConcreateCompany rootCompany = new ConcreateCompany("北京总公司");
        rootCompany.Add(new HRDepartment("北京总公司人力资源部"));
        rootCompany.Add(new FinanceDepartment("北京总公司财务管理部"));

        ConcreateCompany composite = new ConcreateCompany("上海华东分公司");
        composite.Add(new HRDepartment("上海分公司人力资源部"));
        composite.Add(new FinanceDepartment("上海分公司财务管理部"));
        rootCompany.Add(composite);

        ConcreateCompany composite1 = new ConcreateCompany("南京办事处");
        composite1.Add(new HRDepartment("南京办事处人力资源部"));
        composite1.Add(new FinanceDepartment("南京办事处财务管理部"));
        composite.Add(composite1);

        ConcreateCompany composite2 = new ConcreateCompany("杭州办事处");
        composite2.Add(new HRDepartment("杭州办事处人力资源部"));
        composite2.Add(new FinanceDepartment("杭州办事处财务管理部"));
        composite1.Add(composite2);

        Debug.Log("结构图");
        rootCompany.Display(1);

        Debug.Log("职责");
        rootCompany.LineOfDuty();
    }
}

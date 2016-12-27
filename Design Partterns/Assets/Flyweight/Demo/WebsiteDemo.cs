using UnityEngine;
using System.Collections;

public class WebsiteDemo : MonoBehaviour
{

    //最后一站的资源管理和这个模式很像

    void Start()
    {
        WebsiteFactory factory = new WebsiteFactory();
        Website website = factory.GetWebsiteCategory("产品展示");
        website.Use();

        website = factory.GetWebsiteCategory("产品展示");
        website.Use();

        website = factory.GetWebsiteCategory("产品展示");
        website.Use();

        website = factory.GetWebsiteCategory("微博");
        website.Use();

        website = factory.GetWebsiteCategory("微博");
        website.Use();

        website = factory.GetWebsiteCategory("微博");
        website.Use();

       Debug.Log(factory.GetWebsiteCount());
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WebsiteFactory 
{
    private Dictionary<string, ConcreateWebsite> websiteTable = new Dictionary<string, ConcreateWebsite>();

    public Website GetWebsiteCategory(string name)
    {
        if(!websiteTable.ContainsKey(name))
        {
            websiteTable.Add(name, new ConcreateWebsite(name));
        }
        return websiteTable[name];
    }

    public int GetWebsiteCount()
    {
        return websiteTable.Count;
    }
}

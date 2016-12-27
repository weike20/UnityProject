using System.Collections.Generic;

public class ObjectStructure 
{
    private List<Element> elements = new List<Element>();

    public void Add(Element element)
    {
        elements.Add(element);
    }
    public void Remove(Element element)
    {
        elements.Remove(element);
    }
    public void Clear()
    {
        elements.Clear();
    }

    public void Accept(Visitor visitor)
    {
        for(int i=0;i<elements.Count; ++i)
        {
            elements[i].Accept(visitor);
        }
    }
}

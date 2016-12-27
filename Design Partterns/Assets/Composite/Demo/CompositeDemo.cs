using UnityEngine;
using System.Collections;

public class CompositeDemo : MonoBehaviour
{
    void Start()
    {
        Composite root = new Composite("Root");
        root.Add(new Leaf("Leaf A"));
        root.Add(new Leaf("Leaf B"));

        Composite composite = new Composite("Composite X");
        composite.Add(new Leaf("Leaf XA"));
        composite.Add(new Leaf("Leaf XB"));

        root.Add(composite);

        Composite composite1 = new Composite("Composite XY");
        composite1.Add(new Leaf("Composite XYA"));
        composite1.Add(new Leaf("Composite XYB"));

        composite.Add(composite1);

        root.Add(new Leaf("Leaf C"));

        Leaf leafD = new Leaf("LeafD");
        root.Add(leafD);
        root.Remove(leafD);

        root.Display(1);
    }
}

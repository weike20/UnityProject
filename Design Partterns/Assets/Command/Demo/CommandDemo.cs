using UnityEngine;
using System.Collections;

public class CommandDemo : MonoBehaviour
{
    void Start()
    {
        Barbecuer boy = new Barbecuer();

        BakeMuttonCommand bakeMutton1 = new BakeMuttonCommand(boy);
        BakeMuttonCommand bakeMutton2 = new BakeMuttonCommand(boy);
        BakeChickenWingCommand bakeChicken = new BakeChickenWingCommand(boy);

        Waiter girl = new Waiter();


        girl.AddOrder(bakeMutton1);
        girl.AddOrder(bakeMutton2);
        girl.AddOrder(bakeChicken);
        girl.Notify();
        
        
    }
}

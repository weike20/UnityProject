using UnityEngine;
using System.Collections;

public class FactoryMethod : MonoBehaviour
{
    void Start()
    {
        IFactory factory = new VolunteerFactory();
        LeiFeng volunteer = factory.CreateLeiFeng();
        volunteer.Sweep();
        volunteer.BuyRice();
        volunteer.Wash();
    }
}

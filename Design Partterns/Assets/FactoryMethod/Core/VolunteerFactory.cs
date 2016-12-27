using UnityEngine;
using System.Collections;

public class VolunteerFactory :IFactory
{
    public LeiFeng CreateLeiFeng()
    {
        return new Volunteer();
    }
}

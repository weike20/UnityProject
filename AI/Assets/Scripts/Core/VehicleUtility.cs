using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ITGGame.AI
{
    public class VehicleUtility
    {
        public static void TagNeighbors(Vehicle vehicle,List<Vehicle> entitys,double radius)
        {
            using (var itr = entitys.GetEnumerator())
            {
                while(itr.MoveNext())
                {
                    itr.Current.TagNeighbor = false;
                    Vector3 toEntity = itr.Current.transform.position - vehicle.transform.position;
                    if (itr.Current != vehicle && toEntity.sqrMagnitude < radius * radius)
                        itr.Current.TagNeighbor = true;
                }
            }
        }
    }


}


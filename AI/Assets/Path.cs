using UnityEngine;
using System.Collections.Generic;

namespace ITGGame.AI
{
    public class Path : MonoBehaviour
    {
        [SerializeField]
        private List<WayPoint> wayPoints = new List<WayPoint>();
        private WayPoint currentWayPoint = null;

        public WayPoint CurrentWayPoint
        {
            get
            {
                if (currentWayPoint == null && wayPoints.Count != 0)
                    currentWayPoint = wayPoints[0];
                return currentWayPoint;
            }
        }
        public void SetNextWayPoint()
        {
            if(wayPoints.Count < 2)
            {
                Debug.Log("There is not enough way point");
                return;
            }

            int index = wayPoints.FindIndex(item => item == currentWayPoint);
            if(index != -1)
            {
                if (index + 1 == wayPoints.Count)
                    currentWayPoint = wayPoints[0];
                else
                    currentWayPoint = wayPoints[index + 1];
            }
        }
    }

}



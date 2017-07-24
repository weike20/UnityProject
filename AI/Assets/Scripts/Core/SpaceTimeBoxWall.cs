using UnityEngine;
using System.Collections;
[RequireComponent(typeof(BoxCollider))]
public class SpaceTimeBoxWall : MonoBehaviour
{
    private BoxCollider boxCollider;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
    }



    void OnTriggerExit(Collider other)
    {
        Vector3 toOther = other.transform.position - transform.position;
        Vector3 targetPos = transform.position - toOther;
        other.transform.position = targetPos;
    }
}

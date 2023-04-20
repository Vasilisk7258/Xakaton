using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableComponentOnCollision : MonoBehaviour
{
    public MonoBehaviour componentToDisable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollisionTag"))
        {
            componentToDisable.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CollisionTag"))
        {
            componentToDisable.enabled = true;
        }
    }
}

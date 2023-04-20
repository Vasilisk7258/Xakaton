using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHand : MonoBehaviour
{
    public GameObject zombie;
    private Animator zomb_a;
    private bool _HandTrigger;
    public MonoBehaviour componentToDisable;

    private void Start()
    {
        zomb_a = zombie.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Trigger_Zombie"))
        {
            _HandTrigger = UnityEngine.Random.value > 0.5f;
            if (_HandTrigger)
            {
                
                 componentToDisable.enabled = false;
               
                zomb_a.SetTrigger("zomb");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trigger_Zombie"))
        {
            componentToDisable.enabled = true;
        }
    }
}

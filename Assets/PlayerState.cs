using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerState : MonoBehaviour
{
    [Tooltip("Tomato slap(panel) gameobject")]
    public GameObject _TomatoSlap;
  
    [SerializeField]
    private int ChangeTime = 5;
    [SerializeField]
    private float ChangeSpeed = 0.5f;
    public ActionBasedContinuousMoveProvider _ContProv;

    public float forceMagnitude = 1f; 
    public float stopDuration = 0.2f;

    private Rigidbody rb;

    private void Start()
    {
        _ContProv.moveSpeed = 2.5f;
        rb = GetComponent<Rigidbody>();
        _TomatoSlap.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Tomato")
        {
            StartCoroutine(_ChangeSpeed());
        }
        else if (other.tag == "Zomb")
        {
            rb.AddForce(-Vector3.forward * forceMagnitude, ForceMode.Impulse); 
            Invoke("StopForce", stopDuration);
        }
    }

    private void StopForce()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero; 
    }

    IEnumerator _ChangeSpeed()
    {
        _ContProv.moveSpeed -= ChangeSpeed;
        _TomatoSlap.SetActive(true);
        yield return new WaitForSeconds(ChangeTime);
        _TomatoSlap.SetActive(false);
        _ContProv.moveSpeed = 2.5f;
    }
}

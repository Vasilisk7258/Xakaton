using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerState : MonoBehaviour
{
    [Tooltip("Tomato slap(panel) gameobject")]
    public GameObject _TomatoSlap;
    private Rigidbody _PlayerRB;
    [SerializeField]
    private int ChangeTime = 5;
    [SerializeField]
    private float ChangeSpeed = 0.5f;
    private float initialTime = 0;
    public ActionBasedContinuousMoveProvider _ContProv;

    private void Start()
    {
        _PlayerRB = this.gameObject.GetComponent<Rigidbody>();
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
            StartCoroutine(_ZombiPush());
        }
    }

    IEnumerator _ChangeSpeed()
    {
        initialTime = _ContProv.moveSpeed;
        _ContProv.moveSpeed -= ChangeSpeed;
        _TomatoSlap.SetActive(true);
        yield return new WaitForSeconds(ChangeTime);
        _TomatoSlap.SetActive(false);
        _ContProv.moveSpeed = initialTime;
    }

    IEnumerator _ZombiPush()
    {
        _PlayerRB.AddForce(-Vector3.forward, ForceMode.Impulse);
        yield return new WaitForFixedUpdate();
        _PlayerRB.velocity = Vector3.zero;
    }

}

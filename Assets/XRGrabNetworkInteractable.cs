using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class XRGrabNetworkInteractable : XRGrabInteractable
{
    // Start is called before the first frame update

    private PhotonView photonView;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        photonView.RequestOwnership();
        base.OnSelectEntering(args);
    }

   
}

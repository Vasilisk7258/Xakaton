using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;


public class NetworkPlayer : MonoBehaviour
{
    public Transform Head;
    public Transform LeftHand;
    public Transform RightHand;

    public Animator LeftHandAnimator;
    public Animator RightHandAnimator;


    private PhotonView photonview;



    void Start()
    {
        

        photonview = GetComponent<PhotonView>();
        if (photonview.IsMine)
        {
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }
    }


    void Update()
    {
        if (photonview.IsMine)
        {
           

            MapPosition(Head, XRNode.Head);
            MapPosition(LeftHand, XRNode.LeftHand);
            MapPosition(RightHand, XRNode.RightHand);

            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), LeftHandAnimator);
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), RightHandAnimator);
        }

         

    }

    void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator)
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
         {
            handAnimator.SetFloat("Trigger", 0);
        } 

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    void MapPosition(Transform target,XRNode node )
    {
         InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
         InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

         target.position = position;
         target.rotation = rotation;
       

    }
}

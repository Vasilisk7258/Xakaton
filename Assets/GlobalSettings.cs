using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class GlobalSettings : MonoBehaviour
{
    private float bright;


    private void Update()
    {
        bright = this.gameObject.GetComponent<XRSlider>().value;
        Bright();
        print(bright);
    }
    public void Bright()
    {
        Screen.brightness = bright;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingClim : MonoBehaviour
{
    public bool isBreaking;
    public int BreakingTime;

    public void Broken()
    {
        if (isBreaking)
            Debug.LogWarning(string.Format("This object( {0} ) is not breaking", this.gameObject));
        else
            StartCoroutine(_BreakingGameObject());
    }
    IEnumerator _BreakingGameObject()
    {
        yield return new WaitForSeconds(BreakingTime);
        Destroy(this.gameObject);
    }
}

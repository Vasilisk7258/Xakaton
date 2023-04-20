using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Loader()
    {
        if(this.gameObject.tag == "ToMenu")
        {
            SceneManager.LoadScene("PlayableMenu");
        }

        else if(this.gameObject.tag == "ToSettings")
        {
            SceneManager.LoadScene("MainMenu");
        }

        else if(this.gameObject.tag == "SingleLobby")
        {
            //Paste single player scene name
            SceneManager.LoadScene("Rabota");
        }

        else if(this.gameObject.tag == "MultiPlayer")
        {
            //Paste multi player scene name
            SceneManager.LoadScene("MultiPlayer");
        }
    }
}

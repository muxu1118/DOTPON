using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameSelect : MonoBehaviour
{
  
    public string sceneToLoad;
 

    public void twoPlayer()
    {
        PlayerPrefs.SetInt("PlayerNumbers", 2);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ThreePlayer()
    {
        PlayerPrefs.SetInt("PlayerNumbers", 3);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void fourPlayer()
    {
        PlayerPrefs.SetInt("PlayerNumbers", 4);
        SceneManager.LoadScene(sceneToLoad);
    }


}

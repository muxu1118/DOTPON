using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreenController : MonoBehaviour
{
    public GameObject MainCamera, singlePlayerCam, twoPlayerCam, threeplayerCam, fourPlayerCam,  screenPanel;
    public GameObject[] cameras;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetButtonDown("Cancel"))
        {
            screenPanel.SetActive(true);
        }
        
    }

    public void singlePlayer()
    {
        deactiveCamAndPanel();
        singlePlayerCam.SetActive(true);
        screenPanel.SetActive(false);
    }
    public void twoPlayer()
    {
        deactiveCamAndPanel();
        twoPlayerCam.SetActive(true);
        screenPanel.SetActive(false);

    }
    public void threePlayer()
    {
        deactiveCamAndPanel();
        threeplayerCam.SetActive(true);
        screenPanel.SetActive(false);
    }
    public void fourPlayer()
    {
        deactiveCamAndPanel();
        fourPlayerCam.SetActive(true);
        screenPanel.SetActive(false);

    }
    public void deactiveCamAndPanel()
    {
        for(int i=0; i<cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
            
        }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreenController : MonoBehaviour
{
    public GameObject MainCamera, singlePlayerCam, twoPlayerCam, fourPlayerCam, screenPanel;
    public Camera cam1, cam2, cam3, cam4;
    public bool twoPlayerDead=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            twoPlayerDead = true;
        }
        if (Input.GetButtonDown("Cancel"))
        {
            screenPanel.SetActive(true);
        }
        
    }

    public void singlePlayer()
    {
        twoPlayerCam.SetActive(false);
        fourPlayerCam.SetActive(false);
        singlePlayerCam.SetActive(true);
        screenPanel.SetActive(false);
        MainCamera.SetActive(false);
        twoPlayerDead = false;
    }
    public void twoPlayer()
    {
        twoPlayerCam.SetActive(true);
        fourPlayerCam.SetActive(false);
        singlePlayerCam.SetActive(false);
        screenPanel.SetActive(false);
        MainCamera.SetActive(false);
        twoPlayerDead = false;
    }
    public void fourPlayer()
    {
        twoPlayerCam.SetActive(false);
        fourPlayerCam.SetActive(true);
        singlePlayerCam.SetActive(false);
        screenPanel.SetActive(false);
        MainCamera.SetActive(false);
        twoPlayerDead = false;
    }
}

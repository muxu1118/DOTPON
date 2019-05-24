using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreenController : MonoBehaviour
{
    public GameObject MainCamera, singlePlayerCam, twoPlayerCam, threeplayerCam, fourPlayerCam,  screenPanel;
    public GameObject[] cameras;
    public bool isChanged;
    private int playerNumbers;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerNumbers"))
        {playerNumbers =PlayerPrefs.GetInt("PlayerNumbers");

            switch (playerNumbers)
            {
                case 2:twoPlayer();
                    break;
                case 3: threePlayer();
                    break;
                case 4: fourPlayer();
                    break;
                   
            }
        }
        else
        {
            singlePlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
       
       /* if (Input.GetButtonDown("Cancel"))
        {
            screenPanel.SetActive(true);
        }
        */
        
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

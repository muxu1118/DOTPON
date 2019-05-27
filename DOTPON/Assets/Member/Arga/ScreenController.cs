using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{

    public GameObject[] cameras;
    private int playerNumbers;
    private Rect singleCam = new Rect(0f, 0f, 1f, 1f);
    private Rect dualCam1 = new Rect(0f, 0f, 0.5f, 1f);
    private Rect dualCam2 = new Rect(0.5f, 0f, 1f, 1f);
    private Rect multiCam1 = new Rect(0f, 0.5f, 0.5f, 1f);
    private Rect multiCam2 = new Rect(0.5f, 0.5f, 1f, 1f);
    private Rect multiCam3 = new Rect(0f, 0f, 0.5f, 0.5f);
    private Rect multiCam4 = new Rect(0.5f, 0f, 1f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        switch (MultiPlayerManager.instance.totalPlayer)
        {

            case 1: singlePlayer();
                break;
            case 2: twoPlayer();
                break;
            case 3: threePlayer();
                break;
            case 4: fourPlayer();
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void singlePlayer()
    {
        DeactiveCam();
        cameras[0].GetComponent<Camera>().rect = singleCam;
        cameras[0].SetActive(true);
    }

    public void twoPlayer()
    {
        DeactiveCam();
        cameras[0].GetComponent<Camera>().rect = dualCam1;
        cameras[1].GetComponent<Camera>().rect = dualCam2;
        cameras[0].SetActive(true);
        cameras[1].SetActive(true);
    }

    public void threePlayer()
    {
        DeactiveCam();
        cameras[0].GetComponent<Camera>().rect = multiCam1;
        cameras[1].GetComponent<Camera>().rect = multiCam2;
        cameras[2].GetComponent<Camera>().rect = multiCam3;
        cameras[0].SetActive(true);
        cameras[1].SetActive(true);
        cameras[2].SetActive(true);
        cameras[4].SetActive(true);
    }

    public void fourPlayer()
    {
        DeactiveCam();
        cameras[0].GetComponent<Camera>().rect = multiCam1;
        cameras[1].GetComponent<Camera>().rect = multiCam2;
        cameras[2].GetComponent<Camera>().rect = multiCam3;
        cameras[3].GetComponent<Camera>().rect = multiCam4;
        cameras[0].SetActive(true);
        cameras[1].SetActive(true);
        cameras[2].SetActive(true);
        cameras[3].SetActive(true);
    }

    public void DeactiveCam()
    {
        for(int i=0; i <cameras.Length; i++)
        {
            if (cameras[i].gameObject == null) return;
            cameras[i].gameObject.SetActive(false);
        }
        
    }
}

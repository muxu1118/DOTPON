using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    [SerializeField]GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //スタート画面のスクショ用
        StartScreen();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScreenCapture.CaptureScreenshot("image.png");
        }
    }

    private void StartScreen()
    {
        player.GetComponent<Animator>().SetTrigger("PV1");
    }
}

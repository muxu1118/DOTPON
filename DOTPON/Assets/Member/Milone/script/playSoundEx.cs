using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundEx : MonoBehaviour
{
    public int musicToPlay,soundEffToPlay,music2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AudioManager.instance.playMusic(musicToPlay);
        }else if(Input.GetKeyDown(KeyCode.W))
        {
            AudioManager.instance.playMusic(music2);
        }
       else if (Input.GetKeyDown(KeyCode.E))
        {
            AudioManager.instance.playSfx(soundEffToPlay);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            AudioManager.instance.musicStop();
        }
    }
}

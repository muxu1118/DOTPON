using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] music;
    public AudioSource[] soundEffect;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        instance = this;

    }
    public void playSfx(int num)
    {
        soundEffect[num].Play();
    }
   public  void playMusic(int num)
    {
        musicStop();
        music[num].Play();
    }
    public void musicStop()
    {
        for (int i = 0; i < music.Length; i++)
        {
            music[i].Stop();
        }
    }
}

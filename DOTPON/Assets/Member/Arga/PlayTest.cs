using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayTest : MonoBehaviour
{
    public Text number;
    // Start is called before the first frame update
    void Start()
    {
        MultiPlayerManager.instance.P1Dot = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //  number.text = MultiPlayerManager.instance.TotalPlayer.ToString();
    }

    public void Plus()
    {
        MultiPlayerManager.instance.totalPlayer++;
    }

    public void Minus()
    {
        MultiPlayerManager.instance.totalPlayer--;
    }

    public void singlePlayer()
    {
        MultiPlayerManager.instance.totalPlayer = 1;
        SceneManager.LoadScene(1);
    } 

    public void twoPlayer()
    {
        MultiPlayerManager.instance.totalPlayer = 2;
        SceneManager.LoadScene(1);
    } 

    public void threePlayer()
    {
        MultiPlayerManager.instance.totalPlayer = 3;
        SceneManager.LoadScene(1);
    } 

    public void fourPlayer()
    {
        MultiPlayerManager.instance.totalPlayer = 4;
        SceneManager.LoadScene(1);
    } 

    public void backButton()
    {
        SceneManager.LoadScene(0);
    }
}

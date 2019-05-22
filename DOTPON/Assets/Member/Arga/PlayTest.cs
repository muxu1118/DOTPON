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
        
    }

    // Update is called once per frame
    void Update()
    {
        //  number.text = MultiPlayerManager.instance.TotalPlayer.ToString();
    }

    public void Plus()
    {
        MultiPlayerManager.instance.TotalPlayer++;
    }

    public void Minus()
    {
        MultiPlayerManager.instance.TotalPlayer--;
    }

    public void singlePlayer()
    {
        MultiPlayerManager.instance.TotalPlayer = 1;
        MultiPlayerManager.instance.MultiPlayer();
        SceneManager.LoadScene(1);
    } 

    public void twoPlayer()
    {
        MultiPlayerManager.instance.TotalPlayer = 2;
        MultiPlayerManager.instance.MultiPlayer();
        SceneManager.LoadScene(1);
    } 

    public void threePlayer()
    {
        MultiPlayerManager.instance.TotalPlayer = 3;
        MultiPlayerManager.instance.MultiPlayer();
        SceneManager.LoadScene(1);
    } 

    public void fourPlayer()
    {
        MultiPlayerManager.instance.TotalPlayer = 4;
        MultiPlayerManager.instance.MultiPlayer();
        SceneManager.LoadScene(1);
    } 

    public void backButton()
    {
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestTitle : MonoBehaviour
{
    public Text number;
    // Start is called before the first frame update
    void Start()
    {
        //MultiPlayerManager.instance.P1Dot = 1;
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

    public void SinglePlayer()
    {
        MultiPlayerManager.instance.totalPlayer = 1;
        SceneManager.LoadScene(3);
    }

    public void TwoPlayer()
    {
        MultiPlayerManager.instance.totalPlayer = 2;
        SceneManager.LoadScene(3);
    }

    public void ThreePlayer()
    {
        MultiPlayerManager.instance.totalPlayer = 3;
        SceneManager.LoadScene(3);
    }

    public void FourPlayer()
    {
        MultiPlayerManager.instance.totalPlayer = 4;
        SceneManager.LoadScene(3);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(2);
    }
}

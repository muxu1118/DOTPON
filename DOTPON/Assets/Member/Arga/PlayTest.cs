﻿using System.Collections;
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
<<<<<<< HEAD
        //MultiPlayerManager.instance.P1Dot = 1;
=======
        // MultiPlayerManager.instance.P1Dot = 1;
>>>>>>> origin/Arga
    }

    // Update is called once per frame
    void Update()
    {
        //  number.text = MultiPlayerManager.instance.TotalPlayer.ToString();
    }

    public void PlusPl()
    {
        MultiPlayerManager.instance.totalPlayer++;
    }

    public void MinusPl()
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

    public void P1PlusDot()
    {
        MultiPlayerManager.instance.P1Dot++;
    }
    public void P2PlusDot()
    {
        MultiPlayerManager.instance.P2Dot++;
    }

    public void P3PlusDot()
    {
        MultiPlayerManager.instance.P3Dot++;
    }

    public void P4PlusDot()
    {
        MultiPlayerManager.instance.P4Dot++;
    }

    public void P1PlusStar()
    {
        MultiPlayerManager.instance.P1Star++;
    }

    public void P2PlusStar()
    {
        MultiPlayerManager.instance.P2Star++;
    }

    public void P3PlusStar()
    {
        MultiPlayerManager.instance.P3Star++;
    }

    public void P4PlusStar()
    {
        MultiPlayerManager.instance.P4Star++;
    }


}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
<<<<<<< HEAD:DOTPON/Assets/Member/Takahashi/script/EffectManager.cs

    // Start is called before the first frame update
    void Start()
    {
        
=======
    enum StarText
    {
        P1Text,
        P2Text,
        P3Text,
        P4Text
    }
    [SerializeField]
    StarText starText;

    private Text Star_Text;

    private int count;
    // Start is called before the first frame update
    void Start()
    {
        Star_Text = GetComponent<Text>();
>>>>>>> origin/Arga:DOTPON/Assets/Member/Arga/testScript/test2.cs
    }

    // Update is called once per frame
    void Update()
    {
        SetStarText();
    }



    void SetStarText()
    {
        switch (starText)
        {
            case StarText.P1Text:
                Star_Text.text = "×" + MultiPlayerManager.instance.P1Star.ToString();
                break;
            case StarText.P2Text:
                Star_Text.text = "×" + MultiPlayerManager.instance.P2Star.ToString();
                break;
            case StarText.P3Text:
                Star_Text.text = "×" + MultiPlayerManager.instance.P3Star.ToString();
                break;
            case StarText.P4Text:
                Star_Text.text = "×" + MultiPlayerManager.instance.P4Star.ToString();
                break;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test1 : MonoBehaviour
{
    enum DotText
    {
        P1Text,
        P2Text,
        P3Text,
        P4Text
    }
    [SerializeField]
    DotText dotText;

    private Text Dot_Text;
    void Start()
    {
        Dot_Text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        SetDotText();
    }
    void SetDotText()
    {
        switch (dotText)
        {
            case DotText.P1Text:
                Dot_Text.text = "×" + MultiPlayerManager.instance.P1Dot.ToString();
                break;
            case DotText.P2Text:
                Dot_Text.text = "×" + MultiPlayerManager.instance.P2Dot.ToString();
                break;
            case DotText.P3Text:
                Dot_Text.text = "×" + MultiPlayerManager.instance.P3Dot.ToString();
                break;
            case DotText.P4Text:
                Dot_Text.text = "×" + MultiPlayerManager.instance.P4Dot.ToString();
                break;
        }
    }
}

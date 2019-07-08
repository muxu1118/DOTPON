using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dot_count : MonoBehaviour
{
    enum DotText
    {
        P1Text,
        P2Text,
        P3Text,
        P4Text,
        P1Star,
        P2Star,
        P3Star,
        P4Star
    }
    [SerializeField]
    DotText dotText;

    private Text Dot_Text;
    
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 10;
        Dot_Text = GetComponent<Text>();
        Debug.Log(Dot_Text);
    }

    // Update is called once per frame
    void Update()
    {
        SetCountText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        switch (dotText)
        {
            case DotText.P1Text:
                Dot_Text.text = " " + MultiPlayerManager.instance.P1Dot.ToString("00") + " ";
                break;
            case DotText.P2Text:
                Dot_Text.text = " " + MultiPlayerManager.instance.P2Dot.ToString("00") + " ";
                break;
            case DotText.P3Text:
                Dot_Text.text = " " + MultiPlayerManager.instance.P3Dot.ToString("00") + " ";
                break;
            case DotText.P4Text:
                Dot_Text.text = " " + MultiPlayerManager.instance.P4Dot.ToString("00") + " ";
                break;
            case DotText.P1Star:
                Dot_Text.text = " " + MultiPlayerManager.instance.P1Star.ToString("00") + " ";
                break;
            case DotText.P2Star:
                Dot_Text.text = " " + MultiPlayerManager.instance.P2Star.ToString("00") + " ";
                break;
            case DotText.P3Star:
                Dot_Text.text = " " + MultiPlayerManager.instance.P3Star.ToString("00") + " ";
                break;
            case DotText.P4Star:
                Dot_Text.text = " " + MultiPlayerManager.instance.P4Star.ToString("00") + " ";
                break;
        }
    }
    void SetCountStar()
    {
        switch (dotText)
        {
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dot_star_display : MonoBehaviour
{

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
        count = 1;
        Star_Text = GetComponent<Text>();
        Debug.Log(Star_Text);
    }

    // Update is called once per frame
    void Update()
    {
        SetStarText();
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Pick Up"))
    //    {
    //        other.gameObject.SetActive(false);
    //        count = count + 1;
    //        SetStarText();
    //    }
    //}

    void SetStarText()
    {
        switch (starText)
        {
            case StarText.P1Text:
                Star_Text.text = MultiPlayerManager.instance.P1Star.ToString("0");
                break;
            case StarText.P2Text:
                Star_Text.text = MultiPlayerManager.instance.P2Star.ToString("0");
                break;
            case StarText.P3Text:
                Star_Text.text = MultiPlayerManager.instance.P3Star.ToString("0");
                break;
            case StarText.P4Text:
                Star_Text.text = MultiPlayerManager.instance.P4Star.ToString("0");
                break;
        }
    }
}
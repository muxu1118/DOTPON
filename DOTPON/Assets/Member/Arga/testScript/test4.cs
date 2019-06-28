using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test4 : MonoBehaviour
{
    enum RankText
    {
        R1Text,
        R2Text,
        R3Text,
        R4Text
    }
    [SerializeField]
    RankText rankText;

    private Text Rank_Text;
    // Start is called before the first frame update
    void Start()
    {
        Rank_Text = GetComponent<Text>();
        SetRankingText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetRankingText()
    {

        switch (rankText)
        {
            case RankText.R1Text:
                if (MultiPlayerManager.instance.Ranking1 == "1")
                {
                    Rank_Text.text = "x" + MultiPlayerManager.instance.P1Dot.ToString();
                }
                else if (MultiPlayerManager.instance.Ranking1 == "2")
                {
                    Rank_Text.text = "x" + MultiPlayerManager.instance.P2Dot.ToString();
                }
                else if (MultiPlayerManager.instance.Ranking1 == "3")
                {
                    Rank_Text.text = "x" + MultiPlayerManager.instance.P3Dot.ToString();
                }
                else if (MultiPlayerManager.instance.Ranking1 == "4")
                {
                    Rank_Text.text = "x" + MultiPlayerManager.instance.P4Dot.ToString();
                }
                break;
            case RankText.R2Text:
                if (MultiPlayerManager.instance.Ranking2 == "1")
                {
                    Rank_Text.text = "x" + MultiPlayerManager.instance.P1Dot.ToString();
                }
                else if (MultiPlayerManager.instance.Ranking2 == "2")
                {
                    Rank_Text.text = "x" + MultiPlayerManager.instance.P2Dot.ToString();
                }
                else if (MultiPlayerManager.instance.Ranking2 == "3")
                {
                    Rank_Text.text = "x" + MultiPlayerManager.instance.P3Dot.ToString();
                }
                else if (MultiPlayerManager.instance.Ranking2 == "4")
                {
                    Rank_Text.text = "x" + MultiPlayerManager.instance.P4Dot.ToString();
                }
                break;
            case RankText.R3Text:
                if (MultiPlayerManager.instance.Ranking3 == "1")
                {
                    Rank_Text.text = "x" + MultiPlayerManager.instance.P1Dot.ToString();
                }
                else if (MultiPlayerManager.instance.Ranking3 == "2")
                {
                    Rank_Text.text = "x" + MultiPlayerManager.instance.P2Dot.ToString();
                }
                else if (MultiPlayerManager.instance.Ranking3 == "3")
                {
                    Rank_Text.text = "x" + MultiPlayerManager.instance.P3Dot.ToString();
                }
                else if (MultiPlayerManager.instance.Ranking3 == "4")
                {
                    Rank_Text.text = "x" + MultiPlayerManager.instance.P4Dot.ToString();
                }
                break;
                if (MultiPlayerManager.instance.Ranking4 == "1")
                {
                    Rank_Text.text = "x" + MultiPlayerManager.instance.P1Dot.ToString();
                }
                else if (MultiPlayerManager.instance.Ranking4 == "2")
                {
                    Rank_Text.text = "x" + MultiPlayerManager.instance.P2Dot.ToString();
                }
                else if (MultiPlayerManager.instance.Ranking4 == "3")
                {
                    Rank_Text.text = "x" + MultiPlayerManager.instance.P3Dot.ToString();
                }
                else if (MultiPlayerManager.instance.Ranking4 == "4")
                {
                    Rank_Text.text = "x" + MultiPlayerManager.instance.P4Dot.ToString();
                }
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test3 : MonoBehaviour
{
    enum RankText
    {
        P1Text,
        P2Text,
        P3Text,
        P4Text
    }
    [SerializeField]
    RankText rankText;

    private Text Rank_Text;
    // Start is called before the first frame update
    void Start()
    {
        Rank_Text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        SetRankingText();
    }

    void SetRankingText()
    {
        //   Rank_Text.text = 
        //   "1st= " + MultiPlayerManager.instance.Ranking1 +"player\n"
        //   + "2nd= " + MultiPlayerManager.instance.Ranking2 + "player\n"
        //   + "3rd= " + MultiPlayerManager.instance.Ranking3 + "player\n"
        //   + "4th= " + MultiPlayerManager.instance.Ranking4 + "player\n";

        switch (rankText)
        {
            case RankText.P1Text:
                Rank_Text.text = "Player" + MultiPlayerManager.instance.Ranking1;
                break;
            case RankText.P2Text:
                Rank_Text.text = "Player" + MultiPlayerManager.instance.Ranking2;
                break;
            case RankText.P3Text:
                Rank_Text.text = "Player" + MultiPlayerManager.instance.Ranking3;
                break;
            case RankText.P4Text:
                Rank_Text.text = "Player" + MultiPlayerManager.instance.Ranking4;
                break;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DOTPONDursble : MonoBehaviour
{
    int Dursble;
    [SerializeField]RawImage[] DursbleUI;
    public void SetDursble(int i)
    {
        Dursble = i;
        for (int j = 0;j < i;j++)
        {
            DursbleUI[j].color = new Color(1,1,1,1);
        }
    }
    public void ResetDursble()
    {
        foreach (RawImage raw in DursbleUI)
        {
            raw.color = new Color(1, 1, 1, 0);
        }
    }

    public void DownDursbleUI()
    {
        Dursble--;
        DursbleUI[Dursble].color = new Color(1,1,1,0);
    }
}

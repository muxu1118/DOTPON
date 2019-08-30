using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectedUI : MonoBehaviour
{
    [SerializeField]RawImage[] rawImages;
    public void ChangeTextureUp(int i,Texture texture)
    {
        switch (i)
        {
            case 0:
                rawImages[0].GetComponentInChildren<RawImage>().texture = texture;
                rawImages[0].GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 1);
                break;
            case 1:
                rawImages[1].GetComponentInChildren<RawImage>().texture = texture;
                rawImages[1].GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 1);
                break;
            case 2:
                rawImages[2].GetComponentInChildren<RawImage>().texture = texture;
                rawImages[2].GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 1);
                break;
            default:
                rawImages[0].color = new Color(1, 1, 1, 0);
                break;
        }
    }
    public void ChangeTextureDown(int i)
    {
        switch (i)
        {
            case 0:
                rawImages[0].GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 0);
                break;
            case 1:
                rawImages[1].GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 0);
                break;
            case 2:
                rawImages[2].GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 0);
                break;
            default:
                rawImages[0].color = new Color(1, 1, 1, 0);
                break;
        }
    }

    public void BoxChange(int num)
    {
        for (int i = 0;i < 3;i++)
        {
            if(rawImages[i].color == new Color(1, 1, 0))
            rawImages[i].color = new Color(1,1,1);
        }
        rawImages[num].color = new Color(1, 1, 0);
    }
}

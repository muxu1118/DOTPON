using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectedUI : MonoBehaviour
{
    [SerializeField]RawImage[] ParentObjs;
    [SerializeField] RawImage[] ChildObjs;
    public void ChangeTextureUp(int i,Texture texture)
    {
        switch (i)
        {
            case 0:
                ChildObjs[0].GetComponentInChildren<RawImage>().texture = texture;
                ChildObjs[0].GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 1);
                break;
            case 1:
                ChildObjs[1].GetComponentInChildren<RawImage>().texture = texture;
                ChildObjs[1].GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 1);
                break;
            case 2:
                ChildObjs[2].GetComponentInChildren<RawImage>().texture = texture;
                ChildObjs[2].GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 1);
                break;
            default:
                ChildObjs[0].color = new Color(1, 1, 1, 0);
                break;
        }
    }
    public void ChangeTextureDown(int i)
    {
        ChildObjs[i].GetComponentInChildren<RawImage>().texture = null;
        switch (i)
        {
            case 0:
                ChildObjs[0].GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 0);
                break;
            case 1:
                ChildObjs[1].GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 0);
                break;
            case 2:
                ChildObjs[2].GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 0);
                break;
            default:
                ChildObjs[0].color = new Color(1, 1, 1, 0);
                break;
        }
    }

    public void BoxChange(int num)
    {
        for (int i = 0;i < 3;i++)
        {
            ParentObjs[i].color = new Color(1,1,1);
        }
        ParentObjs[num].color = new Color(1, 1, 0);
    }
}

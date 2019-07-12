using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectedUI : MonoBehaviour
{
    [SerializeField]RawImage[] rawImages;
    public void ChangeTexture(int i,Texture texture)
    {
        switch (i)
        {
            case 1:
                rawImages[0].texture = texture;
                rawImages[0].color = new Color(1, 1, 1, 1);
                rawImages[1].color = new Color(1, 1, 1, 0);
                break;
            case 2:
                rawImages[1].texture = texture;
                rawImages[1].color = new Color(1, 1, 1, 1);
                rawImages[2].color = new Color(1, 1, 1, 0);
                break;
            case 3:
                rawImages[2].texture = texture;
                rawImages[2].color = new Color(1, 1, 1, 1);
                break;
            default:
                rawImages[0].color = new Color(1, 1, 1, 0);
                break;
        }
    }
}

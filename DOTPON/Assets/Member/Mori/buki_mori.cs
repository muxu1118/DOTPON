using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buki_mori : MonoBehaviour
{
    [SerializeField]GameObject[] joicon;
    

    // Start is called before the first frame update
    void Start()
    {
        //
        switch(MultiPlayerManager.instance.totalPlayer)
        {   
            case 1://シングルプレイ
                RectTransform rect = joicon[0].GetComponent<RectTransform>();
                rect.localPosition = new Vector3(0,30,0);
                break;
                
            case 2://二人プレイ
                RectTransform rect1 = joicon[0].GetComponent<RectTransform>();
                rect1.localPosition = new Vector3(-240, 30, 0);
                RectTransform rect2 = joicon[1].GetComponent<RectTransform>();
                rect2.localPosition = new Vector3(240, 30, 0);
                break;
                
            case 3://3人プレイ
                RectTransform rect3 = joicon[0].GetComponent<RectTransform>();
                rect3.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                rect3.localPosition = new Vector3(-220, 160, 0);
                RectTransform rect4 = joicon[1].GetComponent<RectTransform>();
                rect4.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                rect4.localPosition = new Vector3(220, 160, 0);
                RectTransform rect5 = joicon[2].GetComponent<RectTransform>();
                rect5.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                rect5.localPosition = new Vector3(-220, -109, 0);
                break;
                
            case 4://4人プレイ
                RectTransform rect6 = joicon[0].GetComponent<RectTransform>();
                rect6.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                rect6.localPosition = new Vector3(-245, 160, 0);
                RectTransform rect7 = joicon[1].GetComponent<RectTransform>();
                rect7.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                rect7.localPosition = new Vector3(245, 160, 0);
                RectTransform rect8 = joicon[2].GetComponent<RectTransform>();
                rect8.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                rect8.localPosition = new Vector3(-245, -109, 0);
                RectTransform rect9 = joicon[3].GetComponent<RectTransform>();
                rect9.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                rect9.localPosition = new Vector3(245, -109, 0);
                break;
        }
    }
    
}

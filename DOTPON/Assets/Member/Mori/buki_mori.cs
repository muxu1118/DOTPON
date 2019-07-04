using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buki_mori : MonoBehaviour
{
    [SerializeField]GameObject[] joicon;
    

    // Start is called before the first frame update
    void Start()
    {
        float x = Screen.width;
        float y = Screen.height;
        float range = (x + y) / 1000;
        //
        switch(MultiPlayerManager.instance.totalPlayer)
        {   
            case 1://シングルプレイ
                RectTransform rect = joicon[0].GetComponent<RectTransform>();
                //スクリーンのサイズを取って、相対的な位置に移動させる
                //height半分割の上1/3の位置
                rect.localScale = new Vector3(transform.localScale.x * range,transform.localScale.y * range,1);
                rect.localPosition = new Vector3(0,y / 2 * 1 / 3,0);
                break;
                
            case 2://二人プレイ
                RectTransform rect1 = joicon[0].GetComponent<RectTransform>();
                //widthを2分割したそれぞれの真ん中
                rect1.localScale = new Vector3(transform.localScale.x * range,transform.localScale.y * range,1);
                rect1.localPosition = new Vector3(-x / 2 / 2, y / 2 * 1 / 4, 0);
                RectTransform rect2 = joicon[1].GetComponent<RectTransform>();
                rect2.localScale = new Vector3(transform.localScale.x * range, transform.localScale.y * range, 1);
                rect2.localPosition = new Vector3(x /2 / 2, y / 2 * 1 / 4, 0);
                break;
                
            case 3://3人プレイ
                RectTransform rect3 = joicon[0].GetComponent<RectTransform>();
                rect3.localScale = new Vector3(transform.localScale.x * range/2, transform.localScale.y * range/2, 1);
                rect3.localPosition = new Vector3(-x / 2 / 2, y / 2 * 2 / 3, 0);
                RectTransform rect4 = joicon[1].GetComponent<RectTransform>();
                rect4.localScale = new Vector3(transform.localScale.x * range / 2, transform.localScale.y * range / 2, 1);
                rect4.localPosition = new Vector3(x / 2 / 2, y / 2 * 2 / 3, 0);
                RectTransform rect5 = joicon[2].GetComponent<RectTransform>();
                rect5.localScale = new Vector3(transform.localScale.x * range / 2, transform.localScale.y * range / 2, 1);
                rect5.localPosition = new Vector3(-x / 2 / 2, -y / 2 * 1 / 3, 0);
                break;
                
            case 4://4人プレイ
                RectTransform rect6 = joicon[0].GetComponent<RectTransform>();
                rect6.localScale = new Vector3(transform.localScale.x * range / 2, transform.localScale.y * range / 42, 1);
                rect6.localPosition = new Vector3(-x / 2 / 2, y / 2 * 2 / 3, 0);
                RectTransform rect7 = joicon[1].GetComponent<RectTransform>();
                rect7.localScale = new Vector3(transform.localScale.x * range / 2, transform.localScale.y * range / 2, 1);
                rect7.localPosition = new Vector3(x / 2 / 2, y / 2 * 2 / 3, 0);
                RectTransform rect8 = joicon[2].GetComponent<RectTransform>();
                rect8.localScale = new Vector3(transform.localScale.x * range / 2, transform.localScale.y * range / 2, 1);
                rect8.localPosition = new Vector3(-x / 2 / 2, -y / 2 * 1 / 3, 0);
                RectTransform rect9 = joicon[3].GetComponent<RectTransform>();
                rect9.localScale = new Vector3(transform.localScale.x * range / 2, transform.localScale.y * range / 2, 1);
                rect9.localPosition = new Vector3(x / 2 / 2, -y / 2 * 1 / 3, 0);
                break;
        }
    }
    
}

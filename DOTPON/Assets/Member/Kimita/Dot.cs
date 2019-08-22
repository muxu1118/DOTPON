using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    private float lostTime = 10.0f;
    public enum DotColor
    {
        Red = 0,
        Blue,
        Green,
        Yellow,
        White
    }
    public DotColor ownColor;
    public float LostTime
    {
        get { return LostTime; }
        set { LostTime = value; }
    }

   

    private void Start()
    {
        StartCoroutine(LostDot());
       
    }

    IEnumerator LostDot()
    {
        yield return new WaitForSeconds(lostTime);
     
        Destroy(gameObject);
    }

    /// <summary>
    /// 当たった時にドットを取得する
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            // 
        }

    }

    // プレイヤーに当たったどっとを破壊する
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// DotのMaterialを変える
    /// </summary>
    public void MaterialChange(int num,GameObject obj)
    {
        ownColor = (DotColor)num;
        // 1赤2青3緑4黄
        switch (num)
        {
            case 0:
                obj.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 1:
                obj.GetComponent<Renderer>().material.color = Color.blue ;
                break;
            case 2:
                obj.GetComponent<Renderer>().material.color = Color.green;
                break;
            case 3:
                obj.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            default:
                obj.GetComponent<Renderer>().material.color = Color.white;
                break;

        }
        

    }
}

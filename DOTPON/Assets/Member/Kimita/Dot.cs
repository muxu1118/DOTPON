using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    private float lostTime = 10.0f;
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
}

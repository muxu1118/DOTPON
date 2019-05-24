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

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 当たった時にドットを取得する
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //当たったプレイヤーからスクリプトを取得しドットを送信
            //Destroy(gameaObject);
        }

    }
}

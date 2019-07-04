using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    float lostTime = 15f;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void Start()
    {
        StartCoroutine(LostStar());

    }
    IEnumerator LostStar()
    {
        yield return new WaitForSeconds(lostTime);

        Destroy(gameObject);
    }

    // プレイヤーに当たったら破壊
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}

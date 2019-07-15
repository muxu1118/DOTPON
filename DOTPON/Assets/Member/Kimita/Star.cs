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
    public void DestroyObject(Transform trans)
    {
        this.gameObject.transform.position = new Vector3(trans.position.x,trans.position.y + 2,trans.position.z);
        StartCoroutine(PopUpStar());
    }
    IEnumerator PopUpStar()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 1.5f, 0);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}

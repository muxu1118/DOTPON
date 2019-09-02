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
        StartCoroutine(PopUpStar(trans));
    }
    IEnumerator PopUpStar(Transform trans)
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 1.5f, 0);
        for (int i = 0;i < 30;i++)
        {
            this.transform.position = new Vector3(trans.position.x,this.transform.position.y,trans.position.z);
            yield return null;
        }
        Destroy(gameObject);
    }
}

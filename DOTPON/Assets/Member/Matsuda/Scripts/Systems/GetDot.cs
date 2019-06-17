using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDot : MonoBehaviour
{
    Vector3 targetObj;
    // Start is called before the first frame update
    void Start()
    {
        targetObj = GameObject.Find("P1DotText").transform.position;
        StartCoroutine(MoveDot());
    }

    IEnumerator MoveDot()
    {
        float rnd = Random.Range(0.1f, 1f);
        Debug.Log(rnd);
        int i = 0;
        while (i < 120)
        {
            i++;
            Vector3 center = (this.gameObject.transform.position + targetObj) * rnd;
            center -= new Vector3(0, 1, 0);
            Vector3 startPos = this.gameObject.transform.position - center;
            Vector3 targetPos = targetObj - center;
            transform.position =  Vector3.Slerp(startPos, targetPos, Time.deltaTime * 2f);
            transform.position += center;
            yield return null;
        }
        Destroy(this.gameObject);
    }
}

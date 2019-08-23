using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test4 : MonoBehaviour
{
    [SerializeField]GameObject cmr;
    [SerializeField] GameObject[] tagertObj;
    Vector3 vec;
    bool tri;
    [SerializeField]GameObject buki;
    // Start is called before the first frame update
    void Start()
    {
        for (int i= 0;i< tagertObj.Length;i++)
        {
            tagertObj[i].transform.LookAt(Vector3.zero);
        }
        //vec = tagertObj[0].transform.forward;
        //StartCoroutine(Move());
        //StartCoroutine(Attack());
        StartCoroutine(Create());
        StartCoroutine(Move());
        vec = tagertObj[0].transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //cmr.transform.localPosition += vec * Time.deltaTime * 2;
        //vec = tagertObj[0].transform.forward;
        //if (!tri) return;
        tagertObj[0].transform.localPosition += vec * Time.deltaTime * 3;
        //tagertObj[1].GetComponent<Animator>().SetFloat("Speed", 0.8f);
        //for (int i = 0; i < tagertObj.Length; i++)
        //{
        //    tagertObj[i].GetComponent<Animator>().SetFloat("Speed", 0.8f);
        //}

    }
    IEnumerator Move()
    {
        tagertObj[0].GetComponent<Animator>().SetFloat("Speed", 0.8f);
        yield return new WaitForSeconds(1f);
        for (int i = 0;i < 15;i++)
        {
            vec = -tagertObj[0].transform.forward;
            tagertObj[0].GetComponent<Animator>().SetFloat("Speed", 0.2f);
            yield return null;
        }
        tagertObj[0].GetComponent<Animator>().SetTrigger("PunchAttack");
        vec = tagertObj[0].transform.forward;
        yield return new WaitForSeconds(1f);
        vec = -tagertObj[0].transform.forward;
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1.8f);
        for (int i = 0;i < 20;i++)
        {
            tagertObj[1].transform.Rotate(new Vector3(0,-0.8f,0));
            yield return null;
        }
        tri = true;
        tagertObj[1].GetComponent<Animator>().SetTrigger("SwordAttack");
        yield return new WaitForSeconds(0.7f);
        tagertObj[0].SetActive(false);
        DotManager.instance.EnemyDeadDotPop(4,tagertObj[0].transform.position,4);
        yield return new WaitForSeconds(0.8f);
        bool gyaku = false;
        //while(true)
        //{
        //    if (gyaku)
        //    {
        //        for (int i = 0; i < 100; i++)
        //        {
        //            yield return null;
        //        }
        //        for (int i = 0;i < 120;i++)
        //        {
        //            tagertObj[1].transform.Rotate(new Vector3(0, -1.5f, 0));
        //            yield return null;
        //        }
        //        gyaku = false;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < 120; i++)
        //        {
        //            tagertObj[1].transform.Rotate(new Vector3(0, -1.5f, 0));
        //            yield return null;
        //        }
        //        gyaku = true;
        //    }
        //}
    }

    IEnumerator Create()
    {
        tagertObj[1].GetComponent<Animator>().SetFloat("Speed", 0.8f);
        yield return new WaitForSeconds(1f);
        tagertObj[1].GetComponent<Animator>().SetTrigger("PunchAttack");
        tagertObj[1].GetComponent<MoveSample>().speed = 0;
        yield return new WaitForSeconds(1.5f);
        tagertObj[1].GetComponent<Animator>().SetFloat("Speed", 0.1f);
        tagertObj[1].GetComponent<MoveSample>().speed = -3;
        tagertObj[1].GetComponent<Animator>().SetTrigger("Hit");
        DotManager.instance.EnemyDeadDotPop(4, tagertObj[1].transform.position, 0);
        //buki.SetActive(true);
        yield return null;
    }
}

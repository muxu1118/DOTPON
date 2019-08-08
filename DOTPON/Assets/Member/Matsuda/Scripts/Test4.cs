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
        //vec = tagertObj[0].transform.forward;
        //StartCoroutine(Move());
        //StartCoroutine(Attack());
        StartCoroutine(Create());
    }

    // Update is called once per frame
    void Update()
    {
        //cmr.transform.localPosition += vec * Time.deltaTime * 2;
        //vec = tagertObj[0].transform.forward;
        //if (!tri) return;
        //tagertObj[1].transform.localPosition += tagertObj[1].transform.forward * Time.deltaTime * 5;
        //tagertObj[1].GetComponent<Animator>().SetFloat("Speed", 0.8f);


    }
    IEnumerator Move()
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0;i < 60;i++)
        {
            tagertObj[1].transform.localPosition += Vector3.right * Time.deltaTime * 3;
            yield return null;
        }
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
        DotManager.instance.EnemyDeadDotPop(4,tagertObj[0].transform.position);
        yield return new WaitForSeconds(0.8f);
        bool gyaku = false;
        while(true)
        {
            if (gyaku)
            {
                for (int i = 0; i < 100; i++)
                {
                    yield return null;
                }
                for (int i = 0;i < 120;i++)
                {
                    tagertObj[1].transform.Rotate(new Vector3(0, -1.5f, 0));
                    yield return null;
                }
                gyaku = false;
            }
            else
            {
                for (int i = 0; i < 120; i++)
                {
                    tagertObj[1].transform.Rotate(new Vector3(0, -1.5f, 0));
                    yield return null;
                }
                gyaku = true;
            }
        }
    }

    IEnumerator Create()
    {
        yield return new WaitForSeconds(1f);
        tagertObj[1].GetComponent<Animator>().SetTrigger("Create");
        yield return new WaitForSeconds(0.5f);
        buki.SetActive(true);
        yield return null;
    }
}

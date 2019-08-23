using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudCreateScript : MonoBehaviour
{
    [SerializeField]
    GameObject c1Prefab;

    [SerializeField]
    GameObject c2Prefab;

    [SerializeField]
    GameObject c3Prefab;

    [SerializeField]
    int c1 = 3;

    [SerializeField]
    int c2 = 4;

    [SerializeField]
    int c3 = 4;

    [SerializeField]
    int hight = 30;

    // Start is called before the first frame update
    void Start()
    {
        //cloud1の生成
        for(int i=0;i<c1;i++)
        {
            GameObject cloud1 = Instantiate(c1Prefab) as GameObject;

            cloud1.transform.position = new Vector3(Random.Range(-60, 60), hight, Random.Range(-60, 60));
        }

        for (int i = 0; i < c2; i++)
        {
            GameObject cloud2 = Instantiate(c2Prefab) as GameObject;

            cloud2.transform.position = new Vector3(Random.Range(-60, 60), hight, Random.Range(-60, 60));
        }

        for (int i = 0; i < c3; i++)
        {
            GameObject cloud3 = Instantiate(c3Prefab) as GameObject;

            cloud3.transform.position = new Vector3(Random.Range(-60, 60), hight, Random.Range(-60, 60));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

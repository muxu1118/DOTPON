using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownController : MonoBehaviour
{
    [SerializeField] GameObject[] obj;
    [SerializeField] Vector3[] positions;
    [SerializeField] GameObject dragonObj;
    float time;
    bool isDragonSpown = false;
    public int NowSpown;
    [SerializeField] float spownDelay;
    [SerializeField] int MaxSpown;
    [SerializeField] Timer timer;
    int MaxTime;
    // Start is called before the first frame update
    void Start()
    {
        List<int> createdPos = new List<int>() {-1 };
        for (int i = 0; i < 4; i++)
        {
            createdPos.Add(CreateEnemy(createdPos));
        }
        MaxTime = (int)timer.timeCount;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //制限時間/2<=timeだったら
        if (MaxTime / 2 <= time && !isDragonSpown)
        {
            Debug.Log("ドラゴンスポーン");
            isDragonSpown = true;
            return;
            Instantiate(dragonObj, positions[Random.Range(0, 4)], Quaternion.identity);
        }
        List<int> createdPos = new List<int>() { -1 };
        if (time /  spownDelay>= 1)
        {
            for (int i = 0;i < 4;i++)
            {
                if(NowSpown < MaxSpown)
                {
                    createdPos.Add(CreateEnemy(createdPos));
                }
            }
            time = 0;
        }
    }
    int CreateEnemy(List<int> createdPos)
    {
        bool isCreated = true;
        int posNum = 0;
        while (isCreated)
        {
            //同じ場所からスポーンしないようにする処理
            posNum = Random.Range(0,positions.Length);
            if (createdPos[0] == -1)
            {
                createdPos.RemoveAt(0);
                break;
            }
            for (int i = 0;i < createdPos.Count; i++)
            {
                if (posNum != createdPos[i])
                {
                    isCreated = false;
                }
            }
        }
        //ランダムでどれかのEnemyがスポーンする
        switch (Random.Range(0,2))
        {
            case 0:
                GameObject parentObject = new GameObject("GoburinFlock");
                parentObject.tag = "enemy";
                Vector3 spownPos = parentObject.transform.position = positions[posNum];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        GameObject child = Instantiate(obj[0], new Vector3(spownPos.x + i, 1, spownPos.z + j), Quaternion.identity);
                        child.name = child.name.Replace("(Clone)", "");
                        child.transform.parent = parentObject.transform;

                    }
                }
                parentObject.AddComponent<GoburinFlock>();
                break;
            case 1:
                GameObject slime = Instantiate(obj[1], positions[posNum], Quaternion.identity);
                slime.name = slime.name.Replace("(Clone)","");
                break;
            case 2:
                GameObject golem = Instantiate(obj[2], positions[posNum], Quaternion.identity);
                golem.name = golem.name.Replace("(Clone)", "");
                break;
            default:
                break;
        }
        NowSpown++;
        return posNum;
    }
}

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
    [SerializeField]int MaxTime;
    [SerializeField] int oneTimeSpownNum;
    [SerializeField] GameObject effect;

    [SerializeField] Vector3[] dragonPos;
    // Start is called before the first frame update
    void Start()
    {
        List<int> createdPos = new List<int>() {-1 };
        for (int i = 0; i < oneTimeSpownNum; i++)
        {
            createdPos.Add(PosSet(createdPos));
        }
        MaxTime = (int)timer.timeCount;
        spownDelay -= 3;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //制限時間/2<=timeだったら
        if (MaxTime / 2 <= time && !isDragonSpown)
        {
            int rng = Random.Range(0, 5);
            Debug.Log("ドラゴンスポーン");
            isDragonSpown = true;
            var obj = Instantiate(effect,positions[rng],Quaternion.identity);
            StartCoroutine(EndEffect(obj));
            StartCoroutine(CreateDragon(rng));
        }
        List<int> createdPos = new List<int>() { -1 };
        if (time /  spownDelay >= 1)
        {
            for (int i = 0;i < oneTimeSpownNum;i++)
            {
                if(NowSpown < MaxSpown)
                {
                    createdPos.Add(PosSet(createdPos));
                }
            }
            spownDelay += spownDelay - 3;
        }
    }

    int PosSet(List<int> createdPos)
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
                    Collider[] colliders = Physics.OverlapSphere(positions[posNum], 1);
                    bool trigger = false;
                    for (int j = 0;j < colliders.Length;j++)
                    {
                        if(colliders[j].gameObject.tag == "enemy")
                        {
                            trigger = true;
                            break;
                        }
                    }
                    if (!trigger)
                    {
                        isCreated = false;
                    }
                }
            }
        }
        //ランダムでどれかのEnemyがスポーンする
        var obj = Instantiate(effect, positions[posNum], Quaternion.identity);
        StartCoroutine(EndEffect(obj));
        StartCoroutine(CreateEnemy(posNum));
        return posNum;
    }

    IEnumerator CreateEnemy(int posNum)
    {
        yield return new WaitForSeconds(3);
        switch (Random.Range(0, 2))
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
                        NowSpown++;

                    }
                }
                parentObject.AddComponent<GoburinFlock>();
                break;
            case 1:
                GameObject slime = Instantiate(obj[1], positions[posNum], Quaternion.identity);
                slime.name = slime.name.Replace("(Clone)", "");
                NowSpown++;
                break;
            case 2:
                GameObject golem = Instantiate(obj[2], positions[posNum], Quaternion.identity);
                golem.name = golem.name.Replace("(Clone)", "");
                NowSpown++;
                break;
            default:
                break;
        }
    }

    IEnumerator CreateDragon(int num)
    {
        yield return new WaitForSeconds(3);
        var obj = Instantiate(dragonObj, dragonPos[num], Quaternion.identity);
        obj.transform.LookAt(Vector3.zero);
        obj.name = "Doragon";
    }
    IEnumerator EndEffect(GameObject obj)
    {
        var particl = obj.GetComponent<ParticleSystem>();
        yield return new WaitForSeconds(3f);
        Destroy(obj);
    }
}

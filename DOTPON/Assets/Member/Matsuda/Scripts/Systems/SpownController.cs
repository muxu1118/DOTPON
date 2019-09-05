using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            ShowListContentsInTheDebugLog(createdPos);
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
            int rng = Random.Range(0, 4);
            Debug.Log("ドラゴンスポーン");
            isDragonSpown = true;
            var obj = Instantiate(effect,dragonPos[rng],Quaternion.identity);
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
            posNum = Random.Range(0, positions.Length);
            //同じ場所からスポーンしないようにする処理
            if (createdPos[0] == -1)
            {
                createdPos.RemoveAt(0);
                break;
            }
            //回数分回して片方が違くても、もう片方でループ抜ける処理に入っちゃってる
            //一つでもある場合のみループが続くようにするべき
            for (int i = 0;i < createdPos.Count; i++)
            {
                Debug.Log(posNum + " " + createdPos[i]);
                if (posNum != createdPos[i])
                {
                    Collider[] colliders = Physics.OverlapSphere(positions[posNum], 1);
                    bool trigger = false;
                    for (int j = 0;j < colliders.Length;j++)
                    {
                        if(colliders[j].gameObject.tag == "enemy")
                        {
                            Debug.Log("out");
                            trigger = true;
                            break;
                        }
                    }
                    if (!trigger)
                    {
                        isCreated = false;
                    }
                }else
                {
                    Debug.Log("2out");
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
        Debug.Log(positions[posNum]);
        yield return new WaitForSeconds(3);
        switch (Random.Range(0, 3))
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
        var particl = obj.GetComponentsInChildren<ParticleSystem>();
        yield return new WaitWhile(() => particl[1].IsAlive(true));
        Destroy(obj);
    }

    //でバック用
    public void ShowListContentsInTheDebugLog<T>(List<T> list)
    {
        string log = "";

        foreach (var content in list.Select((val, idx) => new { val, idx }))
        {
            if (content.idx == list.Count - 1)
                log += content.val.ToString();
            else
                log += content.val.ToString() + ", ";
        }

        Debug.Log(log);
    }
}

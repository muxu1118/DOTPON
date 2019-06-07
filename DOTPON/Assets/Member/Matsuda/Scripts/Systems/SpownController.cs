using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownController : MonoBehaviour
{
    [SerializeField] GameObject[] obj;
    [SerializeField] Vector3[] positions;
    float time;
    int num;

    [SerializeField] float spownDelay;
    // Start is called before the first frame update
    void Start()
    {
        List<int> createdPos = new List<int>() {-1 };
        for (int i = 0; i < 4; i++)
        {
            createdPos.Add(CreateEnemy(createdPos));
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time /  spownDelay>= 1)
        {
            List<int> createdPos = new List<int>() {-1};
            for (int i = 0;i < 4;i++)
            {
                createdPos.Add(CreateEnemy(createdPos));
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
        switch (Random.Range(0,3))
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
                        child.name = child.name + num;
                        child.transform.parent = parentObject.transform;

                    }
                }
                parentObject.AddComponent<GoburinFlock>();
                break;
            case 1:
                GameObject slime = Instantiate(obj[1], positions[posNum], Quaternion.identity);
                slime.name = slime.name + num;
                break;
            case 2:
                GameObject golem = Instantiate(obj[2], positions[posNum], Quaternion.identity);
                golem.name = golem.name + num;
                break;
            default:
                break;
        }
        num++;
        return posNum;
    }
}

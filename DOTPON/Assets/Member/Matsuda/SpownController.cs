using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownController : MonoBehaviour
{
    [SerializeField] GameObject[] obj;
    [SerializeField] Vector3[] positions;
    float time;
    int num;
    // Start is called before the first frame update
    void Start()
    {
        //_object.transform.position = positions[Random.Range(0, 4)];
        //for (int i = 0; i < 2; i++)
        //{
        //    for (int j = 0; j < 2; j++)
        //    {
        //        GameObject chald = Instantiate(obj[0], new Vector3(obj[0].transform.localPosition.x + i, 1, obj[0].transform.localPosition.z + j), Quaternion.identity);
        //        chald.name = chald.name + (i + j);
        //        chald.transform.parent = _object.transform;

        //    }
        //}
        //_object.AddComponent<GoburinFlock>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time / 10 >= 1)
        {
            switch (Random.Range(0,3))
            {
                case 0:
                    GameObject parentObject = new GameObject("GoburinFlock");
                    parentObject.tag = "enemy";
                    parentObject.transform.position = positions[Random.Range(0, 4)];
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            GameObject child = Instantiate(obj[0], new Vector3(obj[0].transform.localPosition.x + i, 1, obj[0].transform.localPosition.z + j), Quaternion.identity);
                            child.name = child.name + num;
                            child.transform.parent = parentObject.transform;

                        }
                    }
                    parentObject.AddComponent<GoburinFlock>();
                    break;
                case 1:
                    GameObject slime = Instantiate(obj[1], positions[Random.Range(0,4)], Quaternion.identity);
                    slime.name = slime.name + num;
                    break;
                case 2:
                    GameObject golem = Instantiate(obj[2], positions[Random.Range(0, 4)], Quaternion.identity);
                    golem.name = golem.name + num;
                    break;
                default:
                    break;
            }
            num++;
            time = 0;
        }
    }
}

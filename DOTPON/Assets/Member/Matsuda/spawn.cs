using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField] GameObject obj;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        GameObject _object = new GameObject("GoburinFlock");
        _object.tag = "enemy";
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                GameObject chald = Instantiate(obj, new Vector3(i, 1, j), Quaternion.identity);
                chald.name = chald.name + (i + j);
                chald.transform.parent = _object.transform;

            }
        }
        _object.AddComponent<GoburinFlock>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time / 10 >= 1)
        {
            GameObject _object = new GameObject("GoburinFlock");
            _object.tag = "enemy";
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    GameObject chald = Instantiate(obj, new Vector3(i, 1, j), Quaternion.identity);
                    chald.name = chald.name + (i + j);
                    chald.transform.parent = _object.transform;

                }
            }
            _object.AddComponent<GoburinFlock>();
            time = 0;
        }
    }
}

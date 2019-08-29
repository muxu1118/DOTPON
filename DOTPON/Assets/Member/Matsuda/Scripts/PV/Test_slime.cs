using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_slime : MonoBehaviour
{
    [SerializeField] GameObject ply;
    [SerializeField] GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        ply.transform.LookAt(Vector3.zero);
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator Move()
    {
        yield return new WaitForSeconds(2);
        ply.GetComponent<MoveSample>().speed = 0;
        //ply.transform.LookAt(enemy.transform);
        yield return new WaitForSeconds(0.5f);
        ply.GetComponent<MoveSample>().vec = ply.transform.right;
        ply.GetComponent<MoveSample>().speed = 3;
        yield return new WaitForSeconds(0.5f);
        ply.GetComponent<MoveSample>().vec = ply.transform.forward;
        ply.GetComponent<MoveSample>().speed = 0;
        yield return null;
    }
}

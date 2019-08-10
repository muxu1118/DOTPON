using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test5 : MonoBehaviour
{
    [SerializeField]Material sky;

    [SerializeField]Player[] player;
    [SerializeField] GameObject cmr;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(color());
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator color()
    {
        
        for (int i = 0;i < 300;i++)
        {
            player[0].GetComponent<Animator>().SetFloat("Speed", 0.5f);
            player[0].transform.localPosition += player[0].transform.forward * Time.deltaTime * 1;
            yield return null;
        }
        player[0].GetComponent<Animator>().SetFloat("Speed", 0.1f);

        for (int i = 0; i < 60; i++)
        {
            cmr.transform.eulerAngles += new Vector3(-20 * Time.deltaTime, 180 * Time.deltaTime, 0);
            cmr.transform.localPosition += new Vector3(0,0.5f * Time.deltaTime,0);
            //cmr.transform.localPosition = Vector3.MoveTowards(cmr.transform.position,
            //                                         new Vector3(player[0].transform.position.x, 1.5f, player[0].transform.position.z),
            //                                                     1 * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(2);
        while (true)
        {
            for (int j = 0; j < 4; j++)
            {
                player[j].GetComponent<Animator>().SetFloat("Speed", 0.8f);
                player[j].GetComponent<Animator>().SetTrigger("SwordAttack");
                player[j].transform.localPosition += player[j].transform.forward * Time.deltaTime * 4.5f;
            }
            yield return null;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject cmr;
    [SerializeField] GameObject drgn;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Attackw());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Attackw()
    {
        for (int i = 0;i < 100;i++)
        {
            player.transform.position += player.transform.forward * Time.deltaTime * 3;
            player.GetComponent<Animator>().SetFloat("Speed", 0.5f);
            if (i >= 10 && i <= 70)
            {
                cmr.transform.position += new Vector3(0, 0, -1.4f) * Time.deltaTime;
                cmr.transform.position += cmr.transform.forward * Time.deltaTime * 1.2f;
            }
            else
            {
                cmr.transform.position += new Vector3(0, 0, -1.4f) * Time.deltaTime;
            }
            if (i >= 40)
            {
                drgn.GetComponent<Animator>().SetTrigger("Attack");
                if (i >= 50)
                {
                    player.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 2;
                }
            }
            yield return null;
        }
        player.GetComponent<Animator>().SetTrigger("jump");
        yield return new WaitForSeconds(0.4f);
        for (int i = 0;i < 20;i++)
        {
            yield return null;
        }
        
    }
}

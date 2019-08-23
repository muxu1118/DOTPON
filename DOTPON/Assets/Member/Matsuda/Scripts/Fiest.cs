using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiest : MonoBehaviour
{
    [SerializeField] GameObject[] player;
    [SerializeField] GameObject cmr;
    [SerializeField] GameObject[] light;
    [SerializeField] Material mat;
    [SerializeField] Vector3[] pos;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0;i< 4;i++)
        {
            player[i].transform.localPosition = pos[i];
        }
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Move()
    {
        yield return new WaitForSeconds(1f);
        light[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        player[0].GetComponent<Animator>().SetTrigger("Walk");
        for (int i = 0; i < 100; i++)
        {

            player[0].transform.localPosition += player[0].transform.forward * 3 * Time.deltaTime;
            //player[0].GetComponent<Animator>().SetFloat("Speed", 0.4f);
            yield return null;
        }
        player[0].GetComponent<Animator>().SetTrigger("Walk_re");
        //player[0].GetComponent<Animator>().SetFloat("Speed", 0f);
        //player[0].GetComponent<Animator>().SetTrigger("PV1");
        //yield return new WaitForSeconds(1.5f);
        //player[0].GetComponent<Animator>().SetTrigger("PV1_re");
        //for (int i = 0; i < 30; i++)
        //{
        //    player[0].transform.localPosition += player[0].transform.forward * 3 * Time.deltaTime;
        //    player[0].GetComponent<Animator>().SetFloat("Speed", 0.4f);
        //    yield return null;
        //}
        //player[0].GetComponent<Animator>().SetFloat("Speed", 0f);
        //player[0].GetComponent<Animator>().SetTrigger("PV2");
        //yield return new WaitForSeconds(1.5f);
        //player[0].GetComponent<Animator>().SetTrigger("PV2_re");
        //for (int i = 0; i < 30; i++)
        //{
        //    player[0].transform.localPosition += player[0].transform.forward * 3 * Time.deltaTime;
        //    player[0].GetComponent<Animator>().SetFloat("Speed", 0.4f);
        //    yield return null;
        //}
        //player[0].GetComponent<Animator>().SetFloat("Speed", 0f);
        //player[0].GetComponent<Animator>().SetTrigger("PV3");
        //yield return new WaitForSeconds(1.5f);
        //player[0].GetComponent<Animator>().SetTrigger("PV3_re");
        //for (int i = 0; i < 30; i++)
        //{
        //    player[0].transform.localPosition += player[0].transform.forward * 3 * Time.deltaTime;
        //    player[0].GetComponent<Animator>().SetFloat("Speed", 0.4f);
        //    yield return null;
        //}

        //player[0].GetComponent<Animator>().SetFloat("Speed", 0f);
        light[0].SetActive(true);
        light[1].SetActive(false);
        //light[1].transform.localPosition += new Vector3(0,45,25);
        //light[1].GetComponent<Light>().intensity = 0.5f;
        //RenderSettings.skybox = mat;
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 60; i++)
        {
            cmr.transform.eulerAngles += new Vector3(0, 3, 0);
            //camera.transform.localPosition = Vector3.MoveTowards(camera.transform.position,
            //                                         new Vector3(player[j].transform.position.x * 2, player[j].transform.position.y + 0.5f, player[j].transform.position.z * 2),
            //                                                     1 * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 240; i++)
        {
            player[0].transform.localPosition += player[0].transform.forward * 1.2f * Time.deltaTime;
            player[1].transform.localPosition += player[1].transform.forward * 1.2f * Time.deltaTime;
            player[2].transform.localPosition += player[2].transform.forward * 1.2f * Time.deltaTime;
            player[3].transform.localPosition += player[3].transform.forward * 1.2f * Time.deltaTime;

            player[1].GetComponent<Animator>().SetTrigger("PV3");
            player[2].GetComponent<Animator>().SetTrigger("PV2");
            player[3].GetComponent<Animator>().SetTrigger("PV1");
            player[0].GetComponent<Animator>().SetTrigger("jump");
            if (i == 30)
            {
                player[2].GetComponent<Animator>().SetTrigger("PunchAttack");
                player[3].GetComponent<Animator>().SetTrigger("jump");
            }
            if(i >= 30 && i <= 50)
            {
                cmr.transform.localPosition += new Vector3(0, 0.08f, 0);
                cmr.transform.eulerAngles += new Vector3(0.8f, 0, 0);
            }
            yield return null;
        }
    }
}

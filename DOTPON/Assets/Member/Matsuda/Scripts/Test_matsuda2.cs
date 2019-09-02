using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_matsuda2 : MonoBehaviour
{
    [SerializeField]GameObject[] player;
    [SerializeField] GameObject[] buki;
    bool tri;
    bool tri2;
    [SerializeField]Vector3[] vec3;
    [SerializeField]GameObject camera;
    int playerLeng;
    int[] leng = new int[3];
    float time;
    Vector3 axisPos;
    // Start is called before the first frame update
    void Start()
    {
        playerLeng = 0;
        for (int i = 0;i < player.Length;i++)
        {
            SetUp(i);
        }
        camera.transform.position = player[playerLeng].transform.localPosition;
        camera.GetComponentInChildren<Camera>().transform.localPosition = new Vector3(0, player[playerLeng].transform.localPosition.y + 2, -3);
        camera.transform.eulerAngles = vec3[playerLeng] * -1;
        axisPos = player[playerLeng].transform.forward * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!tri) return;
        time += Time.deltaTime;
        for (int i = 0; i < player.Length;i++)
        {
            player[i].transform.localPosition += player[i].transform.forward * Time.deltaTime * 5;
            player[i].GetComponent<Animator>().SetFloat("Speed", 0.8f);
            if (i == 2)
            {
                camera.transform.localPosition += player[2].transform.forward * Time.deltaTime * 5;
            }
        }
    }

    private void SetUp(int i)
    {
        
        player[i].transform.LookAt(Vector3.zero);
        //player[i].GetComponent<Animator>().SetTrigger("KatanaAttack");
        StartCoroutine(Trigger(player[i]));
        leng[0] = 0; leng[1] = 0; leng[2] = 0;
    }

    IEnumerator Trigger(GameObject obj)
    {
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(1f);
        StartCoroutine(CameraMove());
        yield return new WaitForSeconds(8.5f);
        obj.GetComponent<Animator>().SetTrigger("SwordAttack");
    }
    private void Animation()
    {
        for (int i = 0;i< 3; i++)
        {
            player[i].GetComponent<Animator>().SetTrigger("Create");
            buki[i].SetActive(true);
        }
    }
    

    IEnumerator CameraMove()
    {
        for (int j = 0;j < 3;j++)
        {

            if (j == 2) { Animation(); }
            camera.transform.position = player[j].transform.localPosition;
            camera.GetComponentInChildren<Camera>().transform.localPosition = new Vector3(0, player[j].transform.localPosition.y + 2, -3);
            camera.transform.eulerAngles = vec3[j] * -1;
            axisPos = player[j].transform.forward * 2;
            
            yield return new WaitForSeconds(1);
            for (int i = 0; i < 60; i++)
            {
                camera.transform.eulerAngles += new Vector3(0.1f, 1, 0);
                //camera.transform.localPosition = Vector3.MoveTowards(camera.transform.position,
                //                                         new Vector3(player[j].transform.position.x * 2, player[j].transform.position.y + 0.5f, player[j].transform.position.z * 2),
                //                                                     1 * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(1);
        }
        tri = true;
    }
    
}

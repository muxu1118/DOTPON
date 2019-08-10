using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Matsuda : MonoBehaviour
{
    [SerializeField]GameObject[] player;
    [SerializeField] GameObject[] buki;
    bool tri;
    bool tri2;
    [SerializeField]Vector3[] vec3;
    [SerializeField]Camera camera;
    int playerLeng;
    [SerializeField] Vector3[] cameraVec;
    int[] leng = new int[3];
    float time;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0;i < player.Length;i++)
        {
            player[i].transform.LookAt(Vector3.zero);
            StartCoroutine(Animation(player[i]));
            //player[i].GetComponent<Animator>().SetTrigger("KatanaAttack");
            StartCoroutine(Trigger(player[i]));
            tri = true;
            tri2 = true;
                    leng[0] = -1; leng[1] = -2;leng[2] = 2;
            camera.transform.rotation = Quaternion.Euler(cameraVec[0]);
        }
        playerLeng = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (!tri) return;
        time += Time.deltaTime;
            player[playerLeng].transform.localPosition += player[playerLeng].transform.forward * Time.deltaTime * 5;
            player[playerLeng].GetComponent<Animator>().SetFloat("Speed",0.8f);
            if (tri2)
            {
                camera.transform.localPosition = new Vector3(player[playerLeng].transform.localPosition.x + leng[0], leng[2], player[playerLeng].transform.localPosition.z + leng[1]);
                camera.transform.localPosition += player[playerLeng].transform.forward * Time.deltaTime * 5;
            }
        if(time >= 2)
        {
            playerLeng++;
            switch (playerLeng)
            {
                case 1:
                    player[playerLeng + 1].SetActive(false);
                    leng[0] = -1; leng[1] = 1; leng[2] = 1;
                    camera.transform.rotation = Quaternion.Euler(cameraVec[1]);
                    break;
                case 2:
                    player[playerLeng].SetActive(true);
                    Destroy(player[playerLeng-1]);
                    leng[0] = 1; leng[1] = 1; leng[2] = 0;
                    camera.transform.rotation = Quaternion.Euler(cameraVec[2]);
                    break;
                case 0:
                    leng[0] = 0; leng[1] = -2; leng[2] = 1;
                    camera.transform.rotation = Quaternion.Euler(cameraVec[0]);
                    break;
            }
            time = 0;
        }
    }

    IEnumerator Trigger(GameObject obj)
    {
        buki[int.Parse(obj.name.Substring(6)) - 1].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(1f);
        //obj.GetComponent<Animator>().SetTrigger("SwordAttack");
        tri = true;
        tri2 = true;
    }
    IEnumerator Animation(GameObject player)
    {
        //player.GetComponent<Animator>().SetTrigger("Create");
        yield return new WaitForSeconds(0.5f);
    }
}

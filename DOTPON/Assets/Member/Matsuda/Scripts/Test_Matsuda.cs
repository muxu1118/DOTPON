using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Matsuda : MonoBehaviour
{
    [SerializeField]GameObject[] player;
    [SerializeField] GameObject[] buki;
    bool tri;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0;i < player.Length;i++)
        {
            player[i].transform.LookAt(Vector3.zero);
            player[i].GetComponent<Animator>().SetTrigger("Create");
            //player[i].GetComponent<Animator>().SetTrigger("KatanaAttack");
            StartCoroutine(Trigger(player[i]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!tri) return;
        for (int i = 0; i < player.Length;i++)
        {
            player[i].transform.localPosition += player[i].transform.forward * Time.deltaTime * 2;
        }
    }

    IEnumerator Trigger(GameObject obj)
    {
        yield return new WaitForSeconds(0.5f);
        buki[int.Parse(obj.name.Substring(6)) - 1].SetActive(true);
        yield return new WaitForSeconds(1f);
        obj.GetComponent<Animator>().SetTrigger("SwordAttack");
        tri = true;
    }

}

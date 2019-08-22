using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_axe : MonoBehaviour
{
    [SerializeField] Camera cmr;
    [SerializeField] GameObject obj;
    [SerializeField] GameObject obj2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cre());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Cre()
    {
        yield return new WaitForSeconds(1);
        obj.GetComponent<Animator>().SetTrigger("Create");
        yield return new WaitForSeconds(0.4f);
        obj2.SetActive(true);
    }
}

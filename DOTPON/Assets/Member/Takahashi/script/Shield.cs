using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Parametor parametor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "weapon")
        {
            //transform.root.gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine("shild");

        }
    }
    
    IEnumerable shild()
    {
        yield return new WaitForSeconds(0.1f);
        transform.root.gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        transform.root.gameObject.GetComponent<BoxCollider>().enabled = true;
    }    
}

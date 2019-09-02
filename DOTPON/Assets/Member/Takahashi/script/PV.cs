using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PV : MonoBehaviour
{
    Animator anim;    
 
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {            
            anim.SetTrigger("Hit");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("Down");
        }
    }
}

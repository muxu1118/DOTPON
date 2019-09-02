using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PV_Ax : MonoBehaviour
{
    Animator anim;

    bool pv1 = true;
    bool pv2 = true;
    bool pv3 = true;
    bool jump = true;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && jump == true)
        {
            anim.SetTrigger("jump");
            jump = false;
        }
        else if (Input.GetKeyDown(KeyCode.H) && jump == false)
        {
            anim.SetTrigger("jump_re");
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.A) && pv1 == true)
        {
            anim.SetTrigger("PV1");
            pv1 = false;
        }
        else if(Input.GetKeyDown(KeyCode.A) && pv1 == false)
        {
            anim.SetTrigger("PV1_re");
            pv1 = true;
        }

        if (Input.GetKeyDown(KeyCode.S) && pv2 == true)
        {
            anim.SetTrigger("PV2");
            pv2 = false;
        }
        else if (Input.GetKeyDown(KeyCode.S) && pv2 == false)
        {
            anim.SetTrigger("PV2_re");
            pv2 = true;
        }


        if (Input.GetKeyDown(KeyCode.D) && pv3 == true)
        {
            anim.SetTrigger("PV3");
            pv3 = false;
        }
        else if (Input.GetKeyDown(KeyCode.D) && pv3 == false)
        {
            anim.SetTrigger("PV3_re");
            pv3 = true;
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("Walk");
            
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            anim.SetTrigger("walk_re");
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniTest : MonoBehaviour
{
    Animator anim;
    
    enum attackMeans
    {
        ken,
        ax,
        bomb,
        shield,
        fist
    }

    void Start()
    {
        anim = GetComponent<Animator>();
 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {

            switch (tag)
            {
                case "ken":
                    anim.SetTrigger("Attack");
                    break;
                case "ax":
                    anim.SetTrigger("Attack2");
                    break;
            }            
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("Create");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("Damage");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            anim.SetTrigger("Run");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            anim.SetTrigger("Walk");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            anim.SetTrigger("modoru");
        }
    }
}

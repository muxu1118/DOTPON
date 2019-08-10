using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PV_Ax : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            anim.SetTrigger("AxAttack");
            Debug.Log("おーのー");
        }
    }
}

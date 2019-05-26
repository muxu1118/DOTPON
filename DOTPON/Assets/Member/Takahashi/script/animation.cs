using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    private MecanimControl mecanimControl;
    void Start()
    {
        mecanimControl = gameObject.GetComponent<MecanimControl>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            mecanimControl.Play("attack", 1f, 0.1f, false);
            Debug.Log("attack");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            mecanimControl.Play("attack2", 1f, 0.1f, false);
            Debug.Log("attack2");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            mecanimControl.Play("run", 1f, 0.1f, false);
            Debug.Log("run");
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            mecanimControl.Play("walk", 1f, 0.1f, false);
            Debug.Log("walk");
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            mecanimControl.Play("idlng", 1f, 0.1f, false);
            Debug.Log("walk");
        }
    }
}

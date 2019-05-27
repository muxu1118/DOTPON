using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
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
            mecanimControl.Play("Idling", 1f, 0.1f, false);
            Debug.Log("待機");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            mecanimControl.Play("a", 1f, 0.1f, false);
            Debug.Log("剣で攻撃");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            mecanimControl.Play("a2", 1f, 0.1f, false);
            Debug.Log("ハンマーで攻撃");
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

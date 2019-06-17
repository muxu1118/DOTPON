using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadInput : MonoBehaviour
{
    InputManager IM;
    

    // Update is called once per frame
    void Update()
    {
        float h1 = Input.GetAxis("Pad1L_H");
        float v1 = Input.GetAxis("Pad1L_V");
        Debug.Log("1" + h1 + "," + v1);
        float h2 = Input.GetAxis("Pad2L_H");
        float v2 = Input.GetAxis("Pad2L_V");
        Debug.Log("2" + h2 + "," + v2);
    }
}

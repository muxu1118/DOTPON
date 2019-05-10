using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControll : MonoBehaviour
{
    //string x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Button();
    }
    private void Button()
    {
    //    if (Input.GetKeyDown(x))
    //    {
    //        switch ()
    //    }

        if (Input.GetKeyDown("joystick 1 button 0"))
        {
            Debug.Log("1P1");
        }
        if (Input.GetKeyDown("joystick 1 button 1"))
        {
            Debug.Log("1P2");
        }
        if (Input.GetKeyDown("joystick 1 button 2"))
        {
            Debug.Log("1P3");
        }
        if (Input.GetKeyDown("joystick 1 button 3"))
        {
            Debug.Log("1P4");
        }
        if (Input.GetKeyDown("joystick 1 button 4"))
        {
            Debug.Log("1P5");
        }
        if (Input.GetKeyDown("joystick 1 button 5"))
        {
            Debug.Log("1P6");
        }

        if (Input.GetKeyDown("joystick 2 button 0"))
        {
            Debug.Log("2P1");
        }
        if (Input.GetKeyDown("joystick 2 button 1"))
        {
            Debug.Log("2P2");
        }
        if (Input.GetKeyDown("joystick 2 button 2"))
        {
            Debug.Log("2P3");
        }
        if (Input.GetKeyDown("joystick 2 button 3"))
        {
            Debug.Log("2P4");
        }
        if (Input.GetKeyDown("joystick 2 button 4"))
        {
            Debug.Log("2P5");
        }
        if (Input.GetKeyDown("joystick 2 button 5"))
        {
            Debug.Log("2P6");
        }


    }
}

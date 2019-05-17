using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControll : MonoBehaviour
{
    //string x;

    int PlayerNumber;//Playerの人数

    //人数の分だけ動かす

    void Update()
    {
        Button();

        ControllerNum();


    }

    void ControllerNum()
    {
        var controllerNames = Input.GetJoystickNames();

        string[] cName = Input.GetJoystickNames();
        PlayerNumber = 0;
        for (int i = 0; i < cName.Length; i++)
        {
            if (cName[i] != "")
            {
                PlayerNumber++;
            }
        }
        Debug.Log(PlayerNumber);//Player(接続されてるコントローラー)の数
    }
    private void Button()
    {
        //    if (Input.GetKeyDown(x))
        //    {
        //        switch ()
        //    }

        //for(int PadNum = 1;PadNum <= PlayerNumber; PadNum++)
        //{
        //    if(Input.GetButtonDown("joystick" + PlayerNumber + "_1"))
        //    {
        //        Debug.Log("1P1");
        //    }
        //}






        //if (Input.GetKeyDown("joystick 1 button 0"))
        //{
        //    Debug.Log("1P1");
        //}
        //if (Input.GetKeyDown("joystick 1 button 1"))
        //{
        //    Debug.Log("1P2");
        //}
        //if (Input.GetKeyDown("joystick 1 button 2"))
        //{
        //    Debug.Log("1P3");
        //}
        //if (Input.GetKeyDown("joystick 1 button 3"))
        //{
        //    Debug.Log("1P4");
        //}
        //if (Input.GetKeyDown("joystick 1 button 4"))
        //{
        //    Debug.Log("1P5");
        //}
        //if (Input.GetKeyDown("joystick 1 button 5"))
        //{
        //    Debug.Log("1P6");
        //}

        //if (Input.GetKeyDown("joystick 2 button 0"))
        //{
        //    Debug.Log("2P1");
        //}
        //if (Input.GetKeyDown("joystick 2 button 1"))
        //{
        //    Debug.Log("2P2");
        //}
        //if (Input.GetKeyDown("joystick 2 button 2"))
        //{
        //    Debug.Log("2P3");
        //}
        //if (Input.GetKeyDown("joystick 2 button 3"))
        //{
        //    Debug.Log("2P4");
        //}
        //if (Input.GetKeyDown("joystick 2 button 4"))
        //{
        //    Debug.Log("2P5");
        //}
        //if (Input.GetKeyDown("joystick 2 button 5"))
        //{
        //    Debug.Log("2P6");
        //}

    }
}

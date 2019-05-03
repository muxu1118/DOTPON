using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public string Pl;
   
    public static bool AButton(string Pl)
    {
        return Input.GetButtonDown(Pl + "A_Button");
    }
    public static bool BButton(string Pl)
    {
        return Input.GetButtonDown(Pl + "B_Button");
    }
    public static bool XButton(string Pl)
    {
        return Input.GetButtonDown(Pl + "X_Button");
    }
    public static bool YButton(string Pl)
    {
        return Input.GetButtonDown(Pl + "Y_Button");
    }

    public Vector3 mainjoystick()
    {
        return new Vector3(MaintHorizontal(Pl), 0f, MaintVerticall(Pl));
    }

    public float MaintHorizontal(string Pl)
    {
        float h = 0.0f;
        h += Input.GetAxis(Pl + "J_Horizontal");
        h += Input.GetAxis(Pl + "K_Horizontal");
        return Mathf.Clamp(h, -1.0f, 1.0f);

    }
    public void Update()
    {
        if (Input.GetButtonDown(Pl + "Jump"))
        {

        }
    }
    public float MaintVerticall(string Pl)
    {
        float v = 0.0f;
        v += Input.GetAxis(Pl + "J_Vertical");
        v += Input.GetAxis(Pl + "K_Vertical");
        return Mathf.Clamp(v, -1.0f, 1.0f);

    }
}

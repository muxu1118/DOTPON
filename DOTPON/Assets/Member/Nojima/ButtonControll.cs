﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControll : MonoBehaviour
{
    //string x;

    int PlayerNumber;//Playerの人数

    //人数の分だけ動かす

    WeaponCreate weaponCreate;

    void Start()
    {
        weaponCreate = GetComponent<WeaponCreate>();    
    }

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
        //Debug.Log(PlayerNumber + "接続コントローラー数");//Player(接続されてるコントローラー)の数
    }
    private void Button()
    {

        for (int padNum = 1; padNum <= 4; padNum++)
        {
            // ドットポン選択(右)
            if (Input.GetKeyDown("joystick " + padNum + " button 0"))
            {
                weaponCreate.ChangeWeaponMinus();
                Debug.Log(padNum+"_1");
            }
            if (Input.GetKeyDown("joystick " + padNum + " button 1"))
            {
                Debug.Log(padNum + "_2");
            }

            //ドットポンを表示、非表示
            if (Input.GetKeyDown("joystick " + padNum + " button 2"))
            {
                weaponCreate.CreateWeapon();
                Debug.Log(padNum + "_3");
            }

            // ドットポン選択(左)
            if (Input.GetKeyDown("joystick " + padNum + " button 3"))
            {
                weaponCreate.ChangeWeaponPlus();
                Debug.Log(padNum + "_4");
            }
            if (Input.GetKeyDown("joystick " + padNum + " button 4"))
            {

                Debug.Log(padNum + "_5");
            }
            if (Input.GetKeyDown("joystick " + padNum + " button 5"))
            {

                Debug.Log(padNum + "_6");
            }
        }
    }
}
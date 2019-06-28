using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    float run; //走る速度
    [SerializeField]
    float walk; //歩く速度

    Animator anim;
    Vector3 vel;
    float i;

    GameObject Player;
    Rigidbody rg;
    GameObject Cube1;
    GameObject Cube2;
    GameObject Cube3;
    GameObject Cube4;


    void Start()
    {
        /*
        Player = GameObject.Find("Cube");
        anim = GetComponent<Animator>();
        vel = new Vector3(Input.GetAxis("Vertical1_left") ,0f);
        */
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody>();
        transform.rotation = new Quaternion(0, 0, 0, 0);
        Cube1 = GameObject.Find("Cube1");
        Cube2 = GameObject.Find("Cube2");
        Cube3 = GameObject.Find("Cube3");
        Cube4 = GameObject.Find("Cube4");

    }

    void Update()
    {
        MoveInput();
        MoveInputKey();
    }
    
    void MoveInput()
    {
        //i = Input.GetAxis("Vertical1_left");

        //if (i > 0.3)
        //{
        //    //歩き
        //    this.transform.position += transform.forward * walk * Time.deltaTime;
        //    anim.SetFloat("Speed", i);
        //}
        //else if (i > 0.8)
        //{   //走る
        //    this.transform.position += transform.forward * run * Time.deltaTime;
        //    anim.SetFloat("Speed", i);
        //}
        //else
        //{
        //    anim.SetFloat("Speed", 0);
        //}
        

        for (int Num = 1;Num <= 4;Num++)
        {
            if (Input.GetAxis("Vertical"+ Num + "_left") > 0.7)
            {   //走る
                Debug.Log(Num+"run");
                //Cubeをプレイヤーに変更すれば別のシーンで使用可
                if (Num == 1) { Cube1.transform.position += transform.forward * run * Time.deltaTime; }
                if (Num == 2) { Cube2.transform.position += transform.forward * run * Time.deltaTime; }
                if (Num == 3) { Cube3.transform.position += transform.forward * run * Time.deltaTime; }
                if (Num == 4) { Cube4.transform.position += transform.forward * run * Time.deltaTime; }
            }
            if (Input.GetAxis("Vertical" + Num + "_left") > 0.3)
            {
                //歩き
                Debug.Log(Num + "walk");
                if (Num == 1) { Cube1.transform.position += transform.forward * walk * Time.deltaTime; }
                if (Num == 2) { Cube2.transform.position += transform.forward * walk * Time.deltaTime; }
                if (Num == 3) { Cube3.transform.position += transform.forward * walk * Time.deltaTime; }
                if (Num == 4) { Cube4.transform.position += transform.forward * walk * Time.deltaTime; }
            }
            if (Input.GetAxis("Vertical" + Num + "_left") < -0.3)
            {
                //後ろに進む
                Debug.Log(Num + "back");
                if (Num == 1) { Cube1.transform.position -= transform.forward * walk * Time.deltaTime; }
                if (Num == 2) { Cube2.transform.position -= transform.forward * walk * Time.deltaTime; }
                if (Num == 3) { Cube3.transform.position -= transform.forward * walk * Time.deltaTime; }
                if (Num == 4) { Cube4.transform.position -= transform.forward * walk * Time.deltaTime; }
            }
            if (Input.GetAxis("Horizontal" + Num + "_left") > 0.4)
            {
                //右に進む
                Debug.Log(Num + "right");
                if (Num == 1) { Cube1.transform.position += transform.right * walk * Time.deltaTime; }
                if (Num == 2) { Cube2.transform.position += transform.right * walk * Time.deltaTime; }
                if (Num == 3) { Cube3.transform.position += transform.right * walk * Time.deltaTime; }
                if (Num == 4) { Cube4.transform.position += transform.right * walk * Time.deltaTime; }
            }
            if (Input.GetAxis("Horizontal" + Num + "_left") < -0.4)
            {
                //左に進む
                Debug.Log(Num + "left");
                if (Num == 1) { Cube1.transform.position -= transform.right * walk * Time.deltaTime; }
                if (Num == 2) { Cube2.transform.position -= transform.right * walk * Time.deltaTime; }
                if (Num == 3) { Cube3.transform.position -= transform.right * walk * Time.deltaTime; }
                if (Num == 4) { Cube4.transform.position -= transform.right * walk * Time.deltaTime; }

            }
        }
    }

    void MoveInputKey()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                this.transform.position += transform.forward * run * Time.deltaTime;
                anim.SetFloat("Speed", 0.8f);
            }
            else
            {
                this.transform.position += transform.forward * walk * Time.deltaTime;
                anim.SetFloat("Speed", 0.5f);
            }
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position -= transform.forward * walk * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position -= transform.right * walk * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += transform.right * walk * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            this.transform.Rotate(0, 120 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            this.transform.Rotate(0, -120 * Time.deltaTime, 0);
        }
        /*
        if (Input.anyKey)
        {
            rg.constraints = RigidbodyConstraints.FreezeRotation;
            rg.constraints = RigidbodyConstraints.FreezeRotationY;
        }
        else
        {
            rg.constraints = RigidbodyConstraints.FreezeRotationY;
        }
        */
    }
}

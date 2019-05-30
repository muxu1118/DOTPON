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

    void Start()
    {
        /*
        Player = GameObject.Find("Cube");
        anim = GetComponent<Animator>();
        vel = new Vector3(Input.GetAxis("Vertical1_left") ,0f);
        */
        anim = GetComponent<Animator>();
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    void Update()
    {
        MoveInput();
        MoveInputKey();
    }
    
    void MoveInput()
    {
        i = Input.GetAxis("Vertical1_left");

        if (i > 0.3)
        {
            //歩き
            this.transform.position += transform.forward * walk * Time.deltaTime;
            anim.SetFloat("Speed", i);
        }
        else if (i > 0.8)
        {   //走る
            this.transform.position += transform.forward * run * Time.deltaTime;
            anim.SetFloat("Speed", i);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }

        if (Input.GetAxis("Vertical1_left") > 0.7)
        {   //走る
            this.transform.position += transform.forward * run * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical1_left") > 0.3){
            //歩き
            this.transform.position += transform.forward * walk * Time.deltaTime;
        }
        if(Input.GetAxis("Vertical1_left") < -0.3)
        {
            //後ろに進む
            this.transform.position -= transform.forward * walk * Time.deltaTime;
        }
        if(Input.GetAxis("Horizontal1_left") > 0.4)
        {
            //右に進む
            this.transform.position += transform.right * walk * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal1_left") < -0.4)
        {
            //左に進む
            this.transform.position -= transform.right * walk * Time.deltaTime;
        }
    }

    void MoveInputKey()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += transform.forward * run * Time.deltaTime;
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
            this.transform.Rotate(0, 60 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            this.transform.Rotate(0, -60* Time.deltaTime, 0);
        }
    }
}

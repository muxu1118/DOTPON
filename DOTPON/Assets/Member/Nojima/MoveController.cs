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
        Player = GameObject.Find("Cube");
        anim = GetComponent<Animator>();
        vel = new Vector3(Input.GetAxis("Vertical1_left") ,0f);
    }

    void Update()
    {
        MoveInput();
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
        if (i > 0.7)
        {   //走る
            this.transform.position += transform.forward * run * Time.deltaTime;
            anim.SetFloat("Speed", i);
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
}

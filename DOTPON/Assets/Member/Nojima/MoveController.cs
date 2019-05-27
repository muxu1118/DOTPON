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

    GameObject Player;
    void Update()
    {
        MoveInput();
    }
    void Start()
    {
        Player = GameObject.Find("Cube");
    }
    void MoveInput()
    {
        if (Input.GetAxis("Vertical1") > 0.7)
        {   //走る
            this.transform.position += transform.forward * run * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical1") > 0.3){
            //歩き
            this.transform.position += transform.forward * walk * Time.deltaTime;
        }
        if(Input.GetAxis("Vertical1") < -0.3)
        {
            //後ろに進む
            this.transform.position -= transform.forward * walk * Time.deltaTime;
        }
        if(Input.GetAxis("Horizontal1") > 0.4)
        {
            //右に進む
            this.transform.position += transform.right * walk * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal1") < -0.4)
        {
            //左に進む
            this.transform.position -= transform.right * walk * Time.deltaTime;
        }
    }
}

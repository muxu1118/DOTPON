using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetest : MonoBehaviour
{
    [SerializeField]
    float run; //走る速度
    [SerializeField]
    float walk; //歩く速度
    GameObject Cube1;
    GameObject Cube2;
    GameObject Cube3;
    GameObject Cube4;
    // Start is called before the first frame update
    void Start()
    {
        Cube1 = GameObject.Find("Cube1");
        Cube2 = GameObject.Find("Cube2");
        Cube3 = GameObject.Find("Cube3");
        Cube4 = GameObject.Find("Cube4");
    }

    // Update is called once per frame
    void Update()
    {
        Movetest();
    }
    void Movetest()
    {
        for (int Num = 1; Num <= 4; Num++)
        {
            // _left で左スティック。 _right で右スティック
            if (Input.GetAxis("Vertical" + Num + "_left") > 0.7)
            {   //走る
                Debug.Log(Num + "run");
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




            if (Input.GetAxis("Vertical" + Num + "_right") > 0.7)
            {   //走る
                Debug.Log(Num + "run");
                //Cubeをプレイヤーに変更すれば別のシーンで使用可
                if (Num == 1) { Cube1.transform.position += transform.forward * run * Time.deltaTime; }
                if (Num == 2) { Cube2.transform.position += transform.forward * run * Time.deltaTime; }
                if (Num == 3) { Cube3.transform.position += transform.forward * run * Time.deltaTime; }
                if (Num == 4) { Cube4.transform.position += transform.forward * run * Time.deltaTime; }
            }
            if (Input.GetAxis("Vertical" + Num + "_right") > 0.3)
            {
                //歩き
                Debug.Log(Num + "walk");
                if (Num == 1) { Cube1.transform.position += transform.forward * walk * Time.deltaTime; }
                if (Num == 2) { Cube2.transform.position += transform.forward * walk * Time.deltaTime; }
                if (Num == 3) { Cube3.transform.position += transform.forward * walk * Time.deltaTime; }
                if (Num == 4) { Cube4.transform.position += transform.forward * walk * Time.deltaTime; }
            }
            if (Input.GetAxis("Vertical" + Num + "_right") < -0.3)
            {
                //後ろに進む
                Debug.Log(Num + "back");
                if (Num == 1) { Cube1.transform.position -= transform.forward * walk * Time.deltaTime; }
                if (Num == 2) { Cube2.transform.position -= transform.forward * walk * Time.deltaTime; }
                if (Num == 3) { Cube3.transform.position -= transform.forward * walk * Time.deltaTime; }
                if (Num == 4) { Cube4.transform.position -= transform.forward * walk * Time.deltaTime; }
            }
            if (Input.GetAxis("Horizontal" + Num + "_right") > 0.4)
            {
                //右に進む
                Debug.Log(Num + "right");
                if (Num == 1) { Cube1.transform.position += transform.right * walk * Time.deltaTime; }
                if (Num == 2) { Cube2.transform.position += transform.right * walk * Time.deltaTime; }
                if (Num == 3) { Cube3.transform.position += transform.right * walk * Time.deltaTime; }
                if (Num == 4) { Cube4.transform.position += transform.right * walk * Time.deltaTime; }
            }
            if (Input.GetAxis("Horizontal" + Num + "_right") < -0.4)
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
}

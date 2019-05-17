﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goburin : Enemy
{
    Vector3 vector;
    [SerializeField]GameObject[] lookingCollider;
    bool isAction = false;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        //パラメータの値を変数に格納
        vector = transform.forward;
        HP = parameter.HP;
        DropDotNumber = parameter.dropDot;
        speed = parameter.speed / 100;
        rotateTime = parameter.rotateTime;
        rotateAngle = parameter.rotateAngle;
        lookingAngle = parameter.lookingAngle / 2;
        distance = parameter.distance;
        lookSpeed = parameter.lookSpeed;
        attackPow = parameter.attackPow;
        //視野のcollider3つを配置するループ
        for (int i = 0;i < 3;i++)
        {
            lookingCollider[i].GetComponent<BoxCollider>().size = new Vector3(lookingAngle, 1, lookingAngle);
            switch (i)
            { 
                case 0:
                    lookingCollider[i].transform.localPosition = new Vector3(0, 0, CantLookPos(lookingAngle));
                    break;
                case 1:
                    lookingCollider[i].transform.localPosition = new Vector3(CantLookPos(lookingAngle), 0, 0);
                    break;
                case 2:
                    lookingCollider[i].transform.localPosition = new Vector3(-CantLookPos(lookingAngle), 0, 0);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        DropDot(gameObject);
        if (isAction) return;
        transform.position += vector * speed;
        if (time > 3 && !isLooking)
        {
            isAction = true;
            //回転のコルーチンを呼び出す
            StartCoroutine(Rotating(rotateAngle,rotateTime * 60));
            StartCoroutine(WaitTime());
            time = 0;
        }
        vector = transform.forward;
    }

    private void OnTriggerStay(Collider other)
    {
        //タグ判定
        if (other.gameObject.tag == "player")
        {
            //パッて向く
            //transform.LookAt(player.transform.position);
            //すーっと向く
            //ターゲットの方向ベクトルを取得
            Vector3 relativePos = other.transform.position - this.gameObject.transform.position;
            //方向を回転情報に変換
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            //現在の回転情報と、ターゲットの回転情報を補完する
            transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, lookSpeed);
            //進む方向を自分の前に変更
            vector = transform.forward;
            isLooking = true;
            //自分とプレイヤーの距離の取得
            float dis = Vector3.Distance(this.transform.position, other.gameObject.transform.position);
            //distanceより近かったら攻撃する関数を呼ぶ
            if(dis <= distance)
            {
                isAction = true;
                Attack(attackPow);
                StartCoroutine(WaitTime());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isLooking = false;
    }
    //行動しない時間
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(rotateTime);
        isAction = false;
        yield break;
    }
}

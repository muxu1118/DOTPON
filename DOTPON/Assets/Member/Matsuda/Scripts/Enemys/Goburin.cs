using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goburin : Enemy
{
    Vector3 vector;
    [SerializeField]GameObject[] lookingCollider;
    float time;
    float lookingAngle;
    bool stayLooking;
    // Start is called before the first frame update
    void Start()
    {
        //パラメータの値を変数に格納
        vector = transform.forward;
        HP = parameter.HP;
        lookingAngle = parameter.lookingAngle / 2;
        //視野のcollider3つを配置するループ
        for (int i = 0;i < 3;i++)
        {
            lookingCollider[i].GetComponent<BoxCollider>().size = new Vector3(lookingAngle, transform.localScale.x /10, lookingAngle);
            switch (i)
            { 
                case 0:
                    lookingCollider[i].transform.localPosition = new Vector3(0, 0, CantLookPos(lookingAngle)/2);
                    break;
                case 1:
                    lookingCollider[i].transform.localPosition = new Vector3(CantLookPos(lookingAngle)/2, 0, 0);
                    break;
                case 2:
                    lookingCollider[i].transform.localPosition = new Vector3(-CantLookPos(lookingAngle)/2, 0, 0);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (isAction || transform.localPosition.y >= 0 ) return;
        this.transform.localPosition += vector * parameter.speed / 100;
        if (time > parameter.lookAngleChangeTime && !isLooking)
        {
            isAction = true;
            //回転のコルーチンを呼び出す
            StartCoroutine(Rotating(parameter.rotateAngle,parameter.rotateTime * 60));
            StartCoroutine(WaitTime(parameter.rotateTime));
            time = 0;
        }
        vector = transform.forward;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "goburin" && stayLooking)
        {
            isAction = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (stayLooking)
        {
            isAction = false;
            stayLooking = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //タグ判定
        if (other.gameObject.tag == "player")
        {
            //パッて向く
            //transform.LookAt(other.transform.position);
            //すーっと向く
            //ターゲットの方向ベクトルを取得
            Vector3 relativePos = other.transform.position - this.gameObject.transform.position;
            //方向を回転情報に変換
            Quaternion rotation = Quaternion.LookRotation(new Vector3(relativePos.x, 0, relativePos.z));
            //現在の回転情報と、ターゲットの回転情報を補完する
            transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, parameter.lookSpeed);
            //進む方向を自分の前に変更
            vector = new Vector3(transform.forward.x,0, transform.forward.z);
            isLooking = true;
            if (isAction) return;
            //自分とプレイヤーの距離の取得
            float dis = Vector3.Distance(this.transform.position, other.gameObject.transform.position);
            //distanceより近かったら攻撃する関数を呼ぶ
            if(dis <= parameter.distance)
            {
                isAction = true;
                Attack();
                StartCoroutine(WaitTime(parameter.attackWait));
            }else if (dis <= parameter.distance * 2)
            {
                stayLooking = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "player") return;
        isLooking = false;
    }
}

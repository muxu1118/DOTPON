using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    Vector3 vector;
    [SerializeField] GameObject[] lookingCollider;
    float time;
    float lookingAngle;
    [SerializeField] GameObject bukiObj;
    // Start is called before the first frame update
    void Start()
    {
        //パラメータの値を変数に格納
        vector = transform.forward;
        HP = parameter.HP;
        lookingAngle = parameter.lookingAngle / 2;
        //視野のcollider3つを配置するループ
        float scale = transform.localScale.x * 2;
        for (int i = 0; i < 3; i++)
        {
            lookingCollider[i].GetComponent<BoxCollider>().size = new Vector3(lookingAngle, 1, lookingAngle);
            switch (i)
            {
                case 0:
                    lookingCollider[i].transform.localPosition = new Vector3(0, 0, CantLookPos(lookingAngle) / scale);
                    break;
                case 1:
                    lookingCollider[i].transform.localPosition = new Vector3(CantLookPos(lookingAngle) / scale, 0, 0);
                    break;
                case 2:
                    lookingCollider[i].transform.localPosition = new Vector3(-CantLookPos(lookingAngle) / scale, 0, 0);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (isAction) return;
        this.transform.position += vector * parameter.speed / 100;
        if (time > parameter.lookAngleChangeTime && !isLooking)
        {
            isAction = true;
            //回転のコルーチンを呼び出す
            StartCoroutine(Rotating(parameter.rotateAngle, parameter.rotateTime * 60));
            StartCoroutine(WaitTime(parameter.rotateTime));
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
            //transform.LookAt(other.transform.position);
            //すーっと向く
            //ターゲットの方向ベクトルを取得
            Vector3 relativePos = other.transform.position - this.gameObject.transform.position;
            //方向を回転情報に変換
            Quaternion rotation = Quaternion.LookRotation(new Vector3(relativePos.x,0,relativePos.z));
            //現在の回転情報と、ターゲットの回転情報を補完する
            transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, parameter.lookSpeed);
            //進む方向を自分の前に変更
            vector = transform.forward;
            isLooking = true;
            if (isAction) return;
            isAction = true;
            var obj = Instantiate(bukiObj, transform.localPosition, Quaternion.identity);
            //遠距離攻撃の距離を自分とプレイヤーの距離に
            obj.GetComponent<FarAttack>().pow = Vector3.Distance(this.transform.position,other.gameObject.transform.position);
            obj.transform.parent = this.gameObject.transform;
            buki = obj;
            Attack();
            StartCoroutine(WaitTime(1.5f));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isLooking = false;
    }
}


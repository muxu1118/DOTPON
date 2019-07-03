using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Enemy
{
    Vector3 vector;
    [SerializeField] GameObject[] lookingCollider;
    float time;
    float lookingAngle;
    [SerializeField] GameObject[] bukiObj;
    void Start()
    {
        HP = parameter.HP;
        
    }
    void Update()
    {
        time += Time.deltaTime;
        if (isAction) return;
        if (time > parameter.lookAngleChangeTime && !isLooking)
        {
            isAction = true;
            //回転のコルーチンを呼び出す
            StartCoroutine(Rotating(parameter.rotateAngle /parameter.rotateTime, parameter.rotateTime * 60));
            StartCoroutine(WaitTime(parameter.rotateTime));
            time = 0;
        }
        vector = transform.forward;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "player") return;
        //ターゲットの方向ベクトルを取得
        Vector3 relativePos = other.transform.position - this.gameObject.transform.position;
        //方向を回転情報に変換
        Quaternion rotation = Quaternion.LookRotation(new Vector3(relativePos.x, 0, relativePos.z));
        //現在の回転情報と、ターゲットの回転情報を補完する
        transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, parameter.lookSpeed);
        //進む方向を自分の前に変更
        vector = transform.forward;
        isLooking = true;
        if (isAction) return;
        //自分とプレイヤーの距離の取得
        float dis = Vector3.Distance(this.transform.position, other.gameObject.transform.position);
        isAction = true;
        if(dis <= parameter.distance / 2)
        {
            //スタンプ攻撃
            bukiObj[0].SetActive(true);
            bukiObj[0].GetComponent<Animator>().SetTrigger("Attack");
            StartCoroutine(WaitTime(1.5f));
        }
        else if (dis <= parameter.distance)
        {
            //ブレス攻撃
            bukiObj[1].SetActive(true);
            bukiObj[1].GetComponent<Animator>().SetTrigger("Attack2");
            StartCoroutine(WaitTime(2f));
        }
        StartCoroutine(Active(1.5f));
    }

    IEnumerator Active(float num)
    {
        yield return new WaitForSeconds(num);
        for (int i = 0;i < 2; i++)
        {
            bukiObj[i].SetActive(false);
        }
    }
}

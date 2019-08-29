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

    [SerializeField] GameObject headObj;

    [HideInInspector]public int[] damageInstance = {0,0,0,0};
    void Start()
    {
        //パラメータの値を変数に格納
        vector = transform.forward;
        HP = parameter.HP;
        lookingAngle = parameter.lookingAngle / 2;
        for (int i = 0; i < 3; i++)
        {
            lookingCollider[i].GetComponent<BoxCollider>().size = new Vector3(lookingAngle, transform.localScale.x / 5, lookingAngle);
            switch (i)
            {
                case 0:
                    lookingCollider[i].transform.localPosition = new Vector3(0, 1, parameter.lookingAngle);
                    break;
                case 1:
                    lookingCollider[i].transform.localPosition = new Vector3(parameter.lookingAngle, 1, 0);
                    break;
                case 2:
                    lookingCollider[i].transform.localPosition = new Vector3(-parameter.lookingAngle, 1, 0);
                    break;
            }
        }
    }
    void Update()
    {
        time += Time.deltaTime;
        if (isAction) return;
        if (time > parameter.lookAngleChangeTime && !isLooking)
        {
            isAction = true;
            //回転のコルーチンを呼び出す
            StartCoroutine(Rotating(parameter.rotateAngle /parameter.rotateTime, parameter.rotateTime));
            StartCoroutine(WaitTime(parameter.rotateTime,false));
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
            //スタンプ攻撃0
            GetComponent<Animator>().SetTrigger("Attack");
            StartCoroutine(WaitTime(1.5f,false));
        }
        else if (dis <= parameter.distance)
        {
            //ブレス攻撃
            GetComponent<Animator>().SetTrigger("Attack2");
            StartCoroutine(Bless());
            StartCoroutine(WaitTime(2.5f,false));
        }
    }

    public void PlayerAttackCount(GameObject player,int pow)
    {
        int i = pow * 3;
        damageInstance[(int)player.GetComponent<Player>().own] += i;
        Debug.Log("1p = "+damageInstance[0]+" 2p = "+damageInstance[1]+" 3p = "+damageInstance[2]+"4p = "+damageInstance[3]);
    }

    IEnumerator Active(float num)
    {
        yield return new WaitForSeconds(num);
    }

    IEnumerator Bless()
    {
        yield return new WaitForSeconds(1.3f);
        bukiObj[0].SetActive(true);
        var particl = bukiObj[0].GetComponent<ParticleSystem>();
        yield return new WaitWhile(() => particl.IsAlive(true));
        bukiObj[0].SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Damage(99,collision.gameObject);
        }else if (collision.gameObject.tag == "player")
        {
            //collision.gameObject.transform.position += Vector3.back * 5;
        }
    }
}

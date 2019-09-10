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
    bool isAttack;
    [SerializeField] GameObject center;

    DragonAt attack;
    void Start()
    {
        //パラメータの値を変数に格納
        vector = transform.forward;
        HP = parameter.HP;
        float scale = transform.localScale.x * 2;
        for (int i = 0; i < 3; i++)
        {
            lookingCollider[i].GetComponent<BoxCollider>().size = new Vector3(parameter.lookingAngle, transform.localScale.x / 5, parameter.lookingAngle);
            switch (i)
            {
                case 0:
                    lookingCollider[i].transform.localPosition = new Vector3(0, 1, CantLookPos(parameter.lookingAngle) / scale);
                    break;
                case 1:
                    lookingCollider[i].transform.localPosition = new Vector3(CantLookPos(parameter.lookingAngle) / scale, 1, 0);
                    break;
                case 2:
                    lookingCollider[i].transform.localPosition = new Vector3(-CantLookPos(parameter.lookingAngle) / scale, 1, 0);
                    break;
            }
        }
        center.GetComponent<BoxCollider>().size = new Vector3(10, 1, parameter.lookingAngle * 1.1f);
        center.transform.localPosition = new Vector3(0, 1, parameter.lookingAngle / 2.6f);
        attack = GetComponentInChildren<DragonAt>();
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
        if (other.gameObject.tag != "player" || isAttack) return;
        //ターゲットの方向ベクトルを取得
        Vector3 relativePos = other.transform.position - this.gameObject.transform.position;
        //方向を回転情報に変換
        Quaternion rotation = Quaternion.LookRotation(new Vector3(relativePos.x, 0, relativePos.z));
        //現在の回転情報と、ターゲットの回転情報を補完する
        transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, parameter.lookSpeed);
        //進む方向を自分の前に変更
        vector = transform.forward;
        isLooking = true;
        if (!attack.attackOk) return;
        //自分とプレイヤーの距離の取得
        float dis = Vector3.Distance(this.transform.position, other.gameObject.transform.position);
        isAction = true;
        isAttack = true;
        if(dis <= parameter.distance / 2)
        {
            //スタンプ攻撃0
            GetComponent<Animator>().SetTrigger("Attack");
            StartCoroutine(Stomp());
            StartCoroutine(WaitTime(3f,false));
        }
        else if (dis <= parameter.distance)
        {
            //ブレス攻撃
            GetComponent<Animator>().SetTrigger("Attack2");
            StartCoroutine(Bless());
            StartCoroutine(WaitTime(4f,false));
        }
    }

    public void PlayerAttackCount(GameObject player,int pow)
    {
        int i = pow * 2;
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
        isAttack = false;
    }

    IEnumerator Stomp()
    {
        yield return new WaitForSeconds(1.5f);
        bukiObj[1].SetActive(true);
        bukiObj[1].GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        bukiObj[1].GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        bukiObj[1].SetActive(false);
        isAttack = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
        }else if (collision.gameObject.tag == "player")
        {
            //collision.gameObject.transform.position += Vector3.back * 5;
        }
    }
}

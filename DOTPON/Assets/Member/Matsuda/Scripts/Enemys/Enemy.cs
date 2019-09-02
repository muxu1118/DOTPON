using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyParameter parameter;
    [HideInInspector]public int HP;
    [HideInInspector]public bool isLooking = false;
    [SerializeField] protected GameObject buki;

    public bool isAction = false;
    //プレイヤーを攻撃する関数
    protected void Attack()
    {
        
        if (gameObject.name == "golem" || gameObject.name == "Dragom(clone)")
        {
            buki.GetComponent<Animator>().SetTrigger("Attack");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Attack");
        }

    }
    //しんだとき
    public void DropDot(GameObject obj,int kazu,GameObject parentObj)
    {
        if (HP > 0) return;
        // managerに投げる
        Debug.Log("しんだ");
        GetComponent<Animator>().SetTrigger("Down");
        //ドラゴンが死んだ場合、最後の攻撃者にstarを与える
        if (obj.name == "dragon(Clone)")
        {
            switch (parentObj.GetComponent<Player>().own)
            {
                case Player.PlayerKind.Player1:
                    MultiPlayerManager.instance.P1Star++;
                    break;
                case Player.PlayerKind.Player2:
                    MultiPlayerManager.instance.P2Star++;
                    //Debug.Log(MultiPlayerManager.instance.P2Dot);
                    break;
                case Player.PlayerKind.Player3:
                    MultiPlayerManager.instance.P3Star++;
                    //Debug.Log(MultiPlayerManager.instance.P3Dot);
                    break;
                case Player.PlayerKind.Player4:
                    MultiPlayerManager.instance.P4Star++;
                    //Debug.Log(MultiPlayerManager.instance.P4Dot);
                    break;
                default:
                    Debug.LogError("よばれちゃいけんのやぞ");
                    break;
            }
        }
        GameObject.Find("SpownController").GetComponent<SpownController>().NowSpown--;
        DotManager.instance.EnemyDeadDotPop(kazu, obj.transform.position, (int)parentObj.GetComponent<Player>().own);
        
        //enemyの消去
        Destroy(obj);
    }
    /// <summary>
    /// ダメージを受けたときに呼ばれる関数
    /// </summary>
    /// <param name="At">攻撃力</param>
    public void Damage(int At,GameObject obj)
    {
        HP -= At;
        DropDot(this.gameObject,parameter.dropDot,obj);
        isAction = true;
        StartCoroutine(WaitTime(1,true));
        if(this.gameObject.name == "slime")
        {
            var slime = GetComponentInChildren<MeshRenderer>();
            //slime.material.color = new Color(0, 0, 0);
        }
        else if(this.gameObject.name == "goburin")
        {
            GetComponent<Animator>().SetTrigger("Down");
        }
        Debug.Log(this.gameObject.name + "のHPは" + HP + "です");
    }
    /// <summary>
    /// エネミーの回転をさせるコルーチン
    /// </summary>
    /// <param name="rotate">回る角度</param>
    /// <param name="time">回る時間</param>
    /// <returns></returns>
    public IEnumerator Rotating(float rotate,float time)
    {
        if (isLooking) yield break;
        for(int i = 0;i <= time * 60; i++)
        {
            transform.Rotate(new Vector3(0, rotate  / time, 0) * Time.deltaTime);
            yield return null;
        }
        yield break;
    }
    /// <summary>
    /// 視野のcolliderの配置場所を定める関数
    /// </summary>
    /// <param name="lookingAngle">視野の広さ</param>
    /// <returns></returns>
    protected float CantLookPos(float lookingAngle)
    {
        float pos =  Mathf.Sqrt(Mathf.Pow(lookingAngle,2) * 2) / 2;
        //Debug.Log(pos);
        return pos;
    }

    //行動しない時間
    public IEnumerator WaitTime(float time,bool isDamage)
    {
        if (isDamage)
        {
            SkinnedMeshRenderer[] gob = GetComponentsInChildren<SkinnedMeshRenderer>();
            for (int i = 0; i < 2; i++)
            {
                foreach (SkinnedMeshRenderer skin in gob)
                {
                    skin.material.color = new Color(0, 0, 0);
                }
                yield return new WaitForSeconds(time / 4);
                foreach (SkinnedMeshRenderer skin in gob)
                {
                    skin.material.color = new Color(1, 1, 1);
                }
                yield return new WaitForSeconds(time / 4);
            }
        }
        else
        {
            yield return new WaitForSeconds(time);
        }
        isAction = false;
        yield break;
    }
}

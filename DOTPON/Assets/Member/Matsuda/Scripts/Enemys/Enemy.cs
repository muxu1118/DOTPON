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
    public void SpawnEnemy()
    {
        /*判定場所は後々
        現在のモンスター数を取得。一定数以上だったらreturn
        前回の生成からの時間を取得。
        ５秒経っているか
        */
        //4か所にenemy生成
        //enemyに対応した情報を持たせる
    }
    //プレイヤーを攻撃する関数
    protected void Attack(int attack)
    {
        //GameObject.Find("player").GetComponent<plaer_m>().Damage(attack);
        buki.GetComponent<Animator>().SetTrigger("Attack");
        //プレイヤーのスクリプトのダメージの関数に投げる
    }
    //しんだとき
    public void DropDot(GameObject obj,int kazu)
    {
        if (HP > 0) return;
        // managerに投げる
        Debug.Log("しんだ");
        DotManager.instance.EnemyDeadDotPop(kazu,obj.transform.position);
        //enemyの消去
        Destroy(obj);
    }
    /// <summary>
    /// ダメージを受けたときに呼ばれる関数
    /// </summary>
    /// <param name="At">攻撃力</param>
    public void Damage(int At)
    {
        HP -= At;
        isAction = true;
        StartCoroutine(WaitTime(1));
        this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(0,0,0);
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
        for(int i = 0;i < time; i++)
        {
            transform.Rotate(new Vector3(0, rotate, 0) * Time.deltaTime);
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
    public IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
        isAction = false;
        this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1,1,1);
        yield break;
    }
    private void FixedUpdate()
    {
    }
}

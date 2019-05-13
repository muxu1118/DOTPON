using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyParameter parameter;
    [HideInInspector]public int HP;
    [HideInInspector]public int DropDotNumber;
    [HideInInspector] public float speed;
    [HideInInspector] public float rotateTime;
    [HideInInspector] public int rotateAngle;
    [HideInInspector] public float lookingAngle;
    [HideInInspector] public float distance;
    [HideInInspector]public bool isLooking = false;
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

    public void DropDot(GameObject obj)
    {
        if (HP > 0) return;
        // managerからしゅとく
        /*
         * HP取得。0以外return
        */
        //ドロップするドット数取得
        //マップにドロップを生成する処理
        //enemyの消去
        Destroy(obj);
    }

    public void Damage(int At)
    {
        HP -= At;
        Debug.Log(HP);
    }
    
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
    protected float CantLookPos(float lookingAngle)
    {
        float pos =  Mathf.Sqrt(Mathf.Pow(lookingAngle,2) * 2) / 4;
        Debug.Log(pos);
        return pos;
    }

    private void FixedUpdate()
    {
    }
}

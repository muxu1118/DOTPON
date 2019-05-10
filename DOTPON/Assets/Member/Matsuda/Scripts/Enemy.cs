using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public EnemyParameter parameter;
    [HideInInspector]public int HP;
    [HideInInspector]public int DropDotNumber;
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

    public void RotateChange()
    {
        //アニメーションつかうかも
        StartCoroutine(Rotating(90));
    }
    public IEnumerator Rotating(float rotate)
    {
        if (isLooking) yield break;
        for(int i = 0;i < 60; i++)
        {
            transform.Rotate(new Vector3(0, rotate, 0) * Time.deltaTime);
            yield return null;
        }
        yield break;
    }
}

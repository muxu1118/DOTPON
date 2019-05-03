using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]int HP;
    int DropDotNumber;

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

    public IEnumerator Rotating()
    {
        for(int i = 0;i < 60; i++)
        {
            transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
            Debug.Log("Rotating");
            yield return null;
        }
        yield break;
    }
}

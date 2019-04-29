using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    int HP;
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

    public void DropDot()
    {
        /*
         * HP取得。0以外return
        */
        //ドロップするドット数取得
        //マップにドロップを生成する処理
        //enemyの消去
    }
}

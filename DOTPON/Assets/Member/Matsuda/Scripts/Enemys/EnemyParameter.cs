﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="MyName/Create EnemyParameter",fileName = "EnemyParameterTable")]
public class EnemyParameter : ScriptableObject
{
    [SerializeField]
    [HeaderAttribute("HP")]
    public int HP;//HP
    [SerializeField]
    [HeaderAttribute("ドロップするドット数")]
    public int dropDot;//ドロップするドット数
    [HeaderAttribute("攻撃力")]
    public int attackPow;
    [HeaderAttribute("攻撃頻度")]
    public int attackWait;
    [SerializeField]
    [HeaderAttribute("移動速度(cubeのサンプルを目安に)")]
    public float speed;
    [SerializeField]
    [HeaderAttribute("回転時間(秒)")]
    public float rotateTime;//回転時間(秒)
    [SerializeField]
    [HeaderAttribute("回転角度")]
    public int rotateAngle;//回転角度
    [SerializeField]
    [HeaderAttribute("視野の広さ")]
    public float lookingAngle;//視野の広さ
    [SerializeField]
    [HeaderAttribute("攻撃するプレイヤーとの距離")]
    public float distance;//攻撃するプレイヤーとの距離
    [SerializeField]
    [HeaderAttribute("プレイヤーの方向を向く速度")]
    public float lookSpeed;
    [SerializeField]
    [HeaderAttribute("移動の角度が変わるまでの間隔")]
    public int lookAngleChangeTime;//HP
}


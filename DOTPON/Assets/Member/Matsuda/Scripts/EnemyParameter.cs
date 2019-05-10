using System.Collections;
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
    [SerializeField]
    [HeaderAttribute("回転時間")]
    public int rotateTime;//回転時間
    [SerializeField]
    [HeaderAttribute("回転角度")]
    public int rotateAngle;//回転角度
    [SerializeField]
    [HeaderAttribute("視野の広さ")]
    public float lookingAngle;//視野の広さ
    [SerializeField]
    [HeaderAttribute("攻撃するプレイヤーとの距離")]
    public float distance;//攻撃するプレイヤーとの距離
}


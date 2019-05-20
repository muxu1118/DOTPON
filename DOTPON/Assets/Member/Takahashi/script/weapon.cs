using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    //各武器にステータスを参照させる
    public Parametor parametor;

    [HideInInspector]
    public int _attackSpeed;
    [HideInInspector]
    public int _attackDamage;
    [HideInInspector]
    public int _necessaryDot;
    [HideInInspector]
    public int _durableValue;

    void Start()
    {
        _attackSpeed = parametor.attackSpeed;
        _attackDamage = parametor.attackDamage;
        _necessaryDot = parametor.necessaryDot;
        _durableValue = parametor.durableValue;
    }   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
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

    private void OnTriggerEnter(Collider other)
    {

        switch (other.gameObject.tag)
        {
            case "player":
                Debug.Log(other.name + "に攻撃！" + _attackDamage + "ダメージ！");
                other.gameObject.GetComponent<plaer_m>().Damage(_attackDamage);
                break;
            case "enemy":
                if (gameObject..tag == "enemy") return;
                Debug.Log(other.name + "に攻撃！" + _attackDamage + "ダメージ！");
                other.gameObject.GetComponent<Enemy>().Damage(_attackDamage);
                break;
        }
    }
}

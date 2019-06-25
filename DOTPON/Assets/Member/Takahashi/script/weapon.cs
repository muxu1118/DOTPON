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
    //    _attackSpeed = parametor.attackSpeed;
    //    _attackDamage = parametor.attackDamage;
    //    _necessaryDot = parametor.necessaryDot;
    //    _durableValue = parametor.durableValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "player":
                if (other.gameObject.GetComponent<Player>().isDamage) return;
                //Debug.Log(gameObject.transform.root.name + "に攻撃された！" + parametor.attackDamage + "ダメージ！");
                other.gameObject.GetComponent<Player>().Damage(parametor.attackDamage);
                break;
            case "enemy":
                if (gameObject.transform.root.tag == "enemy") return;
                //Debug.Log(other.name + "に攻撃！" + parametor.attackDamage + "ダメージ！");
                other.gameObject.GetComponent<Enemy>().Damage(parametor.attackDamage,transform.root.gameObject);
                transform.root.GetComponent<WeaponCreate>().DownDursble();
                break;
        }
    }
}

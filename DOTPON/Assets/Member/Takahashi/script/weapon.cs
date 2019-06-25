using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
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

    private string tagName;
    

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
                other.gameObject.GetComponent<Player>().Damage(GetAttackPower(parametor.attackDamage));
                break;
            case "enemy":
                if (gameObject.transform.root.tag == "enemy") return;
                //Debug.Log(other.name + "に攻撃！" + parametor.attackDamage + "ダメージ！");
                other.gameObject.GetComponent<Enemy>().Damage(GetAttackPower(parametor.attackDamage),transform.root.gameObject);
                transform.root.GetComponent<WeaponCreate>().DownDursble();
                break;
        }
    }

    private int GetAttackPower(float power)
    {
        int numPower = (int)power;
        //攻撃力計算の処理
        return numPower;
    }

    public void TagGet(string weaponName)
    {
        weaponName = gameObject.tag;
        Debug.Log(tagName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Parametor parametor;

    enum AttackMeans
    {
        ken,
        ax,
        bomb,
        shield,
        fist,
        weapon
    }
    
    /// <summary>
    /// 盾を構えているときに武器が当たった時の処理
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().Damage(parametor.attackDamage);
        }
        else if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().Damage(parametor.attackDamage,other.gameObject);
        }

        if(other.gameObject.tag == "s")
        {            
            StartCoroutine("shieldGuard");
        }
    }
    
    /// <summary>
    /// 盾に武器が当たったらプレイヤーの当たり判定を失くす
    /// </summary>
    /// <returns></returns>
    IEnumerable shieldGuard()
    {
        yield return new WaitForSeconds(0.1f);
        transform.root.gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        transform.root.gameObject.GetComponent<BoxCollider>().enabled = true;
    }        
}

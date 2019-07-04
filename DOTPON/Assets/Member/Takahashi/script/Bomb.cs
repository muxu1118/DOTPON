using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{        
    public Parametor parametor;
    //AudioManager audioManager; 
    SphereCollider sph;
    float range = 1.5f;
    
    void Start()
    {
        sph = GetComponent<SphereCollider>();
        //audioManager = GameObject.Find("Manager").GetComponent<AudioManager>();

        //StartCoroutine("bomExplosion");
    }

    /// <summary>
    /// 爆弾の爆発
    /// </summary>
    /// <returns></returns>
    IEnumerator bomExplosion()
    {
        yield return new WaitForSeconds(3.0f);

        //エフェクトを再生させる
        //audioManager.playSfx(3);

        BombAttack();
        sph.radius = range;
        yield return new WaitForSeconds(0.5f);
        sph.radius = 0.5f;
        Destroy(gameObject);
    }

    /// <summary>
    /// 爆弾の当たり判定
    /// </summary>
    public void BombAttack()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, 0.7f);
        foreach(Collider obj in targets)
        {
            if(obj.gameObject.tag == "Player")
            {
                obj.gameObject.GetComponent<Player>().Damage(parametor.attackDamage);
            }
            else if(obj.gameObject.tag == "Enemy")
            {
                obj.gameObject.GetComponent<Enemy>().Damage(parametor.attackDamage,obj.gameObject);
            }
        }
    }
}

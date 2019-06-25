using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{        
    public Parametor parametor;
    AudioManager audioManager; 
    
    void Start()
    {
        audioManager = GameObject.Find("Manager").GetComponent<AudioManager>();
        StartCoroutine("bom");
    }

    IEnumerator bom()
    {
        yield return new WaitForSeconds(3.0f);

        //エフェクトを再生させる
        //audioManager.playSfx(3);

        BombAttack();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    /// <summary>
    /// 爆弾の処理
    /// </summary>
    private void BombAttack()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, 0.7f);
        foreach(Collider obj in targets)
        {
            if(obj.tag == "Player")
            {
                obj.gameObject.GetComponent<Player>().Damage(parametor.attackDamage);
            }
            else if(obj.tag == "Enemy")
            {
                obj.gameObject.GetComponent<Enemy>().Damage(parametor.attackDamage);
            }
        }
    }
}

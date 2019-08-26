using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{        
    public Parametor parametor;
    
    [SerializeField]
    SphereCollider sph;
    [SerializeField]
    GameObject obj;
    [SerializeField]
    float range;
    
    void Start()
    {
        
        //audioManager = GameObject.Find("Manager").GetComponent<AudioManager>();

        //StartCoroutine("bomExplosion");
    }

    public void ExplotionCoroutine()
    {
        Destroy(obj);
        //transform.parent = null;
        StartCoroutine(bomExplosion());
    }

    /// <summary>
    /// 爆弾の爆発
    /// </summary>
    /// <returns></returns>
    ///
    IEnumerator bomExplosion()
    {       
        //爆発の範囲
        int i = 0;        
        while (i < 30)
        {
            gameObject.transform.localScale += new Vector3(1.3f,1.3f,1.3f) * range * Time.deltaTime;
            i++;
            BombAttack();
            yield return null;
        }
        sph.radius = 1f;
        Destroy(gameObject);
        Debug.Log(gameObject.name);
    }

    /// <summary>
    /// 爆弾の当たり判定
    /// </summary>
    public void BombAttack()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, 0.7f);
        foreach(Collider obj in targets)
        {
            if(obj.gameObject.tag == "player")
            {
                if (obj.gameObject.GetComponent<Player>().isDamage == true) return;
                obj.gameObject.GetComponent<Player>().Damage(parametor.attackDamage, (int)transform.root.gameObject.GetComponent<Player>().own);
                Debug.Log("bm");
            }
            else if(obj.gameObject.tag == "enemy")
            {
                obj.gameObject.GetComponent<Enemy>().Damage(parametor.attackDamage,obj.gameObject);
            }
        }
    }
}

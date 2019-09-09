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
    [SerializeField]
    private MeshRenderer rend;

    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        //audioManager = GameObject.Find("Manager").GetComponent<AudioManager>();        
        //StartCoroutine("bomExplosion");
    }

    //public void ExplotionCoroutine()
    //{        
    //    //transform.parent = null;        
    //    StartCoroutine(bomExplosion());
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "enemy")
        {
            StartCoroutine(bomExplosion());
        }
    }

    /// <summary>
    /// 爆弾の爆発の処理
    /// </summary>
    IEnumerator bomExplosion()
    {
        rend.enabled = true;
        //爆風が出ている間ダメージが入る
        int i = 0;
        float ko = 0;
        while (i < 15)
        {
            ko += 0.025f;
            //ko += Time.deltaTime;
            gameObject.transform.localScale += new Vector3(1,1,1) * ko;
            i++;
            BombAttack();
            Destroy(obj);
            yield return null;
        }
        Debug.LogWarning(ko);
        sph.radius = 1f;
        Destroy(gameObject);
        ////yield return new WaitForSeconds(1.5f);
        ////rend.enabled = false;
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
            }
            else if(obj.gameObject.tag == "enemy")
            {
                obj.gameObject.GetComponent<Enemy>().Damage(parametor.attackDamage,obj.gameObject);
            }
        }
    }    
}

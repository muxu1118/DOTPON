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

    bool chack = true;

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
        //|| other.gameObject.tag == "enemy"        
        if (other.gameObject.tag == "Ground" && chack)
        {
            Debug.Log(other.gameObject.tag + "だよ");
            chack = false;
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
        Destroy(obj);        
        while (i < 33)
        {
            //ko += 0.005f;
            gameObject.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * 6;
                        
            i++;
            BombAttack();            
            yield return null;
        }
        sph.radius = 1f;
        chack = true;
        Destroy(gameObject);
        yield return new WaitForSeconds(1.5f);
        rend.enabled = false;
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
                if (obj.gameObject.GetComponent<Enemy>().Damage) return;
                Debug.Log("ここです");
                obj.gameObject.GetComponent<Enemy>().isDamage(parametor.attackDamage,transform.root.gameObject);
            }
        }
    }    
}

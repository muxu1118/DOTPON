using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    //public Parametor parametor;  
    [SerializeField]
    GameObject shield;

    public void OnTriggerEnter(Collider other)
    {        
        if(other.gameObject.tag == "weapon")
        {            
            StartCoroutine(shieldGuard());
        }
    }

    /// <summary>
    /// 盾に武器が当たったらプレイヤーの当たり判定を失くす
    /// </summary>
    /// <returns></returns>
    IEnumerator shieldGuard()
    {
        shield = transform.root.gameObject;
        Debug.Log(shield);        
        shield.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        Debug.Log(gameObject.name);
        shield.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        Debug.LogWarning("守れた？");
    }        
}

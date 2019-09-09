using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    //public Parametor parametor;  
    //[SerializeField]
    //GameObject shield;
    Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();        
    }

    //public void Update()
    //{
    //    StunStart();
    //}

    //public void OnTriggerEnter(Collider other)
    //{        
    //    if(other.gameObject.tag == "weapon")
    //    {            
    //        StartCoroutine(shieldGuard());
    //    }
    //}
    
    public void StunStart()
    {
        StartCoroutine("WaitAnimation");
    }

    /// <summary>
    /// 盾に武器が当たったらプレイヤーの当たり判定を失くす
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitAnimation()
    {
        anim.SetTrigger("Stun");

        yield return null;
        yield return new WaitForAnimation(anim, 0);


        Debug.LogWarning("守れた？");
    }        
}
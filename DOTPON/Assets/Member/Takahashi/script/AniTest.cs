using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniTest : MonoBehaviour
{
    Animator anim;
    string weaponName;
    Weapon weapon;

    FarAttack farAttack;

    SphereCollider sph;
    //[SerializeField]
    //GameObject capga;

    private int hash;
    
    enum attackMeans
    {
        ken,
        ax,
        bomb,
        shield,
        fist
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        weapon = GetComponent<Weapon>();
        hash = Animator.StringToHash("NotMove");
        //farAttack = this.gameObject.GetComponent<FarAttack>();
        //farAttack.PosMove2();
        //sph = GetComponent<SphereCollider>();
        //sph.radius = 1.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning("こいつが出たらヤバイ");
        //攻撃ボタンを押したときの処理
        if(Input.GetKeyDown(KeyCode.A))
        {
            //weapon.TagGet(weaponName);
            Debug.Log(weaponName);
            switch (weaponName)
            {
                case "sword":
                    anim.SetTrigger("SwordAttack");
                    break;
                case "ax":
                    anim.SetTrigger("AxAttack");
                    break;
                case "shield":
                    anim.SetTrigger("ShieldAttack");

                    break;
            }            
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.speed = 2.0f;
            anim.SetTrigger("SwordAttack");
        }
        //if(Input.GetKeyUp(KeyCode.S))
        //{
        //    anim.SetTrigger("ShieldGuard");
        //}

        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetFloat("X", 1);
            //anim.SetTrigger("Create");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("gg");
        }
        if (Input.GetKeyDown(KeyCode.G) && anim.GetCurrentAnimatorStateInfo(0).tagHash != hash)
        {
            anim.SetTrigger("SwordAttack");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            anim.SetTrigger("AxAttack");
        }        
    }
}

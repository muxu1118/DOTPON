using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniTest : MonoBehaviour
{
    Animator anim;
    string weaponName;
    Weapon weapon;
    
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
    }

    // Update is called once per frame
    void Update()
    {
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
            anim.SetTrigger("SwordAttack");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("Create");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("AxAttack");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            anim.SetTrigger("Run");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            anim.SetTrigger("Walk");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AniTest : MonoBehaviour
{
    Animator anim;
    string weaponName;
    Weapon weapon;
    FarAttack farAttack;
    SphereCollider sph;

    [SerializeField]
    GameObject[] Weapon;
    int weaponNumber;
    bool trigger;
    int weaponType = 0;
    public GameObject nowWeapon;

    //[SerializeField]
    //GameObject capga;

    private int hash;

    void Start()
    {
        anim = GetComponent<Animator>();
        weapon = GetComponent<Weapon>();
        hash = Animator.StringToHash("NotMove");
        //farAttack = this.gameObject.GetComponent<FarAttack>();
        //farAttack.PosMove2();
        //sph = GetComponent<SphereCollider>();
        //sph.radius = 1.5f;

        weaponNumber = Weapon.Length;
    }

    void Update()
    {
        //Debug.LogWarning("こいつが出たらヤバイ");
        //攻撃ボタンを押したときの処理
        if (Input.GetKeyDown(KeyCode.A))
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
            //anim.speed = 2.0f;
            anim.SetTrigger("ShieldAttack");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetTrigger("ShieldGuard");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //anim.SetFloat("X", 1);
            anim.SetTrigger("Create");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            //anim.SetTrigger("AxAttack");
            anim.SetFloat("Speed", 0.4f);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //anim.SetTrigger("AxAttack");
            anim.SetFloat("Speed", 0.8f);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            anim.SetTrigger("SwordAttack");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            //anim.SetTrigger("AxAttack");
        }
    }

    public void WeaponChoice(string str)
    {
        switch (str)
        {
            case "a":
                if (trigger)
                {

                    GetComponent<Animator>().SetTrigger("Create");
                    Weapon[6].SetActive(false);
                    Weapon[weaponType].SetActive(true);
                    nowWeapon = Weapon[weaponType];
                    if (nowWeapon != Weapon[5])
                    {
                        nowWeapon.GetComponent<BoxCollider>().enabled = false;
                    }                    
                }
                else
                {
                    //作成した武器を破棄
                    nowWeapon.SetActive(false);
                    Weapon[6].SetActive(true);
                    nowWeapon = Weapon[6];
                    //value = nowWeapon.GetComponent<Weapon>().parametor.durableValue;
                    trigger = true;
                }
                break;

            //作成する武器の切り替え
            case "s":
                weaponType += 1;
                if (weaponType == weaponNumber - 1)
                {
                    weaponType = 0;
                }                               
                break;

            //作成する武器の切り替え
            case "d":
                if (weaponType > 0)
                {
                    weaponType -= 1;
                    Debug.Log(weaponType);
                }
                else if (weaponType == 0)
                {
                    weaponType = weaponNumber - 2;
                    Debug.Log(weaponType);
                }
                break;
        }
    }
}

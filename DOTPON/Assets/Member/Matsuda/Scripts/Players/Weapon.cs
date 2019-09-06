﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Parametor parametor;
    [HideInInspector]
    public int _attackSpeed;
    [HideInInspector]
    public int _attackDamage;
    [HideInInspector]
    public int _necessaryDot;
    [HideInInspector]
    public int _durableValue;

    private string tagName;
    Shield shield;

    [HideInInspector]
    public int damegUP = 1;

    AudioSource audio;
    Animator animator;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        //    _attackSpeed = parametor.attackSpeed;
        //    _attackDamage = parametor.attackDamage;
        //    _necessaryDot = parametor.necessaryDot;
        //    _durableValue = parametor.durableValue;

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "player":
                if (other.gameObject.GetComponent<Player>().isDamage) return;
                Debug.Log(gameObject.transform.root.name + "に攻撃された！" + parametor.attackDamage + "ダメージ！");
                audio.clip = parametor.clip;
                audio.Play();
                StartCoroutine(Effect(other.gameObject.transform));
                if (this.transform.root.gameObject.tag == "player")
                {
                    other.gameObject.GetComponent<Player>().Damage(GetAttackPower(parametor.attackDamage), (int)transform.root.GetComponent<Player>().own);
                }
                else
                {
                    other.gameObject.GetComponent<Player>().Damage(GetAttackPower(parametor.attackDamage), 4);
                }
                if (this.gameObject.tag == "player")
                {
                    transform.root.GetComponent<WeaponCreate>().DownDursble();
                }
                break;
            case "enemy":
                if (gameObject.transform.root.tag == "enemy") return;
                //Debug.Log(other.name + "に攻撃！" + parametor.attackDamage + "ダメージ！");
                audio.clip = parametor.clip;
                audio.Play();
                StartCoroutine(Effect(other.gameObject.transform));
                other.gameObject.GetComponent<Enemy>().Damage(GetAttackPower(parametor.attackDamage), transform.root.gameObject);
                if (this.gameObject.name == "bomb(Clone)") return;
                transform.root.GetComponent<WeaponCreate>().DownDursble();
                break;
            case "Shild":
                if (gameObject.transform.name == "Shild")
                {
                    StartCoroutine("WaitAnimation");
                    other.gameObject.GetComponent<Player>().Damage(GetAttackPower(parametor.attackDamage * damegUP), (int)transform.root.GetComponent<Player>().own);
                }
                break;
        }
    }

    private int GetAttackPower(float power)
    {
        int numPower = (int)power;
        //攻撃力計算の処理
        return numPower;
    }

    public void TagGet(string weaponName)
    {
        weaponName = gameObject.tag;
        Debug.Log(tagName);
    }

    IEnumerator Effect(Transform pos)
    {
        Debug.Log("pos");
        var effect = Instantiate(parametor.effect,pos.position + new Vector3(0,1.5f,0),Quaternion.identity);
        var particl = effect.GetComponentInChildren<ParticleSystem>();
        yield return new WaitWhile(() => particl.IsAlive(true));
        Destroy(effect);
    }
    IEnumerator WaitAnimation()
    {
        animator.SetTrigger("Stun");
        damegUP = 2;

        yield return null;
        yield return new WaitForAnimation(animator, 0);
        damegUP = 1;

        Debug.LogWarning("守れた？");
    }
}

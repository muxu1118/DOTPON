using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plaer_m : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] GameObject obj;
    [SerializeField] GameObject obj2;
    [HideInInspector]public bool isDamage = false;

    public bool isAttack;
    [SerializeField] GameObject ax;
    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        KeyInout();
    }
    void KeyInout()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerMove(new Vector3(0, 0, 5));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerMove(new Vector3(-5, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerMove(new Vector3(0, 0, -5));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerMove(new Vector3(5, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttackColliderOn();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            AttackColliderOn();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject _object = new GameObject("GoburinFlock");
            for(int i = 0;i < 2; i++)
            {
                for(int j = 0;j < 2; j++)
                {
                    Instantiate(obj, new Vector3(i, 1, j), Quaternion.identity).transform.parent = _object.transform;
                }
            }
        }
    }
    void PlayerMove(Vector3 vec)
    {
        GetComponent<Rigidbody>().velocity += vec;
    }
    public void Damage(int damage)
    {
        if (isDamage) return;
        hp = hp - damage;
        Debug.Log(hp);
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
        isDamage = true;
        StartCoroutine(DamegeWait());
    }
    IEnumerator DamegeWait()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.25f);
            this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
            yield return new WaitForSeconds(0.25f);
            this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1);
        }
        isDamage = false;
        ax.GetComponent<BoxCollider>().enabled = false;
    }
    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(0.8f);
        ax.GetComponent<BoxCollider>().enabled = false;
        yield break;
    }
    void AttackColliderOn()
    {
        ax.GetComponent<Animator>().SetTrigger("Trigger");
        ax.GetComponent<BoxCollider>().enabled = true;
       StartCoroutine(AttackWait());
    }
}

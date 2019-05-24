using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plaer_m : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] GameObject obj;
    [SerializeField] GameObject obj2;
    public bool isDamage = false;

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
        if (isAttack) return;
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
                    GameObject chald = Instantiate(obj, new Vector3(i, 1, j), Quaternion.identity);
                    chald.name = chald.name + (i + j);
                    chald.transform.parent = _object.transform;

                }
            }
            _object.AddComponent<GoburinFlock>();
        }
    }
    void PlayerMove(Vector3 vec)
    {
        GetComponent<Rigidbody>().velocity += vec;
    }
    /// <summary>
    /// プレイヤーがダメージを受けた時の処理
    /// </summary>
    /// <param name="damage">ダメージ量</param>
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
    /// <summary>
    /// ダメージを受けた時の無敵時間
    /// </summary>
    /// <returns></returns>
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
    /// <summary>
    /// 攻撃したときの待機時間
    /// </summary>
    /// <returns></returns>
    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(0.8f);
        ax.GetComponent<BoxCollider>().enabled = false;
        isAttack = false;
        yield break;
    }
    void AttackColliderOn()
    {
        isAttack = true;
        ax.GetComponent<Animator>().SetTrigger("Trigger");
        ax.GetComponent<BoxCollider>().enabled = true;
       StartCoroutine(AttackWait());
    }
}

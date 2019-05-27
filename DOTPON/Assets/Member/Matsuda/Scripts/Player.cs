using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     public enum PlayerKind
    {
        Player1 = 0,
        Player2,
        Player3,
        Player4,
    }
    public PlayerKind own;

    [SerializeField] int hp;
    [SerializeField] GameObject obj;
    [SerializeField] GameObject obj2;
    public bool isDamage = false;


    [SerializeField]
    private float WalkSpeed = 10f; //歩く速度
    [SerializeField]
    private float RunSpeed = 100f; //走る速度
    //private float RotationSpeed = 100f; //向きを変える速度

    public bool isAttack;
    [SerializeField]
    WeaponCreate weapon;
    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        KeyInout();
        Move();
    }
    void KeyInout()
    {
        if (isAttack) return;
        /*
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
        */
        if (Input.GetKeyDown("joystick 1 button 3"))
        {
            AttackColliderOn();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttackColliderOn();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
        }
    }
    void Move()
    {
        //transform.potisionの移動

        //走る
        if (Input.GetAxisRaw("Mouse Y") == -1)
        {
            transform.position += transform.forward * RunSpeed * Time.deltaTime;
            Debug.Log("呼ばれた");
        }
        //前に歩く
        if (Input.GetAxisRaw("Mouse Y") < -0.3)
        {
            transform.position += transform.forward * WalkSpeed * Time.deltaTime;
        }
        //左に移動
        if (Input.GetAxisRaw("Mouse X") < -0.3)
        {
            transform.position -= transform.right * WalkSpeed * Time.deltaTime;
        }
        //右に移動
        if (Input.GetAxisRaw("Mouse X") > 0.3)
        {
            transform.position += transform.right * WalkSpeed * Time.deltaTime;
        }
        //後ろに歩く
        if (Input.GetAxisRaw("Mouse Y") > 0.3)
        {
            transform.position -= transform.forward * WalkSpeed * Time.deltaTime;
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
    }
    /// <summary>
    /// 攻撃したときの待機時間
    /// </summary>
    /// <returns></returns>
    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(0.8f);
        isAttack = false;
        yield break;
    }
    void AttackColliderOn()
    {
        isAttack = true;
        weapon.nowWeapon.GetComponent<Animator>().SetTrigger("Trigger");
       StartCoroutine(AttackWait());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Dot")
        {
            switch (own)
            {
                case PlayerKind.Player1:
                    MultiPlayerManager.instance.P1Dot++;
                    break;
                case PlayerKind.Player2:
                    MultiPlayerManager.instance.P2Dot++;
                    break;
                case PlayerKind.Player3:
                    MultiPlayerManager.instance.P3Dot++;
                    break;
                case PlayerKind.Player4:
                    MultiPlayerManager.instance.P4Dot++;
                    break;
                default:
                    break;
            }
        }
    }
}

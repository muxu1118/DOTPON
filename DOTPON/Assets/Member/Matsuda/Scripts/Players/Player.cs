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
    public bool isDamage = false;
    //スター作成のフラグ
    bool createStar;

    [SerializeField]
    private float WalkSpeed = 10f; //歩く速度
    [SerializeField]
    private float RunSpeed = 100f; //走る速度
                                   //private float RotationSpeed = 100f; //向きを変える速度

    //遠距離攻撃の武器
    [SerializeField] GameObject farAtkWeapon;
    //遠距離攻撃の距離
    int farAtkDistance = 3;

    public bool isAttack;
    //[SerializeField]
    //WeaponCreate weapon;

    //[SerializeField]
    //public GameObject[] weapon = new GameObject[4]; //武器を格納

    //bool trigger = true; //武器の作成と破棄の切り替え 
    //int weaponNumber;    //武器の種類
    //int weaponType = 0;  //武器を指定するための数値

    //public GameObject nowWeapon;
    //int createNum = 0;
    WeaponCreate create;

    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        //weaponNumber = weapon.Length;
        //createNum = weapon[weaponType].GetComponent<weapon>().parametor.dotNum;
        create = GetComponent<WeaponCreate>();
        //this.gameObject.transform.LookAt(GameObject.Find("Tower").transform);
        Debug.Log(transform.forward.x + " + " + transform.forward.y + " + " + transform.forward.z);
    }

    // Update is called once per frame
    void Update()
    {
        KeyInout();
        //Move();
        
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
        if (Input.GetKeyDown("joystick 1 button 1"))
        {
            AttackColliderOn();
        }
        if (Input.GetKeyDown("joystick 1 button 2"))
        {
            create.WeaponChoice("a");
        }
        if (Input.GetKeyDown("joystick 1 button 5"))
        {
            create.WeaponChoice("s");
        }
        if (Input.GetKeyDown("joystick 1 button 7"))
        {
            create.WeaponChoice("d"); 
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            AttackColliderOn();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            FarAttack();
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            farAtkDistance++;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (farAtkDistance > 1)
            {
                farAtkDistance--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
    /// <summary>
    /// プレイヤーがダメージを受けた時の処理
    /// </summary>
    /// <param name="damage">ダメージ量</param>
    public void Damage(int damage)
    {
        if (isDamage) return;
        hp = hp - damage;
        switch (own)
        {
            case PlayerKind.Player1:
                MultiPlayerManager.instance.P1Dot--;
                //Debug.Log(MultiPlayerManager.instance.P1Dot);
                break;
            case PlayerKind.Player2:
                MultiPlayerManager.instance.P2Dot--;
                //Debug.Log(MultiPlayerManager.instance.P2Dot);
                break;
            case PlayerKind.Player3:
                MultiPlayerManager.instance.P3Dot--;
                //Debug.Log(MultiPlayerManager.instance.P3Dot);
                break;
            case PlayerKind.Player4:
                MultiPlayerManager.instance.P4Dot--;
                //Debug.Log(MultiPlayerManager.instance.P4Dot);
                break;
            default:
                Debug.LogError("よばれちゃいけんのやぞ");
                break;
        }
        DotManager.instance.EnemyDeadDotPop(1,transform.position);
        //Debug.Log(hp);
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
        isDamage = true;
        Debug.Log(this.gameObject.name + "が" + damage + "ダメージ受けた\nのこり体力" + hp);
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
            //this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
            yield return new WaitForSeconds(0.25f);
            //this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1);
        }
        isDamage = false;
    }
    /// <summary>
    /// 攻撃したときの待機時間
    /// </summary>
    /// <returns></returns>
    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(0.5f);
        create.nowWeapon.gameObject.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        create.nowWeapon.gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.12f);
        isAttack = false;
        yield break;
    }
    void AttackColliderOn()
    {
        isAttack = true;
        if (create.nowWeapon.name == "Axe" || create.nowWeapon.name == "punch")
        {
            //腕振るほう
            GetComponent<Animator>().SetTrigger("Attack");
        }else if (create.nowWeapon.name == "Katana" || create.nowWeapon.name == "sword")
        {
            //上段切りみたいなの
            GetComponent<Animator>().SetTrigger("Attack2");
        }
        StartCoroutine(AttackWait());
    }
    void FarAttack()
    {
        isAttack = true;
        Instantiate(farAtkWeapon,transform.localPosition + transform.forward,Quaternion.identity).GetComponent<FarAttack>().pow = farAtkDistance;
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
                    //Debug.Log(MultiPlayerManager.instance.P1Dot);
                    break;
                case PlayerKind.Player2:
                    MultiPlayerManager.instance.P2Dot++;
                    //Debug.Log(MultiPlayerManager.instance.P2Dot);
                    break;
                case PlayerKind.Player3:
                    MultiPlayerManager.instance.P3Dot++;
                    //Debug.Log(MultiPlayerManager.instance.P3Dot);
                    break;
                case PlayerKind.Player4:
                    MultiPlayerManager.instance.P4Dot++;
                    //Debug.Log(MultiPlayerManager.instance.P4Dot);
                    break;
                default:
                    Debug.LogError("よばれちゃいけんのやぞ");
                    break;
            }
            other.GetComponent<Dot>().DestroyObject();
        }
    }
    
}

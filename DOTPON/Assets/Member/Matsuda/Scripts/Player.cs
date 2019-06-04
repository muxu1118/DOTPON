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


    [SerializeField]
    private float WalkSpeed = 10f; //歩く速度
    [SerializeField]
    private float RunSpeed = 100f; //走る速度
    //private float RotationSpeed = 100f; //向きを変える速度

    public bool isAttack;
    //[SerializeField]
    //WeaponCreate weapon;

    [SerializeField]
    public GameObject[] weapon = new GameObject[4]; //武器を格納

    bool trigger = true; //武器の作成と破棄の切り替え 
    int weaponNumber;    //武器の種類
    int weaponType = 0;  //武器を指定するための数値

    public GameObject nowWeapon;
    int createNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        weaponNumber = weapon.Length;
        createNum = weapon[weaponType].GetComponent<weapon>().parametor.dotNum;
        this.gameObject.transform.LookAt(GameObject.Find("Tower").transform);
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
            WeaponChoice("a");
        }
        if (Input.GetKeyDown("joystick 1 button 5"))
        {
            WeaponChoice("s");
        }
        if (Input.GetKeyDown("joystick 1 button 7"))
        {
            WeaponChoice("d"); 
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
        /*
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
        */
    }/// <summary>
     /// コントローラーのボタンが押された時の各判定
     /// </summary>
    private void WeaponChoice(string str)
    {
        switch (str)
        {
            case "a":
                if (trigger && DotManager.instance.DotPonCreate(GetComponent<Player>(), createNum))
                {
                    GetComponent<Animator>().SetTrigger("Create");
                    weapon[3].SetActive(false);
                    weapon[weaponType].SetActive(true);
                    nowWeapon = weapon[weaponType];
                    nowWeapon.GetComponent<BoxCollider>().enabled = false;
                    trigger = false;
                }
                else
                {
                    //作成した武器を破棄

                    nowWeapon.SetActive(false);
                    weapon[3].SetActive(true);
                    nowWeapon = weapon[3];
                    trigger = true;
                }
                break;

            //作成する武器の切り替え
            case "s":
                weaponType += 1;
                if (weaponType == weaponNumber -1)
                {
                    weaponType = 0;
                }
                createNum = weapon[weaponType].GetComponent<weapon>().parametor.dotNum;
                //Debug.Log(weaponType);
                break;

            //作成する武器の切り替え
            case "d":
                if (weaponType > 0)
                {
                    weaponType -= 1;
                    //Debug.Log(weaponType);
                }
                else if (weaponType == 0)
                {
                    weaponType = weaponNumber - 2;
                    //Debug.Log(weaponType);
                }
                createNum = weapon[weaponType].GetComponent<weapon>().parametor.dotNum;
                break;
        }
    }

    /// <summary>
    /// 武器を表示非表示
    /// </summary>
    public void CreateWeapon()
    {
        if (trigger)
        {
            weapon[weaponNumber].SetActive(true);
            trigger = false;
        }
        else
        {
            //作成した武器を破棄
            weapon[weaponNumber].SetActive(false);
            trigger = true;
        }
    }

    ///// <summary>
    ///// 表示させる武器を変えるプラス方向)
    ///// </summary>
    //public void ChangeWeaponPlus()
    //{
    //    weaponType += 1;
    //    if (weaponType == weaponNumber)
    //    {
    //        weaponType = 0;
    //    }
    //    Debug.Log(weaponType);
    //}

    ///// <summary>
    ///// 表示させる武器を変える(マイナス方向)
    ///// </summary>
    //public void ChangeWeaponMinus()
    //{
    //    if (weaponType > 0)
    //    {
    //        weaponType -= 1;
    //        Debug.Log(weaponType);
    //    }
    //    else if (weaponType == 0)
    //    {
    //        weaponType = weaponNumber - 1;
    //        Debug.Log(weaponType);
    //    }
    //}
    //void PlayerMove(Vector3 vec)
    //{
    //    GetComponent<Rigidbody>().velocity += vec;
    //}
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
        nowWeapon.gameObject.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        nowWeapon.gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.12f);
        isAttack = false;
        yield break;
    }
    void AttackColliderOn()
    {
        isAttack = true;
        GetComponent<Animator>().SetTrigger("Attack");
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

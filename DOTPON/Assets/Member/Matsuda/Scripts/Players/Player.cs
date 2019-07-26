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
    bool trigger; 

    //遠距離攻撃の武器
    [SerializeField] GameObject farAtkWeapon;
    //遠距離攻撃の距離
    int farAtkDistance = 3;

    public bool isAction;
    bool shieldCheck = false;  //盾を構えているか構えていないかのフラグ

    // コントローラーに対応する番号
    int padNum;

    Animator animator;
    WeaponCreate create;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        switch (own)
        {
            case PlayerKind.Player1:
                hp = MultiPlayerManager.instance.P1Dot;
                break;
            case PlayerKind.Player2:
                hp = MultiPlayerManager.instance.P2Dot;
                break;
            case PlayerKind.Player3:
                hp = MultiPlayerManager.instance.P3Dot;
                break;
            case PlayerKind.Player4:
                hp = MultiPlayerManager.instance.P4Dot;
                break;
            default:
                Debug.LogError("よばれちゃいけんのやぞ");
                break;
        }
        padNum = (int)own+1;
        //weaponNumber = weapon.Length;
        //createNum = weapon[weaponType].GetComponent<weapon>().parametor.dotNum;
        create = GetComponent<WeaponCreate>();
        //this.gameObject.transform.LookAt(GameObject.Find("Tower").transform);
    }

    // Update is called once per frame
    void Update()
    {
        KeyInout();
        //Move();
        
    }
    void KeyInout()
    {
        if (isAction) return;
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
        //盾を構えてい時ボタンを離したらIdlingに戻す
        if(shieldCheck == true)
        {
            if (Input.GetKeyUp("joystick " + padNum + " button 1"))
            {
                shieldCheck = false;
                GetComponent<MoveController>().shieldStart(false);
                animator.SetTrigger("ShieldGuard");
            }            
        }        
        if (Input.GetKeyUp("joystick " + padNum + " button 1"))
        {
            animator.SetTrigger("ShieldGuard");
        }
        if (Input.GetKeyDown("joystick " + padNum + " button 1"))
        {
            AttackColliderOn();
            Debug.Log("At");
        }
        if (Input.GetKeyDown("joystick " + padNum + " button 2"))
        {
            create.WeaponChoice("a");
        }
        if (Input.GetKeyDown("joystick " + padNum + " button 3"))
        {
            create.WeaponChoice("s");
        }
        if (Input.GetKeyDown("joystick " + padNum + " button 0"))
        {
            create.WeaponChoice("d"); 
        }
        if (Input.GetKeyDown("joystick " + padNum + " button 7")&&trigger)
        {
            // Towerでスターの生成
            switch (own)
            {
                case PlayerKind.Player1:
                    if (!DotManager.instance.DotPonCreate(GetComponent<Player>(), 10)) return;
                    MultiPlayerManager.instance.P1Star++;
                    StarInit();
                    //Debug.Log(MultiPlayerManager.instance.P1Dot);
                    break;
                case PlayerKind.Player2:
                    if (!DotManager.instance.DotPonCreate(GetComponent<Player>(), 10)) return;
                    MultiPlayerManager.instance.P2Star++;
                    StarInit();
                    //Debug.Log(MultiPlayerManager.instance.P2Dot);
                    break;
                case PlayerKind.Player3:
                    if (!DotManager.instance.DotPonCreate(GetComponent<Player>(), 10)) return;
                    MultiPlayerManager.instance.P3Star++;
                    StarInit();
                    //Debug.Log(MultiPlayerManager.instance.P3Dot);
                    break;
                case PlayerKind.Player4:
                    if (!DotManager.instance.DotPonCreate(GetComponent<Player>(), 10)) return;
                    MultiPlayerManager.instance.P4Star++;
                    StarInit();
                    //Debug.Log(MultiPlayerManager.instance.P4Dot);
                    break;
                default:
                    Debug.LogError("よばれちゃいけんのやぞ");
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AttackColliderOn();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            create.WeaponChoice("a");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            create.WeaponChoice("s");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            create.WeaponChoice("d");
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

        if (Input.GetKeyDown(KeyCode.Space) && trigger)
        {
            // Towerでスターの生成
            switch (own)
            {
                case PlayerKind.Player1:
                    if (!DotManager.instance.DotPonCreate(GetComponent<Player>(), 10)) return;
                    MultiPlayerManager.instance.P1Star++;
                    StarInit();
                    //Debug.Log(MultiPlayerManager.instance.P1Dot);
                    break;
                case PlayerKind.Player2:
                    if (!DotManager.instance.DotPonCreate(GetComponent<Player>(), 10)) return;
                    MultiPlayerManager.instance.P2Star++;
                    StarInit();
                    //Debug.Log(MultiPlayerManager.instance.P2Dot);
                    break;
                case PlayerKind.Player3:
                    if (!DotManager.instance.DotPonCreate(GetComponent<Player>(), 10)) return;
                    MultiPlayerManager.instance.P3Star++;
                    StarInit();
                    //Debug.Log(MultiPlayerManager.instance.P3Dot);
                    break;
                case PlayerKind.Player4:
                    if (!DotManager.instance.DotPonCreate(GetComponent<Player>(), 10)) return;
                    MultiPlayerManager.instance.P4Star++;
                    StarInit();
                    //Debug.Log(MultiPlayerManager.instance.P4Dot);
                    break;
                default:
                    Debug.LogError("よばれちゃいけんのやぞ");
                    break;
            }
        }
    }
    private void StarInit()
    {
        GameObject obj = StarManager.instance.InstanceStar();
        obj.GetComponent<Move>().enabled = false;
        obj.GetComponent<Star>().DestroyObject(this.transform);
    }


    /// <summary>
    /// プレイヤーがダメージを受けた時の処理
    /// </summary>
    /// <param name="damage">ダメージ量</param>
    public void Damage(int damage)
    {
        if (isDamage) return;
        int hp = 0;
        switch (own)
        {
            case PlayerKind.Player1:
                hp = MultiPlayerManager.instance.P1Dot -= damage;
                
                //Debug.Log(MultiPlayerManager.instance.P1Dot);
                break;
            case PlayerKind.Player2:
                hp = MultiPlayerManager.instance.P2Dot -= damage;
                
                //Debug.Log(MultiPlayerManager.instance.P2Dot);
                break;
            case PlayerKind.Player3:
                hp = MultiPlayerManager.instance.P3Dot -= damage;
                
                //Debug.Log(MultiPlayerManager.instance.P3Dot);
                break;
            case PlayerKind.Player4:
                hp = MultiPlayerManager.instance.P4Dot -= damage;
                
                //Debug.Log(MultiPlayerManager.instance.P4Dot);
                break;
            default:
                Debug.LogError("よばれちゃいけんのやぞ");
                break;
        }
        DotManager.instance.EnemyDeadDotPop(damage,transform.position);
        Debug.Log(hp);
        if (hp <= 0)
        {
            //HPが0になったとき
            isAction = false;
            create.ResetWeapon();
            StarManager.instance.DeadStarDrop(transform.position,own);
            GameObject.Find("PlayerSetting").GetComponent<StartGame>().RespornPlayer(this.gameObject);
        }
        else
        {
            isDamage = true;
            Debug.Log(this.gameObject.name + "が" + damage + "ダメージ受けた\nのこり体力" + hp);
            StartCoroutine(DamegeWait());
            animator.SetTrigger("Hit");
            //animator.SetBool("Trigger" ,isAction);
            //shieldCheck = false;
        }
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
        yield return new WaitForSeconds(0.3f);
        isAction = false;
        yield break;
    }
    /// <summary>
    /// 遠距離攻撃用のコルーチン
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    IEnumerator FarAttackWait(GameObject obj)
    {
        yield return new WaitForSeconds(0.65f);
        obj.GetComponent<FarAttack>().PosMove2(farAtkDistance);
        isAction = false;
    }


    /// <summary>
    /// なにかアクションしたとき
    /// </summary>
    /// <returns></returns>
    public IEnumerator ActionWait(float time)
    {
        yield return new WaitForSeconds(time);
        isAction = false;
        yield break;
    }
    void AttackColliderOn()
    {
        isAction = true;
        Debug.Log(create.nowWeapon.name);
        switch (create.nowWeapon.name)
        {
            case "Axe": animator.SetTrigger("AxAttack"); break;
            case "sword": animator.SetTrigger("SwordAttack"); break;
            case "bomb":animator.SetTrigger("BombAttack");
                var obj = Instantiate(create.nowWeapon, this.transform.position, Quaternion.identity);
                obj.transform.parent = this.gameObject.transform;
                StartCoroutine(FarAttackWait(obj));
                break;
            case "Shield":
                shieldCheck = true;
                GetComponent<MoveController>().shieldStart(true);
                animator.SetTrigger("ShieldAttack");                
                break;
            default: animator.SetTrigger("SwordAttack"); break;

        }
        //if (true/*create.nowWeapon.name == "Axe" || create.nowWeapon.name == "punch"*/)
        //{
        //    //腕振るほう
        //    GetComponent<Animator>().SetTrigger("SwordAttack");
        //}/*else if (create.nowWeapon.name == "Katana" || create.nowWeapon.name == "sword")
        //{
        //    //上段切りみたいなの
        //    GetComponent<Animator>().SetTrigger("Attack2");
        //}*/
        if (create.nowWeapon.name == "bomb")
        {
            create.DownDursble();
            return;
        }
        StartCoroutine(AttackWait());
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Dot")
        {
            switch (own)
            {
                case PlayerKind.Player1:
                    hp = MultiPlayerManager.instance.P1Dot++;
                    //Debug.Log(MultiPlayerManager.instance.P1Dot);
                    break;
                case PlayerKind.Player2:
                    hp = MultiPlayerManager.instance.P2Dot++;
                    //Debug.Log(MultiPlayerManager.instance.P2Dot);
                    break;
                case PlayerKind.Player3:
                    hp = MultiPlayerManager.instance.P3Dot++;
                    //Debug.Log(MultiPlayerManager.instance.P3Dot);
                    break;
                case PlayerKind.Player4:
                    hp = MultiPlayerManager.instance.P4Dot++;
                    //Debug.Log(MultiPlayerManager.instance.P4Dot);
                    break;
                default:
                    Debug.LogError("よばれちゃいけんのやぞ");
                    break;
            }
            other.GetComponent<Dot>().DestroyObject();
        }
        if (other.gameObject.tag == "Star")
        {
            switch (own)
            {
                case PlayerKind.Player1:
                    MultiPlayerManager.instance.P1Star++;
                    //Debug.Log(MultiPlayerManager.instance.P1Dot);
                    break;
                case PlayerKind.Player2:
                    MultiPlayerManager.instance.P2Star++;
                    //Debug.Log(MultiPlayerManager.instance.P2Dot);
                    break;
                case PlayerKind.Player3:
                    MultiPlayerManager.instance.P3Star++;
                    //Debug.Log(MultiPlayerManager.instance.P3Dot);
                    break;
                case PlayerKind.Player4:
                    MultiPlayerManager.instance.P4Star++;
                    //Debug.Log(MultiPlayerManager.instance.P4Dot);
                    break;
                default:
                    Debug.LogError("よばれちゃいけんのやぞ");
                    break;
            }
            other.GetComponent<Move>().enabled = false;
            other.GetComponent<Star>().DestroyObject(this.transform);
        }
        if (other.gameObject.tag == "Tower")
        {
            trigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tower")
        {
            trigger = false;
        }
    }

}

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
    AnimatorStateInfo animInfo;
    WeaponCreate create;

    //colorScriptにアタッチ
    ColorScript colorScript;

    //SE類
    [SerializeField]AudioClip[] clips;
    AudioSource audio;
    [SerializeField]
    GameObject crown;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        colorScript = GetComponent<ColorScript>();
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
        CrownActive();
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
            if (Input.GetKeyUp("joystick " + padNum + " button 0"))
            {
                shieldCheck = false;
                GetComponent<MoveController>().shieldStart(false);
                animator.SetTrigger("ShieldGuard");
                Debug.LogError("ちゃんときた");
            }            
        }        
        if (Input.GetKeyUp("joystick " + padNum + " button 1"))
        {
            animator.SetTrigger("ShieldGuard");
        }
        if (Input.GetKeyDown("joystick " + padNum + " button 2"))
        {
            AttackColliderOn();
            Debug.Log("At");
        }
        if (Input.GetKeyDown("joystick " + padNum + " button 3"))
        {
            create.WeaponChoice("a");
        }
        if (Input.GetKeyDown("joystick " + padNum + " button 4"))
        {
            create.WeaponChoice("s");
        }
        if (Input.GetKeyDown("joystick " + padNum + " button 5"))
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
                    //MultiPlayerManager.instance.P1Star++;
                    StarInit();
                    //Debug.Log(MultiPlayerManager.instance.P1Dot);
                    break;
                case PlayerKind.Player2:
                    if (!DotManager.instance.DotPonCreate(GetComponent<Player>(), 10)) return;
                    //MultiPlayerManager.instance.P2Star++;
                    StarInit();
                    //Debug.Log(MultiPlayerManager.instance.P2Dot);
                    break;
                case PlayerKind.Player3:
                    if (!DotManager.instance.DotPonCreate(GetComponent<Player>(), 10)) return;
                    //MultiPlayerManager.instance.P3Star++;
                    StarInit();
                    //Debug.Log(MultiPlayerManager.instance.P3Dot);
                    break;
                case PlayerKind.Player4:
                    if (!DotManager.instance.DotPonCreate(GetComponent<Player>(), 10)) return;
                    //MultiPlayerManager.instance.P4Star++;
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
                    //StarInit();
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
    public void Damage(int damage,int playerNum)
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
        DotManager.instance.EnemyDeadDotPop(damage,transform.position, playerNum);
        Debug.Log(hp);
        if (hp <= 0)
        {
            //HPが0になったとき            
            StartCoroutine(DownPlayer());                       
                        
            //create.ResetWeapon();
            //StarManager.instance.DeadStarDrop(transform.position, own);
            //GameObject.Find("PlayerSetting").GetComponent<StartGame>().RespornPlayer(this.gameObject);
        }
        else
        {
            isDamage = true;
            audio.clip = clips[0];
            audio.Play();
            Debug.Log(this.gameObject.name + "が" + damage + "ダメージ受けた\nのこり体力" + hp);
            StartCoroutine(DamegeWait());
            colorScript.DamagedOn();

            shieldCheck = false;
            GetComponent<MoveController>().shieldStart(false);

            animator.SetTrigger("Hit");
            bool getWeapon = create.nowWeapon.name == "punch";
            animator.SetBool("HoldingWeapon",getWeapon ); //武器を持っているか持っていないかの判定
            //animator.SetBool("Trigger" ,isAction);
            //shieldCheck = false;
        }
    }
    /// <summary>
    /// ダウンした時の処理
    /// </summary>
    /// <returns></returns>
    IEnumerator DownPlayer()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetTrigger("Down");
        yield return new WaitForSeconds(1.5f);        
        isAction = false;
        create.ResetWeapon();
        StarManager.instance.DeadStarDrop(transform.position, own);
        GameObject.Find("PlayerSetting").GetComponent<StartGame>().RespornPlayer(this.gameObject);
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
    IEnumerator AttackWait(float time1,float time2)
    {
        yield return new WaitForSeconds(time1);
        create.nowWeapon.gameObject.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(time2);
        create.nowWeapon.gameObject.GetComponent<BoxCollider>().enabled = false;
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
            case "hammer": animator.SetTrigger("HammerAttack"); break;
            case "sword": animator.SetTrigger("SwordAttack"); break;
            case "katana": animator.SetTrigger("KatanaAttack"); break;
            case "bomb":animator.SetTrigger("BombAttack");
                var obj = Instantiate(create.nowWeapon, this.transform.position, Quaternion.identity);
                obj.transform.parent = this.gameObject.transform;
                StartCoroutine(FarAttackWait(obj));
                break;
            case "Shield":
                shieldCheck = true;
                //GetComponent<MoveController>().shieldStart(true);
                animator.SetTrigger("ShieldAttack");                
                break;
            default: animator.SetTrigger("PunchAttack"); break;

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
        //animInfo = animator.GetCurrentAnimatorStateInfo(0);
        //if (animInfo.normalizedTime > 1.0f) return;
        if (create.nowWeapon.name == "bomb")
        {
            create.DownDursble();
            return;
        }else if (create.nowWeapon.name == "Hammmer" || create.nowWeapon.name == "Axe")
        {
            StartCoroutine(AttackWait(0.8f,0.4f));
        }
        else
        {
            StartCoroutine(AttackWait(0.5f,0.3f));
        }
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Dot")
        {
            if ((int)other.gameObject.GetComponent<Dot>().ownColor == 4 || (int)other.gameObject.GetComponent<Dot>().ownColor == (int)own)
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
    /// <summary>
    /// クラウンをアクティブにする
    /// </summary>
    /// <param name="n"></param>
    public void CrownActive()
    {
        // bit[0] 人数 bit[1] 二進数にした時に一位の人に1がつく
        int[] bit = MultiPlayerManager.instance.FindFirstPlayer();
        
        // 自分のクラウンがセルフだったらまず見えなくする
        if (crown.activeSelf) crown.SetActive(false);

        for (int i = 0;i < 4; i++)
        {
            if (MultiPlayerManager.instance.Ranking[i] == (int)own+1)
            {
                if (MultiPlayerManager.instance.RankingStarNumber()[i] == 0)
                {
                    crown.SetActive(false);
                    return;
                }
            }
        }
        // 一位の人間の人数によって操作を変える
        switch (bit[0])
        {
            // 人数一人の時 bitの数が自分の番号と一緒だったら
            case 1: if (bit[1] != (int)own + 1) return; break;
            // 人数二人の時 bitと自分の番号分シフトした値が一緒だったら
            case 2: if ((bit[1] & 1 << ((int)own)) != 1 << (int)own) return; break;
            // 人数三人の時 人数二人と一緒
            case 3: if ((bit[1] & 1 << ((int)own)) != 1 << (int)own) return; break;
            // 問答無用でOK
            case 4:break;
            // エラー用 DebugErrorでも可
            default:Debug.Log("おかしいぞ");break;
        }
        crown.SetActive(true);
    }

}

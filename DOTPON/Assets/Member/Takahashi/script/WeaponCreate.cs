using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCreate : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapon; //武器を格納
    [SerializeField]
    GameObject[] usedWeapon = new GameObject[3];
    [SerializeField]
    GameObject Punch;

    [SerializeField]GameObject efe;
    [SerializeField] bool trigger = true; //武器の作成と破棄の切り替え 
    int weaponNumber;    //武器の種類
    int weaponType = 0;  //武器を指定するための数値
    
    public GameObject nowWeapon;
    //DTOPON作成に必要な数
    int createNum = 0;
    GameObject DotPonText;
    GameObject DOTPONDursbleUI;
    Pizza pizza;

    //DTOPONの耐久値
    int value;

    Player player;
    Animator animator;

    AudioSource audio;
    [SerializeField]AudioClip[] clips;
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        player = GetComponent<Player>();
        weaponNumber = 3;
        List<GameObject> UI = new List<GameObject>();
        UI = GameObject.Find("PlayerCanvas").GetComponent<UIManager>().saveCanvas;
        foreach (Transform child in UI[(int)player.own].transform)
        {
            if(child.gameObject.name == "P1DOTPON")
            {
                DotPonText = child.gameObject;
                switch (player.own)
                {
                    case Player.PlayerKind.Player1:
                        DotPonText.GetComponent<ChangeDOTPON>().SetTexture(MultiPlayerManager.instance.P1Weapon);
                        UsedWeapon(MultiPlayerManager.instance.P1Weapon);
                        break;
                    case Player.PlayerKind.Player2:
                        DotPonText.GetComponent<ChangeDOTPON>().SetTexture(MultiPlayerManager.instance.P2Weapon);
                        UsedWeapon(MultiPlayerManager.instance.P2Weapon);
                        break;
                    case Player.PlayerKind.Player3:
                        DotPonText.GetComponent<ChangeDOTPON>().SetTexture(MultiPlayerManager.instance.P3Weapon);
                        UsedWeapon(MultiPlayerManager.instance.P3Weapon);
                        break;
                    case Player.PlayerKind.Player4:
                        DotPonText.GetComponent<ChangeDOTPON>().SetTexture(MultiPlayerManager.instance.P4Weapon);
                        UsedWeapon(MultiPlayerManager.instance.P4Weapon);
                        break;
                }
                DotPonText.GetComponent<ChangeDOTPON>().DrubleText(usedWeapon[weaponType].GetComponent<Weapon>().parametor.necessaryDot);
            }
            if (child.gameObject.name == "P1Dursble")
            {
                DOTPONDursbleUI = child.gameObject;
            }
        }
        //switch (player.own)
        //{
        //    case Player.PlayerKind.Player1:
        //        DotPonText = GameObject.Find("P1DOTPON");
        //        DOTPONDursbleUI = GameObject.Find("P1Dursble");
        //        break;
        //    case Player.PlayerKind.Player2:
        //        DotPonText = GameObject.Find("P2DOTPON");
        //        DOTPONDursbleUI = GameObject.Find("P2Dursble");
        //        break;
        //    case Player.PlayerKind.Player3:
        //        DotPonText = GameObject.Find("P3DOTPON");
        //        DOTPONDursbleUI = GameObject.Find("P3Dursble");
        //        break;
        //    case Player.PlayerKind.Player4:
        //        DotPonText = GameObject.Find("P4DOTPON");
        //        DOTPONDursbleUI = GameObject.Find("P4Dursble");
        //        break;
        //}
        foreach(Transform child in DotPonText.transform)
        {
            if(child.gameObject.name == "Pizza")
            {
                pizza = child.gameObject.GetComponent<Pizza>();
            }
        }
        //DotPonText.GetComponent<Text>().text = "選択しているDOTPONは " + weaponName[weaponType];
        createNum = usedWeapon[weaponType].GetComponent<Weapon>().parametor.necessaryDot;
        value = nowWeapon.GetComponent<Weapon>().parametor.durableValue;
        //DotPonText.GetComponent<ChangeDOTPON>().DrubleText(weapon[0].GetComponent<Weapon>().parametor.necessaryDot);
    }
    private void Update()
    {
    }
    /// <summary>
    /// 指定の武器を作成
    /// </summary>
    /*public void Create(int x)
    {        
        fakeWeapon = Instantiate(weapon[x], point.transform.position, Quaternion.identity);            
    }*/

    /// <summary>
    /// コントローラーのボタンが押された時の各判定
    /// </summary>
    public void WeaponChoice(string str)
    {
        switch (str)
        {             
            case "a":
                if(trigger && DotManager.instance.DotPonCreate(player,createNum ))
                {
                    Instantiate(efe, transform.localPosition + new Vector3(0, 2, 0) + transform.right / 2, Quaternion.identity).transform.parent = transform;
                    //GetComponent<Animator>().SetTrigger("Create");
                    animator.SetTrigger("Create");
                    animator.SetBool("HoldingWeapon", false);
                    nowWeapon.SetActive(false);
                    StartCoroutine(CreateWait());
                    nowWeapon = usedWeapon[weaponType];
                    if (nowWeapon != weapon[5])
                    {
                        nowWeapon.GetComponent<BoxCollider>().enabled = false;
                    }
                    value = nowWeapon.GetComponent<Weapon>().parametor.durableValue;
                    trigger = false;
                    player.isAction = true;
                    StartCoroutine(player.ActionWait(2.5f));
                    SEOn(clips[0]);
                    //DOTPONDursbleUI.GetComponent<DOTPONDursble>().SetDursble(value);
                    //pizza.PizzaUI(usedWeapon[weaponType].GetComponent<Weapon>().parametor.necessaryDot);
                }
                else
                {
                    //作成した武器を破棄
                    animator.SetBool("HoldingWeapon", true);
                    nowWeapon.SetActive(false);
                    Punch.SetActive(true);
                    nowWeapon = Punch;
                    value = nowWeapon.GetComponent<Weapon>().parametor.durableValue;
                    trigger = true;
                    if (nowWeapon != Punch)
                    {
                        switch (player.own)
                        {
                            case Player.PlayerKind.Player1:
                                MultiPlayerManager.instance.P1Dot++;
                                break;
                            case Player.PlayerKind.Player2:
                                MultiPlayerManager.instance.P2Dot++;
                                break;
                            case Player.PlayerKind.Player3:
                                MultiPlayerManager.instance.P3Dot++;
                                break;
                            case Player.PlayerKind.Player4:
                                MultiPlayerManager.instance.P4Dot++;
                                break;
                        }
                    }
                    SEOn(clips[1]);
                    //DOTPONDursbleUI.GetComponent<DOTPONDursble>().ResetDursble();
                }
                break;     
                
            //作成する武器の切り替え
            case "s":
                weaponType += 1;
                if (weaponType == weaponNumber)
                {
                    weaponType = 0;
                }
                createNum = usedWeapon[weaponType].GetComponent<Weapon>().parametor.necessaryDot;
                //DotPonText.GetComponent<Text>().text = "選択しているDOTPONは " + weaponName[weaponType];  
                DotPonText.GetComponent<ChangeDOTPON>().DOTPONWheelGame(weaponType,true);
                DotPonText.GetComponent<ChangeDOTPON>().DrubleText(usedWeapon[weaponType].GetComponent<Weapon>().parametor.necessaryDot);
                //pizza.PizzaChange(PlayerDot(), weapon[weaponType].GetComponent<Weapon>().parametor.necessaryDot);
                //DotPonText.GetComponent<ChangeDOTPON>().MoveWheel(weaponType, true);
                Debug.Log(weaponType);
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
                    weaponType = weaponNumber-1;
                    Debug.Log(weaponType);
                }
                //DotPonText.GetComponent<Text>().text = "選択しているDOTPONは " + weaponName[weaponType];  
                DotPonText.GetComponent<ChangeDOTPON>().DOTPONWheelGame(weaponType,false);
                DotPonText.GetComponent<ChangeDOTPON>().DrubleText(usedWeapon[weaponType].GetComponent<Weapon>().parametor.necessaryDot);
                //pizza.PizzaChange(PlayerDot(), weapon[weaponType].GetComponent<Weapon>().parametor.necessaryDot);
                //DotPonText.GetComponent<ChangeDOTPON>().MoveWheel(weaponType, true);
                createNum = usedWeapon[weaponType].GetComponent<Weapon>().parametor.necessaryDot;
                break;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    private int PlayerDot()
    {
        switch (player.own)
        {
            case Player.PlayerKind.Player1:
                return MultiPlayerManager.instance.P1Dot;
            case Player.PlayerKind.Player2:
                return MultiPlayerManager.instance.P2Dot;
            case Player.PlayerKind.Player3:
                return MultiPlayerManager.instance.P3Dot;
            case Player.PlayerKind.Player4:
                return MultiPlayerManager.instance.P4Dot;
            default:return 0;
        }
    }

    /// <summary>
    /// 武器を表示非表示
    /// </summary>
    public void CreateWeapon(){
        if (trigger)
        {
            usedWeapon[weaponNumber].SetActive(true);
            trigger = false;
        }
        else
        {
            //作成した武器を破棄
            animator.SetBool("HoldingWeapon", true);
            usedWeapon[weaponNumber].SetActive(false);
            trigger = true;
        }
    }

    /// <summary>
    /// 表示させる武器を変えるプラス方向)
    /// </summary>
    public void ChangeWeaponPlus()
    {
        weaponType += 1;
        if (weaponType == weaponNumber)
        {
            weaponType = 0;
        }
        Debug.Log(weaponType);
    }

    /// <summary>
    /// 表示させる武器を変える(マイナス方向)
    /// </summary>
    public void ChangeWeaponMinus()
    {
        if (weaponType > 0)
        {
            weaponType -= 1;
            Debug.Log(weaponType);
        }
        else if (weaponType == 0)
        {
            weaponType = weaponNumber - 1;
            Debug.Log(weaponType);
        }
    }
    /// <summary>
    /// 耐久値がダウンした時に呼ばれる関数
    /// </summary>
    public void DownDursble()
    {
        if (nowWeapon == Punch) return;
        value--;
        if (value <= 0)
        {
            animator.SetBool("HoldingWeapon", true);
            nowWeapon.SetActive(false);
            nowWeapon = Punch;
            Punch.SetActive(true);
            Debug.Log("こわれた");
            value = nowWeapon.GetComponent<Weapon>().parametor.durableValue;
            trigger = true;
        }
        else
        {
            Debug.Log("残り耐久値 = " + value);
            animator.SetBool("HoldingWeapon", false);
        }
        //DOTPONDursbleUI.GetComponent<DOTPONDursble>().DownDursbleUI();
        //pizza.PizzaUI(nowWeapon.GetComponent<Weapon>().parametor.durableValue);
    }

    //死んだときに武器を初期化
    public void ResetWeapon()
    {
        animator.SetBool("HoldingWeapon", true);
        nowWeapon.SetActive(false);
        Punch.SetActive(true);
        nowWeapon = Punch;
        value = nowWeapon.GetComponent<Weapon>().parametor.durableValue;
        trigger = true;
    }
    private void UsedWeapon(List<int> num)
    {
        for (int i = 0;i < num.Count;i++)
        {
            usedWeapon[i] = weapon[num[i]];
        }
    }

    IEnumerator CreateWait()
    {
        yield return new WaitForSeconds(0.7f);
        usedWeapon[weaponType].SetActive(true);
    }

    private void SEOn(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }
}

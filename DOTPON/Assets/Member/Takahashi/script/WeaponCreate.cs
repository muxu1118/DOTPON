using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCreate : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapon; //武器を格納
    [SerializeField]
    string[] weaponName = new string[3];
        
    bool trigger = true; //武器の作成と破棄の切り替え 
    int weaponNumber;    //武器の種類
    int weaponType = 0;  //武器を指定するための数値
    
    public GameObject nowWeapon;
    //DTOPON作成に必要な数
    int createNum = 0;
    GameObject DotPonText;
    GameObject DOTPONDursbleUI;

    //DTOPONの耐久値
    int value;

    Player player;


    void Start()
    {
        player = GetComponent<Player>();
        weaponNumber = weapon.Length;
        switch (player.own)
        {
            case Player.PlayerKind.Player1:
                DotPonText = GameObject.Find("P1DOTPON");
                DOTPONDursbleUI = GameObject.Find("P1Dursble");
                break;
            case Player.PlayerKind.Player2:
                DotPonText = GameObject.Find("P2DOTPON");
                DOTPONDursbleUI = GameObject.Find("P2Dursble");
                break;
            case Player.PlayerKind.Player3:
                DotPonText = GameObject.Find("P3DOTPON");
                DOTPONDursbleUI = GameObject.Find("P3Dursble");
                break;
            case Player.PlayerKind.Player4:
                DotPonText = GameObject.Find("P4DOTPON");
                DOTPONDursbleUI = GameObject.Find("P4Dursble");
                break;
        }
        //DotPonText.GetComponent<Text>().text = "選択しているDOTPONは " + weaponName[weaponType];
        createNum = weapon[weaponType].GetComponent<Weapon>().parametor.dotNum;
        value = nowWeapon.GetComponent<Weapon>().parametor.durableValue;
        DotPonText.GetComponent<ChangeDOTPON>().DrubleText(weapon[0].GetComponent<Weapon>().parametor.necessaryDot);
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

                    GetComponent<Animator>().SetTrigger("Create");
                    weapon[6].SetActive(false);
                    weapon[weaponType].SetActive(true);
                    nowWeapon = weapon[weaponType];
                    if (nowWeapon == weapon[5])
                    {
                    }
                    else
                    {
                        nowWeapon.GetComponent<BoxCollider>().enabled = false;
                    }
                    value = nowWeapon.GetComponent<Weapon>().parametor.durableValue;
                    trigger = false;
                    player.isAction = true;
                    StartCoroutine(player.ActionWait(2.5f));
                    DOTPONDursbleUI.GetComponent<DOTPONDursble>().SetDursble(value);
                }
                else
                {
                    //作成した武器を破棄
                    nowWeapon.SetActive(false);
                    weapon[6].SetActive(true);
                    nowWeapon = weapon[6];
                    value = nowWeapon.GetComponent<Weapon>().parametor.durableValue;
                    trigger = true;
                    if (nowWeapon != weapon[6])
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
                    DOTPONDursbleUI.GetComponent<DOTPONDursble>().ResetDursble();
                }
                break;     
                
            //作成する武器の切り替え
            case "s":
                weaponType += 1;
                if (weaponType == weaponNumber - 1)
                {
                    weaponType = 0;
                }
                createNum = weapon[weaponType].GetComponent<Weapon>().parametor.dotNum;
                //DotPonText.GetComponent<Text>().text = "選択しているDOTPONは " + weaponName[weaponType];  
                DotPonText.GetComponent<ChangeDOTPON>().DOTPONWheel(weaponType,true);
                DotPonText.GetComponent<ChangeDOTPON>().DrubleText(weapon[weaponType].GetComponent<Weapon>().parametor.necessaryDot);
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
                    weaponType = weaponNumber - 2;
                    Debug.Log(weaponType);
                }
                //DotPonText.GetComponent<Text>().text = "選択しているDOTPONは " + weaponName[weaponType];  
                DotPonText.GetComponent<ChangeDOTPON>().DOTPONWheel(weaponType,false);
                DotPonText.GetComponent<ChangeDOTPON>().DrubleText(weapon[weaponType].GetComponent<Weapon>().parametor.necessaryDot);
                //DotPonText.GetComponent<ChangeDOTPON>().MoveWheel(weaponType, true);
                createNum = weapon[weaponType].GetComponent<Weapon>().parametor.dotNum;
                break;
        }
    }

    /// <summary>
    /// 武器を表示非表示
    /// </summary>
    public void CreateWeapon(){
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
        if (nowWeapon == weapon[6]) return;
        value--;
        if (value <= 0)
        {
            nowWeapon.SetActive(false);
            nowWeapon = weapon[6];
            weapon[6].SetActive(true);
            Debug.Log("こわれた");
            value = nowWeapon.GetComponent<Weapon>().parametor.durableValue;
        }
        else
        {
            Debug.Log("残り耐久値 = " + value);
        }
        DOTPONDursbleUI.GetComponent<DOTPONDursble>().DownDursbleUI();
    }

    //死んだときに武器を初期化
    public void ResetWeapon()
    {
        nowWeapon.SetActive(false);
        weapon[6].SetActive(true);
        nowWeapon = weapon[6];
        value = nowWeapon.GetComponent<Weapon>().parametor.durableValue;
        trigger = true;
    }
}

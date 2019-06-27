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

    //DTOPONの耐久値
    int value;

    void Start()
    {
        weaponNumber = weapon.Length;
        switch (GetComponent<Player>().own)
        {
            case Player.PlayerKind.Player1:
                DotPonText = GameObject.Find("P1DOTPON");
                break;
            case Player.PlayerKind.Player2:
                DotPonText = GameObject.Find("P2DOTPON");
                break;
            case Player.PlayerKind.Player3:
                DotPonText = GameObject.Find("P3DOTPON");
                break;
            case Player.PlayerKind.Player4:
                DotPonText = GameObject.Find("P4DOTPON");
                break;
        }
        //DotPonText.GetComponent<Text>().text = "選択しているDOTPONは " + weaponName[weaponType];
        createNum = weapon[weaponType].GetComponent<Weapon>().parametor.dotNum;
        value = nowWeapon.GetComponent<Weapon>().parametor.durableValue;
    }
    private void Update()
    {
        WeaponChoice("");
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
        switch (Input.inputString)
        {             
            case "a":
                if(trigger && DotManager.instance.DotPonCreate(GetComponent<Player>(),createNum ))
                {

                    GetComponent<Animator>().SetTrigger("Create");
                    weapon[3].SetActive(false);
                    weapon[weaponType].SetActive(true);
                    nowWeapon = weapon[weaponType];
                    nowWeapon.GetComponent<BoxCollider>().enabled = false;
                    value = nowWeapon.GetComponent<Weapon>().parametor.durableValue;
                    trigger = false;
                }
                else
                {
                    //作成した武器を破棄
                    nowWeapon.SetActive(false);
                    weapon[3].SetActive(true);
                    nowWeapon = weapon[3];
                    value = nowWeapon.GetComponent<Weapon>().parametor.durableValue;
                    trigger = true;
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
        value--;
        if (value <= 0)
        {
            nowWeapon.SetActive(false);
            nowWeapon = weapon[3];
            weapon[3].SetActive(true);
            Debug.Log("こわれた");
            value = nowWeapon.GetComponent<Weapon>().parametor.durableValue;
        }
        else
        {
            Debug.Log("残り耐久値 = " + value);
        }
    }
}

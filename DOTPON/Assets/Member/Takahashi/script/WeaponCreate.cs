using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCreate : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapon; //武器を格納
        
    bool trigger = true; //武器の作成と破棄の切り替え 
    int weaponNumber;    //武器の種類
    int weaponType = 0;  //武器を指定するための数値
    
    public GameObject nowWeapon;
   
    void Start()
    {
        weaponNumber = weapon.Length;
    }
    private void Update()
    {
        WeaponChoice();
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
    private void WeaponChoice()
    {
        switch (Input.inputString)
        {             
            case "a":
                if(trigger)
                {
                    weapon[weaponType].SetActive(true);
                    nowWeapon = weapon[weaponType];
                    trigger = false;
                }
                else
                {
                    //作成した武器を破棄
                    nowWeapon.SetActive(false);
                    trigger = true;
                }                
                break;     
                
            //作成する武器の切り替え
            case "s":
                weaponType += 1;
                if (weaponType == weaponNumber)
                {
                    weaponType = 0;
                }
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
                    weaponType = weaponNumber - 1;
                    Debug.Log(weaponType);
                }
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
}

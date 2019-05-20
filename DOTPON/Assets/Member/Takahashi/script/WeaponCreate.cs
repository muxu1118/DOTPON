using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCreate : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapon;
    [SerializeField]
    Transform point;

    KeyCode _keyCode;
    int p;
    int weaponNumbur = 0;
   
    void Start()
    {
        p = weapon.Length;
    }

    void Update()
    {        

        if (Input.GetKeyDown(KeyCode.A))
        {
            Create(weaponNumbur);
            Debug.Log(weaponNumbur);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            weaponNumbur += 1;
            if (weaponNumbur == p)
            {
                weaponNumbur = 0;
            }
            Debug.Log(weaponNumbur);
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(weaponNumbur > 0)
            {
                weaponNumbur -= 1;
                Debug.Log(weaponNumbur);
            }            
            else if(weaponNumbur == 0)
            {
                weaponNumbur = p;
                Debug.Log(weaponNumbur);
            }        
        }                
    }

    /// <summary>
    /// 指定のDOTPONを作成
    /// </summary>
    private void Create(int x)
    {        
        Instantiate(weapon[x], point.transform.position, Quaternion.identity);            
    }

    private void WeaponChoice()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            weaponNumbur += 1;            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(weaponNumbur > 0)
            {
                weaponNumbur -= 1;
            }            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BUKSelect : MonoBehaviour
{
    enum weapon
    {
        axe = 0,
        katana,
        sword,
        hammar,
        shield,
        bomb
    }
    weapon nowWeapon = 0;

    [HideInInspector] public SelectedUI selectedObj;
    List<GameObject> objs = new List<GameObject>();
    List<int> weapons = new List<int>();
    [SerializeField]
    RawImage[] rawImages;
    [SerializeField]
    Texture[] textures;
    int num;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (nowWeapon == weapon.bomb) nowWeapon = weapon.bomb;
            nowWeapon++;
            GetComponent<ChangeDOTPON>().DOTPONWheel((int)nowWeapon,true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (nowWeapon == weapon.axe) nowWeapon = weapon.bomb;
            nowWeapon--;
            GetComponent<ChangeDOTPON>().DOTPONWheel((int)nowWeapon, false);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (weapons.Count >= 3) return;
            weapons.Add((int)nowWeapon);
            selectedObj.ChangeTexture(weapons.Count - 1,textures[(int)nowWeapon]);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (weapons.Count <= 0) return;
            weapons.RemoveAt(weapons.Count);
            selectedObj.ChangeTexture(weapons.Count, textures[(int)nowWeapon]);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log(num);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log(num);
        }
    }
    
    
}

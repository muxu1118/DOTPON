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

    public enum player
    {
        player1,
        player2,
        player3,
        player4
    }
    // コントローラーに対応する番号
    public player playerNum = 0;
    int padNum ;

    public SelectedUI selectedObj;
    List<GameObject> objs = new List<GameObject>();
    public List<int> weapons = new List<int>();
    [SerializeField]
    RawImage[] rawImages;
    [SerializeField]
    Texture[] textures;
    int num;
    bool isChange;

    [SerializeField]GameObject[] bukis;
    GameObject instantedBuki;
    private void Start()
    {
        padNum = (int)playerNum + 1;
        InstanceBuki();
    }

    private void Update()
    {
        if (Input.GetKeyDown("joystick " + padNum + " button 1"))
        {
            if (weapons.Count <= 0) return;
            weapons.RemoveAt(weapons.Count - 1);
            selectedObj.ChangeTextureDown(weapons.Count);
        }
        if (Input.GetKeyDown("joystick " + padNum + " button 2"))
        {
            foreach (int i in weapons)
            {
                Debug.Log(i + " + " + (int)nowWeapon);
                if (i == (int)nowWeapon) isChange = true;
            }
            if (weapons.Count >= 3 || isChange)
            {
                isChange = false;
                return;
            }
            weapons.Add((int)nowWeapon);
            selectedObj.ChangeTextureUp(weapons.Count, textures[(int)nowWeapon]);
            isChange = false;
        }
        if (Input.GetKeyDown("joystick " + padNum + " button 3"))
        {
            if (nowWeapon == weapon.bomb) nowWeapon = weapon.axe;
            nowWeapon++;
            GetComponent<ChangeDOTPON>().DOTPONWheel((int)nowWeapon, true);
        }
        if (Input.GetKeyDown("joystick " + padNum + " button 0"))
        {
            if (nowWeapon == weapon.axe) nowWeapon = weapon.bomb;
            nowWeapon--;
            GetComponent<ChangeDOTPON>().DOTPONWheel((int)nowWeapon, false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (nowWeapon == weapon.bomb)
            {
                nowWeapon = weapon.axe;
            }
            else
            {
                nowWeapon++;
            }
            GetComponent<ChangeDOTPON>().DOTPONWheel((int)nowWeapon,true);
            InstanceBuki();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (nowWeapon == weapon.axe)
            {
                nowWeapon = weapon.bomb;
            }
            else
            {
                nowWeapon--;
            }
            GetComponent<ChangeDOTPON>().DOTPONWheel((int)nowWeapon, false);
            InstanceBuki();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            foreach (int i in weapons)
            {
                Debug.Log(i + " + " + (int)nowWeapon);
                if (i == (int)nowWeapon) isChange = true;
            }
            if (weapons.Count >= 3 || isChange)
            {
                isChange = false;
                return;
            }
            weapons.Add((int)nowWeapon);
            selectedObj.ChangeTextureUp(weapons.Count,textures[(int)nowWeapon]);
            isChange = false;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (weapons.Count <= 0) return;
            weapons.RemoveAt(weapons.Count-1);
            selectedObj.ChangeTextureDown(weapons.Count);
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
    private void InstanceBuki()
    {
        if (instantedBuki != null)
        {
            Destroy(instantedBuki);
        }
        instantedBuki = Instantiate(bukis[(int)nowWeapon], new Vector3(0,2,0), Quaternion.identity);
    }
    
}

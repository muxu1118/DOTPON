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
    public int[] weapons;
    [SerializeField]
    RawImage[] rawImages;
    [SerializeField]
    Texture[] textures;
    int num;
    bool isChange;
    [SerializeField] Vector3[] pos;
    [SerializeField] Vector3[] pos2;

    [SerializeField]GameObject[] bukis;
    GameObject instantedBuki;

    int BoxNum = 0;
    bool tri;
    private void Start()
    {
        padNum = (int)playerNum + 1;
        InstanceBuki();
        StartCoroutine(RotateBuki());
        selectedObj.BoxChange(BoxNum);
    }

    private void Update()
    {
        if (Input.GetKeyDown("joystick " + padNum + " button 0"))
        {
            if (weapons.Length <= 0) return;
            weapons[BoxNum] = -1;
            selectedObj.ChangeTextureDown(BoxNum);
        }
        if (Input.GetKeyDown("joystick " + padNum + " button 2"))
        {
            foreach (int i in weapons)
            {
                Debug.Log(i + " + " + (int)nowWeapon);
                if (i == (int)nowWeapon) isChange = true;
            }
            if (isChange)
            {
                isChange = false;
                return;
            }
            weapons[BoxNum] = ((int)nowWeapon);
            selectedObj.ChangeTextureUp(BoxNum, textures[(int)nowWeapon]);
            isChange = false;
        }
        if (Input.GetKeyDown("joystick " + padNum + " button 5"))
        {
            if (nowWeapon == weapon.bomb)
            {
                nowWeapon = weapon.axe;
            }
            else
            {
                nowWeapon++;
            }
            GetComponent<ChangeDOTPON>().DOTPONWheel((int)nowWeapon, true);
            InstanceBuki();
        }
        if (Input.GetKeyDown("joystick " + padNum + " button 4"))
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
        if (Input.GetAxisRaw("Horizontal" + padNum + "_left") < -0.9f)
        {
            if (!tri) return;
            if (BoxNum == 2) { BoxNum = -1; }
            BoxNum++;
            selectedObj.BoxChange(BoxNum);
            tri = false;
        }else if (Input.GetAxisRaw("Horizontal" + padNum + "_left") > 0.9f)
        {
            if (!tri) return;
            if (BoxNum == 0) { BoxNum = 3; }
            BoxNum--;
            selectedObj.BoxChange(BoxNum);
            tri = false;
        }
        else
        {
            tri = true;
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
            if (isChange)
            {
                isChange = false;
                return;
            }
            weapons[BoxNum] = ((int)nowWeapon);
            selectedObj.ChangeTextureUp(BoxNum, textures[(int)nowWeapon]);
            isChange = false;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (weapons.Length <= 0) return;
            weapons[BoxNum] = -1;
            selectedObj.ChangeTextureDown(BoxNum);
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
        switch (MultiPlayerManager.instance.totalPlayer)
        {
            case 1:
                instantedBuki = Instantiate(bukis[(int)nowWeapon], new Vector3(-3.75f,0f,3), Quaternion.identity);
                instantedBuki.transform.localScale = instantedBuki.transform.localScale * 2.3f;
                break;
            case 2:
                instantedBuki = Instantiate(bukis[(int)nowWeapon], pos2[padNum-1], Quaternion.identity);
                instantedBuki.transform.localScale = instantedBuki.transform.localScale * 2.3f;
                break;
            case 3:
                instantedBuki = Instantiate(bukis[(int)nowWeapon], pos[padNum-1], Quaternion.identity);
                instantedBuki.transform.localScale = instantedBuki.transform.localScale * 1.8f;
                break;
            case 4:
                instantedBuki = Instantiate(bukis[(int)nowWeapon], pos[padNum-1], Quaternion.identity);
                instantedBuki.transform.localScale = instantedBuki.transform.localScale * 1.8f;
                break;
        }
        if(instantedBuki.name == "Axe(Clone)")
        {
            instantedBuki.transform.localPosition += new Vector3(0,-0.5f,0);
        }

    }
    IEnumerator RotateBuki()
    {
        while (true)
        {
            if (instantedBuki != null)
            {
                instantedBuki.transform.Rotate(0, 30 * Time.deltaTime, 0);
            }
            yield return null;
        }
    }
}

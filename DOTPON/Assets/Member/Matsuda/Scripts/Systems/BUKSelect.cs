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
    
    List<GameObject> objs = new List<GameObject>();
    List<int> weapons = new List<int>();
    [SerializeField]
    RawImage[] rawImages;
    [SerializeField]
    Texture[] textures;
    private void Start()
    {
    }
    int num;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<ChangeDOTPON>().DOTPONWheel(num,true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<ChangeDOTPON>().DOTPONWheel(num, false);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (weapons.Count >= 3) return;
            weapons.Add((int)nowWeapon);
            SetWeapon();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (weapons.Count <= 0) return;
            weapons.RemoveAt(weapons.Count);
            SetWeapon();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            num++;
            Debug.Log(num);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log(num);
            num--;
        }
    }

    void SetWeapon()
    {
        switch (weapons.Count)
        {
            case 0:
                rawImages[0].texture = textures[weapons[0]];
                rawImages[0].color = new Color(1, 1, 1, 1);
                rawImages[1].color = new Color(1, 1, 1, 0);
                break;
            case 1:
                rawImages[1].texture = textures[weapons[1]];
                rawImages[1].color = new Color(1, 1, 1, 1);
                rawImages[2].color = new Color(1, 1, 1, 0);
                break;
            case 2:
                rawImages[2].texture = textures[weapons[2]];
                rawImages[2].color = new Color(1, 1, 1, 1);
                break;
            default:
                rawImages[0].color = new Color(1,1,1,0);
                break;
        }
    }
    
}

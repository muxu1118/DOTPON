using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUKSelect : MonoBehaviour
{
    enum weapon
    {
        axe = 0,
        sword,
        katana,
        shield,
        bomb,
        hammer
    }
    weapon nowWeapon = 0;

    [SerializeField]
    GameObject selectObj;

    List<GameObject> objs = new List<GameObject>();
    List<int> weapons = new List<int>();
    private void Start()
    {
        SetSelectUI();   
    }
    int num;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            objs[0].GetComponent<ChangeDOTPON>().DOTPONWheel(num,true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            objs[0].GetComponent<ChangeDOTPON>().DOTPONWheel(num, false);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (weapons.Count >= 3) return;
            weapons.Add((int)nowWeapon);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (weapons.Count <= 0) return;
            weapons.RemoveAt(weapons.Count);
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

    public void SetSelectUI()
    {
        float screenX = Screen.width;
        int players = MultiPlayerManager.instance.totalPlayer;
        for (int i = 0;i < players;i++)
        {
            objs.Add(Instantiate(selectObj));
            objs[i].transform.parent = this.transform;
            objs[i].GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
        switch (players)
        {
            case 1:
                break;
            case 2:
                objs[0].GetComponent<RectTransform>().localPosition = new Vector3(screenX / 4 - screenX / 2,20,0);
                objs[1].GetComponent<RectTransform>().localPosition = new Vector3(-screenX / 4 + screenX / 2, 20, 0);
                break;
            case 3:
                objs[0].GetComponent<RectTransform>().localPosition = new Vector3(screenX / 5 - screenX / 2, 20, 0);
                objs[1].GetComponent<RectTransform>().localPosition = new Vector3(0, 20, 0);
                objs[2].GetComponent<RectTransform>().localPosition = new Vector3(-screenX / 5 + screenX / 2, 20, 0);
                break;
            case 4:
                objs[0].GetComponent<RectTransform>().localPosition = new Vector3(screenX / 8 - screenX / 2, 20, 0);
                objs[1].GetComponent<RectTransform>().localPosition = new Vector3(-screenX * 5 / 8 + screenX / 2, 20, 0);
                objs[2].GetComponent<RectTransform>().localPosition = new Vector3(screenX * 5 / 8 - screenX / 2, 20, 0);
                objs[3].GetComponent<RectTransform>().localPosition = new Vector3(-screenX / 8 + screenX / 2, 20, 0);
                break;
        }
    }
}

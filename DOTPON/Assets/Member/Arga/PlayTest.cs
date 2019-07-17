using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayTest : MonoBehaviour
{
    public Text number;
    [SerializeField]
    GameObject SelectPanel;
    [SerializeField]
    GameObject StartPanel;
    [SerializeField]
    GameObject WeaponPanel;
    [SerializeField]
    GameObject selectObj;
    [SerializeField]
    GameObject selectedObj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //  number.text = MultiPlayerManager.instance.TotalPlayer.ToString();
    }

    public void PlusPl()
    {
        MultiPlayerManager.instance.totalPlayer++;
    }

    public void MinusPl()
    {
        MultiPlayerManager.instance.totalPlayer--;
    }

    public void singlePlayer()
    {
        MultiPlayerManager.instance.totalPlayer = 1;
        WeaponPanel.SetActive(true);
        SelectPanel.SetActive(false);
        SetSelectUI();
    } 

    public void twoPlayer()
    {
        MultiPlayerManager.instance.totalPlayer = 2;
        WeaponPanel.SetActive(true);
        SelectPanel.SetActive(false);
        SetSelectUI();
    } 

    public void threePlayer()
    {
        MultiPlayerManager.instance.totalPlayer = 3;
        WeaponPanel.SetActive(true);
        SelectPanel.SetActive(false);
        SetSelectUI();
    } 

    public void fourPlayer()
    {
        MultiPlayerManager.instance.totalPlayer = 4;
        WeaponPanel.SetActive(true);
        SelectPanel.SetActive(false);
        SetSelectUI();
    } 

    public void SetSelectUI()
    {
        List<GameObject> objs = new List<GameObject>();
        List<GameObject> selectObjs = new List<GameObject>();
        float screenX = Screen.width;
        float screenY = Screen.height;
        int players = MultiPlayerManager.instance.totalPlayer;
        for (int i = 0; i < players; i++)
        {
            objs.Add(Instantiate(selectObj));
            switch (i)
            {
                case 0:
                    objs[i].GetComponent<BUKSelect>().playerNum = BUKSelect.player.player1;
                    break;
                case 1:
                    objs[i].GetComponent<BUKSelect>().playerNum = BUKSelect.player.player2;
                    break;
                case 2:
                    objs[i].GetComponent<BUKSelect>().playerNum = BUKSelect.player.player3;
                    break;
                case 3:
                    objs[i].GetComponent<BUKSelect>().playerNum = BUKSelect.player.player4;
                    break;
            }
            objs[i].transform.parent = GameObject.Find("WeaponPanel").transform;
            objs[i].GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            selectObjs.Add(Instantiate(selectedObj));
            selectObjs[i].name = "P" + i + "Select";
            selectObjs[i].transform.parent = GameObject.Find("WeaponPanel").transform;
            objs[i].GetComponent<BUKSelect>().selectedObj = selectObjs[i].GetComponent<SelectedUI>();
        }
        switch (players)
        {
            case 1:
                objs[0].GetComponent<RectTransform>().localPosition = new Vector3(0, screenY * 2 / 3 - screenY / 2, 0);
                selectObjs[0].GetComponent<RectTransform>().localPosition = new Vector3(0, screenY * 4 / 5 -screenY / 2, 0);
                break;
            case 2:
                objs[0].GetComponent<RectTransform>().localPosition = new Vector3(screenX / 4 - screenX / 2, 100, 0);
                objs[1].GetComponent<RectTransform>().localPosition = new Vector3(-screenX / 4 + screenX / 2, 100, 0);
                
                selectObjs[0].GetComponent<RectTransform>().localPosition = new Vector3(screenX / 4 - screenX / 2, 200, 0);
                selectObjs[1].GetComponent<RectTransform>().localPosition = new Vector3(-screenX / 4 + screenX / 2, 200, 0);
                break;
            case 3:
                objs[0].GetComponent<RectTransform>().localPosition = new Vector3(screenX / 5 - screenX / 2,100 , 0);
                objs[1].GetComponent<RectTransform>().localPosition = new Vector3(0, 100, 0);
                objs[2].GetComponent<RectTransform>().localPosition = new Vector3(-screenX / 5 + screenX / 2, 100, 0);

                selectObjs[0].GetComponent<RectTransform>().localPosition = new Vector3(screenX / 5 - screenX / 2, 200, 0);
                selectObjs[1].GetComponent<RectTransform>().localPosition = new Vector3(0, 200, 0);
                selectObjs[2].GetComponent<RectTransform>().localPosition = new Vector3(-screenX / 5 + screenX / 2, 200, 0);
                break;
            case 4:
                objs[0].GetComponent<RectTransform>().localPosition = new Vector3(screenX / 8 - screenX / 2, 100, 0);
                objs[1].GetComponent<RectTransform>().localPosition = new Vector3(-screenX * 5 / 8 + screenX / 2, 100, 0);
                objs[2].GetComponent<RectTransform>().localPosition = new Vector3(screenX * 5 / 8 - screenX / 2, 100, 0);
                objs[3].GetComponent<RectTransform>().localPosition = new Vector3(-screenX / 8 + screenX / 2, 100, 0);

                selectObjs[0].GetComponent<RectTransform>().localPosition = new Vector3(screenX / 8 - screenX / 2, 300, 0);
                selectObjs[1].GetComponent<RectTransform>().localPosition = new Vector3(-screenX * 5 / 8 + screenX / 2, 300, 0);
                selectObjs[2].GetComponent<RectTransform>().localPosition = new Vector3(screenX * 5 / 8 - screenX / 2, 300, 0);
                selectObjs[3].GetComponent<RectTransform>().localPosition = new Vector3(-screenX / 8 + screenX / 2, 300, 0);
                break;
        }
    }

    public void GameStartButton()
    {
        bool trigger = false;
        BUKSelect[] select = WeaponPanel.GetComponentsInChildren<BUKSelect>();
        for (int i = 0;i < MultiPlayerManager.instance.totalPlayer;i++)
        {
            if (select[i].weapons.Count == 3) {
                trigger = true;
                switch (i)
                {
                    case 0:
                        MultiPlayerManager.instance.P1Weapon = select[i].weapons;
                        break;
                    case 1:
                        MultiPlayerManager.instance.P2Weapon = select[i].weapons;
                        break;
                    case 2:
                        MultiPlayerManager.instance.P3Weapon = select[i].weapons;
                        break;
                    case 3:
                        MultiPlayerManager.instance.P4Weapon = select[i].weapons;
                        break;
                }
            }
        }
        if (trigger)
        {
            FadeManager.Instance.LoadScene("Main",1.0f);
        }
    }

    public void backButton()
    {
        FadeManager.Instance.LoadScene("StartScene",1.0f);
    }
    public void ResultButton()
    {
        SceneManager.LoadScene(2);
    }
    public void StartButton()
    {
        StartPanel.SetActive(false);
        SelectPanel.SetActive(true);
    }

    public void P1PlusDot()
    {
        MultiPlayerManager.instance.P1Dot++;
    }
    public void P2PlusDot()
    {
        MultiPlayerManager.instance.P2Dot++;
    }

    public void P3PlusDot()
    {
        MultiPlayerManager.instance.P3Dot++;
    }

    public void P4PlusDot()
    {
        MultiPlayerManager.instance.P4Dot++;
    }

    public void P1PlusStar()
    {
        MultiPlayerManager.instance.P1Star++;
    }

    public void P2PlusStar()
    {
        MultiPlayerManager.instance.P2Star++;
    }

    public void P3PlusStar()
    {
        MultiPlayerManager.instance.P3Star++;
    }

    public void P4PlusStar()
    {
        MultiPlayerManager.instance.P4Star++;
    }


}

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
    GameObject player;
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
                    objs[i].GetComponentInChildren<BUKSelect>().playerNum = BUKSelect.player.player1;
                    break;
                case 1:
                    objs[i].GetComponentInChildren<BUKSelect>().playerNum = BUKSelect.player.player2;
                    break;
                case 2:
                    objs[i].GetComponentInChildren<BUKSelect>().playerNum = BUKSelect.player.player3;
                    break;
                case 3:
                    objs[i].GetComponentInChildren<BUKSelect>().playerNum = BUKSelect.player.player4;
                    break;
            }
            objs[i].transform.parent = GameObject.Find("WeaponPanel").transform;
            objs[i].GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            selectObjs.Add(objs[i].GetComponentInChildren<ChangeDOTPON>().gameObject);
            selectObjs[i].name = "P" + i + "Select";
            objs[i].GetComponentInChildren<BUKSelect>().selectedObj = objs[i].GetComponentInChildren<SelectedUI>();
        }
        switch (players)
        {
            case 1:
                objs[0].GetComponent<RectTransform>().localPosition = new Vector3(0, 50, 0);
                Instantiate(player, new Vector3(0, 1, 0), Quaternion.identity).name = "Player1";
                break;
            case 2:

                var obj1 = Instantiate(player, new Vector3(2f,1, 0), Quaternion.identity);
                var obj2 = Instantiate(player, new Vector3(-2f, 1, 0), Quaternion.identity);
                obj1.name = "Player1";
                obj2.name = "Player2";
                objs[0].GetComponent<RectTransform>().localPosition = new Vector3(Camera.main.WorldToScreenPoint(obj1.transform.position).x - screenX / 2, 50, 0);
                objs[1].GetComponent<RectTransform>().localPosition = new Vector3(Camera.main.WorldToScreenPoint(obj2.transform.position).x - screenX / 2, 50, 0);
                Debug.Log(Camera.main.WorldToScreenPoint(obj1.transform.position) + " & " + Camera.main.ScreenToWorldPoint(obj1.transform.position));
                Debug.Log(Camera.main.WorldToScreenPoint(obj2.transform.position) + " & " + Camera.main.ScreenToWorldPoint(obj2.transform.position));
                break;
            case 3:
                objs[0].GetComponent<RectTransform>().localPosition = new Vector3(screenX / 5,50 , 0);
                objs[1].GetComponent<RectTransform>().localPosition = new Vector3(0, 50, 0);
                objs[2].GetComponent<RectTransform>().localPosition = new Vector3(-screenX / 5, 50, 0);
                objs[0].transform.localScale = objs[0].transform.localScale * 0.8f;
                objs[1].transform.localScale = objs[1].transform.localScale * 0.8f;
                objs[2].transform.localScale = objs[2].transform.localScale * 0.8f;

                var obj3 = Instantiate(player, new Vector3(3f, 1, 0), Quaternion.identity);
                var obj4 = Instantiate(player, new Vector3(0, 1, 0), Quaternion.identity);
                var obj5 = Instantiate(player, new Vector3(-3f, 1, 0), Quaternion.identity);
                obj3.name = "Player1";
                obj4.name = "Player2";
                obj5.name = "Player3";
                objs[0].GetComponent<RectTransform>().localPosition = new Vector3(Camera.main.WorldToScreenPoint(obj3.transform.position).x - screenX / 2, 50, 0);
                objs[1].GetComponent<RectTransform>().localPosition = new Vector3(Camera.main.WorldToScreenPoint(obj4.transform.position).x - screenX / 2, 50, 0);
                objs[2].GetComponent<RectTransform>().localPosition = new Vector3(Camera.main.WorldToScreenPoint(obj5.transform.position).x - screenX / 2, 50, 0);
                Debug.Log(Camera.main.WorldToScreenPoint(obj3.transform.position) + " & " + Camera.main.ScreenToWorldPoint(obj3.transform.position));
                Debug.Log(Camera.main.WorldToScreenPoint(obj4.transform.position) + " & " + Camera.main.ScreenToWorldPoint(obj4.transform.position));
                Debug.Log(Camera.main.WorldToScreenPoint(obj5.transform.position) + " & " + Camera.main.ScreenToWorldPoint(obj5.transform.position));
                break;
            case 4:
                objs[0].GetComponent<RectTransform>().localPosition = new Vector3(screenX / 8, 50, 0);
                objs[1].GetComponent<RectTransform>().localPosition = new Vector3(-screenX * 5 / 8, 50, 0);
                objs[2].GetComponent<RectTransform>().localPosition = new Vector3(screenX * 5 / 8, 50, 0);
                objs[3].GetComponent<RectTransform>().localPosition = new Vector3(-screenX / 8, 50, 0);
                objs[0].transform.localScale = objs[0].transform.localScale * 0.6f;
                objs[1].transform.localScale = objs[1].transform.localScale * 0.6f;
                objs[2].transform.localScale = objs[2].transform.localScale * 0.6f;
                objs[3].transform.localScale = objs[3].transform.localScale * 0.6f;

                var obj6 = Instantiate(player, new Vector3(3f, 1, 0), Quaternion.identity);
                var obj7 = Instantiate(player, new Vector3(1, 1, 0), Quaternion.identity);
                var obj8 = Instantiate(player, new Vector3(-1f, 1, 0), Quaternion.identity);
                var obj9 = Instantiate(player, new Vector3(-3, 1, 0), Quaternion.identity);
                obj6.name = "Player1";
                obj7.name = "Player2";
                obj8.name = "Player3";
                obj9.name = "Player4";
                objs[0].GetComponent<RectTransform>().localPosition = new Vector3(Camera.main.WorldToScreenPoint(obj6.transform.position).x - screenX / 2, 50, 0);
                objs[1].GetComponent<RectTransform>().localPosition = new Vector3(Camera.main.WorldToScreenPoint(obj7.transform.position).x - screenX / 2, 50, 0);
                objs[2].GetComponent<RectTransform>().localPosition = new Vector3(Camera.main.WorldToScreenPoint(obj8.transform.position).x - screenX / 2, 50, 0);
                objs[3].GetComponent<RectTransform>().localPosition = new Vector3(Camera.main.WorldToScreenPoint(obj9.transform.position).x - screenX / 2, 50, 0);
                Debug.Log(Camera.main.WorldToScreenPoint(obj6.transform.position) + " & " + Camera.main.ScreenToWorldPoint(obj6.transform.position));
                Debug.Log(Camera.main.WorldToScreenPoint(obj7.transform.position) + " & " + Camera.main.ScreenToWorldPoint(obj7.transform.position));
                Debug.Log(Camera.main.WorldToScreenPoint(obj8.transform.position) + " & " + Camera.main.ScreenToWorldPoint(obj8.transform.position));
                Debug.Log(Camera.main.WorldToScreenPoint(obj9.transform.position) + " & " + Camera.main.ScreenToWorldPoint(obj9.transform.position));
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

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
    GameObject back;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject hand;
    [SerializeField] float[] poss;

    

    int playerNumber;
    List<Vector2> canvasPosis = new List<Vector2>();
    List<GameObject> saveCanvas = new List<GameObject>();
    float screenX, screenY;

    bool tri;
    // Start is called before the first frame update
    void Start()
    {
        screenX = Screen.width;
        screenY = Screen.height;
        MultiPlayerManager.instance.totalPlayer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick 1 button 9"))
        {
            if(SceneManager.GetActiveScene().name == "StartScene")
            {

                if (StartPanel.active)
                {
                    StartButton();
                }
                else if (SelectPanel.active)
                {
                    PlayerNum();
                }
                else if (WeaponPanel.active)
                {
                    GameStartButton();
                }
            }
            else
            {
                backButton();
            }
        }
        else if (Input.GetAxisRaw("Vertical1_left") > 0.9f)
        {
            if (MultiPlayerManager.instance.totalPlayer == 1 || tri) return;
            MultiPlayerManager.instance.totalPlayer--;
            Debug.Log(MultiPlayerManager.instance.totalPlayer);
            tri = true;
            HandMove();
        }
        else if (Input.GetAxisRaw("Vertical1_left") < -0.9f)
        {
            if (MultiPlayerManager.instance.totalPlayer == 4 || tri) return;
            MultiPlayerManager.instance.totalPlayer++;
            Debug.Log(MultiPlayerManager.instance.totalPlayer);
            tri = true;
            HandMove();
        }else if (Input.GetAxisRaw("Vertical1_left") > -0.9f && Input.GetAxisRaw("Vertical1_left") < 0.9f)
        {
            tri = false;
        }
        //  number.text = MultiPlayerManager.instance.TotalPlayer.ToString();
    }

    private void HandMove()
    {
        hand.transform.localPosition = new Vector3(60,poss[MultiPlayerManager.instance.totalPlayer -1],0);
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
        canvasPosis.Add(new Vector2(0, 0));
        SetSelectUI();
    } 

    public void twoPlayer()
    {
        MultiPlayerManager.instance.totalPlayer = 2;
        WeaponPanel.SetActive(true);
        SelectPanel.SetActive(false);
        canvasPosis.Add(new Vector2(0, 100));
        canvasPosis.Add(new Vector2(0, -100));
        SetSelectUI();
    } 

    public void threePlayer()
    {
        MultiPlayerManager.instance.totalPlayer = 3;
        WeaponPanel.SetActive(true);
        SelectPanel.SetActive(false);
        canvasPosis.Add(new Vector2(-200, 140));
        canvasPosis.Add(new Vector2(200, 140));
        canvasPosis.Add(new Vector2(-200, -80));
        SetSelectUI();
    } 

    public void fourPlayer()
    {
        MultiPlayerManager.instance.totalPlayer = 4;
        WeaponPanel.SetActive(true);
        SelectPanel.SetActive(false);
        canvasPosis.Add(new Vector2(-200, 140));
        canvasPosis.Add(new Vector2(200, 140));
        canvasPosis.Add(new Vector2(-200, -80));
        canvasPosis.Add(new Vector2(200, -80));
        SetSelectUI();
    } 
    private void PlayerNum()
    {
        WeaponPanel.SetActive(true);
        SelectPanel.SetActive(false);
        switch (MultiPlayerManager.instance.totalPlayer)
        {
            case 1:
                canvasPosis.Add(new Vector2(0, 0));
                break;
            case 2:
                canvasPosis.Add(new Vector2(0, 100));
                canvasPosis.Add(new Vector2(0, -100));
                break;
            case 3:
                canvasPosis.Add(new Vector2(-200, 140));
                canvasPosis.Add(new Vector2(200, 140));
                canvasPosis.Add(new Vector2(-200, -80));
                break;
            case 4:
                canvasPosis.Add(new Vector2(-200, 140));
                canvasPosis.Add(new Vector2(200, 140));
                canvasPosis.Add(new Vector2(-200, -80));
                canvasPosis.Add(new Vector2(200, -80));
                break;
            default:
                break;
        }
        SetSelectUI();
    }

    public void SetSelectUI()
    {
        playerNumber = MultiPlayerManager.instance.totalPlayer;
        List<GameObject> objs = new List<GameObject>();
        List<GameObject> selectObjs = new List<GameObject>();
        Debug.Log(screenX+"+"+screenY);
        for (int i = 0; i < playerNumber; i++)
        {
            objs.Add(Instantiate(selectObj,canvasPosis[i],Quaternion.identity));
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
            objs[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(canvasPosis[i].x, canvasPosis[i].y, 0);
            
            objs[i].transform.localScale = new Vector3(0.8f, 0.8f, 1);
            if (playerNumber == 2)
            {
                objs[i].transform.localScale = new Vector3(0.45f, 0.45f, 1);
            }else if(playerNumber >= 3)
            {
                objs[i].transform.localScale = new Vector3(0.4f, 0.4f, 1);
            }
        }
        switch (playerNumber)
        {
            case 1:
                var obj = Instantiate(player, new Vector3(2.5f, 1, 2), Quaternion.identity);
                obj.name = "Player1";
                break;
            case 2:

                var obj1 = Instantiate(player, new Vector3(3f, 2, 0), Quaternion.identity);
                var obj2 = Instantiate(player, new Vector3(-1f, 2, 0), Quaternion.identity);
                obj1.name = "Player1";
                obj2.name = "Player2";
                break;
            case 3:

                var obj3 = Instantiate(player, new Vector3(5f, 1.5f, 0), Quaternion.identity);
                var obj4 = Instantiate(player, new Vector3(-1f, 1.5f, 0), Quaternion.identity);
                var obj5 = Instantiate(player, new Vector3(2.5f, 0, 3), Quaternion.identity);
                obj3.name = "Player1";
                obj4.name = "Player2";
                obj5.name = "Player3";
                obj5.transform.localScale = new Vector3(0.6f, 0.6f, 1);
                break;
            case 4:

                var obj6 = Instantiate(player, new Vector3(5f, 1.5f, 0), Quaternion.identity);
                var obj7 = Instantiate(player, new Vector3(-1f,1.5f,0), Quaternion.identity);
                var obj8 = Instantiate(player, new Vector3(2.8f, 0, 3f), Quaternion.identity);
                var obj9 = Instantiate(player, new Vector3(-0.7f, 0, 3f), Quaternion.identity);
                obj6.name = "Player1";
                obj7.name = "Player2";
                obj8.name = "Player3";
                obj9.name = "Player4";
                obj8.transform.localScale = new Vector3(0.6f, 0.6f, 1);
                obj9.transform.localScale = new Vector3(0.6f, 0.6f, 1);
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
            Cursor.visible = false;
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

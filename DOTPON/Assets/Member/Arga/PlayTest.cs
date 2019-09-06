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

    [SerializeField]
    GameObject cameraObj;
    

    int playerNumber;
    List<Vector2> canvasPosis = new List<Vector2>();
    List<GameObject> saveCanvas = new List<GameObject>();
    float screenX, screenY;
    [SerializeField]
    GameObject[] kyokaisen;

    BUKSelect[] select;
    [SerializeField]GameObject text;
    bool tri;

    bool startTrigger;
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
        
       
        if (Input.GetKeyDown("joystick 1 button 9") || Input.GetKeyDown("joystick 2 button 9") || Input.GetKeyDown("joystick 3 button 9") || Input.GetKeyDown("joystick 4 button 9") || Input.GetKeyDown(KeyCode.Space))
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
        else if (Input.GetAxisRaw("Vertical1_left") > 0.9f || Input.GetAxisRaw("Vertical2_left") > 0.9f || Input.GetAxisRaw("Vertical3_left") > 0.9f || Input.GetAxisRaw("Vertical4_left") > 0.9f)
        {
            if (MultiPlayerManager.instance.totalPlayer == 1 || tri) return;
            MultiPlayerManager.instance.totalPlayer--;
            Debug.Log(MultiPlayerManager.instance.totalPlayer);
            tri = true;
            HandMove();
        }
        else if (Input.GetAxisRaw("Vertical1_left") < -0.9f || Input.GetAxisRaw("Vertical2_left") < -0.9f || Input.GetAxisRaw("Vertical3_left") < -0.9f || Input.GetAxisRaw("Vertical4_left") < -0.9f)
        {
            if (MultiPlayerManager.instance.totalPlayer == 4 || tri) return;
            MultiPlayerManager.instance.totalPlayer++;
            Debug.Log(MultiPlayerManager.instance.totalPlayer);
            tri = true;
            HandMove();
        }else if (Input.GetAxisRaw("Vertical1_left") > -0.9f && Input.GetAxisRaw("Vertical1_left") < 0.9f || Input.GetAxisRaw("Vertical2_left") > -0.9f && Input.GetAxisRaw("Vertical2_left") < 0.9f || Input.GetAxisRaw("Vertical3_left") > -0.9f && Input.GetAxisRaw("Vertical3_left") < 0.9f || Input.GetAxisRaw("Vertical4_left") > -0.9f && Input.GetAxisRaw("Vertical4_left") < 0.9f)
        {
            tri = false;
        }
        //  number.text = MultiPlayerManager.instance.TotalPlayer.ToString();
        if (WeaponPanel.active)
        {
            List<int> trigger = new List<int>();
            bool trig = true;
            for (int i = 0; i < MultiPlayerManager.instance.totalPlayer; i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < 3; j++)
                {
                    list.Add(select[i].weapons[j]);
                    if (list[j] == -1) { trig = false; }
                }

                if (list[0] != list[1] && list[0] != list[2] && list[1] != list[2] && trig)
                {
                    trigger.Add(1);
                    switch (i)
                    {
                        case 0:
                            MultiPlayerManager.instance.P1Weapon = list;
                            break;
                        case 1:
                            MultiPlayerManager.instance.P2Weapon = list;
                            break;
                        case 2:
                            MultiPlayerManager.instance.P3Weapon = list;
                            break;
                        case 3:
                            MultiPlayerManager.instance.P4Weapon = list;
                            break;
                    }
                }
            }
            Debug.Log(trigger.Count);
            if (trigger.Count == MultiPlayerManager.instance.totalPlayer)
            {
                startTrigger = true;
                text.SetActive(true);
            }
            else
            {
                startTrigger = false;
                text.SetActive(false);
            }
        }
    }

    private void HandMove()
    {
        hand.transform.localPosition = new Vector3(45,poss[MultiPlayerManager.instance.totalPlayer -1],0);
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
        canvasPosis.Add(new Vector2(-200, 100));
        canvasPosis.Add(new Vector2(200, 100));
        SetSelectUI();
    } 

    public void threePlayer()
    {
        MultiPlayerManager.instance.totalPlayer = 3;
        WeaponPanel.SetActive(true);
        SelectPanel.SetActive(false);
        canvasPosis.Add(new Vector2(-200, 140));
        canvasPosis.Add(new Vector2(200, 140));
        canvasPosis.Add(new Vector2(-200, -100));
        SetSelectUI();
    } 

    public void fourPlayer()
    {
        MultiPlayerManager.instance.totalPlayer = 4;
        WeaponPanel.SetActive(true);
        SelectPanel.SetActive(false);
        canvasPosis.Add(new Vector2(-200, 140));
        canvasPosis.Add(new Vector2(200, 140));
        canvasPosis.Add(new Vector2(-200, -100));
        canvasPosis.Add(new Vector2(200, -100));
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
                canvasPosis.Add(new Vector2(-200, 100));
                canvasPosis.Add(new Vector2(200, 100));
                break;
            case 3:
                canvasPosis.Add(new Vector2(-200, 140));
                canvasPosis.Add(new Vector2(200, 140));
                canvasPosis.Add(new Vector2(-200, -100));
                break;
            case 4:
                canvasPosis.Add(new Vector2(-200, 140));
                canvasPosis.Add(new Vector2(200, 140));
                canvasPosis.Add(new Vector2(-200, -100));
                canvasPosis.Add(new Vector2(200, -100));
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
            objs.Add(Instantiate(selectObj,canvasPosis[i],Quaternion.identity, GameObject.Find("WeaponPanel").transform));
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
            objs[i].GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            objs[i].GetComponent<RectTransform>().localRotation = new Quaternion(0, 0, 0,0);
            selectObjs.Add(objs[i].GetComponentInChildren<ChangeDOTPON>().gameObject);
            selectObjs[i].name = "P" + i + "Select";
            objs[i].GetComponentInChildren<BUKSelect>().selectedObj = objs[i].GetComponentInChildren<SelectedUI>();
            objs[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(canvasPosis[i].x, canvasPosis[i].y, 0);
            
            objs[i].transform.localScale = new Vector3(0.8f, 0.8f, 1);
            if (playerNumber == 2)
            {
                objs[i].transform.localScale = new Vector3(0.4f, 0.4f, 1);
                kyokaisen[0].SetActive(true);
            }
            else if(playerNumber >= 3)
            {
                objs[i].transform.localScale = new Vector3(0.4f, 0.4f, 1);
                kyokaisen[0].SetActive(true);
                kyokaisen[1].SetActive(true);
            }
             
        }
        switch (playerNumber)
        {
            case 1:
                Vector3[] vec = { new Vector3(3.75f, -1.2f, 2) };
                SetPlayerInstance(1,vec);
                break;
            case 2:
                Vector3[] vec2 = { new Vector3(4f, -1.2f, 1.2f), new Vector3(-4f, -1.2f, 1.2f) };
                SetPlayerInstance(2,vec2);
                break;
            case 3:
                Vector3[] vec3 = { new Vector3(5f, 1.8f, 0), new Vector3(-1f, 1.8f, 0), new Vector3(5f, -1.47f, 0) };
                SetPlayerInstance(3,vec3);
                break;
            case 4:
                Vector3[] vec4 = { new Vector3(5f, 1.8f, 0), new Vector3(-1f, 1.8f, 0), new Vector3(5f, -1.47f, 0), new Vector3(-1f, -1.47f, 0) };
                SetPlayerInstance(4, vec4);
                break;
        }
        select = WeaponPanel.GetComponentsInChildren<BUKSelect>();
    }
    private void SetPlayerInstance(int num,Vector3[] vec)
    {
        List<GameObject> playerObjs = new List<GameObject>();
        for (int i = 0; i < num; i++)
        {
            playerObjs.Add(Instantiate(player, vec[i], Quaternion.identity));
            playerObjs[i].name = "Player" + (i + 1);
            if(num <= 2)
            {
                playerObjs[i].transform.localScale = playerObjs[i].transform.localScale * 1.5f;
            }
        }
    }

    public void GameStartButton()
    {
        if (startTrigger)
        {
            Cursor.visible = false;
            FadeManager.Instance.LoadScene("Main", 1.0f);
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

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
        float screenX = Screen.width;
        int players = MultiPlayerManager.instance.totalPlayer;
        for (int i = 0; i < players; i++)
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
                objs[0].GetComponent<RectTransform>().localPosition = new Vector3(screenX / 4 - screenX / 2, 20, 0);
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

    public void GameStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void backButton()
    {
        SceneManager.LoadScene(0);
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

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    Vector3[] spownPos;
    [SerializeField]
    GameObject playerPrefab;

    [SerializeField]
    GameObject[] DotTextObj;
    [SerializeField]
    GameObject[] StarTextObj;
    [SerializeField]
    GameObject[] BukiUIObj;
    [SerializeField]
    ScreenController screenController;

    [SerializeField]
    GameObject[] cameras;
    // Start is called before the first frame update
    void Start()
    {
        //人数分の回数まわす
        for (int i = 0;i < MultiPlayerManager.instance.totalPlayer;i++)
        {
            //プレイヤーの生成
            var playerObj = Instantiate(playerPrefab, spownPos[i],Quaternion.identity);
            playerObj.name = "Player" + (i + 1);
            //ぷれいやーのenumをそれぞれに対応させる
            playerObj.GetComponent<Player>().own = PlayerEnum(i);
            //カメラのオブジェクトを探して参照させる
            //cameras[i].transform.parent = playerObj.transform;
            cameras[i].GetComponent<CameraMove>().Setting(playerObj);
            DotTextObj[i].SetActive(true);
            StarTextObj[i].SetActive(true);
            BukiUIObj[i].SetActive(true);
        }

        //text.text = screenController.cameras[0].name + " + " + screenController.cameras[1].name + " + " + screenController.cameras[2].name + " + " + screenController.cameras[3].name;
        screenController.CameraNumCheck();
    }
    /// <summary>
    /// 死んだあと復活
    /// </summary>
    /// <returns></returns>
    private IEnumerator RespornPlayerCoroutine(GameObject obj)
    {
        Debug.Log("start");
        obj.SetActive(false);
        obj.transform.position = spownPos[int.Parse(obj.name.Substring(6)) - 1];
        yield return new WaitForSeconds(5.0f);
        Debug.Log("end");
        obj.SetActive(true);
    }

    public void RespornPlayer(GameObject obj)
    {
        StartCoroutine(RespornPlayerCoroutine(obj));
    }
    
    private Player.PlayerKind PlayerEnum(int num)
    {
        switch (num) {
            case 0:
                return Player.PlayerKind.Player1;
            case 1:
                return Player.PlayerKind.Player2;
            case 2:
                return Player.PlayerKind.Player3;
            case 3:
                return Player.PlayerKind.Player4;
            default:
                return Player.PlayerKind.Player1;
        }
        
    }
}

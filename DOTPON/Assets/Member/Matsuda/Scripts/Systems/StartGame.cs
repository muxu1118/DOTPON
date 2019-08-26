using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    //エネミー生成位置の配列
    [SerializeField]
    Vector3[] spownPos;
    //プレイヤーのプレハブ
    [SerializeField]
    GameObject playerPrefab;
    //選択武器表示のUI
    [SerializeField]
    GameObject[] BukiUIObj;
    [SerializeField]
    GameObject[] DursbleUI;
    [SerializeField]
    ScreenController screenController;
    //プレイヤーにアタッチするカメラ
    [SerializeField]
    GameObject[] cameras;

    [SerializeField]
    SpownController SpownClass;
    [SerializeField]
    Timer timer;
    [SerializeField]
    Text text;
    [SerializeField]
    Image[] kyokaisen;

    List<GameObject> players = new List<GameObject>();
    List<MoveController> moveControllers = new List<MoveController>();

    // Start is called before the first frame update
    void Start()
    {
        //人数分の回数まわす
        for (int i = 0;i < MultiPlayerManager.instance.totalPlayer;i++)
        {
            //プレイヤーの生成
            var playerObj = Instantiate(playerPrefab, spownPos[i],Quaternion.identity);
            players.Add(playerObj);
            moveControllers.Add(playerObj.GetComponent<MoveController>());
            playerObj.GetComponent<PlayerMove>().enabled = false;
            playerObj.transform.LookAt(new Vector3(0,0,0));
            playerObj.name = "Player" + (i + 1);
            //ぷれいやーのenumをそれぞれに対応させる
            playerObj.GetComponent<Player>().own = PlayerEnum(i);
            //カメラのオブジェクトを探して参照させる
            //cameras[i].transform.parent = playerObj.transform;
            cameras[i].GetComponent<CameraMove>().Setting(playerObj);
            playerObj.GetComponent<PlayerMove>().cmr = cameras[i].GetComponentInChildren<Camera>();
            DotManager.instance.playerObj.Clear();
            DotManager.instance.playerObj.Add(playerObj);
            //GameObject.Find("P" + i + 1 + "DOTPON").GetComponent<ChangeDOTPON>().SetTexture(MultiPlayerManager.instance.P1Weapon);
            //if(i>=1)
            //kyokaisen[i/2].gameObject.SetActive(true);
        }
        //text.text = screenController.cameras[0].name + " + " + screenController.cameras[1].name + " + " + screenController.cameras[2].name + " + " + screenController.cameras[3].name;
        StartCoroutine(GameStartCoroutine());
        screenController.CameraNumCheck();
        SetStar();
    }
    /// <summary>
    /// 死んだあと復活
    /// </summary>
    /// <returns></returns>
    private IEnumerator RespornPlayerCoroutine(GameObject obj)
    {
        Debug.Log("start");
        obj.SetActive(false);
        int i = int.Parse(obj.name.Substring(6)) - 1;
        obj.transform.position = spownPos[i];
        PlayerEnum(i);
        yield return new WaitForSeconds(5.0f);
        Debug.Log("end");
        obj.SetActive(true);
    }

    /// <summary>
    /// ３，２，１、GO
    /// </summary>
    IEnumerator GameStartCoroutine()
    {
        yield return new WaitForSeconds(4f);
        SpownClass.enabled = true;
        for (int i = 0;i < players.Count;i++)
        {
            players[i].GetComponent<Player>().isAction = false;
            moveControllers[i].GetComponent<PlayerMove>().enabled = true;
        }
    }

    public void RespornPlayer(GameObject obj)
    {
        StartCoroutine(RespornPlayerCoroutine(obj));
    }
    
    private Player.PlayerKind PlayerEnum(int num)
    {
        switch (num) {
            case 0:
                MultiPlayerManager.instance.P1Dot = 10;
                return Player.PlayerKind.Player1;
            case 1:
                MultiPlayerManager.instance.P2Dot = 10;
                return Player.PlayerKind.Player2;
            case 2:
                MultiPlayerManager.instance.P3Dot = 10;
                return Player.PlayerKind.Player3;
            case 3:
                MultiPlayerManager.instance.P4Dot = 10;
                return Player.PlayerKind.Player4;
            default:
                return Player.PlayerKind.Player1;
        }
        
    }
    private void SetStar()
    {
        MultiPlayerManager.instance.P1Star = 0;
        MultiPlayerManager.instance.P2Star = 0;
        MultiPlayerManager.instance.P3Star = 0;
        MultiPlayerManager.instance.P4Star = 0;
    }
}

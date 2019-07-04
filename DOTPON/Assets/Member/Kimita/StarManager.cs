using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : SingletonMonoBehaviour<StarManager>
{
    // マルチプレイヤー

    //今までに作ったStarの数
    int numStar = 0;

    public GameObject starObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StarInstance(Vector3.zero);
        }
    }

    // プレイヤーが死んだらスターを生成
    private void StarInstance(Vector3 vec3)
    {
        Instantiate(starObject, new Vector3(vec3.x, 1, vec3.z), Quaternion.identity);
        
    }


    /// <summary>
    /// スターの出現 (出現される場所と減らすプレイヤー)
    /// </summary>
    public void DeadStarDrop( Vector3 vec3,Player.PlayerKind PK)
    {
        switch (PK)
        {
            case Player.PlayerKind.Player1:
                if (MultiPlayerManager.instance.P1Star > 0)
                {
                    MultiPlayerManager.instance.P1Star--;
                }
                else return;
                break;
            case Player.PlayerKind.Player2:
                if (MultiPlayerManager.instance.P1Star > 0)
                {
                    MultiPlayerManager.instance.P2Star--;
                }
                else return;
                break;
            case Player.PlayerKind.Player3:
                if (MultiPlayerManager.instance.P1Star > 0)
                {
                    MultiPlayerManager.instance.P3Star--;
                }
                else return;
                break;
            case Player.PlayerKind.Player4:
                if (MultiPlayerManager.instance.P1Star > 0)
                {
                    MultiPlayerManager.instance.P4Star--;
                }
                else return;
                break;
            default:
                Debug.LogError("よばれちゃいけんのやぞ");
                break;
        }
        //スター出現させる
        Instantiate(starObject, new Vector3(vec3.x, 1, vec3.z), Quaternion.identity).name = "Star";
    }

    /// <summary>
    /// スターを作成する関数
    /// </summary>
    public void StarCreate(/*MultiPrayerかプレイヤーのスクリプト*/)
    {
        //MultiPrayerから取りたい
        //if(プレイヤーの所持しているドットの数が20以上){//マルチプレイヤーにスターの送信　numStar++;}
    }
}

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
    /// スターを作成する関数
    /// </summary>
    public void StarCreate(/*MultiPrayerかプレイヤーのスクリプト*/)
    {
        //MultiPrayerから取りたい
        //if(プレイヤーの所持しているドットの数が20以上){//マルチプレイヤーにスターの送信　numStar++;}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotManager : SingletonMonoBehaviour<DotManager>
{
    public GameObject dotObj;
    // Dotの持ってる数 配列はプレイヤーの数
    private int[] dotHave = new int[4];
    // 読み取り用
    public int[] DotHave
    {
        get
        {
            return dotHave;
        }
    }
   

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            CheckDot("Player1");
            InstanceDot(2, 3, Vector3.zero);
        }
    }

    /// <summary>
    /// ドットを出現される (数と出現される時間と場所)
    /// </summary>
    /// <param name="dotNum"></param>
    /// <param name="time"></param>
    /// <param name="vec3"></param>
    public void InstanceDot(int dotNum,float time,Vector3 vec3)
    {
        // dotObjのスクリプトを読み込み出現に時間を加える
        // DotScript Dot = dotObj.GetCompoment<DotScript>();
        // Dot.Time = time;

        // 指定の数まで繰り返し
        while (dotNum > 0) {
            // ドットの出現(位置はランダム)
            Instantiate(dotObj, new Vector3(Random.Range(-1f, 1f), 1, Random.Range(-1f, 1f)), Quaternion.identity);
            dotNum--;
        }


    }

    private int PlayerCheck(string name)
    {
        switch (name)
        {
            case "Player1":
                return 1;
            case "Player2":
                return 2;
            case "Player3":
                return 3;
            case "Player4":
                return 4;
            default: break;
        }
        Debug.Log("プレイヤーネームが間違ってます");
        return 0;
    }

    public void CheckDot(string name)
    {
        if (PlayerCheck(name) == 0) return;
        int playerNum = PlayerCheck(name);
        dotHave[playerNum] += 10;

    }

}

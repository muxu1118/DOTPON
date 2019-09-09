using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotManager : SingletonMonoBehaviour<DotManager>
{
    public GameObject dotObj;
    // Dotの持ってる数 配列はプレイヤーの数
    private int[] dotHave = new int[4];
    public List<GameObject> playerObj = new List<GameObject>();
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
        //for (int i = 1; i <= 4; i++)
        //{
        //    playerObj.Add(GameObject.Find("Player" + i));
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            //EnemyDeadDotPop(5,Vector3.zero);
        }
    }

    /// <summary>
    /// ドットを出現される (出現される時間と場所とどのプレイヤーか)
    /// </summary>
    /// <param name="time"></param>
    /// <param name="vec3"></param>
    public void InstanceDot(float time,Vector3 vec3,int num)
    {
        // dotObjのスクリプトを読み込み出現に時間を加える
        // DotScript Dot = dotObj.GetCompoment<DotScript>();
        // Dot.Time = time;
        int count = SendDot();
        // 指定の数まで繰り返し
        while (count > 0) {
            
            // ドットの出現(位置はランダム)
            GameObject target =  Instantiate(dotObj, new Vector3(vec3.x, 1, vec3.z), Quaternion.identity);
            target.name = "Dot";

            dotObj.GetComponent<Dot>().MaterialChange(num,target);
            count--;
        }
    }


    /// <summary>
    /// ドットの数を計算して値を返す
    /// </summary>
    /// <returns></returns>
    public int SendDot()
    {
        int dot= 0,exAtk=1,exDef=0;
        //攻撃力　防御力からドットの数を出す
        dot = exAtk - exDef;
        return dot;

    }

    /// <summary>
    /// 敵が死んだらドットをドロップ
    /// </summary>
    /// <param name="rank"></param>
    public void EnemyDeadDotPop(int rank, Vector3 vec3,int num)
    {

        // 敵によって落とす数の変更
        int count = rank;
        
        // 指定の数まで繰り返し
        while (count > 0)
        {
            // ドットの出現(位置はランダム)

            GameObject target = Instantiate(dotObj, new Vector3(vec3.x, 1, vec3.z), Quaternion.identity);
            target.name = "Dot";
            dotObj.GetComponent<Dot>().MaterialChange(num,target);
            if (num < 4) playerObj[num].GetComponent<Player>().myDotObj.Add(target);
            //Debug.Log("ドット生成");
            count--;
        }
    }

    /// <summary>
    /// ドットポンの作成
    /// </summary>
    /// <param name="player">ドットポンを作成するプレイヤー</param>
    /// <param name="num">減らす数</param>
    public bool DotPonCreate(Player player,int num)
    {
        switch (player.own)
        {
            case Player.PlayerKind.Player1:
                if (MultiPlayerManager.instance.P1Dot < num) return false;
                MultiPlayerManager.instance.P1Dot -= num;
                break;
            case Player.PlayerKind.Player2:
                if (MultiPlayerManager.instance.P2Dot < num) return false;
                MultiPlayerManager.instance.P2Dot -= num;
                break;
            case Player.PlayerKind.Player3:
                if (MultiPlayerManager.instance.P3Dot < num) return false;
                MultiPlayerManager.instance.P3Dot -= num;
                break;
            case Player.PlayerKind.Player4:
                if (MultiPlayerManager.instance.P4Dot < num) return false;
                MultiPlayerManager.instance.P4Dot -= num;
                break;
            default:
                Debug.LogError("よばれちゃいけんのやぞ");
                return false;
        }
        return true;
    }

    public void DeathPlayerDot(List<GameObject> objs)
    {
        Debug.Log("リストの数"+objs.Count);
        for(int i = 0;i < objs.Count; i++)
        {
            if (objs[i] != null)
            {
                Destroy(objs[i].gameObject);
            }
        }
    }

        /*
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
        */

    }

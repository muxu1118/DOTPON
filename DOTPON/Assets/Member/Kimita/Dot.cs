using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    //集まる時間
    [SerializeField]
    private float setTime = 10.0f;
    public enum DotColor
    {
        Red = 0,
        Blue,
        Green,
        Yellow,
        White
    }
    public DotColor ownColor;
    public float LostTime
    {
        get { return LostTime; }
        set { LostTime = value; }
    }
    private BoxCollider box;
    int playerNum;//Playerの番号の保存

   

    private void Start()
    {
        box = GetComponent<BoxCollider>();
        box.enabled = false;
        StartCoroutine(SetDot());
       
    }

    IEnumerator SetDot()
    {
        yield return new WaitForSeconds(setTime);
        StartCoroutine(MoveSetDot(PlayerPositionCatch(playerNum)));
    }
    /// <summary>
    /// ドットがプレイヤーに向かって集まる
    /// </summary>
    /// <returns></returns>
    IEnumerator MoveSetDot(Vector3 vec3)
    {
        yield return new WaitForSeconds(Time.deltaTime);
    }
    /// <summary>
    /// プレイヤーの位置を引数から見つける
    /// </summary>
    /// <returns></returns>
    private Vector3 PlayerPositionCatch(int num)
    {
        return GameObject.Find("Player" + num.ToString()).transform.position;
    } 

    /// <summary>
    /// 当たった時にドットを取得する
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            // 
        }

    }

    // プレイヤーに当たったどっとを破壊する
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// DotのMaterialを変える
    /// </summary>
    public void MaterialChange(int num,GameObject obj)
    {
        ownColor = (DotColor)num;
        playerNum = num;
        // 1赤2青3緑4黄
        switch (num)
        {
            case 0:
                obj.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 1:
                obj.GetComponent<Renderer>().material.color = Color.blue ;
                break;
            case 2:
                obj.GetComponent<Renderer>().material.color = Color.green;
                break;
            case 3:
                obj.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            default:
                obj.GetComponent<Renderer>().material.color = Color.white;
                break;

        }
        

    }
}

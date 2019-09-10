using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    //集まる時間
    [SerializeField]
    private float setTime = 3.0f;
    [SerializeField]
    private float lostTime = 10.0f;
    public Transform m_target = null;
    public float m_speed = 5;
    public float m_attenuation = 0.5f;

    private Vector3 m_velocity;
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
    [SerializeField]
    bool enable = false;
   

    private void Start()
    {
        MaterialChange((int)ownColor, this.gameObject);
        box = GetComponent<BoxCollider>();
        box.enabled = false;
        if (ownColor == DotColor.White) {
            StartCoroutine(LostDot());
            return;
        }
        StartCoroutine(SetDot());
       
    }
    private void Update()
    {
        if (enable)
        {
            m_velocity += (m_target.position - transform.position) * m_speed;
            m_velocity *= m_attenuation;
            transform.position += m_velocity *= Time.deltaTime;
            m_target = DotManager.instance.playerObj[(int)ownColor].transform;
            m_attenuation += Time.deltaTime;
        }
    }
    IEnumerator LostDot()
    {
        yield return new WaitForSeconds(lostTime);
        Destroy(gameObject);
    }
    IEnumerator SetDot()
    {
        yield return new WaitForSeconds(setTime);
        m_target = DotManager.instance.playerObj[(int)ownColor].transform;
        box.enabled = true;
        enable = true;
        GetComponent<Move>().enable = false;
        yield return null;
    }
    /// <summary>
    /// プレイヤーの位置を引数から見つける
    /// </summary>
    /// <returns></returns>
    private Vector3 PlayerPositionCatch(int num)
    {
        return DotManager.instance.playerObj[num].transform.position;
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

    /// <summary>
    /// プレイヤーが死んだときそのプレイヤーの色のドットを破壊する
    /// </summary>
    /// <param name="pn">プレイヤーの番号</param>
    public void DeathPlayerDot(int pn)
    {
        if((int)ownColor == pn)
        {
            Destroy(gameObject);
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
                obj.GetComponent<BoxCollider>().enabled = false;
                obj.GetComponent<Renderer>().material.color = Color.white;
                break;

        }
        

    }
}

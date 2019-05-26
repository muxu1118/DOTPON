using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dot : MonoBehaviour
{ 
    private float lostTime = 10.0f;

    private Vector3 defaultPos;

    

    private Vector3 speed;
    //上下の速度の処理（予定）

    public float LostTime
    {
        get { return LostTime; }
        set { LostTime = value; }
    }
    

    private void Start()
    {
        StartCoroutine(LostDot());
        defaultPos = transform.position;
        
    }

    IEnumerator LostDot()
    {
        yield return new WaitForSeconds(lostTime);
     
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(65.0f, 65.0f, -35.0f) * Time.deltaTime);
        //回転の処理
        
    }

    private void FixedUpdate()
    {
        transform.position = (new Vector3(defaultPos.x, defaultPos.y + Mathf.PingPong(0.6f*Time.time, 0.6f)));
        //上下移動の移動と速度
        //transform.position = Vector3.Lerp(new Vector3(defaultPos.x, defaultPos.y) , new Vector3 (defaultPos.x, defaultPos.y + Mathf.PingPong(Time.deltaTime,2 )),Time.deltaTime * 20.0f);
        //transform.position = (new Vector3(defaultPos.x, defaultPos.y + Mathf.PingPong(Time.time, 0.6f)));
    }

    
}

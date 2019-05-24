using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float WalkSpeed = 10f; //歩く速度
    [SerializeField]
    private float RunSpeed = 100f; //走る速度
    //private float RotationSpeed = 100f; //向きを変える速度
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        //transform.potisionの移動
        
        //走る
        if (Input.GetAxisRaw("Mouse Y") ==-1)
        {
            transform.position += transform.forward * RunSpeed * Time.deltaTime;
            Debug.Log("呼ばれた");
        }
        //前に歩く
         if (Input.GetAxisRaw("Mouse Y")<-0.3)
        {
            transform.position += transform.forward * WalkSpeed * Time.deltaTime;
            Debug.Log("前");
        }
        //左に移動
        if(Input.GetAxisRaw("Mouse X")<-0.3)
        {
            transform.position -= transform.right * WalkSpeed * Time.deltaTime;
            Debug.Log("左");
        }
        //右に移動
        if(Input.GetAxisRaw("Mouse X")>0.3)
        {
            transform.position += transform.right * WalkSpeed * Time.deltaTime;
            Debug.Log("右");
        }
        //後ろに歩く
        if(Input.GetAxisRaw("Mouse Y")>0.3)
        {
            transform.position -= transform.forward * WalkSpeed * Time.deltaTime;
            Debug.Log("後ろ");
        }
    }
    
}

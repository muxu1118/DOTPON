using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField]
    private float WalkSpeed = 5f; //歩く速度
    [SerializeField]
    private float RunSpeed = 10f; //走る速度

    [SerializeField]
    Transform cam;
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
        if (Input.GetAxisRaw("Mouse Y") <-0.9)
        {
            transform.position += transform.forward * RunSpeed * Time.deltaTime;
            //Debug.Log("呼ばれた");
        }
        //前に歩く
         if (Input.GetAxisRaw("Mouse Y")<-0.3)
        {
            transform.position += transform.forward * WalkSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, cam.eulerAngles.y, transform.rotation.z));
            //Debug.Log("前");
        }
        //左に移動
        if(Input.GetAxisRaw("Mouse X")<-0.3)
        {
            transform.position += transform.forward * WalkSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, cam.eulerAngles.y-90, transform.rotation.z));
           //Debug.Log("左");
        }
        //右に移動
        if(Input.GetAxisRaw("Mouse X")>0.3)
        {
            transform.position += transform.forward * WalkSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, cam.eulerAngles.y+90, transform.rotation.z));
            //Debug.Log("右");
        }
        //後ろに歩く
        if(Input.GetAxisRaw("Mouse Y")>0.3)
        {
            transform.position += transform.forward * WalkSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, cam.eulerAngles.y+180, transform.rotation.z));
            //Debug.Log("後ろ");
        }
        //前に動く時に向きを変える
        /*
        if(Input.GetAxisRaw("Mouse Y") < -0.3)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, cam.eulerAngles.y, transform.rotation.z));
        }
        */
        //xとzの数値に基づいて移動
        
       
    }
    
}

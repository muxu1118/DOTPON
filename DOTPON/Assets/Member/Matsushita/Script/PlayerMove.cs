using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float WalkSpeed = 5f; //歩く速度
    [SerializeField]
    private float RunSpeed = 10f; //走る速度

    private Vector3 Player_pos;
    private Rigidbody rb;

    [SerializeField]
    Transform cam;

    float moveX = 0.0f;
    float moveZ = 0.0f;

    
    //private float RotationSpeed = 100f; //向きを変える速度
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        moveX = Input.GetAxisRaw("Mouse X") * WalkSpeed;
        moveZ = Input.GetAxisRaw("Mouse Y") * WalkSpeed;
        Vector3 direction = new Vector3(moveX, 0, moveZ);
    }
    /*
    void Move()
    {
        /*
        //transform.potisionの移動

        //走る
        if (Input.GetAxisRaw("Mouse Y") < -0.9)
        {
            transform.position += transform.forward * RunSpeed * Time.deltaTime;
            //Debug.Log("呼ばれた");
        }
        //前に歩く
        if (Input.GetAxisRaw("Mouse Y") < -0.3)
        {
            transform.position += transform.forward * WalkSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, cam.eulerAngles.y, transform.rotation.z));
            //Debug.Log("前");
        }
        //左に移動
        if (Input.GetAxisRaw("Mouse X") < -0.3)
        {
            transform.position += transform.forward * WalkSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, cam.eulerAngles.y - 90, transform.rotation.z));
            //Debug.Log("左");
        }
        //右に移動
        if (Input.GetAxisRaw("Mouse X") > 0.3)
        {
            transform.position += transform.forward * WalkSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, cam.eulerAngles.y + 90, transform.rotation.z));
            //Debug.Log("右");
        }
        //後ろに歩く
        if (Input.GetAxisRaw("Mouse Y") > 0.3)
        {
            transform.position += transform.forward * WalkSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, cam.eulerAngles.y + 180, transform.rotation.z));
            //Debug.Log("後ろ");
        }
        //前に動く時に向きを変える
        
        if(Input.GetAxisRaw("Mouse Y") < -0.3)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, cam.eulerAngles.y, transform.rotation.z));
        }
        
        
        //velocity
        moveX = Input.GetAxisRaw("Mouse X") * WalkSpeed;
        moveZ = Input.GetAxisRaw("Mouse Y") * WalkSpeed;
        Vector3 direction = new Vector3(moveX, 0, moveZ);
          
    }
        */
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveX, 0, -moveZ);
        //カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraFoward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        //方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraFoward * moveX + Camera.main.transform.right * moveZ;

        //
        rb.velocity = moveForward * WalkSpeed + new Vector3(0, rb.velocity.y, 0);

        //
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }



}

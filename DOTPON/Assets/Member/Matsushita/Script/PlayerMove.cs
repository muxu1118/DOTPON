using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //[SerializeField]
    //private float WalkSpeed = 5f; //歩く速度
    //[SerializeField]
    //private float RunSpeed = 10f; //走る速度

    float inputHorizontal;
    float inputVertical;

    int NotMoveHash;
    int NotThrowHash;
    [HideInInspector]
    public float MoveDown = 1;

    Animator animator;

    [SerializeField]
    float moveSpeed = 3;

    Vector3 Player_pos;
    Rigidbody rb;

    [SerializeField]string playerNum;

    //[SerializeField]
    //Transform cam;

    public Camera cmr;
    Animator anim;

    //private float RotationSpeed = 100f; //向きを変える速度
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerNum = this.gameObject.name.Substring(6);
        anim = GetComponent<Animator>();

        NotMoveHash = Animator.StringToHash("NotMove");
        NotThrowHash = Animator.StringToHash("NotThrow");
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        inputHorizontal = Input.GetAxisRaw("Horizontal" + playerNum + "_left");
        //Debug.Log(inputHorizontal);
        inputVertical = Input.GetAxisRaw("Vertical" + playerNum + "_left");
        //Debug.Log(inputVertical);
        //Vector3 direction = new Vector3(moveX, 0, moveZ);

        //if (Input.GetAxis("Horizontal" + playerNum + "_left") >= -0.001f && Input.GetAxis("Horizontal" + playerNum + "_left") <= 0.001f) return;
        //if (Input.GetAxis("Vertical" + playerNum + "_left") >= -0.001f && Input.GetAxis("Vertical" + playerNum + "_left") <= 0.001f) return;

    }
    void FixedUpdate()
    {
        //rb.velocity = new Vector3(moveX, 0, moveZ);
        //カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraFoward = Vector3.Scale(cmr.transform.forward, new Vector3(1, 0, 1)).normalized;
        
        if(anim.GetCurrentAnimatorStateInfo(0).tagHash == NotMoveHash)
        {
            StartCoroutine("WaitMoveAnimation");
        }
        else if(anim.GetCurrentAnimatorStateInfo(0).tagHash == NotThrowHash)
        {
            StartCoroutine("WaitAnimation");
        }
        //方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraFoward * inputVertical * MoveDown + cmr.transform.right * inputHorizontal * MoveDown;
        //
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        //

        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
        anim.SetFloat("Speed", Mathf.Abs(inputHorizontal) + Mathf.Abs(inputVertical));

    }

    IEnumerator WaitMoveAnimation()
    {
        MoveDown = 0.7f;
        //Vector3 moveForward = i * inputVertical * MoveDown + cmr.transform.right * inputHorizontal * MoveDown;

        yield return null;
        yield return new WaitForAnimation(anim, 0);
        MoveDown = 1;

        //Debug.LogWarning("戻った");
    }

    IEnumerator WaitAnimation()
    {
        MoveDown = 0;

        yield return null;
        yield return new WaitForAnimation(anim, 0);
        yield return new WaitForSeconds(1.0f);
        MoveDown = 1;

        //Debug.LogWarning("なんできた");
    }
    //public void PlayerWait()
    //{
    //    StartCoroutine("WaitAnimation");
    //}
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



}

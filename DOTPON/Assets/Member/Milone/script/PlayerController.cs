using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCONTROLLER: MonoBehaviour
{
   


    public string playerNum;
    public float inputdelay = 0.1f;
    public float movespeed=10;
    public Animator anim;
    public CharacterController charCon;
    public float jumpForce = 10f;
    public float gravityScale = 5;
    public float rotateSpeed=3;
    Vector3 movedirection;
    // Start is called before the first frame update
    void Start()
    {
        charCon.GetComponent<CharacterController>();
        anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float ystore = movedirection.y;

        movedirection = (transform.forward * (Input.GetAxis("Vertical")));
        movedirection = movedirection.normalized * movespeed;
        movedirection.y = ystore;

        if (charCon.isGrounded)
        {
            movedirection.y = 0;
            if (Input.GetButtonDown("Jump"))
            {
                movedirection.y = jumpForce;
            }
        }

        var h = Input.GetAxis("Horizontal");
        movedirection.y = movedirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        charCon.Move(movedirection * Time.deltaTime);

        if (Mathf.Abs(h)>inputdelay)
        {
            Quaternion nevRotation = transform.rotation;


             nevRotation*= Quaternion.AngleAxis(rotateSpeed*h*Time.deltaTime,Vector3.up);

            transform.rotation = nevRotation;
        }
        anim.SetBool("isGrounded", charCon.isGrounded);
        anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Vertical") ));
        

    }



    
}



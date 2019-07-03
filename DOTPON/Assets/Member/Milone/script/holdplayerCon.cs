using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCONTROLLER1 : MonoBehaviour
{
   


    public string playerNum;
   
    public float movespeed=300;
    
    public CharacterController charCon;
    public float jumpForce = 10f;
    public float gravityScale = 5;
    public float rotateSpeed=3;
    // Start is called before the first frame update
    void Start()
    {
        charCon.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw(playerNum + "Horizontal");
        float vertical = Input.GetAxisRaw(playerNum + "Vertical");
        var movement = new Vector3(horizontal, 0, vertical);
        charCon.SimpleMove(movement * Time.deltaTime * movespeed);
        
        if (movement.magnitude > 0)
        {
            Quaternion newDirection = Quaternion.LookRotation(movement);
            newDirection = Quaternion.Euler(0, transform.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * rotateSpeed);
        }
        
        
       

      
    }



    
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
     public float rotateSpeed=45f;
    private float rotateInput;
    private bool rotateAroundPlayer=false;
    
    
   
    // Start is called before the first frame update
    void Awake()
    {
        offset = transform.position - target.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        

       /* if(Input.GetKey(KeyCode.Q)|| Input.GetKey(KeyCode.E))
        {
            
            rotateAroundPlayer = true;
            if (Input.GetKey(KeyCode.Q)){
               rotateInput  = rotateSpeed;
                
            }
            else
            {
                rotateInput = -rotateSpeed;
            }
        }
        else
        {
            rotateInput= 0f;
            rotateAroundPlayer = false;
        }
       

     if (rotateAroundPlayer)
        {
            Quaternion camrotation = Quaternion.AngleAxis(rotateInput* Time.deltaTime, Vector3.up);
            offset = camrotation * offset;
        }*/
        
        
           // transform.LookAt(target);
        
        transform.position = target.position+offset;
    }
}

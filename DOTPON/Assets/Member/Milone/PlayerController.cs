using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string PlayerNumber;
    public Rigidbody rb;
    public float movespeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movex= Input.GetAxis(PlayerNumber + "Horizontal");
        float movez = Input.GetAxis(PlayerNumber + "Vertical");
        Vector3 movement = new Vector3(movex, 0f, movez);
        rb.velocity = movement * movespeed;
            
        
        
    }
}

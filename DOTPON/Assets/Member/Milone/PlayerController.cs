using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string PlayerNumber;
    public Rigidbody rb;
    public float movespeed;
    public MeshRenderer playerImage;
    public bool knockBackActive;
    public float knockbaklenght=2f;
    public float knockBackCounter;
    public Material[] material;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       knockBackActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (knockBackActive)
        {
            knockBackCounter -= Time.deltaTime;
            if (Mathf.Floor(knockBackCounter * 5f) % 2 == 0)
            {
                playerImage.sharedMaterial = material[1];
            }
            else
            {
                playerImage.sharedMaterial = material[0];
            }
            if (knockBackCounter <= 0)
            {
                playerImage.sharedMaterial = material[2];
                knockBackActive = false;
            }
        }
        float movex= Input.GetAxis(PlayerNumber + "Horizontal");
        float movez = Input.GetAxis(PlayerNumber + "Vertical");
        Vector3 movement = new Vector3(movex, 0f, movez);
        rb.velocity = movement * movespeed;

        if (Input.GetKey(KeyCode.Z))
        {
            knockBackCounter = knockbaklenght;
            knockBackActive = true;
        }
        
        
    }
}

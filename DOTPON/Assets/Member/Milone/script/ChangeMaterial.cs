using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    
   
    
    public MeshRenderer playerImage;
    public bool knockBackActive;
    public float knockbaklenght=2f;
    public float knockBackCounter;
    public Material[] material;

    // Start is called before the first frame update
    void Start()
    {
       
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
        

        if (Input.GetKey(KeyCode.Z))
        {
            knockBackCounter = knockbaklenght;
            knockBackActive = true;
        }
        
        
    }
}

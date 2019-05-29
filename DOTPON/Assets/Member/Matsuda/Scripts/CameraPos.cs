using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(0, 3, -3);
       // Debug.Log(this.transform.position);
    }
}

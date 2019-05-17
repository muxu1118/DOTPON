using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    private float lostTime = 10.0f;
    public float LostTime
    {
        get { return LostTime; }
        set { LostTime = value; }
    }


    private void Start()
    {
        StartCoroutine(LostDot());
    }

    IEnumerator LostDot()
    {
        yield return new WaitForSeconds(lostTime);
     
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

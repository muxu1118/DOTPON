using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoburinFlock : Goburin
{
    private Transform[] childTransform = new Transform[4];
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach(Transform obj in this.gameObject.transform)
        {
            childTransform[i] = obj;
            i++;
        }
        Debug.Log(childTransform);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 AtoB = childTransform[0].position - childTransform[1].position;
        //Vector3 CtoD = childTransform[2].position - childTransform[3].position;
        //this.gameObject.transform.position = (AtoB - CtoD);
        //if (Input.GetKeyDown(KeyCode.RightShift))
        //{
        //    Debug.Log(AtoB + " + " + CtoD);
        //}

    }
}

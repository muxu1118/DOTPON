using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField]
    float Speed = 0.01f;

    [SerializeField]
    float hight = 30;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Speed);

        if(transform.position.z>=70)
        {
            transform.position = new Vector3(Random.Range(-60, 60), hight, Random.Range(-60, 60));
        }
    }
}

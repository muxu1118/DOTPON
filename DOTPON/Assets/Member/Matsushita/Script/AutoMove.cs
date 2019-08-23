using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField]
    float Speed = 1.0f;

    float px = 0;
    float pz = 0;
    // Start is called before the first frame update
    void Start()
    {
        px = Random.Range(-5.0f, 5.0f);
        pz = Random.Range(-5.0f, 5.0f);

        transform.position = new Vector3(px, 10, pz);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;

        if (transform.position.z >= 25.0f)
        {
            transform.position = new Vector3(px, 10, pz);
        }
    }
}

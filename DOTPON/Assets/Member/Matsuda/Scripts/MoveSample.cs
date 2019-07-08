using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSample : MonoBehaviour
{
    [SerializeField] float speed;
    // Update is called once per frame
    private void Start()
    {
        speed = speed / 100;
    }
    void Update()
    {
        transform.position += new Vector3(0, 0, -1) * speed;
    }
}

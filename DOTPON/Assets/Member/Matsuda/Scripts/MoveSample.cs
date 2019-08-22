using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSample : MonoBehaviour
{
    [SerializeField] public float speed;
    public Vector3 vec;
    // Update is called once per frame
    private void Start()
    {
        vec = transform.forward;
    }
    void Update()
    {
        if (speed <= 0)
        {
            GetComponent<Animator>().SetFloat("Speed", 0.1f);
        } else
        {
            transform.position += vec * speed * Time.deltaTime;
            GetComponent<Animator>().SetFloat("Speed", 0.5f);
        }
    }
}

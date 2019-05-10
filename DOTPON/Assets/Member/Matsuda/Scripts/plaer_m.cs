using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plaer_m : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] GameObject obj;
    [SerializeField] GameObject obj2;
    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        KeyInout();
    }
    void KeyInout()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerMove(new Vector3(0, 0, 5));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerMove(new Vector3(-5, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerMove(new Vector3(0, 0, -5));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerMove(new Vector3(5, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           obj.GetComponent<Goburin>().Damage(1);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            obj2.GetComponent<Slime>().Damage(1);
        }
    }
    void PlayerMove(Vector3 vec)
    {
        GetComponent<Rigidbody>().velocity += vec;
    }
}

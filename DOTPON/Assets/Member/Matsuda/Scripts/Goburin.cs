using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goburin : Enemy
{
    [SerializeField] GameObject player;
    Vector3 vector;
    // Start is called before the first frame update
    void Start()
    {
        vector = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        DropDot(gameObject);
        transform.position += vector * 0.03f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == player.GetComponent<BoxCollider>())
        {
            transform.LookAt(player.transform.position);
            vector = transform.forward;
        }
    }
}

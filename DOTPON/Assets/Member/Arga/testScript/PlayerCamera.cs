using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position + new Vector3(0, 3, -3);
        //offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //transform.position = player.transform.position + offset;
    }
}

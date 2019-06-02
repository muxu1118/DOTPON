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
        
            //offset = transform.position - player.transform.position;
            //transform.localRotation = new Quaternion(20, 0, 0, 0);
    }
    public void CameraPosSet()
    {
        player = transform.root.gameObject;
        transform.localPosition = new Vector3(0, 3, -3);
    }
}

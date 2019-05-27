using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    float CamMoveSpeed;

    GameObject CamObj;
    Camera Camera;
    GameObject Player;
    Vector3 PlayerPos;
    
    
    // Start is called before the first frame update
    void Start()
    {
        CamObj = GameObject.Find("Main Camera");
        Camera = CamObj.GetComponent<Camera>();
        Player = GameObject.Find("Cube");
        PlayerPos = Player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
    }

    void CameraMove()
    {
        CamObj.transform.LookAt(Player.transform);

        if(Input.GetAxis("Horizontal1_right") > 0.6)
        {
            //右
            CamObj.transform.position += new Vector3(CamMoveSpeed, 0, 0);
        }
        if (Input.GetAxis("Horizontal1_right") < -0.6)
        {
            //左
            CamObj.transform.position -= new Vector3(CamMoveSpeed, 0, 0);
        }
        
    }
}

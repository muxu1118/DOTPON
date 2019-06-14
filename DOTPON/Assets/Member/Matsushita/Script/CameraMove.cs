using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //X軸の角度を制限するための変数
    float angleUp = 60f;
    float angleDown = -60f;

    //playerをInspecterに入れる
    [SerializeField]
    GameObject player;

    //Main CameraをInspecterに入れる
    [SerializeField]
    Camera cam;

    //Cameraが回転するスピード
    [SerializeField]
    float rotateSpeed = 3;

    //Axisの位置を指定する変数
    [SerializeField]
    Vector3 axisPos;
    // Start is called before the first frame update
    void Start()
    {
        //CameraのAxisに相対的な位置をlocalPositionで指定
        cam.transform.localPosition = new Vector3(0, 0, -3);
        //CameraとAxisの向きを最初だけそろえる
        cam.transform.localRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Axisの位置をplayerの位置+axisPosできめる
        transform.position = player.transform.position + axisPos;

        //Cameraの角度にマウスからとった値を入れる
        transform.eulerAngles += new Vector3(Input.GetAxis("CameraMoveY") * rotateSpeed, Input.GetAxis("CameraMoveX") * rotateSpeed, 0);

        //x軸の角度
        float angleX = transform.eulerAngles.x;

        //x軸の値を180度超えたら360引くことで制限しやすくする
        if(angleX>=180)
        {
            angleX = angleX - 180;
        }
        //Math.Clamp(値、最小値、最大値)でx軸の値を制限する
        transform.eulerAngles = new Vector3(Mathf.Clamp(angleX, angleDown, angleUp), transform.eulerAngles.y, transform.eulerAngles.z);
    }
}

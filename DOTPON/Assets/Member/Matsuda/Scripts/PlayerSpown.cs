using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpown : MonoBehaviour
{
    [SerializeField]
    Vector3[] spewnPos;
    [SerializeField]
    GameObject playerPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0;i < MultiPlayerManager.instance.totalPlayer;i++)
        {
            var playerObj = Instantiate(playerPrefab, spewnPos[i],Quaternion.identity);
            playerObj.GetComponent<Player>().own = PlayerEnum(i);
            playerObj.transform.LookAt(new Vector3(0, 0, 0));
            var CameraController = GameObject.Find("CameraController").GetComponent<ScreenController>();
            CameraController.cameras[i] = playerObj.GetComponentInChildren<Camera>().gameObject;
        }
    }
    private Player.PlayerKind PlayerEnum(int num)
    {
        switch (num) {
            case 0:
                return Player.PlayerKind.Player1;
            case 1:
                return Player.PlayerKind.Player2;
            case 2:
                return Player.PlayerKind.Player3;
            case 3:
                return Player.PlayerKind.Player4;
            default:
                return Player.PlayerKind.Player1;
        }
        
    }
}

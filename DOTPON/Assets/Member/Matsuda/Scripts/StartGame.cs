using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    Vector3[] spewnPos;
    [SerializeField]
    GameObject playerPrefab;

    [SerializeField]
    GameObject[] buttonObj;
    [SerializeField]
    ScreenController screenController;

    // Start is called before the first frame update
    void Start()
    {
        //人数分の回数まわす
        for (int i = 0;i < MultiPlayerManager.instance.totalPlayer;i++)
        {
            //プレイヤーの生成
            var playerObj = Instantiate(playerPrefab, spewnPos[i],Quaternion.identity);
            /*
            var player = playerObj.AddComponent<Player>();
            for(int j = 0; j < 4; j++)
            {
                player.weapon[j] = objects[j];
            }
            var cameraObj = Instantiate(objects[4], playerObj.transform.position + new Vector3(0,2,-3), objects[4].transform.rotation);
            cameraObj.GetComponent<PlayerCamera>().player = playerObj;
            cameraObj.transform.parent = playerObj.transform;
            player.nowWeapon = objects[3];
            playerObj.AddComponent<MoveController>();
            playerObj.AddComponent<BoxCollider>();
            playerObj.AddComponent<Rigidbody>();
            playerObj.GetComponent<Animator>().runtimeAnimatorController = anim;
            //playerObj.GetComponent<Animator>().runtimeAnimatorController = ;
            */
            //ぷれいやーのenumをそれぞれに対応させる
            playerObj.GetComponent<Player>().own = PlayerEnum(i);
            playerObj.transform.LookAt(new Vector3(0, 0, 0));
            //カメラのオブジェクトを探して参照させる
            screenController.cameras[i] = playerObj.GetComponentInChildren<Camera>().gameObject;
            buttonObj[i].SetActive(true);
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

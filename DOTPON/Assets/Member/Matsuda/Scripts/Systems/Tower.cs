using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void GiveStar(Player.PlayerKind kind)
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "player") return;
        Debug.Log("player");
        if (Input.GetKeyDown(KeyCode.A))
        {
            switch (other.GetComponent<Player>().own)
            {
                //case Player.PlayerKind.Player1:
                //    num = MultiPlayerManager.instance.P1Dot;
                //    break;
                //case Player.PlayerKind.Player2:
                //    num = MultiPlayerManager.instance.P2Dot;
                //    break;
                //case Player.PlayerKind.Player3:
                //    num = MultiPlayerManager.instance.P3Dot;
                //    break;
                //case Player.PlayerKind.Player4:
                //    num = MultiPlayerManager.instance.P4Dot;
                //    break;
                case Player.PlayerKind.Player1:
                    MultiPlayerManager.instance.P1Star++;
                    Debug.Log("これは"+other.GetComponent<Player>().own);
                    break;
                case Player.PlayerKind.Player2:
                    MultiPlayerManager.instance.P2Star++;
                    Debug.Log("これは" + other.GetComponent<Player>().own);
                    break;
                case Player.PlayerKind.Player3:
                    MultiPlayerManager.instance.P3Star++;
                    Debug.Log("これは" + other.GetComponent<Player>().own);
                    break;
                case Player.PlayerKind.Player4:
                    MultiPlayerManager.instance.P4Star++;
                    Debug.Log("これは" + other.GetComponent<Player>().own);
                    break;

        }
        }
    }
}

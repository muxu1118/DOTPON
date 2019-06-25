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
        if (other.gameObject.tag != "Player") return;
        switch (other.GetComponent<Player>().own)
        {
            case Player.PlayerKind.Player1:
                num = MultiPlayerManager.instance.P1Dot;

                break;
            case Player.PlayerKind.Player2:
                num = MultiPlayerManager.instance.P2Dot;
                break;
            case Player.PlayerKind.Player3:
                num = MultiPlayerManager.instance.P3Dot;
                break;
            case Player.PlayerKind.Player4:
                num = MultiPlayerManager.instance.P4Dot;
                break;
        }
    }
}

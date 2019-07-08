using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    int playerNumber; // プレイヤーの数を補完

    // Canvasの位置
    List<Vector2> canvasPosis;

    // Start is called before the first frame update
    void Start()
    {
        playerNumber = MultiPlayerManager.instance.totalPlayer;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

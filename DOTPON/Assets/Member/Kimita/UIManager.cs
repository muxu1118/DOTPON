using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    int playerNumber; // プレイヤーの数を補完
    // プレイヤーのキャンバス
    [SerializeField]
    GameObject playerCanvas;

    // Canvasの位置
    List<Vector2> canvasPosis = new List<Vector2>();
    // 出したキャンバスを保存する場所
    List<GameObject> saveCanvas = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        playerNumber = MultiPlayerManager.instance.totalPlayer;
        canvasPosis.Add(new Vector2(-200, 120));
        canvasPosis.Add(new Vector2(200, 120));
        canvasPosis.Add(new Vector2(-200, -100));
        canvasPosis.Add(new Vector2(200, -100));
        if(playerNumber == 1)
        {
            saveCanvas.Add(Instantiate(playerCanvas, Vector3.zero, Quaternion.identity));
            saveCanvas[0].transform.parent = gameObject.transform;
            saveCanvas[0].name = "P1PlayerCanvas" ;
            saveCanvas[0].GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            saveCanvas[0].transform.localScale = Vector3.one;
        }
        else
        {
            for (int i=0; i < playerNumber;i++) {
                saveCanvas.Add(Instantiate(playerCanvas, canvasPosis[i], Quaternion.identity));
                saveCanvas[i].transform.parent = gameObject.transform;
                saveCanvas[i].name = "P" +  (i+1).ToString() + "PlayerCanvas";
                saveCanvas[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(canvasPosis[i].x, canvasPosis[i].y, 0);
                saveCanvas[i].transform.localScale = new Vector3(0.5f,0.5f,1);
            }
        }
        //switch (playerNumber)
        //{
        //    case 1:
        //        saveCanvas.Add(Instantiate(playerCanvas, Vector3.zero, Quaternion.identity));
        //        break;
        //    case 2:
        //        for(int i;)
        //    case 3:
        //    case 4:
        //    default:break;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UIAdjust()
    {

    }
}

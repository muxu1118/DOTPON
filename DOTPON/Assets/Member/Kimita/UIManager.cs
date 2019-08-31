using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    int playerNumber; // プレイヤーの数を補完
    // プレイヤーのキャンバス
    [SerializeField]
    GameObject playerCanvas;

    // Canvasの位置
    List<Vector2> canvasPosis = new List<Vector2>();
    // 出したキャンバスを保存する場所
    public List<GameObject> saveCanvas = new List<GameObject>();
    [SerializeField]
    Sprite[] sprites = new Sprite[4];
    // Start is called before the first frame update
    void Start()
    {
        playerNumber = MultiPlayerManager.instance.totalPlayer;
        canvasPosis.Add(new Vector2(-200, 115));
        canvasPosis.Add(new Vector2(200, 115));
        canvasPosis.Add(new Vector2(-200, -110));
        canvasPosis.Add(new Vector2(200, -110));
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
                // プレイヤーごとにドットとスターを設定する
                foreach (Transform Child in saveCanvas[i].transform)
                {

                    if (Child.name == "Dot" && i < 4 && i >= 0)
                    {
                        Child.GetComponent<Image>().sprite = sprites[i];
                    }
                    foreach (Transform child in Child.transform)
                    {
                        if (null != child.GetComponent<Dot_count>())
                        {
                            if (child.gameObject.name == "DotText")
                            {
                                switch (i)
                                {
                                    case 0:
                                        child.gameObject.GetComponent<Text>().color = Color.red;
                                        break;
                                    case 1:
                                        child.gameObject.GetComponent<Text>().color = Color.blue;
                                        break;
                                    case 2:
                                        child.gameObject.GetComponent<Text>().color = Color.green;
                                        break;
                                    case 3:
                                        child.gameObject.GetComponent<Text>().color = Color.yellow;
                                        break;
                                }
                                child.GetComponent<Dot_count>().dotText = (Dot_count.DotText)i;

                            }
                            else if (child.gameObject.name == "StarText")
                            {
                                child.GetComponent<Dot_count>().dotText = (Dot_count.DotText)(i + 4);
                            }
                        }
                    }
                }
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
     public void UIDestroy()
    {
        saveCanvas.Clear();
    }
}

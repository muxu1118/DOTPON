using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // 時間を計る初期値
    public float timeCount = 300;
    // 時間の上限
    float limitTime = 0;
    // 時間をUnity上で見せる用
    Text textTime;
    // 画像でやるとき（表記用）
    [SerializeField]
    Image[] imageTime = new Image[3];
    // 画像でやるとき（元画像）
    [SerializeField]
    Sprite[] imageCount = new Sprite[10];

    // Start is called before the first frame update
    void Start()
    {
        textTime = GetComponent<Text>();
        textTime.text = "残り時間 " + ((int)(timeCount/60)).ToString()+":"+ ((int)(timeCount % 60)).ToString("00");
        
    }

    // Update is called once per frame
    void Update()
    {
        // 毎秒数える
        timeCount -= Time.deltaTime;
        textTime.text = "残り時間 " + ((int)(timeCount / 60)).ToString() + ":" + ((int)(timeCount % 60)).ToString("00");
        //imageTime[0].sprite = imageCount[(int)(timeCount / 60)];
        //imageTime[1].sprite = imageCount[(int)(timeCount % 60 % 10)];
        //imageTime[2].sprite = imageCount[(int)(timeCount % 60 / 10)];

        if (limitTime >= timeCount)
        {
            // ゲーム終了
            // リザルト画面に移動
            StartCoroutine(EndCorutine());
        }
    }

    IEnumerator EndCorutine()
    {
        textTime.text = "GameSet!!";
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
    }
}

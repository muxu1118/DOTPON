﻿using System.Collections;
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

    // サブ時間
    float subTime = 0;

    //最初のカウントダウン用bool
    bool isCountDown = true;

    // Start is called before the first frame update
    void Start()
    {
        textTime = GetComponent<Text>();
        textTime.text = "残り時間 " + ((int)(timeCount/60)).ToString()+":"+ ((int)(timeCount % 60)).ToString("00");
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountDown) return;
        // 毎秒数える
        timeCount -= Time.deltaTime;
        subTime += Time.deltaTime;
        if (subTime  <= 9)
        {
            textTime.text = "残り時間 " + ((int)(timeCount / 60)).ToString() + ":" + ((int)(timeCount % 60)).ToString("00");
        }else if(subTime <= 10)
        {
            textTime.text = ((int)(timeCount / 60)).ToString() + ":" + ((int)(timeCount % 60)).ToString("00");
            textTime.color = Color.magenta;

        }
        else
        {
            subTime = 0;
            textTime.color = Color.cyan;
        }
        //imageTime[0].sprite = imageCount[(int)(timeCount / 60)];
        //imageTime[1].sprite = imageCount[(int)(timeCount % 60 % 10)];
        //imageTime[2].sprite = imageCount[(int)(timeCount % 60 / 10)];

        if (limitTime >= timeCount)
        {
            // ゲーム終了
            var i = GameObject.Find("EndImage");
            i.GetComponent<EndGame>().EndMainGame();
            // リザルト画面に移動
            StartCoroutine(EndCorutine());
        }
    }

    IEnumerator CountDown()
    {
        textTime.text = "3";
        yield return new WaitForSeconds(1);
        textTime.text = "2";
        yield return new WaitForSeconds(1);
        textTime.text = "1";
        yield return new WaitForSeconds(1);
        textTime.text = "Start!!";
        yield return new WaitForSeconds(1);
        isCountDown = false;
    }

    IEnumerator EndCorutine()
    {
        textTime.text = "GameSet!!";
        yield return new WaitForSeconds(3.5f);
        FadeManager.Instance.LoadScene("ResultScene", 1.0f);
        Destroy(this);
    }
}

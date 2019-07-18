using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mori_Time : MonoBehaviour
{
    [SerializeField] private float Times = 180.0f;

    // Start is called before the first frame update
    void Start()
    {
        Dot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Times);
        Times -= Time.deltaTime;
        Rasttime();
    }

    private void Rasttime()
    {
        if (Times <= 10)
        {
            Dot.SetActive(true);
            StartTenTime();
            Debug.Log("点滅");
            StopTenTime();
            
            if (Times <= 0)
            {
                
                Dot.SetActive(false);
            }
        }
    }

    private void StartTenTime()
    {
        for (int Times = 0; Times < 10; Times++)
        {
            StartCoroutine("DotfadeOut");
        }
    }

    private void StopTenTime()
    {
        for (int Times = 0; Times < 10; Times++)
        {
            StopCoroutine("DotfadeOut");
        }
    }

    //点滅
    private void DotStart()
    {
            //10秒きったら点滅開始
            StartCoroutine("DotfadeOut");
    }

    private void DotOut()
    {
        //前回の点滅の処理を止める
        StopCoroutine("DotfadeOut");
    }


    private float fadeInOut;

    [SerializeField]private float fade = 0.15f;

    [SerializeField] private float fade2 = 0.5f;    

    [SerializeField] private GameObject Dot;

    //透明度を1~0と0~1へと徐々に変更することにより点滅させる
    IEnumerator DotfadeOut()
    {
        while (true)
        {
            //fadein
            while (fadeInOut <= 1)
            {
                Dot.GetComponent<Image>().color += new Color(0, 0, 0, fade);
                fadeInOut += fade;
                yield return null;
            }
            //fadeout
            while (fadeInOut >= 0)
            {
                Dot.GetComponent<Image>().color -= new Color(0, 0, 0, fade2);
                fadeInOut -= fade2;
                yield return null;
            }
        }
    }

}

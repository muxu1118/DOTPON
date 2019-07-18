using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    //timerのスクリプトを取得する
    Timer timer;
    //表示を始める時間。デフォルトは10秒
    [SerializeField]
    float blinkTime = 10.0f;
    //点滅させる画像
    SpriteRenderer blinkImage;
    

    // Start is called before the first frame update
    void Start(){
        //spriteを取得して透明にする
        blinkImage = this.gameObject.GetComponent<SpriteRenderer>();
        blinkImage.color = new Color(255, 255, 255, 0);
        //Timerタグのついたobjectからtimerを取得する
        if(!GameObject.FindGameObjectWithTag("Timer")){ Debug.LogError("timerがないぞ！"); return; }
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
    }

    // Update is called once per frame
    private void LateUpdate(){
        if (timer.timeCount <= blinkTime && blinkTime > 0){
            blinkTime -= 1.0f;
            StartCoroutine(BlinkCoroutine());
        }
    }

    //点滅のコルーチン。0.5秒で点滅する。
    IEnumerator BlinkCoroutine() {
        blinkImage.color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.5f);
        blinkImage.color = new Color(255, 255, 255, 0);
    }

}

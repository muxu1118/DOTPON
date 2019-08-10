using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    public static bool isCutIn; // カットインの間true
    private float cutinCount; // カットインを数える変数
    
    Animator anim;// アニメーター
    [SerializeField]
    GameObject[] objs = new GameObject[4];
    
    // Bannerの位置
    List<Vector2> bannerPosis = new List<Vector2>();
    Animator[] objAnim = new Animator[4];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            objs[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(668,GetComponent<RectTransform>().anchoredPosition.y, 0) ;
            objAnim[i] = objs[i].GetComponent<Animator>();
        }
        StartCoroutine(AnimBanner());
        bannerPosis.Add(new Vector2(47, 88));
        bannerPosis.Add(new Vector2(15, 25));
        bannerPosis.Add(new Vector2(-15, -36));
        bannerPosis.Add(new Vector2(-46, -98));
    }

    // Update is called once per frame
    void Update()
    {
    }
    private IEnumerator AnimBanner()
    {
        for (int i = 0; i < 4; i++)
        {
            
            objAnim[i].SetTrigger("BannerTrigger" + (i+1).ToString());
            yield return new WaitForSeconds(0.5f);
            // アニメーターを止める
            objs[i].GetComponent<Animator>().ResetTrigger("BannerTrigger" + (i + 1).ToString());

            objs[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(bannerPosis[i].x, bannerPosis[i].y, 0) ;
            yield return new WaitForSeconds(0.1f);
        }
    }
}

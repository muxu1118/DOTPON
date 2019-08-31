using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    public static bool isCutIn; // カットインの間true
    private float cutinCount; // カットインを数える変数
    private int player;
    
    Animator anim;// アニメーター
    // バナーのオブジェクト
    [SerializeField]
    GameObject[] objs = new GameObject[4];
    // ドットのオブジェクト
    [SerializeField]
    GameObject[] dots = new GameObject[4];
    // スターのオブジェクト
    [SerializeField]
    GameObject[] stars = new GameObject[4];
    [SerializeField]
    Sprite[] numbers = new Sprite[10];
    // Bannerの位置
    List<Vector2> bannerPosis = new List<Vector2>();
    Animator[] objAnim = new Animator[4];
    [SerializeField]
    Sprite[] playerPic = new Sprite[4];
    [SerializeField]
    GameObject[] Face = new GameObject[4];
    [SerializeField]
    Sprite[] dotColors = new Sprite[4];
    // Start is called before the first frame update
    void Start()
    {
        player = MultiPlayerManager.instance.totalPlayer;
        for (int i = 0; i < player; i++)
        {
            Face[i].GetComponent<Image>().sprite = playerPic[MultiPlayerManager.instance.Ranking[i]-1];
            objs[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(668,GetComponent<RectTransform>().anchoredPosition.y, 0) ;
            objAnim[i] = objs[i].GetComponent<Animator>();

            foreach(Transform child in dots[i].transform)
            {
                int num;
                num = MultiPlayerManager.instance.RankingDotNumber()[i];
                num = (num >= 100) ? 99 : (num < 0) ? 0 : num;
                
                if(child.gameObject.name == "DotImage")
                {
                    child.gameObject.GetComponent<Image>().sprite = dotColors[MultiPlayerManager.instance.Ranking[i]-1];
                }
                if (child.gameObject.name == "Number1")
                {
                    child.gameObject.GetComponent<Image>().sprite = numbers[(num / 10)];
                }
                if (child.gameObject.name == "Number2")
                {
                    child.gameObject.GetComponent<Image>().sprite = numbers[num - (num / 10 * 10)];
                }
            }
            foreach (Transform child in stars[i].transform)
            {
                int num;
                num = MultiPlayerManager.instance.RankingStarNumber()[i];
                if (child.gameObject.name == "Number1")
                {
                    child.gameObject.GetComponent<Image>().sprite = numbers[(num / 10)];
                }
                if (child.gameObject.name == "Number2")
                {
                    child.gameObject.GetComponent<Image>().sprite = numbers[num - (num / 10 * 10)];
                }
            }
            if(MultiPlayerManager.instance.totalPlayer < i)
            {
                objs[i].gameObject.SetActive(false);
            }
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

        Debug.Log("現在の人数"+MultiPlayerManager.instance.totalPlayer);
        for (int i = 0; i < player; i++)
        {
            Debug.Log(MultiPlayerManager.instance.totalPlayer);
            objAnim[i].SetTrigger("BannerTrigger" + (i+1).ToString());
            yield return new WaitForSeconds(0.5f);
            // アニメーターを止める
            objs[i].GetComponent<Animator>().ResetTrigger("BannerTrigger" + (i + 1).ToString());

            objs[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(bannerPosis[i].x, bannerPosis[i].y, 0) ;
            yield return new WaitForSeconds(0.1f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDOTPON : MonoBehaviour
{
    [SerializeField] private GameObject[] Objects;
    [SerializeField] RectTransform[] positions;
    bool isMove = true;
    [SerializeField]int i;
    bool looping = false;
    // Start is called before the first frame update
    void Start()
    {
        i = 10;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DOTPONWheel(int num,bool plus)
    {
        StartCoroutine(MoveWheel(num, plus));
    }
    public IEnumerator MoveWheel(int num ,bool plus)
    {
        looping = true;
        int num2 = num + 1;
        if (num2 > 5) num2 = 0;
        int num3 = num2 + 1;
        if (num3 > 5) num3 = 0;
        int num4 = num3 + 1;
        if (num4 > 5) num4 = 0;
        int num5 = num4 + 1;
        if (num5 > 5) num5 = 0;
        int num6 = num5 + 1;
        if (num6 > 5) num6 = 0;
        float tim = 0;
        while (tim < 10)
        {
            tim++;
            Objects[num].transform.SetAsLastSibling();
            Objects[num].transform.position = Vector3.MoveTowards(Objects[num].transform.position, positions[2].position, i);
            Objects[num].transform.localScale = Vector3.Lerp(Objects[num].transform.localScale, new Vector3(1, 1, 0), Time.deltaTime * 20);
            if (plus)
            {
                Objects[num2].GetComponent<RawImage>().color = Color.Lerp(Objects[num2].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
                Objects[num2].GetComponentInChildren<RawImage>().color = Color.Lerp(Objects[num2].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
                Objects[num2].transform.position = Vector3.MoveTowards(Objects[num2].transform.position, positions[1].position, i);
                Objects[num2].transform.localScale = Vector3.Lerp(Objects[num2].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num3].transform.SetAsFirstSibling();
                Objects[num3].GetComponent<RawImage>().color = Color.Lerp(Objects[num3].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[num3].GetComponentInChildren<RawImage>().color = Color.Lerp(Objects[num3].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[num3].transform.position = Vector3.MoveTowards(Objects[num3].transform.position, positions[0].position, i);
                Objects[num3].transform.localScale = Vector3.Lerp(Objects[num3].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num4].transform.position = Vector3.MoveTowards(Objects[num4].transform.position, positions[5].position, i);
                Objects[num4].transform.localScale = Vector3.Lerp(Objects[num4].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num5].transform.SetAsFirstSibling();
                Objects[num5].GetComponent<RawImage>().color = Color.Lerp(Objects[num5].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[num5].GetComponentInChildren<RawImage>().color = Color.Lerp(Objects[num5].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[num5].transform.position = Vector3.MoveTowards(Objects[num5].transform.position, positions[4].position, i);
                Objects[num5].transform.localScale = Vector3.Lerp(Objects[num5].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num6].GetComponent<RawImage>().color = Color.Lerp(Objects[num6].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
                Objects[num6].GetComponentInChildren<RawImage>().color = Color.Lerp(Objects[num6].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
                Objects[num6].transform.position = Vector3.MoveTowards(Objects[num6].transform.position, positions[3].position, i);
                Objects[num6].transform.localScale = Vector3.Lerp(Objects[num6].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
            }
            else
            {
                Objects[num6].GetComponent<RawImage>().color = Color.Lerp(Objects[num6].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
                Objects[num6].GetComponentInChildren<RawImage>().color = Color.Lerp(Objects[num6].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
                Objects[num6].transform.position = Vector3.MoveTowards(Objects[num6].transform.position, positions[3].position, i);
                Objects[num6].transform.localScale = Vector3.Lerp(Objects[num6].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num5].transform.SetAsFirstSibling();
                Objects[num5].GetComponent<RawImage>().color = Color.Lerp(Objects[num5].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[num5].GetComponentInChildren<RawImage>().color = Color.Lerp(Objects[num5].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[num5].transform.position = Vector3.MoveTowards(Objects[num5].transform.position, positions[4].position, i);
                Objects[num5].transform.localScale = Vector3.Lerp(Objects[num5].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num4].transform.position = Vector3.MoveTowards(Objects[num4].transform.position, positions[5].position, i);
                Objects[num4].transform.localScale = Vector3.Lerp(Objects[num4].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num3].transform.SetAsFirstSibling();
                Objects[num3].GetComponent<RawImage>().color = Color.Lerp(Objects[num3].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[num3].GetComponentInChildren<RawImage>().color = Color.Lerp(Objects[num3].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[num3].transform.position = Vector3.MoveTowards(Objects[num3].transform.position, positions[0].position, i);
                Objects[num3].transform.localScale = Vector3.Lerp(Objects[num3].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num2].GetComponent<RawImage>().color = Color.Lerp(Objects[num2].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
                Objects[num2].GetComponentInChildren<RawImage>().color = Color.Lerp(Objects[num2].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
                Objects[num2].transform.position = Vector3.MoveTowards(Objects[num2].transform.position, positions[1].position, i);
                Objects[num2].transform.localScale = Vector3.Lerp(Objects[num2].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
            }
            yield return null;
        }
        Debug.Log("END");
        looping = false;
        yield break;
    }
}

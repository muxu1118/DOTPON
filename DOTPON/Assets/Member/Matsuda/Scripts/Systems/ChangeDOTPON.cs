using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDOTPON : MonoBehaviour
{
    [SerializeField] private GameObject[] Objects;
    [SerializeField] GameObject[] childObjects;
    [SerializeField] RectTransform[] positions;
    bool isMove = true;
    [SerializeField]int i;
    bool looping = false;
    int[] numbers = new int[3];
    [SerializeField]Texture[] textures = new Texture[6];
    [SerializeField] Text text;
    //説明用のscript
    [SerializeField] DOTPONExplanation explanation;
    // Start is called before the first frame update
    void Start()
    {
        i = 15;
        explanation.SetExplanation(0);
    }
    
    public void SetTexture(List<int> texNum)
    {
        for (int i = 0; i < 3;i++)
        {
            childObjects[i].GetComponent<RawImage>().texture = textures[texNum[i]];
        }
    }

    public void DrubleText(int num)
    {
        text.text = num.ToString();
    }

    public void DOTPONWheel(int num,bool plus)
    {
        StartCoroutine(MoveWheel(num, plus));
    }
    private IEnumerator MoveWheel(int num ,bool plus)
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
        explanation.SetExplanation(num);
        Debug.Log("center is " + num);
        while (tim < 10)
        {
            tim++;
            Objects[num].transform.SetAsLastSibling();
            Objects[num].transform.position = Vector3.MoveTowards(Objects[num].transform.position, positions[2].position, i);
            Objects[num].transform.localScale = Vector3.Lerp(Objects[num].transform.localScale, new Vector3(1, 1, 0), Time.deltaTime * 20);
            if (plus)
            {
                Objects[num2].GetComponent<RawImage>().color = Color.Lerp(Objects[num2].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
                childObjects[num2].GetComponent<RawImage>().color = Color.Lerp(childObjects[num2].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
                Objects[num2].transform.position = Vector3.MoveTowards(Objects[num2].transform.position, positions[1].position, i);
                Objects[num2].transform.localScale = Vector3.Lerp(Objects[num2].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num3].transform.SetAsFirstSibling();
                Objects[num3].GetComponent<RawImage>().color = Color.Lerp(Objects[num3].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                childObjects[num3].GetComponent<RawImage>().color = Color.Lerp(childObjects[num3].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[num3].transform.position = Vector3.MoveTowards(Objects[num3].transform.position, positions[0].position, i);
                Objects[num3].transform.localScale = Vector3.Lerp(Objects[num3].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num4].transform.position = Vector3.MoveTowards(Objects[num4].transform.position, positions[5].position, i);
                Objects[num4].transform.localScale = Vector3.Lerp(Objects[num4].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num5].transform.SetAsFirstSibling();
                Objects[num5].GetComponent<RawImage>().color = Color.Lerp(Objects[num5].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                childObjects[num5].GetComponent<RawImage>().color = Color.Lerp(childObjects[num5].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[num5].transform.position = Vector3.MoveTowards(Objects[num5].transform.position, positions[4].position, i);
                Objects[num5].transform.localScale = Vector3.Lerp(Objects[num5].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num6].GetComponent<RawImage>().color = Color.Lerp(Objects[num6].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
                childObjects[num6].GetComponent<RawImage>().color = Color.Lerp(childObjects[num6].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
                Objects[num6].transform.position = Vector3.MoveTowards(Objects[num6].transform.position, positions[3].position, i);
                Objects[num6].transform.localScale = Vector3.Lerp(Objects[num6].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
            }
            else
            {
                Objects[num6].GetComponent<RawImage>().color = Color.Lerp(Objects[num6].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
                childObjects[num6].GetComponent<RawImage>().color = Color.Lerp(childObjects[num6].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
                Objects[num6].transform.position = Vector3.MoveTowards(Objects[num6].transform.position, positions[3].position, i);
                Objects[num6].transform.localScale = Vector3.Lerp(Objects[num6].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num5].transform.SetAsFirstSibling();
                Objects[num5].GetComponent<RawImage>().color = Color.Lerp(Objects[num5].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                childObjects[num5].GetComponent<RawImage>().color = Color.Lerp(childObjects[num5].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[num5].transform.position = Vector3.MoveTowards(Objects[num5].transform.position, positions[4].position, i);
                Objects[num5].transform.localScale = Vector3.Lerp(Objects[num5].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num4].transform.position = Vector3.MoveTowards(Objects[num4].transform.position, positions[5].position, i);
                Objects[num4].transform.localScale = Vector3.Lerp(Objects[num4].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num3].transform.SetAsFirstSibling();
                Objects[num3].GetComponent<RawImage>().color = Color.Lerp(Objects[num3].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                childObjects[num3].GetComponent<RawImage>().color = Color.Lerp(childObjects[num3].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[num3].transform.position = Vector3.MoveTowards(Objects[num3].transform.position, positions[0].position, i);
                Objects[num3].transform.localScale = Vector3.Lerp(Objects[num3].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num2].GetComponent<RawImage>().color = Color.Lerp(Objects[num2].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
                childObjects[num2].GetComponent<RawImage>().color = Color.Lerp(childObjects[num2].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
                Objects[num2].transform.position = Vector3.MoveTowards(Objects[num2].transform.position, positions[1].position, i);
                Objects[num2].transform.localScale = Vector3.Lerp(Objects[num2].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
            }
            yield return null;
        }
        Debug.Log("END");
        looping = false;
        yield break;
    }
    public void DOTPONWheelS(int num, bool plus)
    {
        StartCoroutine(MoveWheelS(num, plus));
    }
    private IEnumerator MoveWheelS(int num, bool plus)
    {
        switch (num)
        {
            case 0:
                numbers = new int[] { 0, 1, 2 };
                break;
            case 1:
                numbers = new int[] { 1, 2, 0 };
                break;
            case 2:
                numbers = new int[] { 2, 0, 1 };
                break;
        }
        float tim = 0;
        while (tim < 10)
        {
            tim++;
            Objects[numbers[0]].transform.SetAsLastSibling();
            Objects[numbers[0]].GetComponent<RawImage>().color = Color.Lerp(Objects[numbers[0]].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
            childObjects[numbers[0]].GetComponent<RawImage>().color = Color.Lerp(childObjects[numbers[0]].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * 20);
            Objects[numbers[0]].transform.position = Vector3.MoveTowards(Objects[numbers[0]].transform.position, positions[2].position, i);
            Objects[numbers[0]].transform.localScale = Vector3.Lerp(Objects[numbers[0]].transform.localScale, new Vector3(1, 1, 0), Time.deltaTime * 20);
            if (plus)
            {
                Objects[numbers[1]].GetComponent<RawImage>().color = Color.Lerp(Objects[numbers[1]].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                childObjects[numbers[1]].GetComponent<RawImage>().color = Color.Lerp(childObjects[numbers[1]].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[numbers[1]].transform.position = Vector3.MoveTowards(Objects[numbers[1]].transform.position, positions[1].position, i * 2);
                Objects[numbers[1]].transform.localScale = Vector3.Lerp(Objects[numbers[1]].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[numbers[2]].GetComponent<RawImage>().color = Color.Lerp(Objects[numbers[2]].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                childObjects[numbers[2]].GetComponent<RawImage>().color = Color.Lerp(childObjects[numbers[2]].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[numbers[2]].transform.position = Vector3.MoveTowards(Objects[numbers[2]].transform.position, positions[3].position, i);
                Objects[numbers[2]].transform.localScale = Vector3.Lerp(Objects[numbers[2]].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
            }
            else
            {
                Objects[numbers[2]].GetComponent<RawImage>().color = Color.Lerp(Objects[numbers[2]].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                childObjects[numbers[2]].GetComponent<RawImage>().color = Color.Lerp(childObjects[numbers[2]].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[numbers[2]].transform.position = Vector3.MoveTowards(Objects[numbers[2]].transform.position, positions[3].position, i * 2);
                Objects[numbers[2]].transform.localScale = Vector3.Lerp(Objects[numbers[2]].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[numbers[1]].GetComponent<RawImage>().color = Color.Lerp(Objects[numbers[1]].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                childObjects[numbers[1]].GetComponent<RawImage>().color = Color.Lerp(childObjects[numbers[1]].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[numbers[1]].transform.position = Vector3.MoveTowards(Objects[numbers[1]].transform.position, positions[1].position, i);
                Objects[numbers[1]].transform.localScale = Vector3.Lerp(Objects[numbers[1]].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
            }
            yield return null;
        }
        Debug.Log("END");
        looping = false;
        yield break;
    }
}

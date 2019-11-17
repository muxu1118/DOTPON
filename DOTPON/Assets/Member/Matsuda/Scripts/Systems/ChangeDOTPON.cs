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
    int i;
    int j;
    bool looping = false;
    [SerializeField]Texture[] textures = new Texture[6];
    [SerializeField] Text text;
    //説明用のscript
    [SerializeField] DOTPONExplanation explanation;
    //コルーチンを格納
    IEnumerator moveCoroutine;
    IEnumerator moveCoroutineGame;

    void Start()
    {
        if (explanation == null)
        {
            i = 300;
            j = 10;
        }
        else
        {
            i = 5;
            j = 10;
            explanation.SetExplanation(0);
        }

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
        if(moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
            Debug.Log("endCoroutine");
        }
        moveCoroutine = MoveWheel(num, plus);
        StartCoroutine(moveCoroutine);
    }
    private IEnumerator MoveWheel(int num ,bool plus)
    {
        Debug.Log("startCoroutine");
        int[] nums = new int[6];
        looping = true;
        /*
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
        */
        nums[0] = num;
        nums[1] = num + 1;
        if (nums[1] > 5) nums[1] = 0;
        nums[2] = nums[1] + 1;
        if (nums[2] > 5) nums[2] = 0;
        nums[3] = nums[2] + 1;
        if (nums[3] > 5) nums[3] = 0;
        nums[4] = nums[3] + 1;
        if (nums[4] > 5) nums[4] = 0;
        nums[5] = nums[4] + 1;
        if (nums[5] > 5) nums[5] = 0;

        for (int i = nums.Length;i<0;i--)
        {
            int posNumber = 0;
            if (i-4 < 0)
            {
                posNumber = i + 2;
            }
            else
            {
                posNumber = i - 4;
            }
            Objects[nums[i]].transform.position = positions[posNumber].position;
        }

        float tim = 0;
        explanation.SetExplanation(num);
        Debug.Log("center is " + num);
        while (tim < 40)
        {
            tim++;
            Objects[num].transform.SetAsLastSibling();
            MoveObject(nums[0], 2, 1f, 1.1f,1);
            if (!plus)
            {
                Debug.Log("moveright");
                //関数にまとめた
                /*
                Objects[num2].GetComponent<RawImage>().color = Color.Lerp(Objects[num2].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * j);
                childObjects[num2].GetComponent<RawImage>().color = Color.Lerp(childObjects[num2].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * j);
                Objects[num2].transform.position = Vector3.MoveTowards(Objects[num2].transform.position, positions[1].position, Time.deltaTime * i);
                Objects[num2].transform.localScale = Vector3.Lerp(Objects[num2].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * j);
                Objects[num3].transform.SetAsFirstSibling();
                Objects[num3].GetComponent<RawImage>().color = Color.Lerp(Objects[num3].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * j);
                childObjects[num3].GetComponent<RawImage>().color = Color.Lerp(childObjects[num3].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * j);
                Objects[num3].transform.position = Vector3.MoveTowards(Objects[num3].transform.position, positions[0].position, Time.deltaTime * i);
                Objects[num3].transform.localScale = Vector3.Lerp(Objects[num3].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * j);
                Objects[num4].transform.position = Vector3.MoveTowards(Objects[num4].transform.position, positions[5].position, Time.deltaTime * i);
                Objects[num4].transform.localScale = Vector3.Lerp(Objects[num4].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * j);
                Objects[num5].transform.SetAsFirstSibling();
                Objects[num5].GetComponent<RawImage>().color = Color.Lerp(Objects[num5].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * j);
                childObjects[num5].GetComponent<RawImage>().color = Color.Lerp(childObjects[num5].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * j);
                Objects[num5].transform.position = Vector3.MoveTowards(Objects[num5].transform.position, positions[4].position, Time.deltaTime * i);
                Objects[num5].transform.localScale = Vector3.Lerp(Objects[num5].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * j);
                Objects[num6].GetComponent<RawImage>().color = Color.Lerp(Objects[num6].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * j);
                childObjects[num6].GetComponent<RawImage>().color = Color.Lerp(childObjects[num6].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * j);
                Objects[num6].transform.position = Vector3.MoveTowards(Objects[num6].transform.position, positions[3].position, Time.deltaTime * i);
                Objects[num6].transform.localScale = Vector3.Lerp(Objects[num6].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * j);
                */
                /*
                MoveObject(num2, 1, 1f);
                Objects[num3].transform.SetAsFirstSibling();
                MoveObject(num3, 0,0.3f);
                MoveObject(num4, 5,0.3f);
                Objects[num5].transform.SetAsFirstSibling();
                MoveObject(num5,4,0.3f);
                MoveObject(num6, 3,1f);
                */
                MoveObject(nums[1], 1, 1f,0.8f,1f);
                Objects[nums[2]].transform.SetAsFirstSibling();
                MoveObject(nums[2], 0, 0.3f,0.8f,0.8f);
                MoveObject(nums[3], 5, 0.3f,0.8f,1.7f);
                Objects[nums[4]].transform.SetAsFirstSibling();
                MoveObject(nums[4], 4, 0.3f,0.8f,1.7f);
                MoveObject(nums[5], 3, 1f,0.8f,0.8f);
            }
            else
            {

                Debug.Log("moveleft");
                /*
                Objects[num6].GetComponent<RawImage>().color = Color.Lerp(Objects[num6].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * j);
                childObjects[num6].GetComponent<RawImage>().color = Color.Lerp(childObjects[num6].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * j);
                Objects[num6].transform.position = Vector3.MoveTowards(Objects[num6].transform.position, positions[3].position, Time.deltaTime * i);
                Objects[num6].transform.localScale = Vector3.Lerp(Objects[num6].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * j);
                Objects[num5].transform.SetAsFirstSibling();
                Objects[num5].GetComponent<RawImage>().color = Color.Lerp(Objects[num5].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * j);
                childObjects[num5].GetComponent<RawImage>().color = Color.Lerp(childObjects[num5].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * j);
                Objects[num5].transform.position = Vector3.MoveTowards(Objects[num5].transform.position, positions[4].position, Time.deltaTime * i);
                Objects[num5].transform.localScale = Vector3.Lerp(Objects[num5].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * j);
                Objects[num4].transform.position = Vector3.MoveTowards(Objects[num4].transform.position, positions[5].position, Time.deltaTime * i);
                Objects[num4].transform.localScale = Vector3.Lerp(Objects[num4].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * j);
                Objects[num3].transform.SetAsFirstSibling();
                Objects[num3].GetComponent<RawImage>().color = Color.Lerp(Objects[num3].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * j);
                childObjects[num3].GetComponent<RawImage>().color = Color.Lerp(childObjects[num3].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * j);
                Objects[num3].transform.position = Vector3.MoveTowards(Objects[num3].transform.position, positions[0].position, Time.deltaTime * i);
                Objects[num3].transform.localScale = Vector3.Lerp(Objects[num3].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * j);
                Objects[num2].GetComponent<RawImage>().color = Color.Lerp(Objects[num2].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * j);
                childObjects[num2].GetComponent<RawImage>().color = Color.Lerp(childObjects[num2].GetComponent<RawImage>().color, new Color(1, 1, 1, 1), Time.deltaTime * j);
                Objects[num2].transform.position = Vector3.MoveTowards(Objects[num2].transform.position, positions[1].position, Time.deltaTime * i);
                Objects[num2].transform.localScale = Vector3.Lerp(Objects[num2].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * j);
                */
                /*
                MoveObject(num6, 3,1f);
                Objects[num5].transform.SetAsFirstSibling();
                MoveObject(num5, 4,0.3f);
                MoveObject(num4, 5,0.3f);
                Objects[num3].transform.SetAsFirstSibling();
                MoveObject(num3, 0,0.3f);
                MoveObject(num2, 1,1f);
                */
                MoveObject(nums[5], 3, 1f,0.8f,1);
                Objects[nums[4]].transform.SetAsFirstSibling();
                MoveObject(nums[4], 4, 0.3f,0.8f,0.8f);
                MoveObject(nums[3], 5, 0.3f,0.8f,1.7f);
                Objects[nums[2]].transform.SetAsFirstSibling();
                MoveObject(nums[2], 0, 0.3f,0.8f,1.7f);
                MoveObject(nums[1], 1, 1f,0.8f,0.8f);

            }
            yield return null;
        }
        Debug.Log("END");
        looping = false;
        yield break;
    }
    public void DOTPONWheelGame(int num, bool plus)
    {
        if (moveCoroutineGame != null)
        {
            StopCoroutine(moveCoroutineGame);
            moveCoroutine = null;
            Debug.Log("endCoroutine");
        }
        moveCoroutineGame = MoveWheelGame(num,plus);
        StartCoroutine(moveCoroutineGame);
    }
    private IEnumerator MoveWheelGame(int num, bool plus)
    {
        int[] nums = new int[3];
        switch (num)
        {
            case 0:
                nums = new int[] { 0, 1, 2 };
                break;
            case 1:
                nums = new int[] { 1, 2, 0 };
                break;
            case 2:
                nums = new int[] { 2, 0, 1 };
                break;
        }
        for (int i = nums.Length; i < 0; i--)
        {
            int posNumber = 0;
            if (i - 2 < 0)
            {
                posNumber = i +2;
            }
            else
            {
                posNumber = i - 2;
            }
            Objects[nums[i]].transform.position = positions[posNumber].position;
        }
        float tim = 0;
        while (tim < 40)
        {
            tim++;
            Objects[nums[0]].transform.SetAsLastSibling();
            MoveObject(nums[0],1,1f,1.1f,1);
            if (!plus)
            {
                Debug.Log("moveright");
                /*
                Objects[nums[1]].GetComponent<RawImage>().color = Color.Lerp(Objects[nums[1]].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * j);
                childObjects[nums[1]].GetComponent<RawImage>().color = Color.Lerp(childObjects[nums[1]].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[nums[1]].transform.position = Vector3.MoveTowards(Objects[nums[1]].transform.position, positions[2].position, i);
                Objects[nums[1]].transform.localScale = Vector3.Lerp(Objects[nums[1]].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[nums[2]].GetComponent<RawImage>().color = Color.Lerp(Objects[nums[2]].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                childObjects[nums[2]].GetComponent<RawImage>().color = Color.Lerp(childObjects[nums[2]].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[nums[2]].transform.position = Vector3.MoveTowards(Objects[nums[2]].transform.position, positions[0].position, i * 2);
                Objects[nums[2]].transform.localScale = Vector3.Lerp(Objects[nums[2]].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                */
                MoveObject(nums[2], 0, 0.3f, 0.8f, 2);
                MoveObject(nums[1], 2, 0.3f, 0.8f, 1);
            }
            else
            {
                Debug.Log("moveleft");
                /*
                Objects[nums[2]].GetComponent<RawImage>().color = Color.Lerp(Objects[nums[2]].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                childObjects[nums[2]].GetComponent<RawImage>().color = Color.Lerp(childObjects[nums[2]].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[nums[2]].transform.position = Vector3.MoveTowards(Objects[nums[2]].transform.position, positions[0].position, i);
                Objects[nums[2]].transform.localScale = Vector3.Lerp(Objects[nums[2]].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[nums[1]].GetComponent<RawImage>().color = Color.Lerp(Objects[nums[1]].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                childObjects[nums[1]].GetComponent<RawImage>().color = Color.Lerp(childObjects[nums[1]].GetComponent<RawImage>().color, new Color(1, 1, 1, 0.3f), Time.deltaTime * 20);
                Objects[nums[1]].transform.position = Vector3.MoveTowards(Objects[nums[1]].transform.position, positions[2].position, i * 2);
                Objects[nums[1]].transform.localScale = Vector3.Lerp(Objects[nums[1]].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                */
                MoveObject(nums[1], 2, 0.3f, 0.8f, 2);
                MoveObject(nums[2], 0, 0.3f, 0.8f, 1);
            }
            text.transform.SetAsLastSibling();
            yield return null;
        }
        Debug.Log("END");
        looping = false;
        yield break;
    }

    private void MoveObject(int obj,int position,float alpha,float size,float moveSpeed)
    {
        Objects[obj].GetComponent<RawImage>().color = Color.Lerp(Objects[obj].GetComponent<RawImage>().color, new Color(1, 1, 1, alpha), Time.deltaTime * j);
        childObjects[obj].GetComponent<RawImage>().color = Color.Lerp(childObjects[obj].GetComponent<RawImage>().color, new Color(1, 1, 1, alpha), Time.deltaTime * j);
        Objects[obj].transform.position = Vector3.MoveTowards(Objects[obj].transform.position, positions[position].position, Time.deltaTime * i * moveSpeed);
        Objects[obj].transform.localScale = Vector3.Lerp(Objects[obj].transform.localScale, new Vector3(size, size, 0), Time.deltaTime * j);
    }
}

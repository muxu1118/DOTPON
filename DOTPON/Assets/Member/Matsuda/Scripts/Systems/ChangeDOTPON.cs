using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDOTPON : MonoBehaviour
{
    [SerializeField] private GameObject[] Objects;
    [SerializeField] RectTransform[] positions;
    bool isMove = true;
    int i, j, k;
    bool looping = false;
    // Start is called before the first frame update
    void Start()
    {
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
        if (num2 > 2) num2 = 0;
        int num3 = num2 + 1;
        if (num3 > 2) num3 = 0;
        float tim = 0;
        while (tim < 10)
        {
            tim++;
            Objects[num].transform.position = Vector3.Lerp(Objects[num].transform.position, positions[1].position, Time.deltaTime * 20);
            Objects[num].transform.localScale = Vector3.Lerp(Objects[num].transform.localScale, new Vector3(1, 1, 0), Time.deltaTime * 20);
            if (plus)
            {
                Objects[num2].transform.position = Vector3.Lerp(Objects[num2].transform.position, positions[0].position, Time.deltaTime * 20);
                Objects[num2].transform.localScale = Vector3.Lerp(Objects[num2].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num3].transform.position = Vector3.Lerp(Objects[num3].transform.position, positions[2].position, Time.deltaTime * 20);
                Objects[num3].transform.localScale = Vector3.Lerp(Objects[num3].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
            }
            else
            {
                Objects[num3].transform.position = Vector3.Lerp(Objects[num3].transform.position, positions[2].position, Time.deltaTime * 20);
                Objects[num3].transform.localScale = Vector3.Lerp(Objects[num3].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
                Objects[num2].transform.position = Vector3.Lerp(Objects[num2].transform.position, positions[0].position, Time.deltaTime * 20);
                Objects[num2].transform.localScale = Vector3.Lerp(Objects[num2].transform.localScale, new Vector3(0.8f, 0.8f, 0), Time.deltaTime * 20);
            }
            yield return null;
        }
        Debug.Log("END");
        looping = false;
        yield break;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    bool trigger;
    

    private void Update()
    {
        if(this.gameObject.transform.localPosition.y <= 0)
        {
            this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x,0, this.gameObject.transform.localPosition.z);
        }
    }

    public void EndMainGame()
    {
        if (trigger) return;
        this.gameObject.transform.SetAsLastSibling();
        Debug.Log("EndEndCoroutineStart");
        StartCoroutine(EndCoroutine());
    }

    IEnumerator EndCoroutine()
    {
        Debug.Log("EndEndCoroutineNow");
        trigger = true;
        float time = 0;
        while (time <= 10)
        {
            this.gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0,-8,0);
            time += Time.deltaTime;
            yield return null;
        }
    }
}

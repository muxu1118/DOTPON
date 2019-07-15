using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerEffect : MonoBehaviour
{
    Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        img.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.img.color = new Color(0.5f,0,0,0.5f);
        }
        else
        {
            this.img.color = Color.Lerp(this.img.color,Color.clear,Time.deltaTime);
        }
    }
}

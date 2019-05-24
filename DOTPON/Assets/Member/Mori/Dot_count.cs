using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dot_count : MonoBehaviour
{


    public Text Dot_Text;
    
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 10;
    }

    // Update is called once per frame
    void Update()
    {
        SetCountText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        //Dot_Text.text = "×" + MultiPlayerManager.instance.P1dot();
        
    }
}

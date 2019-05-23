using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class test2 : MonoBehaviour
{
    public Text Player1dot;
    // Start is called before the first frame update
    void Start()
    {
        Player1dot.text = MultiPlayerManager.instance.P1Dot.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

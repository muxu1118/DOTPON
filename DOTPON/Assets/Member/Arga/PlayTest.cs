using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTest : MonoBehaviour
{
    public Text number;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        number.text = MultiPlayerManager.instance.TotalPlayer.ToString();
    }

    public void Plus()
    {
        MultiPlayerManager.instance.TotalPlayer++;
    }

    public void Minus()
    {
        MultiPlayerManager.instance.TotalPlayer--;
    }


    public void twoPlayer()
    {
        MultiPlayerManager.instance.TotalPlayer = 2;
    } 

    public void threePlayer()
    {
        MultiPlayerManager.instance.TotalPlayer = 3;
    } 

    public void fourPlayer()
    {
        MultiPlayerManager.instance.TotalPlayer = 4;
    } 
}

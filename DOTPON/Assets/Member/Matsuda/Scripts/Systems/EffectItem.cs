using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectItem : MonoBehaviour
{
    RectTransform rct;
    Rigidbody2D rg2d;
    private void Start()
    {
        rct = GetComponent<RectTransform>();
        rg2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(rct.localPosition.y <= -Screen.height)
        {
            rg2d.simulated = false;
        }
    }
}

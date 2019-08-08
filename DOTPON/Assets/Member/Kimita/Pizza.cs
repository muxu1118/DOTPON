using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pizza : MonoBehaviour
{
    Image pizza;
    // Start is called before the first frame update
    void Start()
    {
        pizza = GetComponent<Image>();

        pizza.fillAmount = 0;
    }
    public void PizzaUI(int n)
    {

        pizza.fillAmount =(n != 0)? 1 - (1 / n):0;

    }

    /// <summary>
    /// ドットポンをチェンジした際にピザの大きさが変わる。
    /// </summary>
    /// <param name="n1">その時のプレイヤーのドット数</param>
    /// <param name="n2">武器に必要なドット数</param>
    public void PizzaChange(int n1, int n2)
    {
        if (n1 <= 0)
        {
            pizza.fillAmount = 0;
        }
        else if (n2 - n1 <= 0)
        {
            pizza.fillAmount = 1;
        }
        else
        {
            pizza.fillAmount =  (float)(n1 / n2);
        }
    }
    private void Update()
    {
    }
}

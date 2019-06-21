using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotPonDruble : MonoBehaviour
{
    [SerializeField] GameObject weaponObj;
    int value;
    // Start is called before the first frame update
    void Start()
    {
        value = weaponObj.GetComponent<weapon>().parametor.durableValue;
    }
    /// <summary>
    /// 耐久値がダウンした時に呼ばれる関数
    /// </summary>
    public void DownDursble(GameObject obj)
    {
        value--;
        if(value <= 0) { obj.SetActive(false); }

    }
}

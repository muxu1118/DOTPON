using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCreate : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapon;
    [SerializeField]
    Transform point;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //Create(0);
    }

    /// <summary>
    /// 指定のDOTPONを作成
    /// </summary>
    public void Create(int x)
    {        
        Instantiate(weapon[x], point.transform.position, Quaternion.identity);            
    }
}

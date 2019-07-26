using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerPlayer : MonoBehaviour
{
    [SerializeField]GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var obj = Instantiate(playerPrefab, this.gameObject.transform.localPosition + new Vector3(0,1,0), Quaternion.identity);
        obj.transform.Rotate(new Vector3(0,150,0));
        obj.name = "Player" + MultiPlayerManager.instance.Ranking1;
    }
    
}

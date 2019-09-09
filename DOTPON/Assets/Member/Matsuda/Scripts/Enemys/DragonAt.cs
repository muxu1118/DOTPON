using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAt : MonoBehaviour
{
    public bool attackOk;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "player") return;
        attackOk = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "player") return;
        attackOk = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    [SerializeField] GameObject player;
    Vector3 vector;
    bool isRotate = false;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        vector = transform.forward;
        HP = parameter.HP;
        DropDotNumber = parameter.dropDot;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        DropDot(gameObject);
        if (isRotate) return;
        transform.position += vector * 0.02f;
        if (time > 3 && !isLooking)
        {
            isRotate = true;
            RotateChange();
            StartCoroutine(WaitTime());
            time = 0;
        }
        vector = transform.forward;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            transform.LookAt(player.transform.position);
            vector = transform.forward;
            isLooking = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isLooking = false;
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1);
        isRotate = false;
        yield break;
    }
}


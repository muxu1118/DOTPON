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
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        DropDot(gameObject);
        if (isRotate) return;
        transform.position += vector * 0.02f;
        RotateChange();
        vector = transform.forward;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == player.GetComponent<BoxCollider>())
        {
            transform.LookAt(player.transform.position);
            vector = transform.forward;
        }
    }
    private void RotateChange()
    {
        if(time > 3)
        {
            //アニメーションつかうかも
            isRotate = true;
            StartCoroutine(Rotating());
            StartCoroutine(WaitTime());
            time = 0;
        }
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1);
        isRotate = false;
        yield break;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goburin : Enemy
{
    [SerializeField] GameObject player;
    Vector3 vector;
    [SerializeField]GameObject[] lookingCollider;
    bool isAction = false;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        vector = transform.forward;
        HP = parameter.HP;
        DropDotNumber = parameter.dropDot;
        speed = parameter.speed / 100;
        rotateTime = parameter.rotateTime;
        rotateAngle = parameter.rotateAngle;
        lookingAngle = parameter.lookingAngle / 2;
        distance = parameter.distance;
        for (int i = 0;i < 3;i++)
        {
            lookingCollider[i].GetComponent<BoxCollider>().size = new Vector3(lookingAngle, 1, lookingAngle);
            switch (i)
            { 
                case 1:
                    lookingCollider[i].transform.localPosition = new Vector3(0, 0, CantLookPos(lookingAngle));
                    break;
                case 2:
                    lookingCollider[i].transform.localPosition = new Vector3(CantLookPos(lookingAngle), 0, 0);
                    break;
                case 3:
                    lookingCollider[i].transform.localPosition = new Vector3(-CantLookPos(lookingAngle), 0, 0);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        DropDot(gameObject);
        if (isAction) return;
        transform.position += vector * speed;
        if (time > 3 && !isLooking)
        {
            isAction = true;
            StartCoroutine(Rotating(rotateAngle,rotateTime * 60));
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
            float dis = Vector3.Distance(this.transform.position, other.gameObject.transform.position);
            if(dis <= distance)
            {
                isAction = true;
                Attack();
                StartCoroutine(WaitTime());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isLooking = false;
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(rotateTime);
        isAction = false;
        yield break;
    }
}

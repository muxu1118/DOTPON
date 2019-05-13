using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goburin : Enemy
{
    [SerializeField] GameObject player;
    [SerializeField] BoxCollider lookingCollider;
    [SerializeField] GameObject cantLookingCollder;
    Vector3 vector;
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
        lookingAngle = parameter.lookingAngle;
        distance = parameter.distance;
        lookingCollider.size = new Vector3(lookingAngle,1,lookingAngle);
        float pos = CantLookPos(lookingAngle);
        cantLookingCollder.transform.position = new Vector3(0,0,pos);
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
                other.gameObject.GetComponent<plaer_m>().Damage();
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

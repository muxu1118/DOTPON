using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnim : MonoBehaviour
{
    Animator animator;
    double time;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time <= 1 || GetComponent<Dragon>().isAction) return;
        int i = Random.Range(0, 6) + Random.Range(0, 6);
        if (i == 6)
        {
            animator.SetTrigger("Change");
        }
        time = 0;

    }
    //しっぽ
    private void Tall()
    {
        //animator.SetTrigger("Tall");
        Debug.Log("tall");
    }
    //首振り
    private void Head()
    {
        //animator.SetTrigger("Head");
        Debug.Log("head");
    }
    //足踏み
    private void Leg()
    {
        // animator.SetTrigger("Leg");
        Debug.Log("leg");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera12 : MonoBehaviour
{
    [SerializeField] GameObject efe;
    [SerializeField] GameObject hnd;
    [SerializeField] GameObject buki;
    bool trg = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick 1 button 3"))
        {
            if (trg)
            {
                StartCoroutine(Cre());
                trg = false;
            }
            else
            {
                trg = true;
            }
        }
        if (Input.GetKeyDown("joystick 1 button 0"))
        {
            buki.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ScreenCapture.CaptureScreenshot("field.png");
            Debug.Log("screenshot");
        }
    }

    IEnumerator Cre()
    {
        var ef = Instantiate(efe, transform.localPosition + new Vector3(0,2,0) + transform.right /2, Quaternion.identity).transform.parent = transform;
        yield return new WaitForSeconds(1.5f);
        //GetComponent<Animator>().SetTrigger("Create");
        yield return new WaitForSeconds(0.4f);
        //buki.SetActive(true);

    }
}

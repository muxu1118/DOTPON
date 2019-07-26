using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField] GameObject img;
    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        x = Screen.width;
        y = Screen.height;
        SwitchScene();
    }
    

    public void SwitchScene()
    {
        StartCoroutine(DropDot());
    }

    IEnumerator DropDot()
    {
        GameObject game = new GameObject("SceneEffect");
        game.transform.SetParent(GameObject.Find("Canvas").transform, false);
        int count = 0;
        while (count <= 180)
        {
            Instantiate(img, new Vector3(Random.Range(-x, x++), y, 0), Quaternion.identity).transform.SetParent(game.transform,false);
            count++;
            yield return null;
        }
    }
}

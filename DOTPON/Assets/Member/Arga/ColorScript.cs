using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{
    [SerializeField]
    float damageOnTime = 0.2f;
    GameObject mainOb;
    Renderer cloakColor,headColor;
    Renderer[] allRenderer;
    string colorType;
    // Start is called before the first frame update
    void Start()
    {
        mainOb = this.transform.Find("Charcter").gameObject;
        allRenderer = mainOb.GetComponentsInChildren<Renderer>();
        cloakColor = this.transform.Find("Charcter/manto").gameObject.GetComponent<Renderer>();
        headColor = this.transform.Find("Charcter/hood").gameObject.GetComponent<Renderer>();
        colorType = this.name;

        switch (colorType)
        {
            case "Player1":
                cloakColor.material = MultiPlayerManager.instance.mat1;
                headColor.material = MultiPlayerManager.instance.mat1;
                break;
            case "Player2":
                cloakColor.material = MultiPlayerManager.instance.mat2;
                headColor.material = MultiPlayerManager.instance.mat2;
                break;
            case "Player3":
                cloakColor.material = MultiPlayerManager.instance.mat3;
                headColor.material = MultiPlayerManager.instance.mat3;
                break;
            case "Player4":
                cloakColor.material = MultiPlayerManager.instance.mat4;
                headColor.material = MultiPlayerManager.instance.mat4;
                break;
            default:
                Debug.LogError("error");
                break;
        }
    }

    public void DamagedOn()
    {
        StartCoroutine("DamagedColor");
    }

    IEnumerator DamagedColor()
    {
        
        foreach (Renderer rend in allRenderer)
        {
            for (var j = 0; j < allRenderer.Length; j++)
            {
                allRenderer[j].material.EnableKeyword("_EMISSION");
                allRenderer[j].material.SetColor("_EmissionColor", Color.red);
            }
        }
        yield return new WaitForSeconds(damageOnTime);

        foreach (Renderer rend in allRenderer)
        {
            for (var j = 0; j < allRenderer.Length; j++)
            {
                allRenderer[j].material.DisableKeyword("_EMISSION");
            }
        }

    }

 //   IEnumerator BlinkingColor()
 //   {

 //   }




    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{

    Renderer cloakColor,headColor;
    string colorType;
    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}

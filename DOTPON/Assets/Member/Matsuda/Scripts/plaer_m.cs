using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plaer_m : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] GameObject obj;
    [SerializeField] GameObject obj2;
    [SerializeField] GameObject goburin;
    bool isDamage = false;
    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        KeyInout();
    }
    void KeyInout()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerMove(new Vector3(0, 0, 5));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerMove(new Vector3(-5, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerMove(new Vector3(0, 0, -5));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerMove(new Vector3(5, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           obj.GetComponent<Goburin>().Damage(1);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            obj2.GetComponent<Slime>().Damage(1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject _object = new GameObject("GoburinFlock");
            for(int i = 0;i < 2; i++)
            {
                for(int j = 0;j < 2; j++)
                {
                    Instantiate(obj, new Vector3(i, 1, j), Quaternion.identity).transform.parent = _object.transform;
                }
            }
        }
    }
    void PlayerMove(Vector3 vec)
    {
        GetComponent<Rigidbody>().velocity += vec;
    }
    public void Damage(int damage)
    {
        if (isDamage) return;
        hp = hp - damage;
        Debug.Log(hp);
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
        isDamage = true;
        StartCoroutine(DamegeWait());
    }
    IEnumerator DamegeWait()
    {
        yield return new WaitForSeconds(1);
        isDamage = false;
    }
}

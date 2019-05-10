using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parametor : MonoBehaviour
{

    [CreateAssetMenu(menuName = "MyGame/Create ParameterTable", fileName = "ParameterTable")]
    public class Status : ScriptableObject
    {
        [SerializeField]
        private int attackSpeed; //攻撃速度

        [SerializeField]
        private int attackDamage; //威力

        [SerializeField]
        private int necessaryDot; //必要ドット数

        [SerializeField]
        private int durableValue; //耐久値

        [SerializeField]
        private GameObject weapon; //武器のオブジェクト

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

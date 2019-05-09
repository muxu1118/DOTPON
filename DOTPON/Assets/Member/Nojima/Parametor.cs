using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parametor : MonoBehaviour
{
    public object weapon;

    [CreateAssetMenu(menuName = "MyGame/Create ParameterTable", fileName = "ParameterTable")]
    public class AttacSpeed : ScriptableObject
    {
        [SerializeField]
        public int attackSpeed; //攻撃速度

        [SerializeField]
        public int attackDamage; //威力

        [SerializeField]
        public int necessaryDot; //必要ドット数

        [SerializeField]
        public int durableValue; //耐久値

        [SerializeField]
        public GameObject weapon; //武器のオブジェクト

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

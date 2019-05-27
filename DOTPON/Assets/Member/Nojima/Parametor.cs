using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(menuName = "MyGame/Create ParameterTable", fileName = "ParameterTable")]
    public class Parametor : ScriptableObject
    {
        [SerializeField]
        [HeaderAttribute("攻撃速度")]
        public int attackSpeed; //攻撃速度
  
        [SerializeField]
        [HeaderAttribute("攻撃力")]
        public int attackDamage; //威力

        [SerializeField]
        [HeaderAttribute("必要ドット数")]
        public int necessaryDot; //必要ドット数


        [SerializeField]
        [HeaderAttribute("耐久値")]
        public int durableValue; //耐久値

        [SerializeField]
        [HeaderAttribute("必要ドット数")]
        public int dotNum;

        [SerializeField]
        [HeaderAttribute("武器のオブジェクト")]
        public GameObject weapon; //武器のオブジェクト

    }
 
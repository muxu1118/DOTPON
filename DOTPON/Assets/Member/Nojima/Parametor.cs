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
        private int attackDamage; //威力

        [SerializeField]
        [HeaderAttribute("必要ドット数")]
        private int necessaryDot; //必要ドット数


        [SerializeField]
        [HeaderAttribute("耐久値")]
        private int durableValue; //耐久値

        [SerializeField]
        [HeaderAttribute("武器のオブジェクト")]
        private GameObject weapon; //武器のオブジェクト

    }
 
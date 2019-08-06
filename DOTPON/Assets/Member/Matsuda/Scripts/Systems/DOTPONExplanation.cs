using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DOTPONExplanation : MonoBehaviour
{
    [SerializeField] Weapon[] objs;
    [SerializeField] Text DotponName,attack, dursble, cost, explanation;
    public void SetExplanation(int num)
    {
        DotponName.text = objs[num].gameObject.name;
        attack.text = "攻撃力：" + objs[num].parametor.attackDamage;
        dursble.text = "耐久値：" + objs[num].parametor.durableValue;
        cost.text = "作成コスト：" + objs[num].parametor.dotNum;
        explanation.text = objs[num].parametor.Commentary;//説明用変数;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarAttack : MonoBehaviour
{
    // timeSpeedは速さ、ratioは割合（どこで落ちるか）、angleは基準の角度、powは投げる距離
    public float timeSpeed, ratio, angle, Range,pow; //　おすすめ(0.4,1,90,2.5)

    private Vector3 defaultPos;
    private Vector3 speed; //上下の速度の処理（予定）    
    private Bomb bombDamage;

    [SerializeField] Vector3 vecter;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        vecter = this.gameObject.transform.root.forward;
        vecter = new Vector3(vecter.x * pow + this.gameObject.transform.position.x,0, vecter.z * pow + this.gameObject.transform.position.z);
        bombDamage = GetComponent<Bomb>();

        //エネミーだったらすぐにボムを投げる
        if (transform.root.gameObject.tag == "enemy")
        {
            StartCoroutine(PosMove(vecter));
        }                                                                            
    }

    public void PosMove2(float pow2)
    {
        Vector3 vecter2 = this.gameObject.transform.root.forward;
        vecter2 = new Vector3(vecter2.x * pow2 + this.gameObject.transform.position.x, 0, vecter2.z * pow2 + this.gameObject.transform.position.z);
        StartCoroutine(PosMove(vecter2));
        if (this.gameObject.name == "bomb(Clone)")
        {
            StartCoroutine(Times());
        }
    }

    IEnumerator PosMove(Vector3 vec)
    {
        Vector3 offset = gameObject.transform.position;
        // 0が初期値　1が終点　全体の割合   
        float t = 0f;
        //目的地から現在地の差分
        Vector3 P2 = vec - offset;
        // 総移動距離を求める（直線）
        float distance = Vector3.Distance(offset, new Vector3(vec.x, vec.y, vec.z));
        // 最大角度
        float max_angle = 180f;
        // 基準の距離
        float base_range = 5f;
        // 実際の角度 = 基準の角度 * 実際の距離 / 基準の距離
        angle = angle * distance / base_range;
        if (angle > max_angle)
        {
            angle = max_angle;
        }
        float P1x = P2.x * ratio;
        float P1z = P2.z * ratio;
        //angle * Mathf.Deg2Rad 角度からラジアンへ変換
        //float P1y = Mathf.Sin(angle * Mathf.Deg2Rad) * Mathf.Abs((P1x + P1z) / 2) / Mathf.Cos(angle * Mathf.Deg2Rad);
        float P1y = 5f;
        Vector3 P1 = new Vector3(P1x, P1y, P1z);
        // 終点についたらおしまい
        while (t <= 1)
        {
            // [x,y]=(1–t)2P0+2(1–t)tP1+t2P2
            float Vx = 2 * (1f - t) * t * P1.x + Mathf.Pow(t, 2) * P2.x + offset.x;
            float Vy = 2 * (1f - t) * t * P1.y + Mathf.Pow(t, 2) * P2.y + offset.y;
            float Vz = 2 * (1f - t) * t * P1.z + Mathf.Pow(t, 2) * P2.z + offset.z;
            transform.position = new Vector3(Vx, Vy, Vz);
            // １秒あたりのtの変化量 *1フレーム
            t += 1 / distance / timeSpeed * Time.deltaTime;
            defaultPos = transform.position;
            yield return null;
        }

        //if (gameObject.name == "bomb(Clone)")
        //{
        //    //ここで爆発によるダメージが入る
        //    //bombDamage.ExplotionCoroutine();
            
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}        
    }
    IEnumerator Times()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponent<SphereCollider>().enabled = true;
    }
}

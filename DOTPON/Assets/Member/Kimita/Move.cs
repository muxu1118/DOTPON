using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // timeSpeedは速さ、ratioは割合（どこで落ちるか）、angleは基準の角度
    public float timeSpeed, ratio, angle,Range; //　おすすめ(0.4,1,90,2.5)

    private Vector3 defaultPos;
    private Vector3 speed; //上下の速度の処理（予定）

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PosMove(new Vector3(Random.Range(gameObject.transform.position.x - Range, gameObject.transform.position.x + Range),0, Random.Range(gameObject.transform.position.z - Range, gameObject.transform.position.z + Range))));

    }

    void Update()
    {
        transform.Rotate(new Vector3(65.0f, 65.0f, -35.0f) * Time.deltaTime);
        transform.position = (new Vector3(defaultPos.x, defaultPos.y + Mathf.PingPong(0.6f * Time.time, 0.6f)));
        //回転の処理
    }
    /// <summary>
    /// ブローチを目的の位置に移動させる
    /// </summary>
    /// <param name="vec">目的の位置</param>
    /// <returns></returns>
    IEnumerator PosMove(Vector3 vec)
    {
        Vector3 offset = gameObject.transform.position;
        // 0が初期値　1が終点　全体の割合   
        float t = 0f;
        //目的地から現在地の差分
        Vector3 P2 = vec - offset;
        // 総移動距離を求める（直線）
        float distance = Vector3.Distance(offset, new Vector3(vec.x, vec.y,vec.z));
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
        float P1y = Mathf.Sin(angle * Mathf.Deg2Rad) * Mathf.Abs(P1x) / Mathf.Cos(angle * Mathf.Deg2Rad);
        Vector3 P1 = new Vector3(P1x, P1y,P1z);
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
        
        
    }

}

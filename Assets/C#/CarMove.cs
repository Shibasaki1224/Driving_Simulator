using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMove : MonoBehaviour
{
    public WheelCollider FL, FR, RL, RR;    //WheelColliderの取得
    public float maxPower;  //最高出力トルク
    public float angle;     //ハンドルを切った時の最高角度
    public float breakePower;     //最大ブレーキトルク
    float Vertical, Horizontal, Breake;
    public Text txt;

    public int input;

    void FixedUpdate()
    {
        Vertical= Input.GetAxis("Vertical") + input;
        Horizontal = Input.GetAxis("Horizontal");
        Breake = (Input.GetAxis("Break") + input)/2 * breakePower;
        Debug.Log(Breake);
        FL.motorTorque = maxPower * (Vertical);   //左リアタイヤのモータートルク
        FR.motorTorque = maxPower * (Vertical);   //右リアタイヤのモータートルク
        RL.motorTorque = maxPower * (Vertical);   //左リアタイヤのモータートルク
        RR.motorTorque = maxPower * (Vertical);   //右リアタイヤのモータートルク

        FL.steerAngle = angle * Horizontal;   //左フロントタイヤの角度
        FR.steerAngle = angle * Horizontal;   //右フロントタイヤの角度

        if (Breake > 0)       //ブレーキシステム
        {
            FL.brakeTorque = Breake;
            FR.brakeTorque = Breake;
            RL.brakeTorque = Breake;
            RR.brakeTorque = Breake;
        }
        else           //ブレーキを踏んでいないときの挙動
        {
            FL.brakeTorque = 0;
            FR.brakeTorque = 0;
            RL.brakeTorque = 0;
            RR.brakeTorque = 0;
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Rail")
        {
            int x = collision.GetComponent<Rail_Select>().Rail.Length;
            int y = (int)Random.Range(0, x);

            if (y == 0)
            {   //直進
                txt.GetComponent<Text>().text = "直進";
            }
            else if(y == 1)
            {   //左折
                txt.GetComponent<Text>().text = "左折";

            }
            else
            {   //右折
                txt.GetComponent<Text>().text = "右折";

            }
        }
    }
}

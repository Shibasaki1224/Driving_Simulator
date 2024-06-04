using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public WheelCollider FL, FR, RL, RR;    //WheelColliderの取得
    public float maxPower;  //最高出力トルク
    public float angle;     //ハンドルを切った時の最高角度
    float Vertical, Horizontal, Breake;

    public int input;

    void FixedUpdate()
    {
        Vertical= Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        Breake = Input.GetAxis("Break") * 1000;

        FL.motorTorque = maxPower * (Vertical + input);   //左リアタイヤのモータートルク
        FR.motorTorque = maxPower * (Vertical + input);   //右リアタイヤのモータートルク
        RL.motorTorque = maxPower * (Vertical + input);   //左リアタイヤのモータートルク
        RR.motorTorque = maxPower * (Vertical + input);   //右リアタイヤのモータートルク

        FL.steerAngle = angle * Horizontal;   //左フロントタイヤの角度
        FR.steerAngle = angle * Horizontal;   //右フロントタイヤの角度

        if ((Breake + input) > 0)       //ブレーキシステム
        {
            FL.brakeTorque = Breake + input;
            FR.brakeTorque = Breake + input;
            RL.brakeTorque = Breake + input;
            RR.brakeTorque = Breake + input;
        }
        else           //ブレーキを踏んでいないときの挙動
        {
            FL.brakeTorque = 0;
            FR.brakeTorque = 0;
            RL.brakeTorque = 0;
            RR.brakeTorque = 0;
        }
    }
    void Update()   //シフトレバー制作中･･･
    {

    }
}

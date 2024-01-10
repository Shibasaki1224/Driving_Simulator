using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public WheelCollider FL, FR, RL, RR;    //WheelColliderの取得
    public float maxPower;  //最高出力トルク
    public float angle;     //ハンドルを切った時の最高角度
    public float breake;    //ブレーキの力
    string ShiftLever;      //シフトレバー制作中･･･

    public int input;

    void FixedUpdate()
    {
        FL.motorTorque = maxPower * (Input.GetAxis("Vertical") + input);   //左リアタイヤのモータートルク
        FR.motorTorque = maxPower * (Input.GetAxis("Vertical") + input);   //右リアタイヤのモータートルク
        RL.motorTorque = maxPower * (Input.GetAxis("Vertical") + input);   //左リアタイヤのモータートルク
        RR.motorTorque = maxPower * (Input.GetAxis("Vertical") + input);   //右リアタイヤのモータートルク

        FL.steerAngle = angle * Input.GetAxis("Horizontal");   //左フロントタイヤの角度
        FR.steerAngle = angle * Input.GetAxis("Horizontal");   //右フロントタイヤの角度

        if ((Input.GetAxis("Break") + input) > 0)       //ブレーキシステム
        {
            FL.brakeTorque = breake * (Input.GetAxis("Break") + input);
            FR.brakeTorque = breake * (Input.GetAxis("Break") + input);
            RL.brakeTorque = breake * (Input.GetAxis("Break") + input);
            RR.brakeTorque = breake * (Input.GetAxis("Break") + input);
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
        if (Input.GetKeyDown("joystick button 0"))
            ShiftLever = "D";
        if (Input.GetKeyDown("joystick button 1"))
            ShiftLever = "R";

        if (ShiftLever == "D")
            Debug.Log("aaa");
    }
}

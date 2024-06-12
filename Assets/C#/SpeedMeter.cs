using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpeedMeter : MonoBehaviour
{
    public bool System;

    public Text txt;
    Text MeterText;
    Rigidbody rb;
    public float speed;

    Vector3 posi, _posi, Distance;
    float Meter;

    void FixedUpdate()
    {
        MeterText = txt.GetComponent<Text>();       //TextUIを取得
        if(System==true)    //Rigidbodyで敬さん
        {
            rb = GetComponent<Rigidbody>();             //Rigidodyの取得
            speed = rb.velocity.magnitude * 3.6f;       //速度[km/h] = 速度[m/s] × 3.6
            MeterText.text = ((int)speed) + " km/h";    //TextUIに表示
        }
        else                //座標で敬さん
        {
            posi = transform.position;  //オブジェクトの[現在の位置]の取得
            Distance = posi - _posi;    //[現在の位置] - [過去の位置]の計算
            _posi = posi;               //[現在の位置]を[過去の位置]に保存

            //[速さ(km/h)] = [ベクトルの長さ(m)] ÷ [時間(s)] × 3.6(m/s → km/h)
            Meter = (Distance.magnitude) / 0.02f * 3.6f;
            MeterText.text = ((int)Meter) + "km/h";    //現在の速度をTextUIに表示
        }
    }
}
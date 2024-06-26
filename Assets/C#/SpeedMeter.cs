using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpeedMeter : MonoBehaviour
{
    public Text SpeedText;
    public RectTransform AxelMeter, BreakeMeter;
    Text MeterText;
    Rigidbody rb;
    public float speed;

    void FixedUpdate()
    {
        MeterText = SpeedText.GetComponent<Text>();       //TextUIを取得
        rb = GetComponent<Rigidbody>();             //Rigidodyの取得
        speed = rb.velocity.magnitude * 3.6f;       //速度[km/h] = 速度[m/s] × 3.6
        MeterText.text = ((int)speed) + " km/h";    //TextUIに表示

        AxelMeter.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Input.GetAxis("Vertical")*100);
        BreakeMeter.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Input.GetAxis("Vertical")*-100);
    }
}
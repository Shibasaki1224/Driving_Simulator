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
        MeterText = SpeedText.GetComponent<Text>();       //TextUI‚ğæ“¾
        rb = GetComponent<Rigidbody>();             //Rigidody‚Ìæ“¾
        speed = rb.velocity.magnitude * 3.6f;       //‘¬“x[km/h] = ‘¬“x[m/s] ~ 3.6
        MeterText.text = ((int)speed) + " km/h";    //TextUI‚É•\¦

        AxelMeter.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Input.GetAxis("Vertical")*100);
        BreakeMeter.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Input.GetAxis("Vertical")*-100);
    }
}
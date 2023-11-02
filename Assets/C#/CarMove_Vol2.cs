using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove_Vol2 : MonoBehaviour
{
    public HingeJoint FL, FR, RL, RR, Axle_L, Axle_R;

    void Update()
    {
        var Power = FL.motor;
        Power.targetVelocity = 100 * Input.GetAxis("Vertical");
        FL.motor = Power;
        FR.motor = Power;
        RL.motor = Power;
        RR.motor = Power;

        var Angle = Axle_L.spring;
        Angle.targetPosition = 30 * Input.GetAxis("Horizontal");
        Axle_L.spring = Angle;
        Axle_R.spring = Angle;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove_Vol2 : MonoBehaviour
{
    public HingeJoint  Axle_L, Axle_R;
    public float MotorPower , AngularVelocity;
    public Rigidbody FL, FR, RL, RR;
    public float BreakPower;
    void Start()
    {
        FL.maxAngularVelocity = AngularVelocity;
        FR.maxAngularVelocity = AngularVelocity;
        RL.maxAngularVelocity = AngularVelocity;
        RR.maxAngularVelocity = AngularVelocity;
    }

    void Update()
    {
        var Angle = Axle_L.spring;
        Angle.targetPosition = 30 * Input.GetAxis("Horizontal");
        Axle_L.spring = Angle;
        Axle_R.spring = Angle;

        if (Input.GetAxis("Break") > 0)
        {
            FL.AddForce(-FL.velocity * Input.GetAxis("Break") * BreakPower);
            FR.AddForce(-FR.velocity * Input.GetAxis("Break") * BreakPower);
            RL.AddForce(-RL.velocity * Input.GetAxis("Break") * BreakPower);
            RR.AddForce(-RR.velocity * Input.GetAxis("Break") * BreakPower);
        }
        else
        {
            float Motor = MotorPower * -Input.GetAxis("Vertical");
            FL.AddRelativeTorque(0, Motor, 0);
            FR.AddRelativeTorque(0, Motor, 0);
            RL.AddRelativeTorque(0, Motor, 0);
            RR.AddRelativeTorque(0, Motor, 0);
        }
    }
}

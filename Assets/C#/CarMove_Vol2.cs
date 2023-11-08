using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove_Vol2 : MonoBehaviour
{
    public HingeJoint  Axle_L, Axle_R;
    public float MotorPower;
    public Rigidbody FL, FR, RL, RR;
    void Start()
    {
        FL.maxAngularVelocity = 120;
        FR.maxAngularVelocity = 120;
        RL.maxAngularVelocity = 120;
        RR.maxAngularVelocity = 120;
    }

    void Update()
    {
        float Motor = MotorPower * Input.GetAxis("Vertical");
        FL.AddTorque(Motor, 0, 0, ForceMode.Force);
        FR.AddTorque(Motor, 0, 0, ForceMode.Force);
        RL.AddTorque(Motor, 0, 0, ForceMode.Force);
        RR.AddTorque(Motor, 0, 0, ForceMode.Force);

        var Angle = Axle_L.spring;
        Angle.targetPosition = 30 * Input.GetAxis("Horizontal");
        Axle_L.spring = Angle;
        Axle_R.spring = Angle;
    }
}

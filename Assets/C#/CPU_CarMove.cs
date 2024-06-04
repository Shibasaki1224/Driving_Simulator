using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU_CarMove : MonoBehaviour
{
    public WheelCollider FL, FR, RL, RR;    //WheelCollider�̎擾
    public float maxPower, angle, Breake;

    public LineRenderer lr, lr_Next;
    Vector3[] posi;
    int i = 0;

    void Update()
    {
        //LPP.Length = lr.positionCount;
        posi = new Vector3[lr.positionCount];
        int cnt = lr.GetPositions(posi);
        Debug.Log(posi[0]);
        Vector3 to = posi[i] - transform.position;
        angle = Vector3.SignedAngle(transform.forward, to, Vector3.up);
        Debug.Log(posi);
        if (cnt < i)
        {
            lr = lr_Next;
            i = 0;
        }

    }
    void FixedUpdate()
    {
        FL.motorTorque = maxPower;
        FR.motorTorque = maxPower;
        RL.motorTorque = maxPower;
        RR.motorTorque = maxPower;

        FL.steerAngle = angle;
        FR.steerAngle = angle;

        if (Breake > 0)
        {
            FL.brakeTorque = Breake * 1000;
            FR.brakeTorque = Breake * 1000;
            RL.brakeTorque = Breake * 1000;
            RR.brakeTorque = Breake * 1000;
        }
        else
        {
            FL.brakeTorque = 0;
            FR.brakeTorque = 0;
            RL.brakeTorque = 0;
            RR.brakeTorque = 0;
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        i++;
        Destroy(collision.gameObject);

    }

}

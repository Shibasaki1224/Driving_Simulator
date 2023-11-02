using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public WheelCollider FL, FR, RL, RR;    //WheelCollider�̎擾
    public float maxPower;  //�ō��o�̓g���N
    public float angle;     //�n���h����؂������̍ō��p�x
    public float breake;    //�u���[�L�̗�
    string ShiftLever;      //�V�t�g���o�[���쒆���

    void FixedUpdate()
    {
        RL.motorTorque = maxPower * (Input.GetAxis("Vertical") + 1);   //�����A�^�C���̃��[�^�[�g���N
        RR.motorTorque = maxPower * (Input.GetAxis("Vertical") + 1);   //�E���A�^�C���̃��[�^�[�g���N

        FL.steerAngle = angle * Input.GetAxis("Horizontal");   //���t�����g�^�C���̊p�x
        FR.steerAngle = angle * Input.GetAxis("Horizontal");   //�E�t�����g�^�C���̊p�x

        if ((Input.GetAxis("Break") + 1) > 0)       //�u���[�L�V�X�e��
        {
            FL.brakeTorque = breake * (Input.GetAxis("Break") + 1);
            FR.brakeTorque = breake * (Input.GetAxis("Break") + 1);
            RL.brakeTorque = breake * (Input.GetAxis("Break") + 1);
            RR.brakeTorque = breake * (Input.GetAxis("Break") + 1);
        }
        else           //�u���[�L�𓥂�ł��Ȃ��Ƃ��̋���
        {
            FL.brakeTorque = 0;
            FR.brakeTorque = 0;
            RL.brakeTorque = 0;
            RR.brakeTorque = 0;
        }
    }
    void Update()   //�V�t�g���o�[���쒆���
    {
        if (Input.GetKeyDown("joystick button 0"))
            ShiftLever = "D";
        if (Input.GetKeyDown("joystick button 1"))
            ShiftLever = "R";

        if (ShiftLever == "D")
            Debug.Log("aaa");
    }
}

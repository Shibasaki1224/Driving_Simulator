using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public WheelCollider FL, FR, RL, RR;    //WheelCollider�̎擾
    public float maxPower;  //�ō��o�̓g���N
    public float angle;     //�n���h����؂������̍ō��p�x
    float Vertical, Horizontal, Breake;

    public int input;

    void FixedUpdate()
    {
        Vertical= Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        Breake = Input.GetAxis("Break") * 1000;

        FL.motorTorque = maxPower * (Vertical + input);   //�����A�^�C���̃��[�^�[�g���N
        FR.motorTorque = maxPower * (Vertical + input);   //�E���A�^�C���̃��[�^�[�g���N
        RL.motorTorque = maxPower * (Vertical + input);   //�����A�^�C���̃��[�^�[�g���N
        RR.motorTorque = maxPower * (Vertical + input);   //�E���A�^�C���̃��[�^�[�g���N

        FL.steerAngle = angle * Horizontal;   //���t�����g�^�C���̊p�x
        FR.steerAngle = angle * Horizontal;   //�E�t�����g�^�C���̊p�x

        if ((Breake + input) > 0)       //�u���[�L�V�X�e��
        {
            FL.brakeTorque = Breake + input;
            FR.brakeTorque = Breake + input;
            RL.brakeTorque = Breake + input;
            RR.brakeTorque = Breake + input;
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

    }
}

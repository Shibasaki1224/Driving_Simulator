using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint_Power : MonoBehaviour
{
    // Hinge Joint �R���|�[�l���g�ւ̎Q��
    public HingeJoint TAIYA;

    // �쓮�̐ݒ�
    public JointMotor motorSettings;

    void Start()
    {
        // Hinge Joint �R���|�[�l���g�ւ̎Q�Ƃ��擾
        TAIYA = GetComponent<HingeJoint>();

        // �쓮�̐ݒ���擾
        motorSettings = TAIYA.motor;

        // �쓮�͂�ݒ�i�K�؂Ȓl�ɕύX���Ă��������j
        motorSettings.force = 1000f;

        // Hinge Joint �ɐݒ��K�p
        TAIYA.motor = motorSettings;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

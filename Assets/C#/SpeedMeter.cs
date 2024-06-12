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
        MeterText = txt.GetComponent<Text>();       //TextUI���擾
        if(System==true)    //Rigidbody�Ōh����
        {
            rb = GetComponent<Rigidbody>();             //Rigidody�̎擾
            speed = rb.velocity.magnitude * 3.6f;       //���x[km/h] = ���x[m/s] �~ 3.6
            MeterText.text = ((int)speed) + " km/h";    //TextUI�ɕ\��
        }
        else                //���W�Ōh����
        {
            posi = transform.position;  //�I�u�W�F�N�g��[���݂̈ʒu]�̎擾
            Distance = posi - _posi;    //[���݂̈ʒu] - [�ߋ��̈ʒu]�̌v�Z
            _posi = posi;               //[���݂̈ʒu]��[�ߋ��̈ʒu]�ɕۑ�

            //[����(km/h)] = [�x�N�g���̒���(m)] �� [����(s)] �~ 3.6(m/s �� km/h)
            Meter = (Distance.magnitude) / 0.02f * 3.6f;
            MeterText.text = ((int)Meter) + "km/h";    //���݂̑��x��TextUI�ɕ\��
        }
    }
}
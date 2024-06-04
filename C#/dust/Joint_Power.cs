using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint_Power : MonoBehaviour
{
    // Hinge Joint コンポーネントへの参照
    public HingeJoint TAIYA;

    // 駆動の設定
    public JointMotor motorSettings;

    void Start()
    {
        // Hinge Joint コンポーネントへの参照を取得
        TAIYA = GetComponent<HingeJoint>();

        // 駆動の設定を取得
        motorSettings = TAIYA.motor;

        // 駆動力を設定（適切な値に変更してください）
        motorSettings.force = 1000f;

        // Hinge Joint に設定を適用
        TAIYA.motor = motorSettings;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

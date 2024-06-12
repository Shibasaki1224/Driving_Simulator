using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("子オブジェクトが何かに当たった！！");
    }
}

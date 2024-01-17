using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CarMove_CPU : MonoBehaviour
{
    [SerializeField] CinemachineDollyCart dollyCart = null;
    public GameObject sensor;
    Vector3 distance;

    void Update()
    {
        distance = sensor.transform.localScale;
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Car"|| collision.gameObject.tag == "Red")
        {
            if (distance.z > 0)
            {
                Debug.Log("abcdefg");
                distance.z -= 0.25f;
            }
        }
        else
        {
            if (distance.z < 17)
            {
                Debug.Log("1234567");
                distance.z += 0.05f;
            }
        }
        dollyCart.m_Speed = distance.z - 3;
        sensor.transform.localScale = new Vector3(1, 1, distance.z);
    }
    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Rail")
        {
            int x = (int)Random.Range(0, 3);
            Debug.Log(x);
            dollyCart.m_Position = 0;
            dollyCart.m_Path = collision.GetComponent<Rail_Select>().Rail[x];
        }
    }
}

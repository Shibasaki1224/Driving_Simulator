using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator_A : MonoBehaviour
{
    public GameObject Signal_E, Signal_W, Signal_S, Signal_N, Walk_E, Walk_W, Walk_S, Walk_N;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Signal_E.GetComponent<Signal>().time = 2300;
            Signal_W.GetComponent<Signal>().time = 2300;
            Signal_S.GetComponent<Signal>().time = 1000;
            Signal_N.GetComponent<Signal>().time = 1000;

            Walk_E.GetComponent<Signal>().time = 2300;
            Walk_W.GetComponent<Signal>().time = 2300;
            Walk_S.GetComponent<Signal>().time = 1000;
            Walk_N.GetComponent<Signal>().time = 1000;
        }
    }
}

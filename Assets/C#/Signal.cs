using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    public GameObject Light_B, Light_Y, Light_R, Walk_Light_B, Walk_Light_R;
    public int time;

    void FixedUpdate() //FixedUpdate = 0.02s
    {
        time++;
        if (time < 1000)
        {
            Light_B.SetActive(true);
            Light_Y.SetActive(false);
            Light_R.SetActive(false);
            this.tag = "Blue";
            Walk_Light_R.SetActive(true);
            Walk_Light_B.SetActive(false);
        }
        else if (time >= 1000 && time < 1150)
        {
            Light_B.SetActive(false);
            Light_Y.SetActive(true);
            Light_R.SetActive(false);
            this.tag = "Yellow";
            Walk_Light_R.SetActive(true);
            Walk_Light_B.SetActive(false);
        }
        else if (time >= 1150 && time < 2600)
        {
            Light_B.SetActive(false);
            Light_Y.SetActive(false);
            Light_R.SetActive(true);
            this.tag = "Red";
            if (time >= 1300 && time < 2000)
            {
                Walk_Light_B.SetActive(true);
                Walk_Light_R.SetActive(false);
            }
            else if (time >= 2000 && time < 2250)
            {
                if (time % 40 == 0)
                {
                    Walk_Light_B.SetActive(false);
                }
                else if (time % 20 == 0)
                {
                    Walk_Light_B.SetActive(true);
                }
            }
            else
            {
                Walk_Light_R.SetActive(true);
                Walk_Light_B.SetActive(false);
            }
        }
        else
            time = 0;
    }
    void OnTriggerEnter(Collider collision)
    {
        if (this.tag == "Red" && collision.gameObject.tag == "Car")
            Debug.Log("あああ!!!\nいっけないんだ～～！！");
        else if (this.tag == "Yellow" && collision.gameObject.tag == "Car")
            Debug.Log("...ぎりセーフな");
    }
}

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
            if(time < 600)
            {
                Walk_Light_B.SetActive(true);
                Walk_Light_R.SetActive(false);
            }
            if(time >= 600 && time < 850)
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
            else if(time >= 850)
            {
                Walk_Light_R.SetActive(true);
                Walk_Light_B.SetActive(false);
            }
        }
        else if (time >= 1000 && time < 1150)
        {
            Light_B.SetActive(false);
            Light_Y.SetActive(true);
            Light_R.SetActive(false);
            Walk_Light_R.SetActive(true);
            Walk_Light_B.SetActive(false);
            this.tag = "Yellow";
        }
        else if (time >= 1150 && time < 2600)
        {
            Light_B.SetActive(false);
            Light_Y.SetActive(false);
            Light_R.SetActive(true);
            Walk_Light_R.SetActive(true);
            Walk_Light_B.SetActive(false);
            this.tag = "Red";
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

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
        float time;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SignalStopping();
    }

    //�M����~Mission
    void SignalStopping()
    {
        //gameObject StopLine;

        txt.GetComponent<Text>().text = "Mission\n�M����~";
        if (Input.GetAxis("Break") > 0 && SpeedMeter.speed <= 0)
        {
            time += Time.deltaTime;
        }
        else
        {
            txt.GetComponent<Text>().text = "Mission[�M����~]\n��������:" + ((float)time);

        }
    }
}

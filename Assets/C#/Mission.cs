using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    public GameObject StopLine, Player, SigA, SigB;
    public Text txt;
    float dis;

    bool LineStop;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (LineStop)
        {
            if (Player.GetComponent<SpeedMeter>().speed > 0.3f)
            {
                txt.GetComponent<Text>().text = "Mission\nêMçÜí‚é~";
                dis = Vector3.Distance(StopLine.transform.position, Player.gameObject.transform.position);
                txt.GetComponent<Text>().text = "Mission[êMçÜí‚é~]\ní‚é~ê¸Ç‹Ç≈ÇÃãóó£:" + ((float)dis);
            }
            else
            {
                if (dis > 0.5f && 4 >= dis)
                    txt.GetComponent<Text>().text = "Mission[êMçÜí‚é~]\ní‚é~ê¸Ç‹Ç≈ÇÃãóó£:" + ((float)dis + "\nó«Çµ");
                else
                    txt.GetComponent<Text>().text = "Mission[êMçÜí‚é~]\ní‚é~ê¸Ç‹Ç≈ÇÃãóó£:" + ((float)dis + "\nà´Çµ");
                LineStop = false;
            }
        }
        else
        {
            //txt.GetComponent<Text>().text = "Mission";
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == Player)
        {
            LineStop = true;
            SigA.GetComponent<Signal>().time = 1000;
            SigB.GetComponent<Signal>().time = 1000;
        }
    }
}

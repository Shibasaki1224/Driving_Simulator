using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    public GameObject StopLine, Player, SigA, SigB, Line,Line2;
    public Text txt;
    float dis;

    bool LineStop;
    // Start is called before the first frame update
    void Start()
    {
        //Line.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speed = Player.GetComponent<SpeedMeter>().speed;
        var cubeRenderer = Line.GetComponent<Renderer>();
        cubeRenderer.material.SetFloat("_TopColorAmount", speed / 80);
        Line2.GetComponent<Renderer>().material.color = new Color(speed/80, speed / 80, speed / 80, 255);
        if (LineStop)
        {
            //Line.SetActive(true);
            if (speed > 0.3f && dis >= 0)
            {
                dis = Mathf.RoundToInt(Vector3.Distance(StopLine.transform.position, Player.gameObject.transform.position) * 10);
                dis = dis / 10 - 2.5f;
                txt.GetComponent<Text>().text = "Mission[信号停止]\n停止線までの距離:" + ((float)dis)+"m";
            }
            else
            {
                if (0 < dis && dis <= 4)
                    txt.GetComponent<Text>().text = "Mission[信号停止]\n停止線までの距離:" + ((float)dis) + "m\n良し";
                else if (dis < 0)
                    txt.GetComponent<Text>().text = "Mission[信号停止]\n停止線超えましたが？？";
                else
                    txt.GetComponent<Text>().text = "Mission[信号停止]\n停止線までの距離:" + ((float)dis) + "m\n悪し";
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

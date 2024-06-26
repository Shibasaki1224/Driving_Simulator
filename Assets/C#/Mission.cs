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
                txt.GetComponent<Text>().text = "Mission[M†’â~]\n’â~ü‚Ü‚Å‚Ì‹——£:" + ((float)dis)+"m";
            }
            else
            {
                if (0 < dis && dis <= 4)
                    txt.GetComponent<Text>().text = "Mission[M†’â~]\n’â~ü‚Ü‚Å‚Ì‹——£:" + ((float)dis) + "m\n—Ç‚µ";
                else if (dis < 0)
                    txt.GetComponent<Text>().text = "Mission[M†’â~]\n’â~ü’´‚¦‚Ü‚µ‚½‚ªHH";
                else
                    txt.GetComponent<Text>().text = "Mission[M†’â~]\n’â~ü‚Ü‚Å‚Ì‹——£:" + ((float)dis) + "m\nˆ«‚µ";
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

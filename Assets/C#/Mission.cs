using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    public GameObject StopLine, Player, SigA, SigB, Line;
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
        var cubeRenderer = Line.GetComponent<Renderer>();
        cubeRenderer.material.SetFloat("_TopColorAmount", Player.GetComponent<SpeedMeter>().speed / 80);
        if (LineStop)
        {
            //Line.SetActive(true);
            if (Player.GetComponent<SpeedMeter>().speed > 0.3f && dis >= 0)
            {
                dis = Mathf.RoundToInt(Vector3.Distance(StopLine.transform.position, Player.gameObject.transform.position) * 10);
                dis = dis / 10 - 2.5f;
                txt.GetComponent<Text>().text = "Mission[�M����~]\n��~���܂ł̋���:" + ((float)dis)+"m";
            }
            else
            {
                if (0 < dis && dis <= 4)
                    txt.GetComponent<Text>().text = "Mission[�M����~]\n��~���܂ł̋���:" + ((float)dis) + "m\n�ǂ�";
                else if (dis < 0)
                    txt.GetComponent<Text>().text = "Mission[�M����~]\n��~�������܂������H�H";
                else
                    txt.GetComponent<Text>().text = "Mission[�M����~]\n��~���܂ł̋���:" + ((float)dis) + "m\n����";
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

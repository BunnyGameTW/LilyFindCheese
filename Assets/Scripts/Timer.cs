using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int iTime;
    public Text timeTxt;

    MouseController mouse;
    bool Hit;
    Text timeUI;
    private float nowTime, previousTime;
    // Use this for initialization
    void Awake()
    {
        //iTime = 60;
        nowTime = previousTime = 0;
        timeUI = timeTxt.GetComponent<Text>();
        mouse = GetComponent<MouseController>();
        Hit = false;
        timeUI.text = iTime + " S";//ui
    }

    // Update is called once per frame
    void Update()
    {
        if (Hit == true)
            CountDown();


    }
    void CountDown()
    {
        if (mouse.isOver == false)
        {
            nowTime = Time.time;
            if (nowTime - previousTime >= 1.0f)
            {
                previousTime = nowTime;
                iTime -= 1;//time--
            }
            if (iTime <= 0)
            {
                mouse.isAlive = false;
                mouse.isOver = true;
                iTime = 0;
                //change sene or..
            }
            timeUI.text = iTime + " S";//ui
        }
    }
    void OnTriggerEnter(Collider Coll)
    {
        if (Coll.gameObject.name == "START")
            Hit = true;
    }
}
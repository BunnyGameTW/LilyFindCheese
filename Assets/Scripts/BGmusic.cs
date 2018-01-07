using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmusic : MonoBehaviour {
	AudioSource BGM,BGSE;
	public AudioClip BG,meowSE;
	MouseController mouse;
	// Use this for initialization
	float ranTime,nowTime,timer2;
    bool once = true;

    void Start () {
		mouse = GetComponentInParent<MouseController> ();
		BGM = gameObject.AddComponent<AudioSource>();
        //playBG ();
        BGSE = gameObject.AddComponent<AudioSource> ();
		randomTime ();
		nowTime =ranTime;
        timer2 = 16.0f;

    }

    // Update is called once per frame
    void Update () {
        if (!mouse.isOver)
        {
            if (once)
            {
                playBG();
                once = false;
            }
            if (Time.time > nowTime)
            {
                playSE();
                randomTime();
                nowTime = ranTime + Time.time;
            }
            if (Time.timeSinceLevelLoad > timer2)//原本是Time.time
            {
                print(123);
                playBG();
                timer2 += 16.0f;//原本是timer2+=Time.time
            }
        }
        else
        {
            BGM.Stop();
            BGSE.Stop();
        }
    }
	void playBG(){
        BGM.Stop();
        BGM.PlayOneShot(BG);
    }
	void randomTime(){
		ranTime = Random.Range (5.0f, 8.0f);
	}
	void playSE(){
		BGSE.PlayOneShot (meowSE,0.02f);
	}
}

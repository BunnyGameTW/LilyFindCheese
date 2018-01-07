using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour {
    AudioSource MouseSE, CatSE;
    MouseController mouse;
   // public GameObject CatObj;
   // Cat cat;
    Timer time;
    public AudioClip  mouseStop, mouseMove, win, lose;
    float nowTime;
    bool canPlay;
    bool catSEPlay;
    void Awake()
    {
       // cat = CatObj.GetComponent<Cat>();
        MouseSE = GetComponent<AudioSource>();
        CatSE = gameObject.AddComponent<AudioSource>();
        mouse = GetComponent<MouseController>();
        time = GetComponent<Timer>();
        nowTime = 2.0f;
        canPlay = true;
        catSEPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        playSE();
    }
    void playSE()
    {
        mouseSE();
    }
    /*void timer(){//2sec per time
		if (Time.time > nowTime) {
			nowTime += Time.time;
			playMoveSE = true;
		} else playMoveSE = false;
			
	}*/
    void mouseSE()
    {
        if (!mouse.isOver)
        {
            if (Input.GetMouseButtonUp(0))
                MouseSE.PlayOneShot(mouseStop);
            if (Input.GetMouseButtonDown(0))
            {
                MouseSE.PlayOneShot(mouseMove);
            }
        }
        if (mouse.isAlive == false && canPlay)
        {
            MouseSE.PlayOneShot(lose, 0.5f);
            canPlay = false;
        }
    }
  
    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Cheese" && mouse.isAlive && time.iTime > 0)
        {
            MouseSE.PlayOneShot(win);
            mouse.isOver = true;
            //Debug.Log("play win SE");
        }

    }
   

}

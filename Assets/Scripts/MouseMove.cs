using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour {
	public float speed;
	bool isMove;
    Animator RatAni;
    MouseController mouse;

    // Use this for initialization
    void Start () {
        mouse = GetComponent<MouseController>();//mouse

        //speed = 1.0f;
        isMove = true;
        RatAni = GetComponent<Animator>();

        if (PlayerPrefs.GetInt("Death") > 1)
            DeathOver();
	}
	
	// Update is called once per frame
	void Update () {
        if (!mouse.isOver)
        {
            if (Input.GetMouseButton(0))
            //print (11);
            {
                Invoke("Opened", 1f);
                RatAni.SetBool("Running", true);

            }
            else
            {
                RatAni.SetBool("Running", false);
                RatAni.SetBool("Opened", false);
                CancelInvoke("Opened");
                //else
                //	transform.position += new Vector3 (speed, 0, 0);
            }
            if (RatAni.GetBool("Running") == true && RatAni.GetBool("Opened") == true)
                transform.position += new Vector3(speed, 0, 0);
        }
        else {
            RatAni.SetBool("Running", false);
            RatAni.SetBool("Opened", false);
        }
    }
    void Opened()
    {
        RatAni.SetBool("Opened", true);
    }
    void DeathOver()
    {
        transform.position = new Vector3(44.4f, -3.83f, 0f);
    }
    /*void OnTriggerEnter(Collider Coll)
    {
        if (Coll.gameObject.name == "Cheese")
            mouse.isOver = true;
    }*/
}

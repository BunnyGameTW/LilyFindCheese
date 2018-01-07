using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinOrLose : MonoBehaviour {
    public AudioClip Win, Lose;
    public GameObject Plane;
    public Sprite WinPic, LosePic;
	// Use this for initialization
	void Start () {
        AudioSource MusicSource = GetComponent<AudioSource>();
        AudioClip Music = GetComponent<AudioClip>();
        Image PicCom = Plane.GetComponent<Image>();
        if (PlayerPrefs.GetInt("WinOrLose") == 1)
        {
            MusicSource.PlayOneShot(Lose);
            PicCom.sprite = LosePic;
        }
        else
        {
            MusicSource.PlayOneShot(Win);
            PicCom.sprite = WinPic;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void BackToMain ()
    {
        Application.LoadLevel(0);   
    }
}

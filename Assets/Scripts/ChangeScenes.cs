using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScenes : MonoBehaviour {
    public AudioClip btn, scr;
    public GameObject Mem, Cancle, cover, imagepic;
    // Use this for initialization
    void Start () {
        Mem.gameObject.SetActive(true);
        Cancle.gameObject.SetActive(false);
        cover.gameObject.SetActive(false);
        imagepic.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnMouseDown(){
		Debug.Log ("game start");
        AudioSource BTNSE = gameObject.AddComponent<AudioSource>();
        BTNSE.PlayOneShot(btn);
        Invoke("GameStart", 1f);
	}
    public void MemberList()
    {
        AudioSource BTNSE = gameObject.AddComponent<AudioSource>();
        BTNSE.PlayOneShot(scr);
        Mem.gameObject.SetActive(false);
        Cancle.gameObject.SetActive(true);
        cover.gameObject.SetActive(true);
        imagepic.gameObject.SetActive(true);
        
    }
    public void CancleMemberList()
    {
        AudioSource BTNSE = gameObject.AddComponent<AudioSource>();
        BTNSE.PlayOneShot(scr);
        Mem.gameObject.SetActive(true);
        Cancle.gameObject.SetActive(false);
        cover.gameObject.SetActive(false);
        imagepic.gameObject.SetActive(false);
    }
    void GameStart()
    {
        Application.LoadLevel(1);
    }
}

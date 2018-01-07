using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayImage : MonoBehaviour {
    public Sprite[] Images;
    float Count;
	// Use this for initialization
	void Start () {
        Count = 0;
        ChangeImage();  
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void ChangeImage()
    {


        Image img = GetComponentsInChildren<Image>()[0];
        img.sprite = Images[(int)Count];
        Count++;
        if (Count == 14)
            Count = 0;
        float randomtime = Random.Range(0.05f, 0.2f);
        Invoke("CallChange", randomtime);
    }
    void CallChange()
    {
        ChangeImage();
    }
}

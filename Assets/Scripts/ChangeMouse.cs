using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMouse : MonoBehaviour {
	RectTransform rect;
	public Sprite normal,click;
	Image mouseImg;
	//Image
	// Use this for initialization
	void Start () {
		rect = GetComponent<RectTransform> ();
		mouseImg= GetComponent<Image>();
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		//mouseImg.sprite
		rect.anchoredPosition = Input.mousePosition;
		if (Input.GetMouseButton (0))
			mouseImg.sprite = click;
		else
			mouseImg.sprite = normal;
	}
}

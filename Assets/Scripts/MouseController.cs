using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseController : MonoBehaviour {
    internal bool isAlive, isOver, goBack;
    public GameObject EndUI;
    public Sprite WinPic, LosePic;
    // Use this for initialization
    void Start () {
        isAlive = true;
        isOver = false;
        goBack = false;

        EndUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        state();

    }
    void state()
    {

        if (!isAlive)//lose
        {
            Invoke("Lose", 2f);
            

        }
        else if (isOver)//win
        {
            Invoke("Win", 1f);

        }
        if (goBack)
        {//go back
            if (Input.GetMouseButtonDown(0))
            {
                Application.LoadLevel(0);


            }
        }
    }
    void Win()
    {
        goBack = true;
        Image img = EndUI.GetComponentsInChildren<Image>()[0];
        img.sprite = WinPic;
        EndUI.SetActive(true);//
        PlayerPrefs.SetInt("Death", 0);
    }
    void Lose()
    {
        Image img = EndUI.GetComponentsInChildren<Image>()[0];
        img.sprite = LosePic;
        EndUI.SetActive(true);
        goBack = true;

        PlayerPrefs.SetInt("Death", PlayerPrefs.GetInt("Death") + 1);
    }
}

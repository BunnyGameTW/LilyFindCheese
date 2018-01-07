using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {
	public GameObject CatObject, MouseObj, CatHead;
	public float CatBackTime;
    public float CatNumber;
	public float Min_Time, Max_Time, ReactionTime;
    public Light WatchLighting;
    float randommode;
    Animator CatAni;
	BoxCollider BoxColl;
    Renderer CatRenderer;
    internal bool CatIsWatching = false;
	bool isFake;
    internal bool isWake = false;
    MouseController mouse;
    AudioSource catSE;
    public AudioClip catAwake, catTurn, catIdle;
    // Use this for initialization
    void Start () {
        CatRenderer = CatHead.GetComponent<Renderer>();

        MouseObj = GameObject.Find("Rat");
        mouse = MouseObj.GetComponent<MouseController>();

        CatAni = CatObject.GetComponent<Animator>();
		BoxColl = gameObject.GetComponent<BoxCollider> ();
        WatchLighting.enabled = false;
        catSE = GetComponent<AudioSource>();
        mouse = MouseObj.GetComponent<MouseController>();
      
      //  CatRenderer.material.mainTexture = Resources.Load("CAT1_BODY 02") as Texture;
    }
	
	// Update is called once per frame
	void Update () {
		if (CatIsWatching)
		{
			if (Input.GetMouseButton(0))
			{
                mouse.isAlive = false;
                mouse.isOver = true;
              //  print("gameover");
				CancelInvoke ("Cat_Back");
			}
		}
        if (mouse.isOver)
            catSE.Stop();
    }
	void OnTriggerEnter(Collider Coll)
	{
		if (Coll.gameObject.tag == "Player")
		{
            catSE.Stop();
            catSE.PlayOneShot(catIdle);
            float randomtime = Random.Range (Min_Time, Max_Time);
			Invoke ("Cat_isWake", randomtime - ReactionTime);
			BoxColl.enabled = false;
            if (isFake) {
				randommode = Random.Range (1, 10);
				isFake = false;
			}
			Debug.Log (randommode);
			if (randommode > 5) {
				
				Invoke ("CatWatch", randomtime);
			}
			else {
				Invoke ("Cat_Back", randomtime);
			}

		}    
	}
	void Cat_isWake()
	{
        catSE.Stop();
        isWake = true;
        randommode = Random.Range(1, 10);
        if (randommode < 3)
            CatAni.SetBool("isWake1", true);
        else if (randommode>7)
            CatAni.SetBool("isWake2", true);
        else
            CatAni.SetBool("isWake3", true);
        catSE.PlayOneShot(catAwake);

    }
    void CatWatch()
	{
        catSE.Stop();
        catSE.PlayOneShot(catTurn);
        WatchLighting.enabled = true;
        CatAni.SetBool("Watching",true);
		CatIsWatching = true;
		Invoke ("Cat_Back", CatBackTime);
        CatTextureTurn01();
	}

    void CatTextureTurn01()
    {
        string TextureFileAddress = "";
        if (CatNumber == 1)
            TextureFileAddress = "Cat1_1/CAT1_HEAD01";
        if (CatNumber == 2)
            TextureFileAddress = "Cat1_2/CAT2_HEAD02";
        if (CatNumber == 3)
            TextureFileAddress = "Cat1_3/CAT3_HEAD02";
        if (TextureFileAddress != "")
            CatRenderer.material.mainTexture = Resources.Load(TextureFileAddress) as Texture;
    }
    void CatTextureTurn02()
    {
        string TextureFileAddress = "";
        if (CatNumber == 1)
            TextureFileAddress = "Cat1_1/CAT1_HEAD02";
        if (CatNumber == 2)
            TextureFileAddress = "Cat1_2/CAT2_HEAD01";
        if (CatNumber == 3)
            TextureFileAddress = "Cat1_3/CAT3_HEAD01";
        if (TextureFileAddress != "")
            CatRenderer.material.mainTexture = Resources.Load(TextureFileAddress) as Texture;
    }
    void Cat_Back()
	{
        catSE.Stop();

        CatAni.SetBool("isWake1", false);
        CatAni.SetBool("isWake2", false);
        CatAni.SetBool("isWake3", false);
        CatIsWatching = false;
		CatAni.SetBool("Watching",false);
		BoxColl.enabled = true;
		isFake = true;
        isWake = false;
        catSE.PlayOneShot(catIdle);
        WatchLighting.enabled = false;
        Invoke("CatTextureTurn02", 0.3f);
    }
}

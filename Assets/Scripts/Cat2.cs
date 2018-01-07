using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat2 : MonoBehaviour {

    public GameObject CatObject, MouseObj, CatHead;
    public float CatBackTime, CatNumber;
    public float Min_Time, Max_Time, ReactionTime;
    float randommode;

    public Light WatchLighting;
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
    void Start()
    {
        CatRenderer = CatHead.GetComponent<Renderer>();

        catSE = GetComponent<AudioSource>();

        MouseObj = GameObject.Find("Rat");
        mouse = MouseObj.GetComponent<MouseController>();
        MouseObj.GetComponent<MouseController>();
        CatAni = CatObject.GetComponent<Animator>();
        BoxColl = gameObject.GetComponent<BoxCollider>();
        WatchLighting.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CatIsWatching)
        {
            if (Input.GetMouseButton(0))
            {
                mouse.isAlive = false;
                mouse.isOver = true;
                //print("gameover");
                CancelInvoke("Cat_Back");
            }
        }
        if (mouse.isOver)
            catSE.Stop();
    }
    void OnTriggerEnter(Collider Coll)
    {
        if (Coll.gameObject.tag == "Player")
        {
            float randomtime = Random.Range(Min_Time, Max_Time);
            Invoke("Cat_isWake", randomtime - ReactionTime);
            BoxColl.enabled = false;
            if (isFake)
            {
                randommode = Random.Range(1, 10);
                isFake = false;
            }
            Debug.Log(randommode);
            if (randommode > 5)
            {

                Invoke("CatWatch", randomtime);
            }
            else
            {
                Invoke("Cat_Back", randomtime);
            }

        }
    }
    void Cat_isWake()
    {
        catSE.Stop();
        isWake = true;
        randommode = Random.Range(1, 10);
        if (randommode > 5)
            CatAni.SetBool("isWake1", true);
        else
            CatAni.SetBool("isWake2", true);
        catSE.PlayOneShot(catAwake);

    }
    void CatWatch()
    {
        catSE.Stop();
        catSE.PlayOneShot(catTurn);
        WatchLighting.enabled = true;
        CatAni.SetBool("Watching", true);
        CatIsWatching = true;
        Invoke("Cat_Back", CatBackTime);
        CatTextureTurn01();
    }
    void CatTextureTurn01()
    {
        string TextureFileAddress="";
        if (CatNumber == 4)
            TextureFileAddress = "Cat2_1/CAT4_HEAD 02";
        if (CatNumber == 5)
            TextureFileAddress = "Cat2_2/CAT5_HEAD 02";
        if(TextureFileAddress != "")
        CatRenderer.material.mainTexture = Resources.Load(TextureFileAddress) as Texture;
    }
    void CatTextureTurn02()
    {
        string TextureFileAddress = "";
        if (CatNumber == 4)
            TextureFileAddress = "Cat2_1/CAT4_HEAD 01";
        if (CatNumber == 5)
            TextureFileAddress = "Cat2_2/CAT5_HEAD 01";
        if (TextureFileAddress != "")
            CatRenderer.material.mainTexture = Resources.Load(TextureFileAddress) as Texture;
        
    }

    void Cat_Back()
    {
        catSE.Stop();
        CatAni.SetBool("isWake1", false);
        CatAni.SetBool("isWake2", false);
        CatIsWatching = false;
        CatAni.SetBool("Watching", false);
        BoxColl.enabled = true;
        isFake = true;
        WatchLighting.enabled = false;
        isWake = false;
        catSE.PlayOneShot(catIdle);
        CatTextureTurn02();
    }
}

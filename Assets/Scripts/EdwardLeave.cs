using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdwardLeave : MonoBehaviour {
    public Animator anim;
    //public RPGTalk rpgTalk;
    public NetFallAction netFallAction;
    public RPGTalkArea rpgTalkArea;
    public Rigidbody2D rb2d;
    int right = 1;
    int left = -1;
    int dir;
    public float speed = 1.45f;
    public bool isRunning = false;
    bool isRight = true;
    // Use this for initialization
    private void OnEnable()
    {
        //netFallAction.OnFallAction += Run();
        //rpgTalk.OnEndTalk += Run;
    }
    private void OnDisable()
    {
        //rpgTalk.OnEndTalk -= Run;
    }
    void Start () {
	}
	public void Run()
    {
        Debug.Log("hey.");
        rb2d.gravityScale = 0;
        if(GetComponent<BoxCollider2D>() != null)
        GetComponent<BoxCollider2D>().isTrigger = true;
        if (GetComponent<CircleCollider2D>() != null)
            GetComponent<CircleCollider2D>().isTrigger = true;
        isRunning = true;
    }
	// Update is called once per frame
	void Update () {
        if(isRight)
        {
            dir = right;
        }
        else
        {
            dir = left;
        }
        if(isRunning)
        {
            transform.parent = null;
            anim.SetBool("isWalking", true);
            transform.Translate(dir * Vector3.right * speed*Time.deltaTime);
        }

    }
}

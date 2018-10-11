using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour {
    public RPGTalk rpgTalk;
    public float speed = .2f;
    public float minDistanceTilMove = 2f;
    public Rigidbody2D rb2d;
    int dir = 1;
    public bool stayStillTillNear = false;
    public bool moveRight = false;
    bool move = false;
    bool pause = false;
    Animator anim;
    Monster monst;
    // Use this for initialization
    public enum MoveState { PlayerNear, Wander };
    public MoveState moveState = MoveState.PlayerNear;

    void OnEnable()
    {
        rpgTalk.OnNewTalk += DisableMovement;
        rpgTalk.OnEndTalk += EnableMovement;
    }
    private void OnDisable()
    {
        rpgTalk.OnNewTalk -= DisableMovement;
        rpgTalk.OnEndTalk -= EnableMovement;
    }
    public void DisableMovement()
    {
        Debug.Log("in disable movement");
        move = false;
        pause = true;
    }
    public void EnableMovement()
    {
        Debug.Log("In enabled movement");
        pause = false;
    }
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        //anim = GetComponent<Animator>();
        rpgTalk = GameObject.Find("RPGTalk Holder").GetComponent<RPGTalk>();

    }
    void Start () {
		if(moveRight)
        {
            SetRight();
        }
        else
        {
            SetLeft();
        }
	}
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, minDistanceTilMove);
    }
    private void FixedUpdate()
    {
        switch(moveState)
        {
            case MoveState.PlayerNear:
                if (Vector3.Distance(PlayerManager.Instance.transform.position, this.transform.position) <= minDistanceTilMove)
                    move = false;
                else
                    move = true;
                    break;
            case MoveState.Wander:
                move = true;
                break;
            default:
                move = true;
                break;
            
        }
        if(move && !pause)
        {
            if(anim!=null)
            anim.SetBool("Running", true);
            rb2d.velocity = dir * Vector2.left * speed;
        }
        else
        {
            if(anim != null)
            anim.SetBool("Running", false);

        }

    }
    public void SetRight()
    {
        dir = -1;
    }
    public void SetLeft()
    {
        dir = 1;
    }
    public void ChangeDirection()
    {
        dir = dir * -1;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    void Update () {

    }
}

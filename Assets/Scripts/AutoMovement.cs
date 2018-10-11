using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour {
    public float speed = .2f;
    public float minDistanceTilMove = 2f;
    public float rotatOffset = 0;
    public Rigidbody2D rb2d;
    int dir = 1;
    public bool stayStillTillNear = false;
    public bool moveRight = false;
    bool move = false;
    bool pause = false;
    bool isDead = false;
    Animator anim;
    Monster monst;
    public enum MoveState { PlayerNear, Wander,Chilling };
    public MoveState moveState = MoveState.PlayerNear;

    void OnEnable()
    {
        PlayerManager.OnSetControl +=SetCanMove;
        monst.OnDeath += SetDead;
        RPGTalk.OnEndTalkGeneral += EnableMovement;
        RPGTalk.OnNewTalkGeneral += DisableMovement;

    }
    private void OnDisable()
    {

        PlayerManager.OnSetControl -= SetCanMove;
        monst.OnDeath -= SetDead;
        RPGTalk.OnEndTalkGeneral -= EnableMovement;
        RPGTalk.OnNewTalkGeneral -= DisableMovement;

    }
    void SetCanMove(bool playerHasControl)
    {
        if(playerHasControl)
        {
            EnableMovement();
        }
        else
        {
            DisableMovement();
        }
    }
    public void SetDead()
    {
        isDead = true;
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
        monst = GetComponentInChildren<Monster>();
        anim = GetComponentInChildren<Animator>();
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
    public void SetChaseCharacter()
    {
        moveState = MoveState.PlayerNear;
    }
    private void FixedUpdate()
    {
        if(!isDead && moveState!= MoveState.Chilling)
        FlipToPlayer();
        switch(moveState)
        {
            case MoveState.PlayerNear:
                if (Vector3.Distance(PlayerManager.Instance.transform.position, this.transform.position) >= minDistanceTilMove)
                    move = false;
                else
                    move = true;
                    break;
            case MoveState.Wander:
                move = true;
                break;
            default:
                move = false;
                break;
            
        }
        if(move && !pause && !isDead)
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
    #region Direction change
    void FlipToPlayer()
    {
        if (PlayerManager.Instance.transform.position.x > this.transform.position.x)
        {
            SetRight();
        }
        else
        {
            SetLeft();
        }
    }
    public void SetRight()
    {
        transform.localRotation = Quaternion.Euler(0, 180, 0);
        dir = -1;
    }
    public void SetLeft()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        dir = 1;
    }
    public void ChangeDirection()
    {
        dir = dir * -1;

    }
    #endregion

}

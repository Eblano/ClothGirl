using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreedNPCBehavior : MonoBehaviour {
    public NetFallAction netFallAction;
    public Animator anim;
    public float speed = 1.24f;
    public string walkBoolName = "Running";
    bool isRunning;
    public int dir =-1;
    int right = 1;
    int left = -1;
    bool isRight;
    public float deathTime = 4f;
    private void OnEnable()
    {
        netFallAction.OnFallAction += WalkAway;
    }
    private void OnDisable()
    {
        netFallAction.OnFallAction -= WalkAway;
    }
    void WalkAway()
    {
        isRunning = true;
        Debug.Log("run");
        //auto movement script?
    }
    void Update()
    {
        if (isRight)
        {
            dir = right;
        }
        else
        {
            dir = left;
        }
        if (isRunning)
        {
            transform.parent = null;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            if (GetComponent<CapsuleCollider2D>() != null)
                GetComponent<CapsuleCollider2D>().isTrigger = true; 
            anim.SetBool(walkBoolName, true);
            transform.Translate(dir * Vector3.right * speed * Time.deltaTime);
            Destroy(gameObject, deathTime);
        }

    }

}

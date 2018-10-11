using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public int numberCuts;
    public float destructTime = .4f;
    public GameObject[] parts;
    public GameObject stitches;
    public GameObject destroyTarget;
    public Animator anim;
    public bool isDead = false;
    float y;
    int ignorePlayerLayer = 11;
    AutoMovement autoMove;
    public delegate void MosnterDeathAction();
    public event MosnterDeathAction OnDeath;
    // Use this for initialization
    void Start () {
        numberCuts = transform.childCount;
        autoMove = GetComponentInParent<AutoMovement>();
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void DamageMonster()
    {
        if(stitches != null)
        y = stitches.transform.position.y;
        Debug.Log("hello?");
        numberCuts--;
        if (numberCuts <= 0)
        {
            Debug.Log("i'mma dead");
            MonsterKillStats.IncreaseMonstersKilled();
            foreach (GameObject part in parts)
            {
                part.tag = "Untagged";
            }
            if(parts.Length > 0)
            parts[0].GetComponent<FixedJoint2D>().enabled = false;
            if (anim != null)
                anim.SetTrigger("Die");
            PlayerManager.Instance.SetPlayerImmunity();
            PlayerManager.Instance.transform.position = new Vector2(transform.parent.position.x,y);
            Debug.Log(transform.parent.gameObject.name);
            autoMove.DisableMovement();
            transform.parent.gameObject.layer = ignorePlayerLayer;
            destroyTarget.layer = ignorePlayerLayer;
            isDead = true;
            if (OnDeath != null)
                OnDeath();

        }
    }

}

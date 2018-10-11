using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSelfOnClick : MonoBehaviour,IBladeInteractable {
    public GameObject targetJoint;
    public GameObject restOfStuff;
    bool mouseDown = false;
	// Use this for initialization
	void Start () {
        if (targetJoint == null)
            targetJoint = gameObject;
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    public void SelfDestruct()
    {
        if(GetComponentInParent<Monster>() != null)
        GetComponentInParent<Monster>().DamageMonster();
        if(this.GetComponent<FixedJoint2D>()!= null)
        {
            this.GetComponent<FixedJoint2D>().enabled = false;
        }
        else
        {
            Destroy(targetJoint);
        }
        //Destroy(targetJoint);
        if(restOfStuff != null)
        {
            Destroy(restOfStuff, 2f);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.tag == "Blade")
        //{
        //    Interact();
        //}
    }
    private void OnMouseOver()
    {
        if(mouseDown)
        SelfDestruct();
    }

    public void BladeInteract()
    {
        //Debug.Log("blade interact?");
        SelfDestruct();
    }
}

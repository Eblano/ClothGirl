using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSelfOnClick : MonoBehaviour,IInteractable {
    public GameObject target;
    bool mouseDown = false;
	// Use this for initialization
	void Start () {
        if (target == null)
            target = gameObject;
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    public void SelfDestruct()
    {
        GetComponentInParent<Monster>().DamageMonster();
        Destroy(target);
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

    public void Interact()
    {
        SelfDestruct();
    }
}

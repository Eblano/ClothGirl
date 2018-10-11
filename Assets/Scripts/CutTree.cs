using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTree : MonoBehaviour, IBladeInteractable
{
    public GameObject targetJoint;
    public GameObject restOfStuff;
    public Rigidbody2D[] rigidBodies;
    bool mouseDown = false;
    // Use this for initialization
    void Start()
    {
        if (targetJoint == null)
            targetJoint = gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SelfDestruct()
    {
        if (GetComponentInParent<Monster>() != null)
            GetComponentInParent<Monster>().DamageMonster();
        if (this.GetComponent<FixedJoint2D>() != null)
        {
            this.GetComponent<FixedJoint2D>().enabled = false;
            PlayerManager.Instance.transform.position = new Vector2(transform.position.x, transform.position.y);
            //rigidBodies[0].isKinematic = true;
            //rigidBodies[1].isKinematic = true;

        }
        else
        {
            Destroy(targetJoint);
        }
        //Destroy(targetJoint);
        if (restOfStuff != null)
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
        if (mouseDown)
            SelfDestruct();
    }

    public void BladeInteract()
    {
        //Debug.Log("blade interact?");
        SelfDestruct();
    }
}

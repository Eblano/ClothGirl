using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetFallAction : MonoBehaviour {
    public delegate void FallAction();
    public event FallAction OnFallAction;
    public CutRope cutRope;
    public GameObject netFall;
    public GameObject openNetTargetPosition;
    public GameObject objectNetIsHolding;
    public string colliderNameCheck = "Platform";
    private void OnEnable()
    {
        cutRope.OnCut += DisableHingeJoints;
    }
    private void OnDisable()
    {
        cutRope.OnCut -= DisableHingeJoints;
    }
    void DisableHingeJoints()
    {
        Debug.Log("yellow");
        this.GetComponent<FixedJoint2D>().enabled = false;
        objectNetIsHolding.GetComponent<FixedJoint2D>().enabled = false;

    }
    void Awake()
    {
        objectNetIsHolding = transform.Find("String/String1/String2/Net/StuffInTheNet").GetChild(0).gameObject;
        foreach (Transform t in transform)
        {
            Debug.Log(t.name);
            if (t.name == "StuffInTheNet")// Do something to child one
            {
                objectNetIsHolding = t.gameObject.GetComponentInChildren<Transform>().gameObject;
            }
         }
    }
    public void OnFall()
    {
        Debug.Log("on fall");
        if (OnFallAction != null)
            OnFallAction();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name == colliderNameCheck)
        {
            OnFall();
            objectNetIsHolding.transform.parent = null;
            //Instantiate(netFall,openNetTargetPosition.transform.position,Quaternion.identity);
            netFall.SetActive(true);
            Destroy(gameObject);
        }
    }
}

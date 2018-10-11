using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Quest Event
public class CutRope : MonoBehaviour,IBladeInteractable {
    int ignorePlayerLayer = 11;
    public FixedJoint2D fixedJoint;
    //public NetFallAction netFallAction;
    public delegate void CutAction();
    public event CutAction OnCut;
    public void Cut()
    {
        if (OnCut != null)
            OnCut();
    }
    public void BladeInteract()
    {
        //fixedJoint.enabled = false;
        Cut();
        Debug.Log("cut down the rope!");
        PlayerManager.Instance.TeleportPlayer(this.transform.position);
        gameObject.layer = ignorePlayerLayer;
        //anim.SetTrigger("Cut");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

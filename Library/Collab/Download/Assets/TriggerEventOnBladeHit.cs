using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventOnBladeHit : MonoBehaviour,IBladeInteractable {
    void IBladeInteractable.BladeInteract()
    {
        Debug.Log("cut down the rope!");

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

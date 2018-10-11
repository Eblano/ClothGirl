using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOffsetAnimation : MonoBehaviour {
    [Range(0.0f, 1.0f)]
    public float offset = 0;
    Animator anim;
    public string offsetPropertyName = "RunningOffset";
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        anim.SetFloat("RunningOffset",offset);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

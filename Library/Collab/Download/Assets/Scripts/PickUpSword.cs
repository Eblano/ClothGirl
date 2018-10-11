using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSword : MonoBehaviour,ICharacterEnter {
    public GameObject sword;
    
    public void Interact()
    {
        //trigger animator
        Animator anim = PlayerManager.Instance.anim;
        anim.SetTrigger("PickUpSword");
        this.gameObject.SetActive(false);
        SetSwordActive();
        Debug.Log("hello?");
        //Debug.Log("interacted");
    }
    void SetSwordActive()
    {
        Debug.Log("setactive");
        PlayerManager.Instance.EquipSword();
        //sword.SetActive(true);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

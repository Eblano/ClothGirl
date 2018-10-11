using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class ShowWinLoseScreen : MonoBehaviour {
    public GameObject[] winItems;
    public GameObject[] loseItems;
    //public GameObject background;
    //public GameObject first;
    //public GameObject second;
    void OnEnable()
    {
        GameManager.OnWinLoseAction += ShowWinGUI;
    }


    void OnDisable()
    {
        GameManager.OnWinLoseAction -= ShowWinGUI;
    }
    void ShowWinGUI(bool won)
    {
        if(won)
        {
            foreach(GameObject item in winItems)
            {
                item.SetActive(true);
            }
            //background.SetActive(true);
            //first.SetActive(true);
            //second.SetActive(true);
        }
        else
        {
            foreach(GameObject item in loseItems)
            {
                item.SetActive(true);
            }
        }


    }
	// Use this for initialization
	void Start () {
        //img = this.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

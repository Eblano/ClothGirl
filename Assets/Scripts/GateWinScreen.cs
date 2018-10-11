using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateWinScreen : MonoBehaviour {
    public GameObject winScreen;


    // Use this for initialization
    void Start () {
        //Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.Instance.WinGame();

            Debug.Log("player enter");
        }

        //if (collision.tag == "Player")
        //{
        //    Time.timeScale = 0;
        //    winScreen.SetActive(true);

        //}
    }

}

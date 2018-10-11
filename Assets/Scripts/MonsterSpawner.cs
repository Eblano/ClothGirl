using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {
    public float spawnRepeatTime = 3;
    public GameObject[] enemies;
    public GameObject parent;
    // Use this for initialization
    public bool goRight = false;
	void Start () {
        InvokeRepeating("Spawn", 1, spawnRepeatTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Spawn()
    {
        //Instantiate(enemy, parent.transform);
        //Instantiate(enemy,)
        int randomnum = Random.Range(0, enemies.Length-1);
        GameObject temp = Instantiate(enemies[randomnum], this.transform.position, enemies[randomnum].transform.rotation, parent.transform);
        Debug.Log(randomnum);
        float speed = Random.Range(10f, 17f);
        temp.GetComponentInChildren<AutoMovement>().speed = speed;
        if (goRight)
            temp.GetComponentInChildren<AutoMovement>().SetRight();
        else
            temp.GetComponentInChildren<AutoMovement>().SetLeft();
    }
}

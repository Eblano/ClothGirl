using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCollider : MonoBehaviour {
    void OnDrawGizmos()
    {
        //Gizmos.color = new Color(0, 1, 0, 0.2F);
        //Vector3 size =GetComponent<BoxCollider2D>().size;
        //Vector3 position = this.transform.position;
        //position.y += GetComponent<BoxCollider2D>().offset.y;
        //Gizmos.DrawCube(position, size);

        //CapsuleCollider2D capCol = GetComponent<CapsuleCollider2D>();
        //if(capCol != null)
        //{
        //    Vector3 capSize = capCol.size;
        //    Gizmos.DrawWireSphere(this.transform.position, 100);
        //}

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

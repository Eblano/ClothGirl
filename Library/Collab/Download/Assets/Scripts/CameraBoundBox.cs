using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundBox : MonoBehaviour,ICharacterEnter {
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public void Interact()
    {
        Debug.Log("CameraboundBox");
        Camera.main.GetComponent<CameraFollow>().SetBounds(minX, minY, maxX, maxY);
    }
    void OnDrawGizmo()
    {
        Gizmos.color = Color.green;
        float size = GetComponent<BoxCollider2D>().size.x;
        Gizmos.DrawWireCube(this.transform.position,new Vector3(size,size,size));
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        float tempMinX, tempMinY, tempMaxX, tempMaxY;
        tempMinX = 0;
        tempMinY = 0;
        tempMaxY = 0;
        tempMaxX = 0;
        if(minX == 0)
        {
            tempMinX = this.transform.position.x;
        }
        if(maxX == 0)
        {
            tempMaxX = this.transform.position.x;
        }
        if(minY == 0)
        {
            tempMinY = this.transform.position.y;
        }
        if(maxY == 0)
        {
            tempMaxY = this.transform.position.y;
        }
        Vector2 xLine1 = new Vector2(tempMinX, tempMinY);
        Vector2 xLine2 = new Vector2(tempMinX, tempMaxY);
        Vector2 yLine1 = new Vector2(tempMinX, tempMaxY);
        Vector2 yLine2 = new Vector2(tempMaxX, tempMaxY);
        Gizmos.DrawLine(xLine1, xLine2);
        Gizmos.DrawLine(yLine1, yLine2);
        Gizmos.DrawLine(yLine2, xLine2);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

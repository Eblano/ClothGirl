using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashTeleporter : MonoBehaviour,IBladeInteractable {
    //public GameObject player;
    public GameObject player;
    public float clickCoolDown = 2f;
    public float maxDistance = 8f;
    BoxCollider2D boxCol;
    Vector3 playerPos;
    SpriteRenderer sprite;
    bool playerCloseEnough = false;
    bool onCoolDown = false;
    public void BladeInteract()
    {
        Vector3 playerPos = PlayerManager.Instance.transform.position;
        float distance = Vector3.Distance(playerPos, this.transform.position);
        if (distance <= maxDistance)
        {
            PlayerManager.Instance.transform.position = this.transform.position;
            StartCoolDown();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 temp = player.transform.position - transform.position;
        Gizmos.DrawRay(transform.position, temp.normalized * maxDistance);
        Gizmos.DrawWireSphere(this.transform.position, maxDistance);
    }
    void StartCoolDown()
    {
        boxCol.enabled = false;
        onCoolDown = true;
        IEnumerator coroutine = SetUnclickable(clickCoolDown);
        StartCoroutine(coroutine);

    }
    IEnumerator SetUnclickable(float time)
    {
        Color temp = new Color();
        temp = sprite.color;
        temp.a = .2f;
        sprite.color = temp;
        yield return new WaitForSeconds(time);
        temp.a = 1;
        sprite.color = temp;
        boxCol.enabled = true;
        onCoolDown = false;

    }
    // Use this for initialization
    void Start () {
        boxCol = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
	}
	void ShowActive()
    {
        sprite.color = Color.green;
    }
    void ShowInActive()
    {
        sprite.color = Color.grey;
    }
	// Update is called once per frame
	void Update () {
        Vector3 temp = player.transform.position - transform.position;

        Debug.DrawRay(transform.position, temp.normalized * maxDistance, Color.green);
        if(PlayerManager.Instance != null)
        {
            playerPos = PlayerManager.Instance.transform.position;

        }
        float distance = Vector3.Distance(playerPos, this.transform.position);
        if(!onCoolDown)
        {
            if (distance <= maxDistance)
            {
                playerCloseEnough = true;
                ShowActive();
            }
            else
            {
                ShowInActive();
                playerCloseEnough = false;
            }
        }



    }
}
